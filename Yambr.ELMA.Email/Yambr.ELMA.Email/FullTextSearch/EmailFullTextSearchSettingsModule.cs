using System;
using EleWise.ELMA;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.FullTextSearch.Manager;
using EleWise.ELMA.FullTextSearch.Services;
using EleWise.ELMA.Runtime.Settings;
using EleWise.ELMA.Services;

namespace Yambr.ELMA.Email.FullTextSearch
{
    /// <summary>
    /// Модуль настройки индексации CRM
    /// </summary>
    [Component]
    public class EmailFullTextSearchSettingsModule : GlobalSettingsModuleBase<EmailFullTextSearchSettings>
    {
        public override string ModuleName => SR.T("Индексация переписки - CRM");

        public override Guid ModuleGuid => Guid.Parse("{C2A0B282-0607-4794-8FB7-78D0B132D6B2}");

        /// <summary>
        /// Действует ли индексация вложений контрагентов в данный момент (с учетом работоспособности сервера индексации)
        /// </summary>
        public static bool IndexingEmailIsOn
        {
            get
            {
                var serviceNotNull =
                    Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
                var serviceNotNull2 = Locator.GetServiceNotNull<IFullTextSearchService>();
                if (serviceNotNull2.IndexingIsWorking() && !IndexQueueManager.Instance.HasIndexAllQueue() &&
                    serviceNotNull.Settings != null && serviceNotNull.Settings.IndexingEmail)
                {
                    return serviceNotNull.Settings.IndexingEmail;
                }

                return false;
            }
        }
    }
}