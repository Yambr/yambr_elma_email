// EleWise.ELMA.EmailMessages.FullTextSearch.Components.EmailMessagesFullTextSearchExtension

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using EleWise.ELMA;
using EleWise.ELMA.Common.Models;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.CRM.Models;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.FullTextSearch.Components;
using EleWise.ELMA.FullTextSearch.Enum;
using EleWise.ELMA.FullTextSearch.Exceptions;
using EleWise.ELMA.FullTextSearch.Model;
using EleWise.ELMA.FullTextSearch.Services;
using EleWise.ELMA.Model.Common;
using EleWise.ELMA.Model.Entities;
using EleWise.ELMA.Model.Filters;
using EleWise.ELMA.Model.Metadata;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Runtime.Db.Migrator.Framework;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Runtime.Settings;
using EleWise.ELMA.Security;
using EleWise.ELMA.Services;
using NHibernate;
using NHibernate.Criterion;
using Yambr.ELMA.Email.FullTextSearch.Model;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Models;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email.FullTextSearch.Components
{
    /// <summary>
    /// Реализация расширения работы с карточкой объекта для модуля документов
    /// </summary>
    [Component]
    internal class EmailMessagesFullTextSearchExtension : ModuleFullTextSearchExtension
    {
       
        private EmailMessageManager _emailMessageManager;

        private ISecurityService _securityService;

        private ITransformationProvider _transformationProvider;

        private ISessionProvider _sessionProvider;

        private IFullTextSearchDescriptorService _fullTextSearchDescriptorService;

        /// <summary>
        /// Uid карточки документа
        /// </summary>
        public static Guid EmailMessageCardUid = Guid.Parse("{0FF46688-7697-4256-ABD4-9A48EF206BDF}");
        
        private EmailMessageManager EmailMessageManager => _emailMessageManager ?? (_emailMessageManager = Locator.GetServiceNotNull<EmailMessageManager>());

        private ISecurityService SecurityService => _securityService ?? (_securityService = Locator.GetServiceNotNull<ISecurityService>());

        private ITransformationProvider TransformationProvider => _transformationProvider ?? (_transformationProvider = Locator.GetServiceNotNull<ITransformationProvider>());

        private ISessionProvider SessionProvider => _sessionProvider ?? (_sessionProvider = Locator.GetServiceNotNull<ISessionProvider>());

        private IFullTextSearchDescriptorService FullTextSearchDescriptorService => _fullTextSearchDescriptorService ?? (_fullTextSearchDescriptorService = Locator.GetServiceNotNull<IFullTextSearchDescriptorService>());

        public override IGlobalSettingsModule SettingModule => Locator.GetService<EmailFullTextSearchSettingsModule>();

        public override Dictionary<string, string> GetReverseMapping(Type cardType)
        {
            var dictionary = new Dictionary<string, string>();
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                dictionary.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject), SR.T("Тема"));
                dictionary.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Text), SR.T("Тело"));
            }
            return dictionary;
        }

        public override Dictionary<string, long> GetHighlightsOrder(Type cardType)
        {
            var dictionary = new Dictionary<string, long>();
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                dictionary.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject), 100L);
                dictionary.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Text), 200L);
            }
            return dictionary;
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
            return cardType == typeof(IEmailMessageFullTextSearchObject) ? (Guid?) EmailMessageCardUid : null;
        }

        public override Type GetSupportedCardTypeByTypeUid(Guid objectTypeUid)
        {
            var emailFullTextSearchSettingsModule = SettingModule as EmailFullTextSearchSettingsModule;
            if (emailFullTextSearchSettingsModule?.Settings == null || !emailFullTextSearchSettingsModule.Settings.IndexingEmail)
            {
                return null;
            }
            var classMetadata = (ClassMetadata)MetadataLoader.LoadMetadata(objectTypeUid);
            var emailUid = InterfaceActivator.UID<IEmailMessage>();
            if (classMetadata != null && (classMetadata.Uid == emailUid || MetadataLoader.GetBaseClasses(classMetadata).Any(delegate (ClassMetadata m)
            {
                if (m != null)
                {
                    return m.Uid == emailUid;
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
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                var list2 = new List<string>();
                list2.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject));
                list2.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Text));
                return list2;
            }
            return new List<string>();
        }

        public override List<string> GetFields(Type cardType)
        {
            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<string>();
            var fields = base.GetFields(cardType);
            fields.AddRange(new List<string>
            {
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Text),
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject),
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.From),
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.To),
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Owners),
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Contractors),
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Contacts)
            });
            return fields;
        }

        public override List<string> GetSearchFields(Type cardType)
        {
            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<string>();
            var searchFields = base.GetSearchFields(cardType);

            searchFields.AddRange(new List<string>
            {
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject),
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Text)
            });

            return searchFields;
        }

        public override List<string> GetSearchFields(Type cardType, IEntityFilter filter)
        {
            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<string>();
            var searchFields = base.GetSearchFields(cardType);
            searchFields.AddRange(new List<string>
            {
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject),
                LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Text)
            });
                
            return searchFields;
        }

        public override Dictionary<string, Weight> GetWeightSearchFields(Type cardType)
        {
            var dictionary = new Dictionary<string, Weight>();
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                dictionary.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject), Weight.High);
                dictionary.Add(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Text), Weight.Medium);
            }
            return dictionary;
        }

        public override FilterList GetFilterFields(Type cardType, FullTextSearchResultModel searchModel)
        {
            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new FilterList();
            var filterList = new FilterList();
            var emailMessageFullTextSearchResultModel = searchModel as EmailMessageFullTextSearchResultModel;
            if (emailMessageFullTextSearchResultModel != null && emailMessageFullTextSearchResultModel.TypeUid != Guid.Empty)
            {
                var classMetadata = MetadataLoader.LoadMetadata(emailMessageFullTextSearchResultModel.TypeUid) as ClassMetadata;
                if (classMetadata != null)
                {
                    var list = (from c in MetadataLoader.GetChildClasses(classMetadata)
                        where c != null
                        select c).ToList();
                    list.Add(classMetadata);
                    var list2 = new List<object>();
                    list2.AddRange(from c in list
                        select c.Uid.ToString("n"));
                    filterList.Add(new FilterListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.TypeUid), list2, FilterListItemType.Must, FullTextFieldType.String));
                }
            }

            var emailMessageFullTextSearchResultModel2 = searchModel as EmailMessageFullTextSearchResultModel;
            if (emailMessageFullTextSearchResultModel2?.Contractor != null)
            {
               var contractorId = emailMessageFullTextSearchResultModel2.Contractor.Id;
                filterList.Add(new FilterListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Contractors), new List<object>()
                {
                    contractorId
                }, FilterListItemType.Must, FullTextFieldType.Long));
            }
            if (emailMessageFullTextSearchResultModel2?.Contact != null)
            {
                var contactId = emailMessageFullTextSearchResultModel2.Contact.Id;
                filterList.Add(new FilterListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Contacts), new List<object>()
                {
                    contactId
                }, FilterListItemType.Must, FullTextFieldType.Long));
            }

            filterList.Add(new FilterListItem(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.IsDeleted), new List<object>
            {
                "false"
            }, FilterListItemType.Must, FullTextFieldType.String));

            return filterList;
        }

     

        public override FilterList GetAutoFilterFields(Type cardType, FilterProperty filterProperty, FullTextSearchResultModel searchModel)
        {
            return null;
        }

        public override void FillObject(Type cardType, IFullTextSearchObject obj, IEntity entity)
        {
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                SecurityService.RunBySystemUser(delegate
                {
                    SecurityService.RunWithElevatedPrivilegies(delegate
                    {
                        var emailMessage = entity as IEmailMessage;
                        if (emailMessage != null)
                        {
                            var emailMessagesFullTextSearchObject = obj as IEmailMessageFullTextSearchObject;
                            if (emailMessagesFullTextSearchObject != null)
                            {
                                emailMessagesFullTextSearchObject.IndexedObject = emailMessage;
                                emailMessagesFullTextSearchObject.Id = emailMessage.Id.ToString(CultureInfo.InvariantCulture);
                                emailMessagesFullTextSearchObject.Subject = emailMessage.Subject;
                              
                                    emailMessagesFullTextSearchObject.Text = emailMessage.Text;
                                

                                emailMessagesFullTextSearchObject.From =
                                    emailMessage.From.Select(c => c.EmailString).ToArray();
                                emailMessagesFullTextSearchObject.To =
                                    emailMessage.To.Select(c => c.EmailString).ToArray();
                                emailMessagesFullTextSearchObject.Owners =
                                    emailMessage.Owners.Select(c => c.EmailLogin).ToArray();
                                emailMessagesFullTextSearchObject.Contacts = emailMessage.Contacts.Select(c => c.Id).ToArray();
                                emailMessagesFullTextSearchObject.Contractors = emailMessage.Contractors.Select(c => c.Id).ToArray();
                                emailMessagesFullTextSearchObject.DateUtc = emailMessage.DateUtc;
                                emailMessagesFullTextSearchObject.TypeUid = emailMessage.TypeUid.ToString("n");
                                emailMessagesFullTextSearchObject.IsDeleted = emailMessage.IsDeleted;
                              /*  if (emailMessage.Permissions.Any())
                                {
                                    emailMessagesFullTextSearchObject.UserSecuritySetCacheId = (from p in (from a in emailMessage.Permissions
                                            where a.PermissionId == EleWise.ELMA.EmailMessages.PermissionProvider.EmailMessageViewPermission.Id
                                            select a).Distinct()
                                        select p.UserSecuritySetCacheId.ToString()).ToArray();
                                }
                                */
                                ProcessingDynamicProperties(entity, emailMessagesFullTextSearchObject);
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
            SecurityService.RunBySystemUser(delegate
            {
                SecurityService.RunWithElevatedPrivilegies(delegate
                {
                    foreach (var item in listUid)
                    {
                        var emailMessage = EmailMessageManager.LoadOrNull(item);
                        if (emailMessage != null)
                        {
                            list.Add(emailMessage);
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
            SecurityService.RunBySystemUser(delegate
            {
                SecurityService.RunWithElevatedPrivilegies(delegate
                {
                    foreach (var item in listId)
                    {
                        var emailMessage = EmailMessageManager.LoadOrNull(item);
                        if (emailMessage != null)
                        {
                            list.Add(emailMessage);
                        }
                    }
                });
            });
            return list;
        }

        public override List<IEntity> LoadEntitiesByPage(Type cardType, int page, List<Guid> typeUidFilter = null)
        {
            List<IEntity> result = null;
            TransformationProvider.ExecuteWithTimeout(0, delegate
            {
                result = LoadEntities(cardType, c => c.SetFirstResult(page * GetPageSize()), typeUidFilter);
            });
            return result;
        }

        public override List<IEntity> LoadEntities(Type cardType, long? lastId, List<Guid> typeUidFilter = null)
        {
            return LoadEntities(cardType, c => !lastId.HasValue ? c : c.Add(Restrictions.Gt("Id", lastId)), typeUidFilter);
        }

        protected virtual List<IEntity> LoadEntities(Type cardType, Func<ICriteria, ICriteria> criteriaAction, List<Guid> typeUidFilter)
        {
            var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
            if (serviceNotNull.Settings == null || !serviceNotNull.Settings.IndexingEmail)
            {
                return new List<IEntity>();
            }

            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType) return new List<IEntity>();
            var list = new List<IEntity>();
            SecurityService.RunBySystemUser(delegate
            {
                SecurityService.RunWithElevatedPrivilegies(delegate
                {
                    var session = SessionProvider.GetSession("");
                    var source = criteriaAction(session.CreateCriteria(InterfaceActivator.TypeOf<IEmailMessage>()).AddOrder(Order.Asc("Id")).SetMaxResults(GetPageSize())).List().Cast<IEntity>();
                    (from d in source
                        where d != null
                        select d).ForEach(list.Add);
                });
            });
            return list;
        }

        public override FullTextSearchResultModel CreateResultModelByFilter(IEntityFilter filter)
        {
            var emailMessageFullTextSearchResultModel = new EmailMessageFullTextSearchResultModel();
            SetFilterTypeUid(emailMessageFullTextSearchResultModel, filter);
            return emailMessageFullTextSearchResultModel;
        }

        public override SortList GetDefaultSortExpression()
        {
            var propMd = InterfaceActivator.LoadPropertyMetadata((IEmailMessage m) => m.DateUtc) as EntityPropertyMetadata;
            var sortField = FullTextSearchDescriptorService.GetSortField(propMd);
            if (sortField == null)
            {
                throw new FullTextFilterException(SR.T("{1}: Поле \"{0}\" не поддерживает сортировку", "SortTypeId", "Dynamic Indexing Error"));
            }
            sortField.Direction = ListSortDirection.Descending;
            var sortList = new SortList {sortField};
            return sortList;
        }

        public override List<KeyValuePair<string, object>> CreateFromObject(Type cardType, IFullTextSearchObject obj)
        {
            if (cardType != null && typeof(IEmailMessageFullTextSearchObject) == cardType)
            {
                var emailMessagesFullTextSearchObject = obj as IEmailMessageFullTextSearchObject;
                if (emailMessagesFullTextSearchObject != null)
                {
                    var list = WebData.CreateFromObject(obj).ToKeyValueList().ToList();
                    return list;
                }
            }
            return new List<KeyValuePair<string, object>>();
        }

        public override void ReconstructEntity(Type cardType, IFullTextSearchResultItem resultItem, IEntity<long> fakeEntity)
        {
            if (cardType == null || typeof(IEmailMessageFullTextSearchObject) != cardType ||
                resultItem?.ResultData == null || fakeEntity == null) return;
            if (!(fakeEntity is IEmailMessage dmsObject)) return;
            var webDataItem = resultItem.ResultData.Items.FirstOrDefault(i => i.Name == LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject));
            if (webDataItem != null)
            {
                dmsObject.Subject = webDataItem.Value;
            }
        }
    }
}
