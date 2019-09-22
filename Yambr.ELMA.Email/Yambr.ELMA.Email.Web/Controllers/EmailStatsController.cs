
using System.Web.Mvc;
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

        public ActionResult Contractor(long id)
        {
            return Json(_emailMessageManager.MonthStatContractor(id));
        }
    }
}
