using System.Web.Mvc;
using System.Web.Mvc.Html;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Web.Mvc.Models.Settings;

namespace Yambr.ELMA.Email.Web.Components
{
    [Component]
    public class YambrEmailSettingsModuleController : GlobalSettingsModuleControllerBase<Email.YambrEmailSettings, YambrEmailSettingsModule>
    {

        public YambrEmailSettingsModuleController(YambrEmailSettingsModule module)
            : base(module)
        {
        }

        public override MvcHtmlString RenderDisplay(HtmlHelper html)
        {
            return html.Action("View", "YambrEmailSettings", new { area = RouteProvider.AreaName });
        }

        public override MvcHtmlString RenderEdit(HtmlHelper html)
        {
            return html.Action("Edit", "YambrEmailSettings", new { area = RouteProvider.AreaName });
        }
    }

}
