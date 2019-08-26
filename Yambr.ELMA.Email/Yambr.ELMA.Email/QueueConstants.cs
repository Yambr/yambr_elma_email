namespace Yambr.ELMA.Email
{
    /// <summary>
    /// Класс констант для очереди
    /// </summary>
    public static class QueueConstants
    {
        /// <summary>
        /// Ключ для очереди Rabbit
        /// </summary>
        public const string RabbitMqQueueKey = "Yambr.ELMA.MessageQueueRMQ.Events.ItemList";

        /// <summary>
        /// Очередь для чтения
        /// </summary>
        public const string RabbitMqQueue = "ELMA_EMAIL_MESSAGES";
        /// <summary>
        /// Очередь для чтения
        /// </summary>
        public const string RabbitMqQueueTasks = "ELMA_EMAIL_TASKS";
        /// <summary>
        /// Exchange для записи
        /// </summary>
        public const string RabbitMqExchange = "ELMA_EMAIL";
        public const string ModelHeaderKey = "model";
    }
}
