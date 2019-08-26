using RabbitMQ.Client.Events;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Services
{
    /// <summary>
    /// Сервис работы с очередью Rabbit
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public interface IRabbitMQService
    {
        /// <summary>
        /// Подключиться к Очереди
        /// </summary>
        void Init();
        /// <summary>
        /// Закрыть подключения
        /// </summary>
        void DisposeConnection();

        /// <summary>
        /// Получить модель сообщения (тип сообщения)
        /// </summary>
        /// <param name="eventArgs"> Contains all the information about a message delivered
        /// from an AMQP broker within the Basic content-class.
        /// (содержит информацию о сообщении, в заголовках можно указать дополнительные параметры)
        /// </param>
        /// <param name="message">сообщение</param>
        /// <returns></returns>
        string GetModelFromMessage(BasicDeliverEventArgs eventArgs, string message);

        /// <summary>
        /// Отправить сообщение немедленно в очередь
        /// </summary>
        /// <param name="setting">настройки очереди RMQSetting</param>
        /// <param name="queueObject"> сообщение для отправки</param>
        void SendMessage(RMQSetting setting, IQueueObject queueObject);
        /// <summary>
        /// Отправить сообщение немедленно
        /// в exchange очереди
        /// </summary>
        /// <param name="queueObject">сообщение для отправки</param>
        void SendMessage(IQueueObject queueObject);

        /// <summary>
        /// Отправить сообщение после сохранения в базу данных (рекомендуется)
        /// в exchange очереди
        /// </summary>
        /// <param name="queueObject">сообщение для отправки</param>
        void SendMessageOnCommit(IQueueObject queueObject);
    }
}
