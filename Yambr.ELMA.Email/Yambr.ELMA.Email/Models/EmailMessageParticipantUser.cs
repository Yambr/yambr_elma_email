namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    using Iesi.Collections.Generic;
    
    
    /// <summary>
    /// EmailMessageParticipantUser
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("71e11768-05e2-4788-b93e-7440e72b32b5")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipantUser), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.BaseClass("2474afc5-cfb2-4c63-aa91-12c4087819d9")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TableView(@"<?xml version=""1.0"" encoding=""utf-8""?>
<TableView xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Uid>46ffb8e8-82cb-4e60-8719-303e04da6364</Uid>
  <ViewType>List</ViewType>
  <SortDescriptors />
  <GroupDescriptors />
</TableView>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("EmailMessageParticipantUser")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.Interface)]
    [global::EleWise.ELMA.Model.Attributes.ImplementationUid("9d070869-4ac7-4d60-a952-b487652baa8f")]
    public partial interface IEmailMessageParticipantUser : global::Yambr.ELMA.Email.Models.IEmailMessageParticipant
    {
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
    }
}
