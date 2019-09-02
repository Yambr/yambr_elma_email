namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    using Iesi.Collections.Generic;
    
    
    /// <summary>
    /// Электронное письмо
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("79626ca2-5121-485b-85c3-c4eb017726f8")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TitleProperty("408d066b-f103-4c0f-825f-a37909f64a2a")]
    [global::EleWise.ELMA.Model.Attributes.TableView(@"<?xml version=""1.0"" encoding=""utf-8""?>
<TableView xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Uid>4a482dc8-e1c7-44b9-a57b-cefcc44424a7</Uid>
  <ViewType>List</ViewType>
  <SortDescriptors />
  <GroupDescriptors />
</TableView>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("EmailMessage")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.Interface)]
    [global::EleWise.ELMA.Model.Attributes.ShowInCatalogList()]
    [global::EleWise.ELMA.Model.Attributes.ImplementationUid("59760e6a-3a97-4e9f-a608-d5d402150c2f")]
    public partial interface IEmailMessage : global::EleWise.ELMA.Model.Entities.IEntity<long>
    {
        
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("3b180cda-c266-4252-a43a-2d5093cf80d4")]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.SystemProperty()]
        [global::EleWise.ELMA.Model.Attributes.Property("eb6e8ddc-fafe-4e0e-9018-1a7667012579")]
        [global::EleWise.ELMA.Model.Types.Settings.GuidSettings(FieldName="Uid")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_Uid_DisplayName")]
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
        [global::EleWise.ELMA.Model.Attributes.Uid("408d066b-f103-4c0f-825f-a37909f64a2a")]
        [global::EleWise.ELMA.Model.Attributes.Order(1)]
        [global::EleWise.ELMA.Model.Attributes.Required(true)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(FieldName="Name")]
        [global::EleWise.ELMA.Model.Types.Validation.RequiredField()]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_Name_DisplayName")]
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
        /// Дата письма
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("58513e49-d049-4c88-b0e5-62adacb6876b")]
        [global::EleWise.ELMA.Model.Attributes.Order(2)]
        [global::EleWise.ELMA.ComponentModel.CanBeNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("dac9211e-e02b-47cd-8868-89a3bfc0f749")]
        [global::EleWise.ELMA.Model.Types.Settings.DateTimeSettings(FieldName="DateUtc")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_DateUtc_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        System.Nullable<System.DateTime> DateUtc
        {
            get;
            set;
        }
        
        /// <summary>
        /// Hash
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("d80dee87-7099-4baa-8490-852c4ebbd939")]
        [global::EleWise.ELMA.Model.Attributes.Order(3)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(FieldName="Hash")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_Hash_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        string Hash
        {
            get;
            set;
        }
        
        /// <summary>
        /// Владельцы письма
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("189e1ab1-acd0-42ee-9f60-5f55b8f4a40a")]
        [global::EleWise.ELMA.Model.Attributes.Order(4)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "06aeb963-e379-4fff-9951-de6bf6cb508f")]
        [global::EleWise.ELMA.Model.Types.Settings.EntitySettings(CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate, FieldName="Owners")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_Owners_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        Yambr.ELMA.Email.Models.IUserMailbox Owners
        {
            get;
            set;
        }
        
        /// <summary>
        /// Основной заголовок
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("63ffa1a8-e8b0-47c7-8e2f-532a4b72a291")]
        [global::EleWise.ELMA.Model.Attributes.Order(5)]
        [global::EleWise.ELMA.Model.Attributes.Property("0aef74a9-d37c-4731-813b-d5f0b5ec4392")]
        [global::EleWise.ELMA.Model.Types.Settings.HtmlStringSettings(FieldName="MainHeader")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_MainHeader_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        System.Web.HtmlString MainHeader
        {
            get;
            set;
        }
        
        /// <summary>
        /// Все заголовки
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("98886b73-7ebf-4c06-860b-2863f32a0d4f")]
        [global::EleWise.ELMA.Model.Attributes.Order(6)]
        [global::EleWise.ELMA.Model.Attributes.Property("0aef74a9-d37c-4731-813b-d5f0b5ec4392")]
        [global::EleWise.ELMA.Model.Types.Settings.HtmlStringSettings(FieldName="CommonHeaders")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_CommonHeaders_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        System.Web.HtmlString CommonHeaders
        {
            get;
            set;
        }
        
        /// <summary>
        /// Тело письма
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("f2cfb4df-fb46-4a2b-aa20-3165cc08af79")]
        [global::EleWise.ELMA.Model.Attributes.Order(7)]
        [global::EleWise.ELMA.Model.Attributes.Property("0aef74a9-d37c-4731-813b-d5f0b5ec4392")]
        [global::EleWise.ELMA.Model.Types.Settings.HtmlStringSettings(FieldName="Body")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_Body_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        System.Web.HtmlString Body
        {
            get;
            set;
        }
        
        /// <summary>
        /// Html письмо
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("4b378993-25ae-457b-b8bb-3762cf7997a9")]
        [global::EleWise.ELMA.Model.Attributes.Order(8)]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("9cd56a40-6192-4d8a-840c-c4bd4dfb88eb")]
        [global::EleWise.ELMA.Model.Types.Settings.BoolSettings(FieldName="IsBodyHtml")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_IsBodyHtml_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        bool IsBodyHtml
        {
            get;
            set;
        }
        
        /// <summary>
        /// Направление письма
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("a68aa038-1344-43fb-863f-6966eea402c1")]
        [global::EleWise.ELMA.Model.Attributes.Order(9)]
        [global::EleWise.ELMA.ComponentModel.NotNull()]
        [global::EleWise.ELMA.Model.Attributes.Property("849c1ac9-4d46-4194-8cbb-43f84adf9c17", "efab67bf-2e70-4118-afb6-82d1990c3777")]
        [global::EleWise.ELMA.Model.Types.Settings.EnumSettings(DefaultValueStr="2c402344-245d-40f1-b6ad-95839adc8ed6", FieldName="Direction")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_Direction_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        Yambr.ELMA.Email.Enums.EmailDirection Direction
        {
            get;
            set;
        }
        
        /// <summary>
        /// От
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("6bb71d88-ab64-4fe3-813b-d7cae7677827")]
        [global::EleWise.ELMA.Model.Attributes.Order(10)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "2474afc5-cfb2-4c63-aa91-12c4087819d9")]
        [global::EleWise.ELMA.Model.Types.Settings.EntitySettings(RelationType=global::EleWise.ELMA.Model.Types.Settings.RelationType.ManyToMany, RelationTableName="M_EmailMessage_From", ParentColumnName="Parent", ChildColumnName="Child", CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate)]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_From_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        Iesi.Collections.Generic.ISet<Yambr.ELMA.Email.Models.IEmailMessageParticipant> From
        {
            get;
            set;
        }
        
        /// <summary>
        /// Кому
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("813fc69c-8716-40af-846c-4437552f50b5")]
        [global::EleWise.ELMA.Model.Attributes.Order(11)]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "2474afc5-cfb2-4c63-aa91-12c4087819d9")]
        [global::EleWise.ELMA.Model.Types.Settings.EntitySettings(RelationType=global::EleWise.ELMA.Model.Types.Settings.RelationType.ManyToMany, RelationTableName="M_EmailMessage_To", ParentColumnName="Parent", ChildColumnName="Child", CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate)]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_To_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        Iesi.Collections.Generic.ISet<Yambr.ELMA.Email.Models.IEmailMessageParticipant> To
        {
            get;
            set;
        }
        
        /// <summary>
        /// Тема
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("eeeb8ddd-eb36-4903-ad28-2f467dffd44e")]
        [global::EleWise.ELMA.Model.Attributes.Order(12)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(FieldName="Subject")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_Subject_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        string Subject
        {
            get;
            set;
        }
        
        /// <summary>
        /// Тема (без тегов)
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("7c753539-013d-4137-8edb-78984be9012a")]
        [global::EleWise.ELMA.Model.Attributes.Order(13)]
        [global::EleWise.ELMA.Model.Attributes.Property("9b9aac17-22bb-425c-aa93-9c02c5146965")]
        [global::EleWise.ELMA.Model.Types.Settings.StringSettings(FieldName="SubjectWithoutTags")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_SubjectWithoutTags_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        string SubjectWithoutTags
        {
            get;
            set;
        }
        
        /// <summary>
        /// Теги
        /// </summary>
        /// <remarks>
        /// теги через запятую
        /// </remarks>
        [global::EleWise.ELMA.Model.Attributes.Uid("fde76d12-ce30-4a72-8cd5-9bb85ba2dded")]
        [global::EleWise.ELMA.Model.Attributes.Order(14)]
        [global::EleWise.ELMA.Model.Attributes.Property("317e3d72-9c47-4b68-926d-ba77a2579bc2")]
        [global::EleWise.ELMA.Model.Types.Settings.TextSettings(FieldName="Tags")]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessage), "P_Tags_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.Description(typeof(@__Resources_IEmailMessage), "P_Tags_Description")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        string Tags
        {
            get;
            set;
        }
    }
    
    internal class @__Resources_IEmailMessage
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Электронное письмо");
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
        
        public static string P_DateUtc_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Дата письма");
            }
        }
        
        public static string P_Hash_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Hash");
            }
        }
        
        public static string P_Owners_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Владельцы письма");
            }
        }
        
        public static string P_MainHeader_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Основной заголовок");
            }
        }
        
        public static string P_CommonHeaders_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Все заголовки");
            }
        }
        
        public static string P_Body_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Тело письма");
            }
        }
        
        public static string P_IsBodyHtml_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Html письмо");
            }
        }
        
        public static string P_Direction_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Направление письма");
            }
        }
        
        public static string P_From_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("От");
            }
        }
        
        public static string P_To_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Кому");
            }
        }
        
        public static string P_Subject_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Тема");
            }
        }
        
        public static string P_SubjectWithoutTags_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Тема (без тегов)");
            }
        }
        
        public static string P_Tags_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Теги");
            }
        }
        
        public static string P_Tags_Description
        {
            get
            {
                return global::EleWise.ELMA.SR.T("теги через запятую");
            }
        }
    }
}
