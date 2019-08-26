using EleWise.ELMA.ComponentModel;

namespace Yambr.ELMA.Email.ExtensionPoints
{
    /// <summary>
    /// Точка расширения для обработки сообщений Rabbit
    /// </summary>
    [ExtensionPoint]
    public interface IRabbitMessageHandler
    {
        /// <summary>
        /// Проверить модель
        /// </summary>
        /// <param name="model"> тип сообщения</param>
        /// <returns></returns>
        bool CheckModel(string model);

        /// <summary>
        /// Обработать сообщение
        /// </summary>
        /// <param name="message">содержимое сообщения</param>
        /// <param name="model"> тип сообщения </param>
        void Execute(string message, string model);
    }
}
