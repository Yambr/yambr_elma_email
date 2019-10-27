// EleWise.ELMA.BPM.Web.Content.Components.UserProfileInfoExtensionZone

using System.Web.Mvc;
using System.Web.Mvc.Html;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Web.Mvc.ExtensionPoints;

namespace Yambr.ELMA.Email.Web.Components
{
    [Component(Order = 750)]
    public class UserProfileInfoExtensionZone : IExtensionZone
    {
        public bool CanRenderInZone(string zoneId, HtmlHelper html)
        {
            if (zoneId != "EleWise.ELMA.BPM.Web.Security.Profile.ProfileCommonInfo")
            {
                return zoneId == "EleWise.ELMA.BPM.Web.Security.ProfileEditor.Table";
            }
            return true;
        }

        public void RenderZone(string zoneId, HtmlHelper html)
        {
            if (zoneId == "EleWise.ELMA.BPM.Web.Security.Profile.ProfileCommonInfo")
            {
                html.RenderPartial("Security/UserProfileInfo");
            }
            if (zoneId == "EleWise.ELMA.BPM.Web.Security.ProfileEditor.Table")
            {
                html.RenderPartial("Security/UserProfileEdit");
            }
        }
    }
}