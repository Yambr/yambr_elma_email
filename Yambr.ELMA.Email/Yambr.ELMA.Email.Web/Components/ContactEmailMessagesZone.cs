using System.Collections.Generic;
using System.Web.Mvc.Html;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.CRM.Models;
using EleWise.ELMA.Model.Entities;
using EleWise.ELMA.Web.Mvc.ExtensionPoints;

namespace Yambr.ELMA.Email.Web.Components
{
    [Component(EnableInterceptiors = false, InjectProerties = false, Order = 10)]
    public class ContactEmailMessagesZone : IExtensionZone
    {

        private static readonly List<string> zones =
            new List<string>
            {
                "Contact.EmailMessages"
            };

        public bool CanRenderInZone(string zoneId, System.Web.Mvc.HtmlHelper html)
        {
            return zones.Contains(zoneId);
        }

        public void RenderZone(string zoneId, System.Web.Mvc.HtmlHelper html)
        {
            if (zones.Contains(zoneId))
            {
                var model = html.ViewData.Model as EntityModel<IContact>;
                if (model == null)
                    return;

                html.RenderPartial("Contact/ContactExt");
            }
        }

    }
}