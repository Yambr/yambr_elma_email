#pragma warning disable 108,114,162
namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    
    
    /// <summary>
    /// Участник письма - Контакт
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("a8ee5fd8-6f4e-4fe3-bd0b-063fe92694ab")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipantContact), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.BaseClass("2474afc5-cfb2-4c63-aa91-12c4087819d9")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TableView("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<TableView xmlns:xsi=\"http://www.w3.org/2" +
        "001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Uid>bc" +
        "4af76d-9693-4b58-ac85-fdd3be8b4938</Uid>\r\n  <ViewType>List</ViewType>\r\n</TableVi" +
        "ew>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("EmailMessageParticipantConta")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.ShowInCatalogList(true)]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.Interface)]
    [global::EleWise.ELMA.Model.Attributes.ImplementationUid("99cb0b2d-1597-4d14-8fee-45e4c511647c")]
    public partial interface IEmailMessageParticipantContact : global::Yambr.ELMA.Email.Models.IEmailMessageParticipant
    {
        
        /// <summary>
        /// Контакт
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("dac4aebc-48ea-401e-9a45-86139f08bec9")]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "a9b1bc6a-3286-4264-81aa-02f6df73c080")]
        [global::EleWise.ELMA.Model.Types.Settings.EntitySettings(CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate, FieldName="Contact")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipantContact), "P_Contact_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        EleWise.ELMA.CRM.Models.IContact Contact
        {
            get;
            set;
        }
    }
    
    internal class @__Resources_IEmailMessageParticipantContact
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Участник письма - Контакт");
            }
        }
        
        public static string P_Contact_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Контакт");
            }
        }
    }
}
#pragma warning restore 108,114,162
