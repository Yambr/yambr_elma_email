
using System;
using System.Web.Mvc;
using System.Web.UI;
using EleWise.ELMA.Web.Mvc.Controllers;
using Yambr.ELMA.Email.Managers;

namespace Yambr.ELMA.Email.Web.Controllers
{
    public class EmailStatsController : BaseApiController
    {
        private readonly EmailMessageManager _emailMessageManager;

        public EmailStatsController(EmailMessageManager emailMessageManager)
        {
            _emailMessageManager = emailMessageManager;
        }
        [OutputCache(Duration = 7200, VaryByParam = "id", VaryByCustom = "TimeZone", Location = OutputCacheLocation.Client)]
        public ActionResult Contractor(long id)
        {
            return Json(_emailMessageManager.MonthStatContractor(id));
        }

        [OutputCache(Duration = 7200, VaryByParam = "id", VaryByCustom = "TimeZone", Location = OutputCacheLocation.Client)]
        public ActionResult Contact(long id)
        {
            return Json(_emailMessageManager.MonthStatContact(id));
        }
    }
}
