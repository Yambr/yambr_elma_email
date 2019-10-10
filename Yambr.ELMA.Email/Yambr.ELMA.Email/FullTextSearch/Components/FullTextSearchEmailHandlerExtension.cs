// EleWise.ELMA.EmailMessages.FullTextSearch.Components.FullTextSearchDmsObjectHandlerExtension

using System;
using System.Collections.Generic;
using System.Linq;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.FullTextSearch.ExtensionPoints;
using EleWise.ELMA.FullTextSearch.Model;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Serialization;
using EleWise.ELMA.Services;
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
    public class FullTextSearchDmsObjectHandlerExtension : FullTextSearchObjectHandlerExtension
    {

        private EmailMessageManager _emailMessageManager;

        private readonly List<string> _importantProperties = new List<string>
        {
            LinqUtils.NameOf((IEmailMessage d) => d.Id),
            LinqUtils.NameOf((IEmailMessage d) => d.Subject),
            LinqUtils.NameOf((IEmailMessage d) => d.DateUtc),
            LinqUtils.NameOf((IEmailMessage d) => d.From),
            LinqUtils.NameOf((IEmailMessage d) => d.To),
            LinqUtils.NameOf((IEmailMessage d) => d.Owners),
            LinqUtils.NameOf((IEmailMessage d) => d.IsDeleted)
        };

        private readonly List<string> _visualDataProperties = new List<string>
        {
            LinqUtils.NameOf((IEmailMessage d) => d.Subject),
            LinqUtils.NameOf((IEmailMessage d) => d.IsDeleted)
        };

        /// <summary>
        /// <see cref="T:EmailMessageManager" />
        /// </summary>
        public EmailMessageManager EmailMessageManager => _emailMessageManager ?? (_emailMessageManager = Locator.GetServiceNotNull<EmailMessageManager>());


        /// <inheritdoc />
        public override Guid Uid { get; } = new Guid("{326BA0AE-FAC1-44AB-AA07-F32ECDECEAC0}");

        /// <inheritdoc />
        public override Type SupportedCard => typeof(IEmailMessageFullTextSearchObject);

        /// <inheritdoc />
        public override List<Guid> SupportedUids { get; } = new List<Guid>
        {
            InterfaceActivator.UID<IEmailMessage>()
        };

        /// <inheritdoc />
        public override List<string> GetImportantProperties
        {
            get
            {
                var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
                if (serviceNotNull.Settings == null || !serviceNotNull.Settings.IndexingEmail)
                {
                    return new List<string>();
                }
                return _importantProperties;
            }
        }

        /// <inheritdoc />
        public override List<string> GetVisualDataProperties
        {
            get
            {
                var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
                if (serviceNotNull.Settings == null || !serviceNotNull.Settings.IndexingEmail)
                {
                    return new List<string>();
                }
                return _visualDataProperties;
            }
        }

        /// <inheritdoc />
        public override List<QueueToIndex> ProcessingMergedIndexQueue(List<KeyValuePair<string, object>> mergedIndexQueueItem, long id, Guid typeUid)
        {
            var list = new List<QueueToIndex>();
            if (mergedIndexQueueItem == null) return list;
            var queueToIndex = new QueueToIndex
            {
                Id = id,
                CardType = typeof(IEmailMessageFullTextSearchObject),
                Properties = new List<KeyValuePair<string, object>>()
            };
           
            var idPair = mergedIndexQueueItem.Find(
                p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.Id)));
            if (idPair.Key != null)
            {
                queueToIndex.Properties.Add(
                    new KeyValuePair<string, object>(
                        LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Id), 
                        idPair.Value));
            }
            var typeUidPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.TypeUid)));
            if (typeUidPair.Key != null)
            {
                queueToIndex.Properties.Add(
                    new KeyValuePair<string, object>(
                        LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.TypeUid),
                        typeUidPair.Value));
            }
            var deletedPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.IsDeleted)));
            if (deletedPair.Key != null)
            {
                queueToIndex.Properties.Add(
                    new KeyValuePair<string, object>(
                        LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.IsDeleted), deletedPair.Value));
            }
            var datePair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.DateUtc)));
            if (datePair.Key != null)
            {
                queueToIndex.Properties.Add(
                    new KeyValuePair<string, object>(LinqUtils.NameOf(
                            (IEmailMessageFullTextSearchObject d) => d.DateUtc),
                        datePair.Value));
            }
            var subjectPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.Subject)));
            if (subjectPair.Key != null)
            {
                queueToIndex.Properties.Add(
                    new KeyValuePair<string, object>(LinqUtils.NameOf(
                            (IEmailMessageFullTextSearchObject d) => d.Subject),
                        subjectPair.Value));
            }
            var textPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.Text)));
            if (textPair.Key != null)
            {
                if (textPair.Value != null)
                {
                    var textPairValue = textPair.Value.ToString();
                    queueToIndex.Properties.Add(
                        new KeyValuePair<string, object>(LinqUtils.NameOf(
                                (IEmailMessageFullTextSearchObject d) => d.Text),
                            textPairValue));
                }
            }

            var fromPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.From)));
            var toPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.To)));
            if (toPair.Key != null || fromPair.Key!=null)
            {
                var emailMessage = EmailMessageManager.LoadOrNull(id);
                if (emailMessage != null)
                {
                    var  from =
                        emailMessage.From.Select(c => c.EmailString).ToArray();
                    var to =
                        emailMessage.To.Select(c => c.EmailString).ToArray();
                    queueToIndex.Properties.Add(
                        new KeyValuePair<string, object>(LinqUtils.NameOf(
                            (IEmailMessageFullTextSearchObject d) => d.From), 
                            new SerializableList<object>(from)));
                    queueToIndex.Properties.Add(
                        new KeyValuePair<string, object>(LinqUtils.NameOf(
                                (IEmailMessageFullTextSearchObject d) => d.To),
                            new SerializableList<object>(to)));
                    queueToIndex.Properties.Add(
                        new KeyValuePair<string, object>(LinqUtils.NameOf(
                                (IEmailMessageFullTextSearchObject d) => d.Contractors),
                            new SerializableList<long>(emailMessage.Contractors.Select(c=>c.Id).ToArray())));
                    queueToIndex.Properties.Add(
                        new KeyValuePair<string, object>(LinqUtils.NameOf(
                                (IEmailMessageFullTextSearchObject d) => d.Contacts),
                            new SerializableList<long>(emailMessage.Contacts.Select(c => c.Id).ToArray())));
                }

                var ownersPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.Owners)));
                if (ownersPair.Value is ISet<IUserMailbox> ownersPairValue)
                {
                    var owners = new SerializableList<object>(ownersPairValue.Select(c => c.EmailLogin));
                    queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Owners), owners));
                }
            }

            queueToIndex.DynamicProperties.AddRange((from i in mergedIndexQueueItem
                select i.Value).OfType<FieldIndexListItem>());
            if (queueToIndex.Properties.Any() || queueToIndex.DynamicProperties.Any())
            {
                list.Add(queueToIndex);
            }
            return list;
        }
    }
}
