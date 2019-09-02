namespace Yambr.ELMA.Email.Enums
{
    using System;
    
    
    /// <summary>
    /// Направление письма
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EnumMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("efab67bf-2e70-4118-afb6-82d1990c3777")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_EmailDirection), "DisplayName")]
    public enum EmailDirection
    {
        
        /// <summary>
        /// Входящее
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("c4065f36-139d-42d9-ac0c-48ff236ba54d")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_EmailDirection), "P_Incoming_DisplayName")]
        Incoming = 0,
        
        /// <summary>
        /// Исходящее
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("2c402344-245d-40f1-b6ad-95839adc8ed6")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_EmailDirection), "P_Outcoming_DisplayName")]
        Outcoming = 1,
    }
    
    internal class @__Resources_EmailDirection
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Направление письма");
            }
        }
        
        public static string P_Incoming_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Входящее");
            }
        }
        
        public static string P_Outcoming_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Исходящее");
            }
        }
    }
}
