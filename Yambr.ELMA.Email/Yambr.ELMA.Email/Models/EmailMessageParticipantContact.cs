namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    using Iesi.Collections.Generic;
    
    
    /// <summary>
    /// EmailMessageParticipantContact
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("a8ee5fd8-6f4e-4fe3-bd0b-063fe92694ab")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IEmailMessageParticipantContact), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.BaseClass("2474afc5-cfb2-4c63-aa91-12c4087819d9")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.TableView(@"<?xml version=""1.0"" encoding=""utf-8""?>
<TableView xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Uid>bc4af76d-9693-4b58-ac85-fdd3be8b4938</Uid>
  <ViewType>List</ViewType>
  <SortDescriptors />
  <GroupDescriptors />
</TableView>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("EmailMessageParticipantConta")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.Interface)]
    [global::EleWise.ELMA.Model.Attributes.ImplementationUid("99cb0b2d-1597-4d14-8fee-45e4c511647c")]
    public partial interface IEmailMessageParticipantContact : global::Yambr.ELMA.Email.Models.IEmailMessageParticipant
    {
    }
    
    internal class @__Resources_IEmailMessageParticipantContact
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("EmailMessageParticipantContact");
            }
        }
    }
}
