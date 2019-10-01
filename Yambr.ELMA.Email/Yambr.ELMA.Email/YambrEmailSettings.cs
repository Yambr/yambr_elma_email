using EleWise.ELMA;
using EleWise.ELMA.Model.Attributes;
using EleWise.ELMA.Runtime.Settings;

namespace Yambr.ELMA.Email
{

    public class YambrEmailSettings : GlobalSettingsBase
    {
        internal const string DefaultHostName = "rabbit.yambr.ru";
        internal const string DefaultVirtualHost = "/";
        internal const string DefaultUserName = "guest";
        internal const string DefaultPassword = "guest";
        public YambrEmailSettings()
        {
            if (string.IsNullOrWhiteSpace(HostName))
            {
                HostName = DefaultHostName;
            }
            if (string.IsNullOrWhiteSpace(VirtualHost))
            {
                VirtualHost = DefaultVirtualHost;
            }
            if (string.IsNullOrWhiteSpace(UserName))
            {
                UserName = DefaultUserName;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                Password = DefaultPassword;
            }
            if (Port == default(int))
            {
                Port = 5672;
            }

            if (string.IsNullOrWhiteSpace(PublicDomainUrl))
            {
                PublicDomainUrl =
                    "https://gist.githubusercontent.com/Yambr/b4d87546ff6e98f385e04b99d1ea46c8/raw/1f0be75228f1e48c40e5cea7f9acabd6034b2ae1/free_email_provider_domains.txt";
            }
        }

        [DisplayName(typeof(@__Resources_MessageQueueRMQSettings), nameof(@__Resources_MessageQueueRMQSettings.PublicDomainUrl_P))]
        public string PublicDomainUrl { get; set; }

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
        [DisplayName(typeof(@__Resources_MessageQueueRMQSettings), nameof(@__Resources_MessageQueueRMQSettings.AutoCreateContractors_P))]
        public bool AutoCreateContractors { get; set; }
    }
    // ReSharper disable once InconsistentNaming
    internal class @__Resources_MessageQueueRMQSettings
    {
        public static string AutoCreateContractors_P =>
            SR.T("Автоматически создавать контрагентов на из писем");
        public static string PublicDomainUrl_P =>
            SR.T("Ежедневное обновление публичных доменов (по ним не создаются контрагенты)");
        public static string HostName_P =>
            SR.T($"Адрес сервиса сбора почты (по умолчанию {YambrEmailSettings.DefaultHostName})");

        public static string VirtualHost_P =>
            SR.T("Выделенный хост для вашей компании (запросите на elma@yambr.ru)");

        public static string Port_P =>
            SR.T("Порт сервиса сбора почты");

        public static string UserName_P =>
            SR.T("Логин");

        public static string Password_P =>
            SR.T("Пароль");


    }
}