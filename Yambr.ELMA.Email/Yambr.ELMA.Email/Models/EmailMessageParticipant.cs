#pragma warning disable 108,114,162
namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    
    
    /// <summary>
    /// EmailMessageParticipant
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("2474afc5-cfb2-4c63-aa91-12c4087819d9")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipant), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.AllowCreateHeirs(true)]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TitleProperty("57cd9014-871c-47f0-b1f5-4600fa36fd12")]
    [global::EleWise.ELMA.Model.Attributes.TableView("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<TableView xmlns:xsi=\"http://www.w3.org/2" +
        "001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Uid>7c" +
        "ddebaa-37b0-48a0-b36f-d72e36b4042a</Uid>\r\n  <ViewType>List</ViewType>\r\n</TableVi" +
        "ew>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("EmailMessageParticipant")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.ShowInCatalogList(true)]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.Interface)]
    [global::EleWise.ELMA.Model.Attributes.Filterable()]
    [global::EleWise.ELMA.Model.Attributes.ImplementationUid("557cb1c9-4b4d-4be0-b3c8-c7d071e2931c")]
    [global::EleWise.ELMA.Model.Attributes.FilterType(typeof(IEmailMessageParticipantFilter))]
    public partial interface IEmailMessageParticipant : global::EleWise.ELMA.Model.Entities.IEntity<long>, global::EleWise.ELMA.Model.Entities.IInheritable
    {
        
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("5dd6c791-037e-44f7-8e89-6d679be1fdf0")]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.SystemProperty()]
        [global::EleWise.ELMA.Model.Attributes.Property("eb6e8ddc-fafe-4e0e-9018-1a7667012579")]
        [global::EleWise.ELMA.Model.Types.Settings.GuidSettings(FieldName="Uid")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipant), "P_Uid_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.All, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        System.Guid Uid
        {
            get;
            set;
        }
        
        /// <summary>
        /// Наименование
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("57cd9014-871c-47f0-b1f5-4600fa36fd12")]
        [global::EleWise.ELMA.Model.Attributes.Order(1)]
        [global::EleWise.ELMA.Model.Attributes.Required(true)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(FieldName="Name")]
        [global::EleWise.ELMA.Model.Types.Validation.RequiredField()]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipant), "P_Name_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.FastSearch(true)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        string Name
        {
            get;
            set;
        }
        
        /// <summary>
        /// Email
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("15f523ba-7a38-458a-a4bf-ecad277f09d1")]
        [global::EleWise.ELMA.Model.Attributes.Order(2)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(MaxValueString="320", FieldName="EmailString")]
        [global::EleWise.ELMA.Model.Types.Validation.StringRangeLength(0, "320")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipant), "P_EmailString_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        string EmailString
        {
            get;
            set;
        }
    }
    
    internal class @__Resources_IEmailMessageParticipant
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("EmailMessageParticipant");
            }
        }
        
        public static string P_Uid_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Уникальный идентификатор");
            }
        }
        
        public static string P_Name_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Наименование");
            }
        }
        
        public static string P_EmailString_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Email");
            }
        }
    }
    
    /// <summary>
    /// Фильтр для объекта "EmailMessageParticipant"
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.FilterFor(typeof(IEmailMessageParticipant))]
    public interface IEmailMessageParticipantFilter : global::EleWise.ELMA.Model.Common.IEntityFilter
    {
        
        /// <summary>
        /// Фильтр для свойства "Наименование"
        /// </summary>
        string Name
        {
            get;
            set;
        }
        
        /// <summary>
        /// Фильтр для свойства "Email"
        /// </summary>
        string EmailString
        {
            get;
            set;
        }
    }
}
#pragma warning restore 108,114,162
