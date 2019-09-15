using System;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Modules;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email.Components
{
    [Component(Order = 100000)]
    // ReSharper disable once InconsistentNaming
    public class SDKContainerEvents : IModuleContainerEvents
    {

        public void Activated()
        {
            StartListening();
        }
        /// <summary>
        /// Запускаем прослушивание очереди
        /// </summary>
        private static void StartListening()
        {
            try
            {
                var rabbitMqListenerService = Locator.GetServiceNotNull<IRabbitMQService>();
                rabbitMqListenerService.Init();
            }
            catch (Exception ex)
            {
                EmailLogger.Logger.Error(ex);
            }
        }

        public void Terminating()
        {
            //ignored
        }
    }
}
