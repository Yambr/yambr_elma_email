#pragma warning disable 108,114,162
namespace Yambr.ELMA.Email.Models
{
    using System;
    using System.Linq;
    using EleWise.ELMA.Extensions;
    
    
    /// <summary>
    /// ContactExt
    /// </summary>
    [global::EleWise.ELMA.Model.Attributes.MetadataType(typeof(global::EleWise.ELMA.Model.Metadata.EntityMetadata))]
    [global::EleWise.ELMA.Model.Attributes.Uid("fc36295d-1bc9-4e0b-b219-c9728c9f6117")]
    [global::EleWise.ELMA.Model.Attributes.DisplayName(typeof(@__Resources_IContactExt), "DisplayName")]
    [global::EleWise.ELMA.Model.Attributes.BaseClass("a9b1bc6a-3286-4264-81aa-02f6df73c080")]
    [global::EleWise.ELMA.Model.Attributes.DisplayFormat(null)]
    [global::EleWise.ELMA.Model.Attributes.ClassFormsScheme(global::EleWise.ELMA.Model.Metadata.ClassFormsScheme.FormConstructor)]
    [global::EleWise.ELMA.Model.Attributes.FormTransformation(typeof(IContactExt), "Yambr.ELMA.Email.Models.ContactExt.Form.Display.xml")]
    [global::EleWise.ELMA.Model.Attributes.TableView("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<TableView xmlns:xsi=\"http://www.w3.org/2" +
        "001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Uid>b4" +
        "7df5a3-2b07-4a3e-9ae5-562e660503ca</Uid>\r\n  <ViewType>List</ViewType>\r\n</TableVi" +
        "ew>")]
    [global::EleWise.ELMA.Model.Attributes.Entity("ContactExt")]
    [global::EleWise.ELMA.Model.Attributes.IdType("d90a59af-7e47-48c5-8c4c-dad04834e6e3")]
    [global::EleWise.ELMA.Model.Attributes.ShowInCatalogList(false)]
    [global::EleWise.ELMA.Model.Attributes.EntityMetadataType(global::EleWise.ELMA.Model.Metadata.EntityMetadataType.InterfaceExtension)]
    [global::EleWise.ELMA.Model.Attributes.ActionsType(typeof(ContactExtActions))]
    public partial interface IContactExt : global::EleWise.ELMA.CRM.Models.IContact
    {
    }
    
    internal class @__Resources_IContactExt
    {
        
        public static string DisplayName
        {
            get
            {
                return global::EleWise.ELMA.SR.T("ContactExt");
            }
        }
        
        private static string @__AllFormsResources
        {
            get
            {
                return global::EleWise.ELMA.SR.T("История переписки");
            }
        }
    }
}
#pragma warning restore 108,114,162
