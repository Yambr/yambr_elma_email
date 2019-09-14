using System;
using System.Linq;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.ExtensionPoints;
using Yambr.ELMA.Email.Extensions;
using Newtonsoft.Json;

namespace Yambr.ELMA.Email.Components.Queue
{

    public abstract class AbstractRabbitMessageHandler<TMessage, TResult> : IRabbitMessageHandler
        where TMessage : class
    {
        /// <summary>
        /// Логгер очереди
        /// </summary>
        protected readonly ILogger Logger = EmailLogger.Logger;
        /// <summary>
        /// Настройки сериалайзера - можно переопределить
        /// </summary>
        protected virtual JsonSerializerSettings SerializerSettings => null;
        private IUnitOfWorkManager _unitOfWorkManager;
        /// <summary>
        /// Менеджер работы с UnitOfWork
        /// </summary>
        public IUnitOfWorkManager UnitOfWorkManager => _unitOfWorkManager ?? (_unitOfWorkManager = Locator.GetServiceNotNull<IUnitOfWorkManager>());

        public abstract string[] Model { get; }
        public virtual bool CheckModel(string model)
        {
            if (Model == null || Model.Length == 0) return true;
            return Model.Contains(model);
        }

        public void Execute(string message, string model)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (model == null) throw new ArgumentNullException(nameof(model));

            var result = default(TResult);
            Action runAction = () =>
            {
                var messageObject = Before(message, model);
                if (messageObject == null) return;

                result = Run(messageObject);
            };
            Action<Exception> errorCallBack = exception =>
            {
                Logger.Error(exception);
                throw exception;
            };
            Action successCallback = () =>
            {
                //TODO обдумать реализацию
                if (result != null) //TODO: V3111 https://www.viva64.com/en/w/v3111/ Checking value of 'result' for null will always return false when generic type is instantiated with a value type.
                {
                    After(result);
                }
            };
            runAction.InNewThread(
                "Загрузка из Rabbit " + model,
                errorCallBack,
                successCallback);

        }
        public virtual TMessage Before(string message, string model)
        {
            return CheckModel(model) && !string.IsNullOrWhiteSpace(message)
                ? JsonConvert.DeserializeObject<TMessage>(message, SerializerSettings)
                : null;
        }

        public abstract TResult Run(TMessage message);
        public virtual void After(TResult result)
        {
        }
    }
}
