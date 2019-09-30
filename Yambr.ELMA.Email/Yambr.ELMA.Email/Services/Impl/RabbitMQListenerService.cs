using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EleWise.ELMA;
using EleWise.ELMA.Cache;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Runtime.Context;
using EleWise.ELMA.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Yambr.ELMA.Email.Exceptions;
using Yambr.ELMA.Email.ExtensionPoints;
using Yambr.ELMA.Email.Models;
using ISecurityService = EleWise.ELMA.Security.ISecurityService;

namespace Yambr.ELMA.Email.Services.Impl
{

    /// <summary>
    /// Реализация подписки на Rabbit
    /// </summary>
    [Service(InjectProperties = false)]
    // ReSharper disable once InconsistentNaming
    public class RabbitMQService : IRabbitMQService
    {
        private const string RabbitMqServiceRegion = nameof(RabbitMQService);
        private readonly ConcurrentDictionary<string, IEnumerable<IRabbitMessageHandler>> _map;
        private readonly IEnumerable<IRabbitMessageHandler> _handlers;
        private readonly IContextBoundVariableService _contextBoundVariableService;
        private readonly ICacheService _cacheService;
        private static readonly ILogger Logger = EmailLogger.Logger;

        public RabbitMQService(
            IEnumerable<IRabbitMessageHandler> handlers,
            IContextBoundVariableService contextBoundVariableService,
            ICacheService cacheService)
        {
            _handlers = handlers;
            _contextBoundVariableService = contextBoundVariableService;
            _cacheService = cacheService;
            _map = new ConcurrentDictionary<string, IEnumerable<IRabbitMessageHandler>>();
        }
        /// <summary>
        /// Активное подключение
        /// </summary>
        public IModel Connection { get; private set; }

        /// <summary>
        /// Закрыть подключения
        /// </summary>
        public void DisposeConnection()
        {
            DisposeConnection(Connection);
            Connection = null;
        }

        private static void DisposeConnection(IModel connection)
        {
            if (connection == null) return;
            if (connection.IsOpen)
            {
                connection.Close();
            }

            connection.Dispose();
            Logger.Debug($"Connection #{connection.ChannelNumber} closed.");
        }

        public string GetModelFromMessage(BasicDeliverEventArgs eventArgs, string message)
        {
            if (eventArgs == null) throw new ArgumentNullException(nameof(eventArgs));
            if (!eventArgs.BasicProperties.Headers.ContainsKey(QueueConstants.ModelHeaderKey))
                throw new ArgumentNullException(QueueConstants.ModelHeaderKey, $"Не содержится заголовок {QueueConstants.ModelHeaderKey} сообщения в сообщении");

            var header = eventArgs.BasicProperties.Headers[QueueConstants.ModelHeaderKey] as byte[];
            if (header == null)
                throw new ArgumentNullException(QueueConstants.ModelHeaderKey, $"Не указан заголовок {QueueConstants.ModelHeaderKey} сообщения в сообщении");
            return Encoding.UTF8.GetString(header);
        }

        

        /// <summary>
        /// Подключиться к Очереди
        /// </summary>
        public void Init()
        {
            _cacheService.ClearRegion(RabbitMqServiceRegion);
            DisposeConnection();
            var rmqSetting = Locator.GetServiceNotNull<YambrEmailSettingsModule>().Settings;
            try
            {
                if (rmqSetting.HostName == null) return;
                var connectionFactory = new ConnectionFactory
                {
                    HostName = rmqSetting.HostName,
                    VirtualHost = rmqSetting.VirtualHost,
                    Protocol = Protocols.AMQP_0_9_1,
                    Port = rmqSetting.Port,
                    UserName = rmqSetting.UserName,
                    Password = rmqSetting.Password,
                    AutomaticRecoveryEnabled = true,
                    TopologyRecoveryEnabled = false
                };

                var connection = connectionFactory.CreateConnection();
                var model = connection.CreateModel();
                InitTopology(model);
                //Читаем по одному сообщению по умолчанию
                model.BasicQos(0, 1, true);
                Logger.Debug($"Waiting for messages {QueueConstants.QueueNewEmail}.");
                var consumer = new EventingBasicConsumer(model);
                consumer.Received += (sender, args) => { OnReceived(sender, args, model); };
                model.BasicConsume(QueueConstants.QueueNewEmail, false, consumer);
            }
            catch (Exception ex)
            {
                Logger.Error($"Не удалось подключиться {rmqSetting.HostName}:{rmqSetting.Port}/{rmqSetting.VirtualHost}", ex);
                throw;
            }
        }

        private static void InitTopology(IModel model)
        {
            model.ExchangeDeclare(QueueConstants.ExchangeMailBox, ExchangeType.Fanout, true, false, null);

            model.QueueDeclare(QueueConstants.QueueMailboxDownload, true, false, false, null);
            model.QueueDeclare(QueueConstants.QueueNewEmail, true, false, false, null);
            
            model.QueueBind(QueueConstants.QueueMailboxDownload, QueueConstants.ExchangeMailBox, QueueConstants.RoutingKeyMailBoxCmdDownload);
        }


        #region Обработка входящего сообщения

        /// <summary>
        /// При получении сообщения из очереди
        /// </summary>
        /// <param name="model"></param>
        /// <param name="eventArgs"></param>
        /// <param name="connection"></param>
        private void OnReceived(object model, BasicDeliverEventArgs eventArgs, IModel connection)
        {
            var dateTimeNow = DateTime.Now;
            try
            {
                
                var body = eventArgs.Body;
                var message = Encoding.UTF8.GetString(body);
                var securityService = Locator.GetServiceNotNull<ISecurityService>();
                securityService
                    .RunWithElevatedPrivilegies(() =>
                    {
                        PrepareMessage(message, eventArgs, connection);
                    });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            if (Logger.IsDebugEnabled())
            {
                var timePrepare = DateTime.Now - dateTimeNow;
                Logger.Debug($"{model}: {timePrepare:g}");
            }
          
        }

        /// <summary>
        /// Обработать сообщение
        /// </summary>
        /// <param name="messageJson"></param>
        /// <param name="eventArgs"></param>
        /// <param name="connection"></param>
        private void PrepareMessage(string messageJson, BasicDeliverEventArgs eventArgs, IModel connection)
        {
            try
            {
                var model = GetModelFromMessage(eventArgs, messageJson);
                var rMessageHandlers = GetRabbitMessageHandlers(model);

                foreach (var handler in rMessageHandlers)
                {
                    handler.Execute(messageJson, model);
                }
                connection.BasicAck(eventArgs.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                PrepareError(eventArgs, connection, ex);
            }
        }

        private IEnumerable<IRabbitMessageHandler> GetRabbitMessageHandlers(string model)
        {
            if (_map.ContainsKey(model))
            {
                return _map[model];
            }

            var rMessageHandlers =
                _handlers
                    .Where(a => a.CheckModel(model)).ToList();

            if (!rMessageHandlers.Any())
                throw new RabbitException($"Не существует обработчика для {model}");

            _map.TryAdd(model, rMessageHandlers);
            return rMessageHandlers;
        }

        private void PrepareError(BasicDeliverEventArgs eventArgs, IModel connection, Exception ex)
        {
                
                var hash = GetHash(eventArgs.Body);
                int attemptCount;
                _cacheService.TryGetValue(hash, RabbitMqServiceRegion, out attemptCount);
                if (attemptCount < 10)
                {
                    Logger.Error(
                        $"Сообщение возвращено в очередь (попытка #{attemptCount})",
                        ex);
                    //Если в очередь ошибки мы не смогли сбросить то сообщение выплевывается обратно
                    connection.BasicNack(eventArgs.DeliveryTag, false, true);
                    attemptCount++;
                    _cacheService.Insert(hash, attemptCount, RabbitMqServiceRegion);
                }
                else
                {
                    Logger.Error(
                        $"Сообщение удалено из очереде после {attemptCount} попыток",
                        ex);
                    connection.BasicAck(eventArgs.DeliveryTag, false);
                    _cacheService.Remove(hash, RabbitMqServiceRegion);
                }
            
        }

        private static string GetHash(byte[] inputBytes)
        {
            // Use input string to calculate MD5 hash
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                var sb = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("X2"));
                }
                return sb.ToString();
            }
        }
        

        #endregion


        #region Отправка сообщений

        private void SendMessage(YambrEmailSettings setting, IQueueObject queueObject)
        {
            if (string.IsNullOrWhiteSpace(queueObject?.Message))
            {
                throw new Exception(SR.T("Ошибка отправки сообщения.") + Environment.NewLine + SR.T("Нельзя отправить пустое текстовое сообщение."));
            }
            var body = Encoding.UTF8.GetBytes(queueObject.Message);
            if (setting == null)
            {
                throw new Exception(SR.T("Не переданы необходимые параметры."));
            }
            if (body == null)
            {
                throw new Exception(SR.T("Ошибка отправки сообщения.") + Environment.NewLine + SR.T("Нельзя отправить пустое текстовое сообщение."));
            }
            try
            {
                var connectionFactory = new ConnectionFactory
                {
                    HostName = setting.HostName,
                    VirtualHost = setting.VirtualHost,
                    Protocol = Protocols.AMQP_0_9_1,
                    Port = setting.Port,
                    UserName = setting.UserName,
                    Password = setting.Password
                };
                var connectionFactory2 = connectionFactory;
                using (var connection = connectionFactory2.CreateConnection())
                {
                    using (var model = connection.CreateModel())
                    {
                        var basicProperties = model.CreateBasicProperties();
                        basicProperties.DeliveryMode = 2;
                        basicProperties.Headers = queueObject.Headers;
                        basicProperties.AppId = "ELMA";
                        model.BasicPublish(QueueConstants.ExchangeMailBox, queueObject.RoutingKey, basicProperties, body);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                throw;
            }
        }


        public void SendMessage(IQueueObject message)
        {
            try
            {
                    var rMqSetting = Locator.GetServiceNotNull<YambrEmailSettingsModule>().Settings;
                    if (rMqSetting == null) return;
                    Logger.Debug(
                        SR.T("Отправляется сообщение в очередь: {0}. Адрес подключения: {1}. Имя очереди: {2}.", 
                            QueueConstants.ExchangeMailBox, 
                            GetHost(rMqSetting),
                            QueueConstants.RoutingKeyMailBoxCmdDownload));
                    SendMessage(rMqSetting, message);
            }
            catch (Exception ex)
            {
                throw new RabbitException("Ошибка при попытке отправить сообщение в очередь", ex);
            }
        }

        public void SendMessageOnCommit(IQueueObject queueObject)
        {
            var queueObjects = 
                _contextBoundVariableService.GetOrAdd(
                    QueueConstants.RabbitMqQueueKey, 
                    () => new List<IQueueObject>());
            queueObjects.Add(queueObject);
        }

       
        private static string GetHost(YambrEmailSettings setting)
        {
            return setting != null ? $"amqp://{setting.HostName}:{setting.Port}" : "";
        }
        #endregion

    }
}
