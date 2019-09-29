// EleWise.ELMA.Email.FullTextSearch.Components.EmailMessageFullTextSearchExtension

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using EleWise.ELMA.Common.Models;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.FullTextSearch.Components;
using EleWise.ELMA.FullTextSearch.Enum;
using EleWise.ELMA.FullTextSearch.Model;
using EleWise.ELMA.Model.Common;
using EleWise.ELMA.Model.Entities;
using EleWise.ELMA.Model.Filters;
using EleWise.ELMA.Model.Metadata;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Runtime.Settings;
using EleWise.ELMA.Security;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.FullTextSearch.Model;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.FullTextSearch.Components
{
    /// <summary>
    /// Реализация расширения работы с карточкой объекта для контрагента
    /// </summary>
    [Component]
    internal class EmailMessageFullTextSearchExtension : ModuleFullTextSearchExtension
    {
        /// <summary>
        /// Uid карточки
        /// </summary>
        public static Guid EmailMessageCardUid = Guid.Parse("{5D774228-6BDD-44B1-BEB0-493B45EC9E55}");
        public static Guid SearchStringFilterPropertyUid = Guid.Parse("{f11a7510-56c7-309c-dbf0-5b82ff71b669}");

        public override IGlobalSettingsModule SettingModule => Locator.GetService<EmailFullTextSearchSettingsModule>();

        public override Dictionary<string, string> GetReverseMapping(Type cardType)
        {
            return new Dictionary<string, string>();
        }

        public override Dictionary<string, long> GetHighlightsOrder(Type cardType)
        {
            return new Dictionary<string, long>();
        }

        public override List<KeyValuePair<Type, Guid>> GetSupportedCardTypes(bool checkSettings = true)
        {
            if (checkSettings)
            {
                var emailFullTextSearchSettingsModule = SettingModule as EmailFullTextSearchSettingsModule;
                if (emailFullTextSearchSettingsModule?.Settings == null || !emailFullTextSearchSettingsModule.Settings.IndexingEmail)
                {
                    return new List<KeyValuePair<Type, Guid>>();
                }
            }

            var list = new List<KeyValuePair<Type, Guid>>
            {
                new KeyValuePair<Type, Guid>(typeof(IEmailMessageFullTextSearchObject), EmailMessageCardUid)
            };
            return list;
        }

        public override Type GetSupportedCardType(Guid cardUid)
        {
            return cardUid.Equals(EmailMessageCardUid) ? typeof(IEmailMessageFullTextSearchObject) : null;
        }

        public override Guid? GetSupportedCardType(Type cardType)
        {
            if (cardType == typeof(IEmailMessageFullTextSearchObject))
            {
                return EmailMessageCardUid;
            }
            return null;
        }

        public override Type GetSupportedCardTypeByTypeUid(Guid objectTypeUid)
        {
            var emailFullTextSearchSettingsModule = SettingModule as EmailFullTextSearchSettingsModule;
            if (emailFullTextSearchSettingsModule?.Settings == null || !emailFullTextSearchSettingsModule.Settings.IndexingEmail)
            {
                return null;
            }
            var classMetadata = (ClassMetadata)MetadataLoader.LoadMetadata(objectTypeUid);
            var uid = InterfaceActivator.UID<IEmailMessage>();
            if (classMetadata != null && (classMetadata.Uid == uid || MetadataLoader.GetBaseClasses(classMetadata).Any(delegate (ClassMetadata m)
            {
                if (m != null)
                {
                    return m.Uid == uid;
                }
                return false;
            })))
            {
                return typeof(IEmailMessageFullTextSearchObject);
            }
            return null;
        }

        public override Type GetSupportedCardTypeByObject(object obj)
        {
            var emailFullTextSearchSettingsModule = SettingModule as EmailFullTextSearchSettingsModule;
            if (emailFullTextSearchSettingsModule?.Settings == null || !emailFullTextSearchSettingsModule.Settings.IndexingEmail)
            {
                return null;
            }
            return obj is IEmailMessage ? typeof(IEmailMessageFullTextSearchObject) : null;
        }

        public override Dictionary<Type, Dictionary<Guid, List<string>>> GetDynamicFieldsMapping()
        {
            var classMd = (ClassMetadata)MetadataLoader.LoadMetadata(typeof(IEmailMessage));
            var value = ProcessingDynamicFieldsMapping(classMd);
            var dictionary = new Dictionary<Type, Dictionary<Guid, List<string>>>
            {
                {typeof(IEmailMessageFullTextSearchObject), value}
            };
            return dictionary;
        }

        public override List<string> GetHighlightFields(Type cardType)
        {
            return new List<string>();
        }

        public override List<string> GetFields(Type cardType)
        {
            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<string>();
            var fields = base.GetFields(cardType);
            fields.AddRange(new List<string>
            {
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject)
            });
            fields.AddRange(new List<string>
            {
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.SearchString)
            });
            return fields;
        }

        public override List<string> GetSearchFields(Type cardType)
        {
            return GetSearchFields(cardType, null);
        }

        public override List<string> GetSearchFields(Type cardType, IEntityFilter filter)
        {
            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<string>();
            var searchFields = base.GetSearchFields(cardType);
            var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
            if (serviceNotNull.Settings != null ||
                filter != null && !filter.FullTextInAttachments)
            {
                searchFields.AddRange(new List<string>
                {
                    
                    LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.SearchString),
                    LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject),
                    LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.From),
                    LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.To),
                    LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Body),
                    LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Owners)
                });
            }

            return searchFields;
        }

        public override FilterList GetFilterFields(Type cardType, FullTextSearchResultModel searchModel)
        {
            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new FilterList();
            var filterList = new FilterList
            {
                new FilterListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.IsDeleted),
                    new List<object> {"false"}, FilterListItemType.Must, FullTextFieldType.String)
            };
            return filterList;
        }


        public override FieldList GetCustomSearchFields(Type cardType, FilterProperty filterProperty)
        {
            var customSearchFields = base.GetCustomSearchFields(cardType, filterProperty);
            if (customSearchFields != null)
            {
                return customSearchFields;
            }

            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType ||
                filterProperty == null) return null;

            
            if (SearchStringFilterPropertyUid == filterProperty.Uid)
            {
                if (filterProperty.Value == null)
                {
                    return new FieldList();
                }
                var value = filterProperty.Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    return new FieldList();
                }

                var fieldList = new FieldList
                {
                    new FieldListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.SearchString), value)
                };
                return fieldList;
            }

            if (InterfaceActivator.LoadPropertyMetadata((IEmailMessageFilter m) => m.From).Uid == filterProperty.Uid)
            {
                if (filterProperty.Value == null)
                {
                    return new FieldList();
                }
                var value = filterProperty.Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    return new FieldList();
                }

                var fieldList = new FieldList
                {
                    new FieldListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.From), value)
                };
                return fieldList;
            }

            if (InterfaceActivator.LoadPropertyMetadata((IEmailMessageFilter m) => m.To).Uid == filterProperty.Uid)
            {
                if (filterProperty.Value == null)
                {
                    return new FieldList();
                }
                var value = filterProperty.Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    return new FieldList();
                }

                var fieldList = new FieldList
                {
                    new FieldListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.To), value)
                };
                return fieldList;
            }
            if (InterfaceActivator.LoadPropertyMetadata((IEmailMessageFilter m) => m.Owners).Uid == filterProperty.Uid)
            {
                if (filterProperty.Value == null)
                {
                    return new FieldList();
                }
                var value = filterProperty.Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    return new FieldList();
                }

                var fieldList = new FieldList
                {
                    new FieldListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Owners), value)
                };
                return fieldList;
            }
            return null;
        }
        
        public override void FillObject(Type cardType, IFullTextSearchObject obj, IEntity entity)
        {
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                Locator.GetServiceNotNull<ISecurityService>().RunBySystemUser(delegate
                {
                    Locator.GetServiceNotNull<ISecurityService>().RunWithElevatedPrivilegies(delegate
                    {
                        var emailMessage = entity as IEmailMessage;
                        if (emailMessage != null)
                        {
                            var emailMessageFullTextSearchObject = obj as IEmailMessageFullTextSearchObject;
                            if (emailMessageFullTextSearchObject != null)
                            {
                                emailMessageFullTextSearchObject.IndexedObject = emailMessage;
                                emailMessageFullTextSearchObject.Id = emailMessage.Id.ToString(CultureInfo.InvariantCulture);
                                emailMessageFullTextSearchObject.Subject = emailMessage.Subject;
                                emailMessageFullTextSearchObject.IsDeleted = emailMessage.IsDeleted;
                                emailMessageFullTextSearchObject.Body = FullTextSearchEmailHandlerExtension.ConvertToPlainText(emailMessage.Body);
                                emailMessageFullTextSearchObject.From = 
                                    emailMessage.From != null ? 
                                        emailMessage.From
                                            .Where(e => !string.IsNullOrEmpty(e?.EmailString))
                                            .Select(e => e.EmailString).ToArray() : 
                                        new string[0];
                                emailMessageFullTextSearchObject.To =
                                    emailMessage.To != null ?
                                        emailMessage.To
                                            .Where(e => !string.IsNullOrEmpty(e?.EmailString))
                                            .Select(e => e.EmailString).ToArray() :
                                        new string[0];
                                emailMessageFullTextSearchObject.Owners =
                                    emailMessage.Owners != null ?
                                        emailMessage.Owners
                                            .Where(e => !string.IsNullOrEmpty(e?.EmailLogin))
                                            .Select(e => e.EmailLogin).ToArray() :
                                        new string[0];
                                emailMessageFullTextSearchObject.SearchString = FullTextSearchEmailHandlerExtension.BuildSearchString(emailMessageFullTextSearchObject);

                                ProcessingDynamicProperties(entity, emailMessageFullTextSearchObject);
                            }
                        }
                    });
                });
            }
        }

       
        public override List<IEntity> GetEntities(Type cardType, List<Guid> listUid)
        {
            var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
            if (serviceNotNull.Settings == null || !serviceNotNull.Settings.IndexingEmail)
            {
                return new List<IEntity>();
            }

            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<IEntity>();
            var list = new List<IEntity>();
            Locator.GetServiceNotNull<ISecurityService>().RunBySystemUser(delegate
            {
                Locator.GetServiceNotNull<ISecurityService>().RunWithElevatedPrivilegies(delegate
                {
                    foreach (var item in listUid)
                    {
                        var contractor = EmailMessageManager.Instance.LoadOrNull(item);
                        if (contractor != null)
                        {
                            list.Add(contractor);
                        }
                    }
                });
            });
            return list;
        }

        public override List<IEntity> GetEntities(Type cardType, List<long> listId)
        {
            var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
            if (serviceNotNull.Settings == null || !serviceNotNull.Settings.IndexingEmail)
            {
                return new List<IEntity>();
            }

            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<IEntity>();
            var list = new List<IEntity>();
            Locator.GetServiceNotNull<ISecurityService>().RunBySystemUser(delegate
            {
                Locator.GetServiceNotNull<ISecurityService>().RunWithElevatedPrivilegies(delegate
                {
                    foreach (var item in listId)
                    {
                        var contractor = EmailMessageManager.Instance.LoadOrNull(item);
                        if (contractor != null)
                        {
                            list.Add(contractor);
                        }
                    }
                });
            });
            return list;
        }

        public override List<IEntity> LoadEntitiesByPage(Type cardType, int page, List<Guid> typeUidFilter = null)
        {
            return LoadEntities(cardType, delegate
            {
                var pageSize = GetPageSize();
                var fetchOptions = new FetchOptions
                {
                    MaxResults = pageSize,
                    FirstResult = page * pageSize,
                    SortExpression = "Id"
                };
                return EmailMessageManager.Instance.Find(fetchOptions).Cast<IEntity>().ToList();
            }, typeUidFilter);
        }

        public override List<IEntity> LoadEntities(Type cardType, long? lastId, List<Guid> typeUidFilter = null)
        {
            return LoadEntities(cardType, delegate
            {
                var fetchOptions = new FetchOptions
                {
                    MaxResults = GetPageSize(),
                    SortExpression = "Id"
                };
                return EmailMessageManager.Instance.Find(lastId.HasValue ? new Filter
                {
                    Query = "Id > " + lastId
                } : null, fetchOptions).Cast<IEntity>().ToList();
            }, typeUidFilter);
        }

        protected virtual List<IEntity> LoadEntities(Type cardType, Func<List<IEntity>> find, List<Guid> typeUidFilter)
        {
            var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
            if (serviceNotNull.Settings == null || !serviceNotNull.Settings.IndexingEmail)
            {
                return new List<IEntity>();
            }

            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<IEntity>();
            var securityService = Locator.GetServiceNotNull<ISecurityService>();
            List<IEntity> list = null;
            securityService.RunBySystemUser(delegate
            {
                securityService.RunWithElevatedPrivilegies(delegate
                {
                    list = find();
                });
            });
            return list;
        }

        public override FullTextSearchResultModel CreateResultModelByFilter(IEntityFilter filter)
        {
            var contractorFullTextSearchResultModel = new EmailMessageFullTextSearchResultModel();
            SetFilterTypeUid(contractorFullTextSearchResultModel, filter);
            return contractorFullTextSearchResultModel;
        }

        public override List<KeyValuePair<string, object>> CreateFromObject(Type cardType, IFullTextSearchObject obj)
        {
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                var contractorFullTextSearchObject = obj as IEmailMessageFullTextSearchObject;
                if (contractorFullTextSearchObject == null) return new List<KeyValuePair<string, object>>();
                var list = WebData.CreateFromObject(obj).ToKeyValueList().ToList();
                return list;
            }
            return new List<KeyValuePair<string, object>>();
        }

        public override Dictionary<string, Weight> GetWeightSearchFields(Type cardType)
        {
            var dictionary = new Dictionary<string, Weight>();
            if (cardType != (Type)null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                dictionary.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.SearchString), Weight.High);
            }
            return dictionary;
        }

        public override void ReconstructEntity(Type cardType, IFullTextSearchResultItem resultItem, IEntity<long> fakeEntity)
        {
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType && resultItem != null && resultItem.ResultData != null && fakeEntity != null)
            {
                var emailMessage = fakeEntity as IEmailMessage;
                if (emailMessage != null)
                {
                    var webDataItem = resultItem.ResultData.Items.FirstOrDefault(i => i.Name == LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject));
                    if (webDataItem != null)
                    {
                        emailMessage.Subject = webDataItem.Value;
                    }
                    var webDataItem2 = resultItem.ResultData.Items.FirstOrDefault(i => i.Name == LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Body));
                    if (webDataItem2 != null)
                    {
                        emailMessage.Body = webDataItem2.Value;
                    }
                }
            }
        }
    }
}
