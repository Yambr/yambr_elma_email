namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    using Iesi.Collections.Generic;
    
    
    /// <summary>
    /// UserExt
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("1a90b668-9e2b-4ac6-8e5f-e1076001ceca")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserExt), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.BaseClass("cfdeb03c-35e9-45e7-aad8-037d83888f73")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TableView(@"<?xml version=""1.0"" encoding=""utf-8""?>
<TableView xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Uid>2eaa076a-3c1a-4be2-b6ee-f730b9aedeb5</Uid>
  <ViewType>List</ViewType>
  <SortDescriptors />
  <GroupDescriptors />
</TableView>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("UserExt")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.InterfaceExtension)]
    [global::EleWise.ELMA.Model.Attributes.ActionsType(typeof(UserExtActions))]
    public partial interface IUserExt : global::EleWise.ELMA.Security.Models.IUser
    {
        
        /// <summary>
        /// Почтовые ящики
        /// </summary>
        [global::EleWise.ELMA.Model.Attributes.Uid("f18d2967-d7d1-43a9-be82-8ff0d7fe70e3")]
        [global::EleWise.ELMA.Model.Attributes.Property("72ed98ca-f260-4671-9bcd-ff1d80235f47", "06aeb963-e379-4fff-9951-de6bf6cb508f")]
        [global::EleWise.ELMA.Model.Types.Settings.EntitySettings(RelationType=global::EleWise.ELMA.Model.Types.Settings.RelationType.OneToMany, KeyColumnUidStr="e11d2fdd-fb0e-4449-822b-cd42d10104ea", CascadeMode=global::EleWise.ELMA.Model.Types.Settings.CascadeMode.SaveUpdate)]
        [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IUserExt), "P_MailBoxes_DisplayName")]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Create, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Edit, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Display, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=true)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.List, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Hidden, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.View(ViewType=global::EleWise.ELMA.Model.Views.ViewType.Filter, ItemType=global::EleWise.ELMA.Model.Views.ItemType.Default, Visibility=global::EleWise.ELMA.Model.Views.Visibility.Visible, ReadOnly=false)]
        [global::EleWise.ELMA.Model.Attributes.Filterable()]
        [global::EleWise.ELMA.Model.Attributes.EntityProperty()]
        Iesi.Collections.Generic.ISet<Yambr.ELMA.Email.Models.IUserMailbox> MailBoxes
        {
            get;
            set;
        }
    }
    
    internal class @__Resources_IUserExt
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("UserExt");
            }
        }
        
        public static string P_MailBoxes_DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("Почтовые ящики");
            }
        }
    }
}
