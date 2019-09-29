using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.FullTextSearch.ExtensionPoints;
using EleWise.ELMA.FullTextSearch.Model;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Serialization;
using EleWise.ELMA.Services;
using HtmlAgilityPack;
using Yambr.ELMA.Email.FullTextSearch.Model;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.FullTextSearch.Components
{
    /// <summary>
    /// Реализация расширения работы с карточкой контрагента для модуля 
    /// </summary>
    [Component]
    public class FullTextSearchEmailHandlerExtension : FullTextSearchObjectHandlerExtension
    {

        public override Guid Uid => new Guid("{5EF5524B-4265-4604-8E26-9F23A48E8DDE}");
        public override Type SupportedCard => typeof(IEmailMessageFullTextSearchObject);

        public override List<Guid> SupportedUids => new List<Guid>
        {
            InterfaceActivator.UID<IEmailMessage>()
        };

        public override List<string> GetImportantProperties
        {
            get
            {
                var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
                if (serviceNotNull.Settings == null || !serviceNotNull.Settings.IndexingEmail)
                {
                    return new List<string>();
                }

                return new List<string>
                {
                    LinqUtils.NameOf((IEmailMessage d) => d.Id),
                    LinqUtils.NameOf((IEmailMessage d) => d.Subject),
                    LinqUtils.NameOf((IEmailMessage d) => d.From),
                    LinqUtils.NameOf((IEmailMessage d) => d.To),
                    LinqUtils.NameOf((IEmailMessage d) => d.Owners),
                    LinqUtils.NameOf((IEmailMessage d) => d.Body),
                    LinqUtils.NameOf((IEmailMessage d) => d.IsDeleted),
                };
            }
        }

        public override List<string> GetVisualDataProperties
        {
            get
            {
                var serviceNotNull = Locator.GetServiceNotNull<EmailFullTextSearchSettingsModule>();
                if (serviceNotNull.Settings == null || !serviceNotNull.Settings.IndexingEmail)
                {
                    return new List<string>();
                }

                return new List<string>
                {
                    LinqUtils.NameOf((IEmailMessage d) => d.Name),
                    LinqUtils.NameOf((IEmailMessage d) => d.IsDeleted)
                };
            }
        }

        public override List<QueueToIndex> ProcessingMergedIndexQueue(List<KeyValuePair<string, object>> mergedIndexQueueItem, long id, Guid typeUid)
        {
            var list = new List<QueueToIndex>();
            if (mergedIndexQueueItem == null) return list;
            IEmailMessage emailMessage = null;
            var queueToIndex = new QueueToIndex
            {
                Id = id,
                CardType = typeof(IEmailMessageFullTextSearchObject),
                Properties = new List<KeyValuePair<string, object>>()
            };

            var idPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.Id)));
            if (idPair.Key != null)
            {
                queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Id), idPair.Value));
            }
            var subjectPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.Subject)));
            if (subjectPair.Key != null)
            {
                queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Subject), subjectPair.Value));
            }

            var bodyPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.Body)));
            if (bodyPair.Key != null)
            {
                var plainText = ConvertToPlainText(bodyPair.Value?.ToString());
                queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Body), plainText));
            }
            if (mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.From))).Key != null)
            {
                if (emailMessage == null)
                {
                    emailMessage = EmailMessageManager.Instance.LoadOrNull(id);
                }
                if (emailMessage != null)
                {
                    var value = emailMessage.From != null ?
                        new SerializableList<object>(emailMessage.From.Where(delegate (IEmailMessageParticipant e)
                            {
                                if (e != null)
                                {
                                    return !string.IsNullOrEmpty(e.EmailString);
                                }

                                return false;
                            })
                            .Select(e => $"{e.EmailString}")) :
                        new SerializableList<object>(new string[0]);

                    queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.From), value));
                }
            }

            if (mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.To))).Key != null)
            {
                if (emailMessage == null)
                {
                    emailMessage = EmailMessageManager.Instance.LoadOrNull(id);
                }
                if (emailMessage != null)
                {
                    var value = emailMessage.To != null ?
                        new SerializableList<object>(emailMessage.To.Where(delegate (IEmailMessageParticipant e)
                            {
                                if (e != null)
                                {
                                    return !string.IsNullOrEmpty(e.EmailString);
                                }

                                return false;
                            })
                            .Select(e => $"{e.EmailString}")) :
                        new SerializableList<object>(new string[0]);

                    queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.To), value));
                }
            }

            if (mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.Owners))).Key != null)
            {
                if (emailMessage == null)
                {
                    emailMessage = EmailMessageManager.Instance.LoadOrNull(id);
                }
                if (emailMessage != null)
                {
                    var value = emailMessage.Owners != null ?
                        new SerializableList<object>(emailMessage.Owners.Where(delegate (IUserMailbox e)
                            {
                                if (e != null)
                                {
                                    return !string.IsNullOrEmpty(e.EmailLogin);
                                }

                                return false;
                            })
                            .Select(e => $"{e.EmailLogin} {e.Owner}")) :
                        new SerializableList<object>(new string[0]);

                    queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Owners), value));
                }
            }

            var deletedPair = mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessage d) => d.IsDeleted)));
            if (deletedPair.Key != null)
            {
                queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.IsDeleted), deletedPair.Value));
            }

            if (mergedIndexQueueItem.Find(p => Equals(p.Key, LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.SearchString))).Key != null)
            {
                if (emailMessage == null)
                {
                    emailMessage = EmailMessageManager.Instance.LoadOrNull(id);
                }
                if (emailMessage != null)
                {
                    queueToIndex.Properties.Add(new KeyValuePair<string, object>(LinqUtils.NameOf((IEmailMessageFullTextSearchObject d) => d.Owners), BuildSearchString(emailMessage)));
                }
            }

            queueToIndex.DynamicProperties.AddRange((mergedIndexQueueItem.Select(i => i.Value)).OfType<FieldIndexListItem>());
            if (queueToIndex.Properties.Any() || queueToIndex.DynamicProperties.Any())
            {
                list.Add(queueToIndex);
            }
            return list;
        }

        internal static string ConvertToPlainText(string value)
        {
            if (value == null) return null;
            var doc = new HtmlDocument();
            var html = value.ToString();
            if (string.IsNullOrWhiteSpace(html)) return null;
            doc.LoadHtml(html);
            var root = doc.DocumentNode;
            var sb = new StringBuilder();
            foreach (var node in root.SelectNodes("//text()"))
            {
                if (!node.HasChildNodes && node.Name != "style" && node.Name != "script")
                {
                    var text = node.InnerText;
                    if (!string.IsNullOrEmpty(text))
                        sb.AppendLine(text.Trim());
                }
            }

            return sb.ToString();

        }

        internal static string BuildSearchString(IEmailMessageFullTextSearchObject emailMessageFullTextSearchObject)
        {
            return BuildSearchString(emailMessageFullTextSearchObject.Subject,
                 emailMessageFullTextSearchObject.From,
                 emailMessageFullTextSearchObject.To,
                 emailMessageFullTextSearchObject.Owners,
                 emailMessageFullTextSearchObject.Body);
        }

        private static string BuildSearchString(string subject, string[] from, string[] to, string[] owners, string body)
        {
            return $"{subject}\n" +
                   $"{body}\n" +
                   $"{string.Join("", from)}\n" +
                   $"{string.Join("", to)}\n" +
                   $"{string.Join("", owners)}";
        }

        internal static string BuildSearchString(IEmailMessage emailMessage)
        {
            return BuildSearchString(emailMessage.Subject,
                emailMessage.From.Select(c => c.EmailString).ToArray(),
                emailMessage.To.Select(c => c.EmailString).ToArray(),
                emailMessage.Owners.Select(c => c.EmailLogin).ToArray(),
                ConvertToPlainText(emailMessage.Body));
        }
    }
}