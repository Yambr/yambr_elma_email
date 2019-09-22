using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Web.Mvc.ExtensionPoints;

namespace Yambr.ELMA.Email.Web.Components
{
    [Component(Order = 250)]
    internal class LayoutScriptSourceProvider : ILayoutScriptSourceProvider
    {
        public string[] ScriptSources => new[]
                {
                };
    }
}