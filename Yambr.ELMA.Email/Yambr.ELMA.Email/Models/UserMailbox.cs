namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    using Iesi.Collections.Generic;
    
    
    /// <summary>
    /// UserMailbox
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("06aeb963-e379-4fff-9951-de6bf6cb508f")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TitleProperty("8aba5c2c-e2e6-466a-8fbe-9fbf6287db1e")]
    [global::EleWise.ELMA.Model.Attributes.TableView(@"<?xml version=""1.0"" encoding=""utf-8""?>
<TableView xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Uid>2b183cbc-bbcc-4b07-8eb6-16de28e59de3</Uid>
  <ViewType>List</ViewType>
  <SortDescriptors />
  <GroupDescriptors />
</TableView>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("UserMailbox")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.Interface)]
    [global::EleWise.ELMA.Model.Attributes.ShowInCatalogList()]
    [global::EleWise.ELMA.Model.Attributes.ImplementationUid("ca2f3a69-b8d4-427f-9c32-d99985594dac")]
    public partial interface IUserMailbox : global::EleWise.ELMA.Model.Entities.IEntity<long>
    {
        
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("398135e9-1c05-4571-a13f-2e7fe60a3a09")]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.SystemProperty()]
        [global::EleWise.ELMA.Model.Attributes.Property("eb6e8ddc-fafe-4e0e-9018-1a7667012579")]
        [global::EleWise.ELMA.Model.Types.Settings.GuidSettings(FieldName="Uid")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "P_Uid_DisplayName")]
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
        [global::EleWise.ELMA.Model.Attributes.Uid("8aba5c2c-e2e6-466a-8fbe-9fbf6287db1e")]
        [global::EleWise.ELMA.Model.Attributes.Order(1)]
        [global::EleWise.ELMA.Model.Attributes.Required(true)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(FieldName="Name")]
        [global::EleWise.ELMA.Model.Types.Validation.RequiredField()]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "P_Name_DisplayName")]
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
        [global::EleWise.ELMA.Model.Attributes.Uid("824e8f7e-a414-4f0b-8c01-8579a556045a")]
        [global::EleWise.ELMA.Model.Attributes.Order(2)]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("dac9211e-e02b-47cd-8868-89a3bfc0f749")]
        [global::EleWise.ELMA.Model.Types.Settings.DateTimeSettings(SetCurrentDate=true, FieldName="CreationDate")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "P_CreationDate_DisplayName")]
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
        [global::EleWise.ELMA.Model.Attributes.Uid("5200cb77-1e0f-4aa8-b89a-7df03624a320")]
        [global::EleWise.ELMA.Model.Attributes.Order(3)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "cfdeb03c-35e9-45e7-aad8-037d83888f73")]
        [global::EleWise.ELMA.Security.Types.Settings.EntityUserSettings(FieldName="CreationAuthor")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "P_CreationAuthor_DisplayName")]
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
        [global::EleWise.ELMA.Model.Attributes.Uid("139faf94-ad8f-43c1-bc9a-f16c0aff553b")]
        [global::EleWise.ELMA.Model.Attributes.Order(4)]
        [global::EleWise.ELMA.ComponentModel.CanBeNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("dac9211e-e02b-47cd-8868-89a3bfc0f749")]
        [global::EleWise.ELMA.Model.Types.Settings.DateTimeSettings(FieldName="ChangeDate")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "P_ChangeDate_DisplayName")]
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
        [global::EleWise.ELMA.Model.Attributes.Uid("8b6d961c-b64c-48b0-ade4-84ecda73c9a1")]
        [global::EleWise.ELMA.Model.Attributes.Order(5)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "cfdeb03c-35e9-45e7-aad8-037d83888f73")]
        [global::EleWise.ELMA.Security.Types.Settings.EntityUserSettings(FieldName="ChangeAuthor")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "P_ChangeAuthor_DisplayName")]
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
        /// Владелец
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("e11d2fdd-fb0e-4449-822b-cd42d10104ea")]
        [global::EleWise.ELMA.Model.Attributes.Order(6)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "cfdeb03c-35e9-45e7-aad8-037d83888f73")]
        [global::EleWise.ELMA.Security.Types.Settings.EntityUserSettings(CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate, FieldName="Owner")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "P_Owner_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        EleWise.ELMA.Security.Models.IUser Owner
        {
            get;
            set;
        }
        
        /// <summary>
        /// Сервер
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("3535c6a8-360e-45ba-95b7-0e0efeff8d5d")]
        [global::EleWise.ELMA.Model.Attributes.Order(7)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "8786ded0-8825-482d-9446-e9a6eaf6caa0")]
        [global::EleWise.ELMA.Model.Types.Settings.EntitySettings(CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate, FieldName="Server")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserMailbox), "P_Server_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        Yambr.ELMA.Email.Models.IMailServer Server
        {
            get;
            set;
        }
    }
    
    internal class @__Resources_IUserMailbox
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("UserMailbox");
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
        
        public static string P_Owner_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Владелец");
            }
        }
        
        public static string P_Server_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Сервер");
            }
        }
    }
}
