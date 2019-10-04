// EleWise.ELMA.CRM.FullTextSearch.Model.IContractorFullTextSearchObject

using System;
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
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Тема
        /// </summary>
        string Subject { get; set; }
        DateTime? DateUtc { get; set; }

        string[] From { get; set; }

        string[] To { get; set; }

        string[] Owners { get; set; }
        string Body { get; set; }

        long[] Contractors { get; set; }
        long[] Contacts { get; set; }

        /// <summary>
        /// Удален
        /// </summary>
        bool IsDeleted { get; set; }

    }
}