using System;
using System.Collections.Generic;
using EleWise.ELMA;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Runtime.Context;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Models;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email.Components.Queue
{
    [Component(Order = 1000010)]
    internal class QueueUnitOfWorkListener : IUnitOfWorkEventListener
    {
        private static readonly ILogger Logger = EmailLogger.Logger;
        #region Ctor

        public QueueUnitOfWorkListener(
            [NotNull] IContextBoundVariableService contextBoundVariableService,
            [NotNull] ISessionProvider sessionProvider, 
            IRabbitMQService rabbitMQService
           
        )
        {
            if (contextBoundVariableService == null) throw new ArgumentNullException(nameof(contextBoundVariableService));
            if (sessionProvider == null) throw new ArgumentNullException(nameof(sessionProvider));
            _contextBoundVariableService = contextBoundVariableService;
            _rabbitMQService = rabbitMQService;
            SessionProvider = sessionProvider;
        }

        #endregion

        public void OnStartUnitofWork(IUnitOfWork unitOfWork)
        {
        }

        public void OnPreFlushUnitofWork(IUnitOfWork unitOfWork, IEnumerable<object> entities)
        {
        }

        public void OnPostFlushUnitofWork(IUnitOfWork unitOfWork)
        {
        }

        public void OnPreCommitUnitofWork(IUnitOfWork unitOfWork)
        {
            try
            {
                var session = SessionProvider.GetSession("");
                var list = GetContextQueue();
                foreach (var queueTempObject in list)
                {
                    _rabbitMQService.SendMessage(queueTempObject);
                }

                if (session.IsDirty())
                    session.Flush();
            }
            catch (Exception ex)
            {
                Logger.Error(SR.T("Ошибка при попытке отправить сообщение в очередь сообщений"), ex);
                
            }
        }

        public void OnPostCommitUnitofWork(IUnitOfWork unitOfWork)
        {
        }

        public void OnPostRollbackUnitofWork(IUnitOfWork unitOfWork)
        {
        }

        public void OnDisposeUnitofWork(IUnitOfWork unitOfWork)
        {
            ClearContextQueue();
        }


        #region Private Members

        /// <summary>
        /// Провайдер сессий NHibernate
        /// </summary>
        private ISessionProvider SessionProvider { get; }
        

        private readonly IContextBoundVariableService _contextBoundVariableService;
        private readonly IRabbitMQService _rabbitMQService;

        private IEnumerable<IQueueObject> GetContextQueue()
        {
            return _contextBoundVariableService.GetOrAdd(QueueConstants.RabbitMqQueueKey, () => new List<IQueueObject>());
        }

        private void ClearContextQueue()
        {
            _contextBoundVariableService.Set(QueueConstants.RabbitMqQueueKey, new List<IQueueObject>());
        }

        #endregion
    }
}
