#pragma warning disable 108,114,162
namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    
    
    /// <summary>
    /// EmailMessageParticipantUser
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("71e11768-05e2-4788-b93e-7440e72b32b5")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipantUser), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.BaseClass("2474afc5-cfb2-4c63-aa91-12c4087819d9")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TableView("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<TableView xmlns:xsi=\"http://www.w3.org/2" +
        "001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Uid>46" +
        "ffb8e8-82cb-4e60-8719-303e04da6364</Uid>\r\n  <ViewType>List</ViewType>\r\n</TableVi" +
        "ew>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("EmailMessageParticipantUser")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.ShowInCatalogList(false)]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.Interface)]
    [global::EleWise.ELMA.Model.Attributes.ImplementationUid("9d070869-4ac7-4d60-a952-b487652baa8f")]
    public partial interface IEmailMessageParticipantUser : global::Yambr.ELMA.Email.Models.IEmailMessageParticipant
    {
        
        /// <summary>
        /// User
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("62ebc39c-714f-471e-955e-ec1c5717c279")]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "cfdeb03c-35e9-45e7-aad8-037d83888f73")]
        [global::EleWise.ELMA.Security.Types.Settings.EntityUserSettings(CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate, FieldName="User")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipantUser), "P_User_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        EleWise.ELMA.Security.Models.IUser User
        {
            get;
            set;
        }
        
        /// <summary>
        /// Mailbox
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("cbf3be84-d207-45d0-a26b-e60822be9197")]
        [global::EleWise.ELMA.Model.Attributes.Order(1)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "06aeb963-e379-4fff-9951-de6bf6cb508f")]
        [global::EleWise.ELMA.Model.Types.Settings.EntitySettings(CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate, FieldName="Mailbox")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipantUser), "P_Mailbox_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        Yambr.ELMA.Email.Models.IUserMailbox Mailbox
        {
            get;
            set;
        }
    }
    
    internal class @__Resources_IEmailMessageParticipantUser
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("EmailMessageParticipantUser");
            }
        }
        
        public static string P_User_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("User");
            }
        }
        
        public static string P_Mailbox_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Mailbox");
            }
        }
    }
}
#pragma warning restore 108,114,162
