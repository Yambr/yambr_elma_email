using System;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Runtime.Settings;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email
{
    [Component]
    public class YambrEmailSettingsModule : GlobalSettingsModuleBase<YambrEmailSettings>
    {

        public override Guid ModuleGuid => new Guid("{8602D11C-7F3D-4520-A4DD-1BB0A57C6AE1}");

        public override string ModuleName => "История переписки - CRM";

        public override void SaveSettings()
        {
            Locator.GetServiceNotNull<IRabbitMQService>().Init();
            base.SaveSettings();
        }
    }
}
