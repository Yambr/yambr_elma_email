using System.Web.Mvc;
using EleWise.ELMA.BPM.Mvc.Controllers;
using EleWise.ELMA.FullTextSearch.Services;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.FullTextSearch;
using Yambr.ELMA.Email.FullTextSearch.Model;

namespace Yambr.ELMA.Email.Web.Controllers
{
    public class FullTextSearchController : BPMController
    {

       [HttpPost]
        public ActionResult IndexingEmailMessageOff()
        {
            Locator.GetServiceNotNull<IFullTextSearchService>().StopIndexingType(typeof(IEmailMessageFullTextSearchObject));

            {
                var module = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
                module.Settings.IndexingEmail = false;
                module.SaveSettings();
            }
            return RedirectToAction("Index", "FullTextSearch", new { area = "EleWise.ELMA.BPM.Web.Common" });

        }
    }
}