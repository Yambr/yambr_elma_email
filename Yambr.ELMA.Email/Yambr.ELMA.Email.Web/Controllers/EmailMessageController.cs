using System;
using System.Web.Mvc;
using System.Web.UI;
using EleWise.ELMA.Web.Mvc.Controllers;
using Yambr.ELMA.Email.Managers;

namespace Yambr.ELMA.Email.Web.Controllers
{
    public class EmailMessageController : BaseApiController
    {
        private readonly EmailMessageManager _emailMessageManager;

        public EmailMessageController(EmailMessageManager emailMessageManager)
        {
            _emailMessageManager = emailMessageManager;
        }

        [OutputCache(Duration = 3600, VaryByParam = "id;from;to;skip;size", VaryByCustom = "TimeZone",
            Location = OutputCacheLocation.Client)]
        public ActionResult Contractor(long id, DateTime from, DateTime to, int skip, int size)
        {
            return Json(_emailMessageManager.Contractor(id, from, to, skip, size));
        }

        [OutputCache(Duration = 3600, VaryByParam = "id;from;to;skip;size", VaryByCustom = "TimeZone",
            Location = OutputCacheLocation.Client)]
        public ActionResult Contact(long id, DateTime from, DateTime to, int skip, int size)
        {
            return Json(_emailMessageManager.Contact(id, from, to, skip, size));
        }

        [OutputCache(Duration = 3600, VaryByParam = "id;searchString;skip;size", VaryByCustom = "TimeZone",
            Location = OutputCacheLocation.Client)]
        public ActionResult ContractorSearch(long id, string searchString, int skip, int size)
        {
            return Json(_emailMessageManager.Contractor(id, searchString, skip, size));
        }

        [OutputCache(Duration = 3600, VaryByParam = "id;searchString;skip;size", VaryByCustom = "TimeZone",
            Location = OutputCacheLocation.Client)]
        public ActionResult ContactSearch(long id, string searchString, int skip, int size)
        {
            return Json(_emailMessageManager.Contact(id, searchString, skip, size));
        }

        [OutputCache(Duration = 3600, VaryByParam = "id", VaryByCustom = "TimeZone",
            Location = OutputCacheLocation.Client)]
        public ActionResult Load(long id)
        {
            return Json(_emailMessageManager.LoadEmail(id));
        }

        public void Delete(long id)
        {
            var emailMessage = _emailMessageManager.Load(id);
            emailMessage.IsDeleted = true;
            emailMessage.Save();
        }
    }
}