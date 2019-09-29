using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using EleWise.ELMA;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.FullTextSearch.ExtensionPoints;
using EleWise.ELMA.FullTextSearch.Model;
using EleWise.ELMA.FullTextSearch.Settings;
using EleWise.ELMA.Runtime.Settings;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.FullTextSearch;

namespace Yambr.ELMA.Email.Web.FullTextSearch.Components
{
    /// <summary>
    /// Точка расширения отображения и редактирования настроек модуля полнотекстового поиска в Email
    /// </summary>
    [Component(Type = ComponentType.Web)]
    public class EmailFullTextSearchModuleSettingsRender : IFullTextSearchModuleSettingsRender
    {
        public bool IsSupported(IFullTextSearchModuleSettings settings)
        {
            return settings as EmailFullTextSearchSettings != null;
        }

        /// <summary>
        /// Отобразить представление только для чтения
        /// </summary>
        public MvcHtmlString RenderDisplay(HtmlHelper html)
        {
            var module = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
            return html.Partial("FullTextSearch/Settings/FullTextSearchEmailSettingsViewForm", module.Settings);
        }

        /// <summary>
        /// Отобразить представление для редактирования (уже внутри формы)
        /// </summary>
        public MvcHtmlString RenderEdit(HtmlHelper html)
        {
            var module = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
            return html.Partial("FullTextSearch/Settings/FullTextSearchEmailSettingsEditForm", module.Settings);
        }

        /// <summary>
        /// Сохранить настройки из текущего контекста
        /// </summary>
        public FullTextSettingsSaveResult SaveSettings(ControllerContext context)
        {
            var res = new FullTextSettingsSaveResult();
            try
            {
                Module.SaveSettings();

                res.Success = true;
                res.ErrorMessage = null;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.ErrorMessage = SR.T("Ошибка при сохранении настроек: {0}", ex.Message);
            }
            return res;
        }

        public IGlobalSettingsModule Module => Locator.GetService<EmailFullTextSearchSettingsModule>();
    }
}