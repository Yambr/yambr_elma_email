using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Modules;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email.Components
{
    [Component()]
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
            var rabbitMqListenerService = Locator.GetServiceNotNull<IRabbitMQService>();
            rabbitMqListenerService.Init();
        }

        public void Terminating()
        {
            //ignored
        }
    }
}
