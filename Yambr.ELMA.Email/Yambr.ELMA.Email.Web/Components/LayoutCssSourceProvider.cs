using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Web.Mvc.ExtensionPoints;

namespace Yambr.ELMA.Email.Web.Components
{
    [Component(Order = 250)]
    internal class LayoutCssSourceProvider : ILayoutCssSourceProvider
    {
        public string[] CssSources => new[]
        {
        };
    }
}