#pragma warning disable 108,114,162
namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    
    
    /// <summary>
    /// ContractorExt
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("f1254386-a72a-4f41-9986-8060c7dae23a")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IContractorExt), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.BaseClass("38096146-0c73-4809-94f5-e18b2d525531")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TableView("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<TableView xmlns:xsi=\"http://www.w3.org/2" +
        "001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Uid>e7" +
        "c98776-cd21-43f9-9290-b27741b61630</Uid>\r\n  <ViewType>List</ViewType>\r\n</TableVi" +
        "ew>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("ContractorExt")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.ShowInCatalogList(false)]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.InterfaceExtension)]
    [global::EleWise.ELMA.Model.Attributes.ActionsType(typeof(ContractorExtActions))]
    public partial interface IContractorExt : global::EleWise.ELMA.CRM.Models.IContractor
    {
        
        /// <summary>
        /// Домены
        /// </summary>
        /// <remarks>
        /// письма с этих доменов автоматически создадут новые контакты и прикрепят к ним новые письма
        /// </remarks>
        [global::EleWise.ELMA.Model.Attributes.Uid("f296ac2f-83c2-45e6-8357-4e0f36b42043")]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "9634d99b-edd4-45fe-9b2e-0dc68465bcc0")]
        [global::EleWise.ELMA.Model.Types.Settings.EntitySettings(RelationType=global::EleWise.ELMA.Model.Types.Settings.RelationType.OneToMany, KeyColumnUidStr="58c867aa-df79-4795-b3a4-8be6fb9b740c")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IContractorExt), "P_Domains_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.Description(typeof(@__Resources_IContractorExt), "P_Domains_Description")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        Iesi.Collections.Generic.ISet<Yambr.ELMA.Email.Models.IMailboxDomain> Domains
        {
            get;
            set;
        }
    }
    
    internal class @__Resources_IContractorExt
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("ContractorExt");
            }
        }
        
        public static string P_Domains_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Домены");
            }
        }
        
        public static string P_Domains_Description
        {
            get
            {
                return global::EleWise.ELMA.SR.T("письма с этих доменов автоматически создадут новые контакты и прикрепят к ним нов" +
                        "ые письма");
            }
        }
    }
}
#pragma warning restore 108,114,162
