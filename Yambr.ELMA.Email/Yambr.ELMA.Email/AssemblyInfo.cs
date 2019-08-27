[assembly: System.Runtime.InteropServices.Guid("1c0e408c-ae15-4642-8f17-fc5a305160ca")]
[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Reflection.AssemblyTitle("История переписок CRM")]
[assembly: EleWise.ELMA.ComponentModel.ComponentAssembly()]
[assembly: EleWise.ELMA.Model.Attributes.ModelAssembly()]

namespace Yambr.ELMA.Email
{
    using System;
    
    
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.AssemblyInfoMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("1c0e408c-ae15-4642-8f17-fc5a305160ca")]
    [global::EleWise.ELMA.Model.Attributes.AssemblySummary(typeof(@__Resources__AssemblyInfo), "Summary")]
    internal class @__AssemblyInfo
    {
        
        /// <summary>
        /// Уникальный идентификатор данного класса
        /// </summary>
        public const string UID_S = "1c0e408c-ae15-4642-8f17-fc5a305160ca";
        
        private static global::System.Guid _UID = new global::System.Guid(UID_S);
        
        /// <summary>
        /// Уникальный идентификатор данного класса
        /// </summary>
        public static global::System.Guid UID
        {
            get
            {
                return _UID;
            }
        }
    }
    
    internal class @__Resources__AssemblyInfo
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("История переписок CRM");
            }
        }
        
        public static string Summary
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Интеграция с сервисом чтения писем");
            }
        }
    }
}
