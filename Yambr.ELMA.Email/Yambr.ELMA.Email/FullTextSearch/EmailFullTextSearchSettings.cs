using EleWise.ELMA;
using EleWise.ELMA.FullTextSearch.Model;
using EleWise.ELMA.Model.Attributes;
using EleWise.ELMA.Runtime.Settings;
using EleWise.ELMA.Services;

namespace Yambr.ELMA.Email.FullTextSearch
{
    /// <summary>
    /// Настройки индексации CRM
    /// </summary>
    public class EmailFullTextSearchSettings : GlobalSettingsBase, IFullTextSearchModuleSettings
    {
        /// <summary>
        /// Индексировать контрагентов
        /// </summary>
        [DisplayName(typeof(__Resources_EnailFullTextSearchSettings), "IndexingEmail")]
        public bool IndexingEmail { get; set; }
    

        /// <summary>
        ///
        /// </summary>
        public EmailFullTextSearchSettings()
        {
            IndexingEmail = true;
        }

        public void BindAndSaveToGlobalSettings()
        {
            var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
            if (serviceNotNull.Settings != null)
            {
                if (serviceNotNull.Settings != this)
                {
                    serviceNotNull.Settings.IndexingEmail = IndexingEmail;
                }

                serviceNotNull.SaveSettings();
            }
        }

        // ReSharper disable once InconsistentNaming
        internal class __Resources_EnailFullTextSearchSettings
        {
            public static string IndexingEmail => SR.T("Индексировать письма");

        }
    }
}