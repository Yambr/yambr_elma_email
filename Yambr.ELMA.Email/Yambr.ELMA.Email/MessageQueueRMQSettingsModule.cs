﻿using System;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Runtime.Settings;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email
{
    [Component]
    public class MessageQueueRMQSettingsModule : GlobalSettingsModuleBase<MessageQueueRMQSettings>
    {

        public override Guid ModuleGuid => new Guid("{E5582CE6-D5A9-4588-B58E-61C4CF955EDB}");

        public override string ModuleName => "Настройки - Сообщения по подписке из очереди (RabbitMQ)";

        public override void SaveSettings()
        {
            Locator.GetServiceNotNull<IRabbitMQService>().Init();
            base.SaveSettings();
        }
    }
}
