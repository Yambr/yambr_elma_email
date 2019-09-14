namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    using Iesi.Collections.Generic;
    
    
    /// <summary>
    /// MailServer
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("8786ded0-8825-482d-9446-e9a6eaf6caa0")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TitleProperty("799d21e8-dd55-4ca4-a37e-00f21505248b")]
    [global::EleWise.ELMA.Model.Attributes.TableView(@"<?xml version=""1.0"" encoding=""utf-8""?>
<TableView xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Uid>c521bb31-e0ff-449f-bb6e-45c5c1c3c132</Uid>
  <ViewType>List</ViewType>
  <SortDescriptors />
  <GroupDescriptors />
</TableView>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("MailServer")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.Interface)]
    [global::EleWise.ELMA.Model.Attributes.ShowInCatalogList()]
    [global::EleWise.ELMA.Model.Attributes.ImplementationUid("27058b45-7262-4578-b0d9-026b2dedd839")]
    public partial interface IMailServer : global::EleWise.ELMA.Model.Entities.IEntity<long>
    {
        
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("757b2769-c9a3-409d-8c82-34048da2027d")]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.SystemProperty()]
        [global::EleWise.ELMA.Model.Attributes.Property("eb6e8ddc-fafe-4e0e-9018-1a7667012579")]
        [global::EleWise.ELMA.Model.Types.Settings.GuidSettings(FieldName="Uid")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_Uid_DisplayName")]
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
        [global::EleWise.ELMA.Model.Attributes.Uid("799d21e8-dd55-4ca4-a37e-00f21505248b")]
        [global::EleWise.ELMA.Model.Attributes.Order(1)]
        [global::EleWise.ELMA.Model.Attributes.Required(true)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(FieldName="Name")]
        [global::EleWise.ELMA.Model.Types.Validation.RequiredField()]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_Name_DisplayName")]
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
        /// Дата создания
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("d68fc0d6-18cd-431d-9f80-b862b2e7b972")]
        [global::EleWise.ELMA.Model.Attributes.Order(2)]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("dac9211e-e02b-47cd-8868-89a3bfc0f749")]
        [global::EleWise.ELMA.Model.Types.Settings.DateTimeSettings(SetCurrentDate=true, FieldName="CreationDate")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_CreationDate_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.PropertyHandler("d0c00d8a-e003-427d-9942-f52cfb77b0f0")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        System.DateTime CreationDate
        {
            get;
            set;
        }
        
        /// <summary>
        /// Автор создания
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("0ecfadd1-97c0-48a3-a0fa-dfd1ce3167eb")]
        [global::EleWise.ELMA.Model.Attributes.Order(3)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "cfdeb03c-35e9-45e7-aad8-037d83888f73")]
        [global::EleWise.ELMA.Security.Types.Settings.EntityUserSettings(FieldName="CreationAuthor")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_CreationAuthor_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.PropertyHandler("b05ac6bd-eb8b-474a-a796-b53831a9967e")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        EleWise.ELMA.Security.Models.IUser CreationAuthor
        {
            get;
            set;
        }
        
        /// <summary>
        /// Дата изменения
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("b7dea550-0cac-4f89-8fc2-1e20f7affab4")]
        [global::EleWise.ELMA.Model.Attributes.Order(4)]
        [global::EleWise.ELMA.ComponentModel.CanBeNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("dac9211e-e02b-47cd-8868-89a3bfc0f749")]
        [global::EleWise.ELMA.Model.Types.Settings.DateTimeSettings(FieldName="ChangeDate")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_ChangeDate_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.PropertyHandler("12a6c5c4-12f8-4b2e-b7ea-5438974a2d25")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        System.Nullable<System.DateTime> ChangeDate
        {
            get;
            set;
        }
        
        /// <summary>
        /// Автор изменения
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("96cbcbcd-11fd-4982-a29a-419589f12b8c")]
        [global::EleWise.ELMA.Model.Attributes.Order(5)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "cfdeb03c-35e9-45e7-aad8-037d83888f73")]
        [global::EleWise.ELMA.Security.Types.Settings.EntityUserSettings(FieldName="ChangeAuthor")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_ChangeAuthor_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.PropertyHandler("d152e660-1ee9-4b5f-a614-df280e5b3f98")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        EleWise.ELMA.Security.Models.IUser ChangeAuthor
        {
            get;
            set;
        }
        
        /// <summary>
        /// Адрес IMAP
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("d301f68b-52fb-4203-b4b4-3b137d1f20a3")]
        [global::EleWise.ELMA.Model.Attributes.Order(6)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(FieldName="ImapHost")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_ImapHost_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.FastSearch(true)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        string ImapHost
        {
            get;
            set;
        }
        
        /// <summary>
        /// Порт IMAP
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("2cbe8b88-74de-4d0f-b975-4958786a69f2")]
        [global::EleWise.ELMA.Model.Attributes.Order(7)]
        [global::EleWise.ELMA.ComponentModel.CanBeNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
        [global::EleWise.ELMA.Model.Types.Settings.Int64Settings(DefaultValueStr="993", FieldName="ImapPort")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_ImapPort_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        System.Nullable<long> ImapPort
        {
            get;
            set;
        }
        
        /// <summary>
        /// Требуется SSL
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("66c1b4b5-b162-499b-83db-160af1f686f1")]
        [global::EleWise.ELMA.Model.Attributes.Order(8)]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("9cd56a40-6192-4d8a-840c-c4bd4dfb88eb")]
        [global::EleWise.ELMA.Model.Types.Settings.BoolSettings(FieldName="RequaredSSL")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IMailServer), "P_RequaredSSL_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        bool RequaredSSL
        {
            get;
            set;
        }
    }
    
    internal class @__Resources_IMailServer
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("MailServer");
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
        
        public static string P_CreationDate_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Дата создания");
            }
        }
        
        public static string P_CreationAuthor_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Автор создания");
            }
        }
        
        public static string P_ChangeDate_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Дата изменения");
            }
        }
        
        public static string P_ChangeAuthor_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Автор изменения");
            }
        }
        
        public static string P_ImapHost_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Адрес IMAP");
            }
        }
        
        public static string P_ImapPort_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Порт IMAP");
            }
        }
        
        public static string P_RequaredSSL_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Требуется SSL");
            }
        }
    }
}
