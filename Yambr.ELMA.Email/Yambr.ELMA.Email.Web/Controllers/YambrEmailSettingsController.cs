using EleWise.ELMA.BPM.Mvc.Controllers;
using System.Web.Mvc;

namespace Yambr.ELMA.Email.Web.Controllers
{
    public class YambrEmailSettingsController : BPMController
    {
        //
        // GET: /YambrEmailSettings/

        public YambrEmailSettingsModule SettingsModule { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public YambrEmailSettings YambrEmailSettings => SettingsModule.Settings;

        [HttpGet]
        public new ActionResult View()
        {
            return PartialView(YambrEmailSettings);
        }

        public ActionResult Edit()
        {
            return PartialView(YambrEmailSettings);
        }

    }
}
