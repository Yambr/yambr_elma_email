using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EleWise.ELMA;
using EleWise.ELMA.Cache;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Runtime.Context;
using EleWise.ELMA.Security;
using EleWise.ELMA.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Yambr.ELMA.Email.Exceptions;
using Yambr.ELMA.Email.ExtensionPoints;
using Yambr.ELMA.Email.Extensions;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Services.Impl
{

    /// <summary>
    /// Реализация подписки на Rabbit
    /// </summary>
    [Service]
    // ReSharper disable once InconsistentNaming
    public class RabbitMQService : IRabbitMQService
    {
        private const string RabbitMQServiceRegion = nameof(RabbitMQService);
        private readonly ConcurrentDictionary<string, IEnumerable<IRabbitMessageHandler>> _map;
        private readonly ISecurityService _securityService;
        private readonly IEnumerable<IRabbitMessageHandler> _handlers;
        private readonly IContextBoundVariableService _contextBoundVariableService;
        private readonly ICacheService _cacheService;
        private static readonly ILogger Logger = EmailLogger.Logger;

        public RabbitMQService(
            ISecurityService securityService, 
            IEnumerable<IRabbitMessageHandler> handlers,
            IContextBoundVariableService contextBoundVariableService,
            ICacheService cacheService)
        {
            _securityService = securityService;
            _handlers = handlers;
            _contextBoundVariableService = contextBoundVariableService;
            _cacheService = cacheService;
            _map = new ConcurrentDictionary<string, IEnumerable<IRabbitMessageHandler>>();
            OtherConnections = new List<IModel>();
        }
        /// <summary>
        /// Активное подключение
        /// </summary>
        public IModel Connection { get; private set; }

        public ICollection<IModel> OtherConnections { get; }

        /// <summary>
        /// Закрыть подключения
        /// </summary>
        public void DisposeConnection()
        {
            DisposeConnection(Connection);
            Connection = null;
            if (OtherConnections == null) return;
            foreach (var otherConnection in OtherConnections)
            {
                DisposeConnection(otherConnection);
            }
            OtherConnections.Clear();
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
            var settings = Locator.GetServiceNotNull<MessageQueueRMQSettingsModule>().Settings;

            if (!eventArgs.BasicProperties.Headers.ContainsKey(settings.ModelHeaderKey))
                throw new ArgumentNullException(settings.ModelHeaderKey, $"Не содержится заголовок {settings.ModelHeaderKey} сообщения в сообщении");

            var header = eventArgs.BasicProperties.Headers[settings.ModelHeaderKey] as byte[];
            if (header == null)
                throw new ArgumentNullException(settings.ModelHeaderKey, $"Не указан заголовок {settings.ModelHeaderKey} сообщения в сообщении");
            return Encoding.UTF8.GetString(header);
        }

        /// <summary>
        /// Подключиться к Очереди
        /// </summary>
        public void Init()
        {
            _cacheService.ClearRegion(RabbitMQServiceRegion);
            DisposeConnection();
            var settings = Locator.GetServiceNotNull<MessageQueueRMQSettingsModule>().Settings;
            if (!(settings.Enabled ?? false)) return;
            ConsumeDefaultQueue(settings);

            if (!(settings.MultipleRead ?? false)) return;
            ConsumeOtherQueues(settings);
        }

        #region Подписка на очереди

        private void ConsumeDefaultQueue(MessageQueueRMQSettings settings)
        {
            var queuesMessages = settings.QueuesMessages;
            if (queuesMessages != null)
            {
                Connection = Init(queuesMessages, true);
            }
            else
            {
                Logger.Debug(
                    $"Очередь {nameof(MessageQueueRMQSettings.QueuesMessages)} не выбрана в настройках {nameof(MessageQueueRMQSettings)}");
            }
        }

        private void ConsumeOtherQueues(MessageQueueRMQSettings settings)
        {
            var otherQueuesMessages =
                EntityManager<IQueuesMessages>.Instance.Find(
                    c =>
                        c.Id != settings.QueuesMessagesId &&
                        c.Id != settings.ErrorQueuesMessagesId &&
                        c.UidTypeQueue == MessageQueueRMQConstants.GeneralUidMessageQueueRMQ);
            foreach (var otherQueuesMessage in otherQueuesMessages)
            {
                try
                {
                    var connection = Init(otherQueuesMessage, false);
                    OtherConnections.Add(connection);
                }
                catch (Exception ex)
                {
                    Logger.Debug(
                        $"Очередь {otherQueuesMessage.Name} не прослушивается", ex);
                }
            }
        }

        private IModel Init(IQueuesMessages queuesMessages, bool exclusiveRead)
        {
            if (queuesMessages == null) throw new ArgumentNullException(nameof(queuesMessages));
            var rmqSetting = queuesMessages.Setting as RMQSetting;
            if (rmqSetting == null)
            {
                Logger.Debug(
                    $"Очередь {queuesMessages.Name} не настроена");
                return null;
            }

            try
            {
                if (rmqSetting.HostName == null) return null;
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
                var connectionFactory2 = connectionFactory;
                if (rmqSetting.UseProxyServer)
                {
                    connectionFactory2.SocketFactory =
                        family =>
                            new TunneledTcpClient(
                                family,
                                rmqSetting.ProxyServerHostName,
                                rmqSetting.ProxyServerPort,
                                rmqSetting.ProxyServerUserName,
                                rmqSetting.ProxyServerPassword);
                }

                var connection = connectionFactory2.CreateConnection();
                var model = connection.CreateModel();
                //Читаем по одному сообщению по умолчанию
                model.BasicQos(0, 1, true);
                Logger.Debug($"Waiting for messages {rmqSetting.QueuesName}.");
                var consumer = new EventingBasicConsumer(model);
                consumer.Received += (sender, args) => { OnReceived(sender, args, model); };
                if (exclusiveRead)
                {
                    model.BasicConsume(
                        rmqSetting.QueuesName,
                        false,
                        "",
                        false,
                        true,
                        null,
                        consumer);
                }
                else
                {
                    model.BasicConsume(
                        rmqSetting.QueuesName, 
                        false, 
                        consumer);
                }
                
                return model;
            }
            catch (Exception ex)
            {
                Logger.Error($"Не удалось подключиться {queuesMessages.Name}", ex);
                throw;
            }
        }

        #endregion


        #region Обработка входящего сообщения

        /// <summary>
        /// При получении сообщения из очереди
        /// </summary>
        /// <param name="model"></param>
        /// <param name="eventArgs"></param>
        /// <param name="connection"></param>
        private void OnReceived(object model, BasicDeliverEventArgs eventArgs, IModel connection)
        {
            try
            {
                var body = eventArgs.Body;
                var message = Encoding.UTF8.GetString(body);
                Logger.Debug($"{eventArgs.Exchange}: { eventArgs.RoutingKey}: {model}: {message}");

                _securityService
                    .RunWithElevatedPrivilegies(() =>
                    {
                        PrepareMessage(message, eventArgs, connection);
                    });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
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
                Logger.Error(ex);
                PrepareError(messageJson, eventArgs, connection, ex);
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

        private void PrepareError(string messageJson, BasicDeliverEventArgs eventArgs, IModel connection, Exception ex)
        {
            try
            {
                var defaultQueueObject = NewExceptionMessage(messageJson, eventArgs, ex);
                SendError(defaultQueueObject);
                //Если в очередь ошибки мы не смогли сбросить то сообщение не отмечается как обработанное
                connection.BasicAck(eventArgs.DeliveryTag, false);
            }
            catch (Exception newException)
            {
                
                
                var hash = GetHash(eventArgs.Body);
                int attemptCount;
                _cacheService.TryGetValue(hash, RabbitMQServiceRegion, out attemptCount);
                if (attemptCount < 10)
                {
                    Logger.Error(
                        $"Сообщение возвращено в очередь (попытка #{attemptCount})",
                        newException);
                    //Если в очередь ошибки мы не смогли сбросить то сообщение выплевывается обратно
                    connection.BasicNack(eventArgs.DeliveryTag, false, true);
                    attemptCount++;
                    _cacheService.Insert(hash, attemptCount, RabbitMQServiceRegion);
                }
                else
                {
                    Logger.Error(
                        $"Сообщение удалено из очереде после {attemptCount} попыток",
                        newException);
                    connection.BasicAck(eventArgs.DeliveryTag, false);
                    _cacheService.Remove(hash, RabbitMQServiceRegion);
                }
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

        private static DefaultQueueObject NewExceptionMessage(string messageJson, BasicDeliverEventArgs eventArgs, Exception ex)
        {
            var defaultQueueObject = new DefaultQueueObject()
            {
                Message = messageJson
            };
            defaultQueueObject.Headers.Add("base_routing_key", eventArgs.RoutingKey);
            defaultQueueObject.Headers.Add("exception", ex.Message);
            if (eventArgs.BasicProperties.Headers != null)
                CopyBasicProperies(eventArgs, defaultQueueObject);

            return defaultQueueObject;
        }

        private static void CopyBasicProperies(BasicDeliverEventArgs eventArgs, DefaultQueueObject defaultQueueObject)
        {
            foreach (var propertiesHeader in eventArgs.BasicProperties.Headers)
            {
                if (defaultQueueObject.Headers.ContainsKey(propertiesHeader.Key))
                {
                    defaultQueueObject.Headers[propertiesHeader.Key] = propertiesHeader.Value;
                }
                else
                {
                    defaultQueueObject.Headers.Add(propertiesHeader.Key, propertiesHeader.Value);
                }
            }
        }

        #endregion


        #region Отправка сообщений

        public void SendMessage(RMQSetting setting, IQueueObject queueObject)
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
                if (setting.UseProxyServer)
                {
                    connectionFactory2.SocketFactory = (family => new TunneledTcpClient(family, setting.ProxyServerHostName, setting.ProxyServerPort, setting.ProxyServerUserName, setting.ProxyServerPassword));
                }
                using (var connection = connectionFactory2.CreateConnection())
                {
                    using (var model = connection.CreateModel())
                    {
                        var settings = Locator.GetServiceNotNull<MessageQueueRMQSettingsModule>().Settings;
                        var basicProperties = model.CreateBasicProperties();
                        basicProperties.DeliveryMode = 2;
                        basicProperties.Headers = queueObject.Headers;
                        basicProperties.AppId = settings.AppId;
                        model.BasicPublish(setting.ExchangeName, queueObject.RoutingKey, basicProperties, body);
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
                    var queue = GetQueue();
                    var rMQSetting = queue.Setting as RMQSetting;
                    if (rMQSetting == null) return;
                    Logger.Debug(SR.T("Отправляется сообщение в очередь: {0}. Адрес подключения: {1}. Имя очереди: {2}.", queue.Name, GetHost(rMQSetting), rMQSetting.QueuesName));
                    SendMessage(rMQSetting, message);
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

        public void SendError(IQueueObject message)
        {
            Action sendErrorAction = () =>
            {
                var queue = GetErrorQueue();
                if (queue == null)
                    throw  new RabbitException($"Очередь для ошибок не настроена \"{__Resources_MessageQueueRMQSettings.ErrorQueuesMessages_P}\"");
                var rMQSetting = queue.Setting as RMQSetting;
                if (rMQSetting == null) return;
                Logger.Debug(SR.T("Отправляется сообщение в: {0}. Адрес подключения: {1}. Имя exchange: {2}.", queue.Name, GetHost(rMQSetting), rMQSetting.ExchangeName));
                SendMessage(rMQSetting, message);
            };
            sendErrorAction.InNewThread(
                "Отправка ошибки в очередь ошибок",
                ex =>
                {
                    throw new RabbitException("Ошибка при попытке отправить сообщение в очередь ошибок", ex);
                },
                null,
                1);
        }

        private static string GetHost(RMQSetting setting)
        {
            return setting != null ? $"amqp://{setting.HostName}:{setting.Port}" : "";
        }
        private static IQueuesMessages GetErrorQueue()
        {
            var settings = Locator.GetServiceNotNull<MessageQueueRMQSettingsModule>().Settings;
            return settings.ErrorQueuesMessagesId.HasValue
                ? settings.ErrorQueuesMessages : null;
        }
        private static IQueuesMessages GetQueue()
        {
            var settings = Locator.GetServiceNotNull<MessageQueueRMQSettingsModule>().Settings;
            return settings.QueuesMessagesId.HasValue
                ? settings.QueuesMessages : null;
        }
        #endregion

    }
}
