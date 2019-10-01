namespace Yambr.ELMA.Email.Enums
{
    using System;
    
    
    /// <summary>
    /// Статус загрузки из почтового ящика
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EnumMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("c2eb5adb-5d14-47ad-a304-58adb8d5432f")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_EmailLoadingStatus), "DisplayName")]
    public enum EmailLoadingStatus
    {
        
        /// <summary>
        /// Выключено
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("f97f9c9d-5e14-40ad-8bd3-f37b3f1f0483")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_EmailLoadingStatus), "P_Disabled_DisplayName")]
        Disabled = 0,
        
        /// <summary>
        /// Активно
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("d680397a-e681-41c5-91c7-115d7bb1dc36")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_EmailLoadingStatus), "P_Active_DisplayName")]
        Active = 1,
        
        /// <summary>
        /// Ошибки при загрузке
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("1c1f19d2-eb54-45be-8b8c-11e8d58f73cb")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_EmailLoadingStatus), "P_Error_DisplayName")]
        Error = 2,
    }
    
    internal class @__Resources_EmailLoadingStatus
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Статус загрузки из почтового ящика");
            }
        }
        
        public static string P_Disabled_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Выключено");
            }
        }
        
        public static string P_Active_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Активно");
            }
        }
        
        public static string P_Error_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Ошибки при загрузке");
            }
        }
    }
}
