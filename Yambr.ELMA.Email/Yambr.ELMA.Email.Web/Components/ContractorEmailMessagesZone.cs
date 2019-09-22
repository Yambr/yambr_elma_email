using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.CRM.Web.Extensions;
using EleWise.ELMA.Web.Mvc.ExtensionPoints;

namespace Yambr.ELMA.Email.Web.Components
{
    [Component(EnableInterceptiors = false, InjectProerties = false, Order = 10)]
    public class ContractorEmailMessagesZone : IExtensionZone
    {

        private static readonly List<string> zones =
            new List<string>
            {
                "Contractor.EmailMessages"
            };

        public bool CanRenderInZone(string zoneId, System.Web.Mvc.HtmlHelper html)
        {
            return zones.Contains(zoneId);
        }

        public void RenderZone(string zoneId, System.Web.Mvc.HtmlHelper html)
        {
            if (zones.Contains(zoneId))
            {
                var model = html.ViewData.Model as IContractorBaseModel;
                if (model == null)
                    return;

                html.RenderPartial("Contractor/ContractorExtensionZone");
            }
        }

    }
}