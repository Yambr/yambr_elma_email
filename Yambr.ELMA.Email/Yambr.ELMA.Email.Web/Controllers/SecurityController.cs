using System.Web.Mvc;
using EleWise.ELMA.Web.Mvc.Controllers;
using Orchard.Themes;

namespace Yambr.ELMA.Email.Web.Controllers
{
    [Themed]
    public class SecurityController : BaseController
    {
        //
        // GET: /Yambr.ELMA.YambrEmailSettings.Web/

        public ActionResult Index()
        {
            return View();
        }

    }
}
