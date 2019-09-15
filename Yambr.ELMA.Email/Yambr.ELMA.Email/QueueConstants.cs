﻿namespace Yambr.ELMA.Email
{
    /// <summary>
    /// Класс констант для очереди
    /// </summary>
    public static class QueueConstants
    {
        /// <summary>
        /// Ключ для очереди Rabbit
        /// </summary>
        public const string RabbitMqQueueKey = "Yambr.ELMA.Email.Events.ItemList";
        public const string ModelHeaderKey = "model";

        /// <summary>
        /// Exchange для записи
        /// </summary>
        public const string ExchangeMailBox = "mailbox";
        public const string RoutingKeyMailBoxCmdDownload = "mailbox.cmd.download";
        /// <summary>
        /// Очередь на обработку
        /// </summary>
        public const string QueueMailboxDownload = "mailbox-download-queue";
        /// <summary>
        /// Очередь для чтения
        /// </summary>
        public const string QueueNewEmail = "email-created-queue";
    
    }
}
