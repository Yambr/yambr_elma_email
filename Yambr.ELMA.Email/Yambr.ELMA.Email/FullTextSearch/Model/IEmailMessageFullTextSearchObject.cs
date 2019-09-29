// EleWise.ELMA.CRM.FullTextSearch.Model.IContractorFullTextSearchObject

using EleWise.ELMA.FullTextSearch.Model;
using EleWise.ELMA.Model.Attributes;
using EleWise.ELMA.Model.Common;

namespace Yambr.ELMA.Email.FullTextSearch.Model
{
    /// <summary>
    ///
    /// </summary>
    [AutoImplement(typeof(IFullTextSearchObject))]
    public interface IEmailMessageFullTextSearchObject : IFullTextSearchObject, IAutoImplement
    {
        string SearchString { get; set; }
        /// <summary>
        /// Тема
        /// </summary>
        string Subject { get; set; }

        string[] From { get; set; }

        string[] To { get; set; }

        string[] Owners { get; set; }
        string Body { get; set; }
        
        /// <summary>
        /// Удален
        /// </summary>
        bool IsDeleted { get; set; }

    }
}