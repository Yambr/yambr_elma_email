using EleWise.ELMA;
using EleWise.ELMA.Model.Attributes;
using EleWise.ELMA.Runtime.Settings;

namespace Yambr.ELMA.Email
{
    public class MessageQueueRMQSettings : GlobalSettingsBase
    {
        internal const string DefaultHostName = "rabbit.yambr.ru";
        public MessageQueueRMQSettings()
        {
            if (string.IsNullOrWhiteSpace(HostName))
            {
                HostName = DefaultHostName;
            }

            if (Port == default(int))
            {
                Port = 5672;
            }
        }
        
        [DisplayName(typeof(@__Resources_MessageQueueRMQSettings), nameof(@__Resources_MessageQueueRMQSettings.HostName_P))]
        public string HostName { get; set; }

        [DisplayName(typeof(@__Resources_MessageQueueRMQSettings), nameof(@__Resources_MessageQueueRMQSettings.VirtualHost_P))]
        public string VirtualHost { get; set; }

        [DisplayName(typeof(@__Resources_MessageQueueRMQSettings), nameof(@__Resources_MessageQueueRMQSettings.Port_P))]
        public int Port { get; set; }

        [DisplayName(typeof(@__Resources_MessageQueueRMQSettings), nameof(@__Resources_MessageQueueRMQSettings.UserName_P))]
        public string UserName { get; set; }

        [DisplayName(typeof(@__Resources_MessageQueueRMQSettings), nameof(@__Resources_MessageQueueRMQSettings.Password_P))]
        public string Password { get; set; }

    }

    // ReSharper disable once InconsistentNaming
    internal class @__Resources_MessageQueueRMQSettings
    {
        public static string HostName_P =>
            SR.T($"Адрес сервиса сбора почты (по умолчанию {MessageQueueRMQSettings.DefaultHostName})");

        public static string VirtualHost_P =>
            SR.T("Виртуальный хост для вашей компании");

        public static string Port_P =>
            SR.T("Название приложение (указывается в заголовке сообщения)");

        public static string UserName_P =>
            SR.T("Название приложение (указывается в заголовке сообщения)");

        public static string Password_P =>
            SR.T("Название приложение (указывается в заголовке сообщения)");


    }
}