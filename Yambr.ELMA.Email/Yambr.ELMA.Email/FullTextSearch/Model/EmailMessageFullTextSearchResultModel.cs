using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EleWise.ELMA.CRM.Models;
using EleWise.ELMA.FullTextSearch.Model;

namespace Yambr.ELMA.Email.FullTextSearch.Model
{
    /// <summary>
    /// Модель результата полнотекстового поиска 
    /// </summary>
    public class EmailMessageFullTextSearchResultModel : FullTextSearchResultModel
    {
        /// <summary>
        /// Контрагент для которого ведется поиск
        /// </summary>
        public IContractor Contractor;
        /// <summary>
        /// Контакт для которого ведется поиск
        /// </summary>
        public IContact Contact;
    }
}
