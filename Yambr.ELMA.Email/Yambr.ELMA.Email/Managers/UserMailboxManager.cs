using System;
using System.Collections.Generic;
using System.Linq;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Helpers;
using EleWise.ELMA.Model.Common;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Runtime.Db.Migrator.Framework;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Security;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Common.EncryptionHelper;
using Yambr.ELMA.Email.Common.Enums;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Models;
using Yambr.ELMA.Email.Services;
using LogLevel = EleWise.ELMA.Logging.LogLevel;

namespace Yambr.ELMA.Email.Managers
{
    public class UserMailboxManager : EntityManager<IUserMailbox, long>
    {
        private readonly ISessionProvider _sessionProvider;
        private readonly IRabbitMQService _rabbitMqService;

        private const string DefaultPassword = "****************";

        internal void UpdateEvent(MailBox mailBox)
        {
            var id = Convert.ToInt64(mailBox.Id);
            if (id <= 0) return;
            var tp = Locator.GetServiceNotNull<ITransformationProvider>();
            try
            {

                if (mailBox.Status == EmailLoadingStatus.Error)
                {
                    EmailLogger.Logger.Log(LogLevel.Error, new Exception(mailBox.Error), $"Ошибка загрузки писем из ящика {mailBox.Login}");
                    tp.Update("UserMailbox",
                        new[] { nameof(IUserMailbox.Status), nameof(IUserMailbox.Error), nameof(IUserMailbox.LastMailUpdate) },
                        new object[] { (int)mailBox.Status, mailBox.Error, mailBox.LastStartTimeUtc.ToLocalTime() },
                        $"{tp.Dialect.QuoteIfNeeded(nameof(IUserMailbox.Id))} = {id}");
                    
                }
                else
                {
                    EmailLogger.Debug($"Успешная загрузка писем из ящика {mailBox.Login} до {mailBox.LastStartTimeUtc.ToLocalTime()}");
                    tp.Update("UserMailbox",
                        new[] { nameof(IUserMailbox.Status), nameof(IUserMailbox.Error) },
                        new object[] { (int)mailBox.Status, null },
                        $"{tp.Dialect.QuoteIfNeeded(nameof(IUserMailbox.Id))} = {id}");
                }

            }
            catch
            {
                tp.RollbackTransaction();
            }

        }

        public UserMailboxManager(ISessionProvider sessionProvider, IRabbitMQService rabbitMqService)
        {
            _sessionProvider = sessionProvider;
            _rabbitMqService = rabbitMqService;
        }
        private static UserMailboxManager _manager;

        public new static UserMailboxManager Instance => _manager ?? (_manager = Locator.GetServiceNotNull<UserMailboxManager>());

        public IUserMailbox Load(string email)
        {
            var guid = GetUid(email);
            return LoadOrNull(guid);
        }

        public static Guid GetUid(string email)
        {
            return email.GetDeterministicGuid();
        }


        public static void UpdateMailBox(IUserMailbox obj)
        {
            var uid = GetUid(obj.EmailLogin);

            if (obj.Uid != uid)
            {
                obj.Uid = uid;
            }
            if (obj.EmailParticipant == null)
            {
                obj.EmailParticipant = InterfaceActivator.Create<IEmailMessageParticipantUser>();
                obj.EmailParticipant.Mailbox = obj;
                obj.EmailParticipant.EmailString = obj.EmailLogin;
                obj.EmailParticipant.User = obj.Owner;
            }
            else
            {
                if (obj.EmailParticipant.EmailString != obj.EmailLogin)
                {
                    obj.EmailParticipant.Name = obj.EmailLogin;
                    obj.EmailParticipant.EmailString = obj.EmailLogin;
                }
            }

            if (obj.EmailPassword != DefaultPassword)
            {
                obj.PasswordEncoded = EncryptionHelper.EncryptPwd(obj.EmailPassword);
                obj.EmailPassword = DefaultPassword;
            }
        }


        public ICollection<IUserMailbox> GetUserMailboxes(ICollection<string> email)
        {
            var session = _sessionProvider.GetSession("");

            var emailsString = string.Join(",", email.Select(c => $"'{c.GetDeterministicGuid()}'"));

            var hqlQuery =
                session.CreateQuery(
                    "select usermailbox FROM UserMailbox usermailbox " +
                    $"where usermailbox.Uid in ({emailsString})");
            hqlQuery.SetMaxResults(email.Count);

            return hqlQuery.List<IUserMailbox>();
        }

        //TODO сделать лицензирование
        public void SendToUpdate()
        {
            var securityService = Locator.GetService<ISecurityService>();
            securityService.RunByUser(
                EleWise.ELMA.Security.Managers.UserManager.Instance.Load(SecurityConstants.AdminUserUid),
                () =>
                {
                    var size = 100;
                    var index = 0;
                    var filter = InterfaceActivator.Create<IUserMailboxFilter>();
                    filter.DisableAutoFilter = true;
                    filter.DisableSecurity = true;
                    var mailboxes = Find(new FetchOptions()
                    {
                        FirstResult = index,
                        MaxResults = size
                    });
                    while (mailboxes.Any())
                    {
                        index += size;
                        foreach (var userMailbox in mailboxes)
                        {
                            SendToUpdate(userMailbox);
                        }

                        if (mailboxes.Count < size)
                        {
                            break;
                        }
                    }
                });
        }

        //TODO сделать без обращения в бд
        internal void SendToUpdate(IUserMailbox userMailbox)
        {
            var localUser = new LocalUser()
            {
                Fio = userMailbox.Owner.ToString(),
                UserId = (int)userMailbox.Owner.Id
            };
            if (!string.IsNullOrWhiteSpace(userMailbox.Aliases))
            {
                localUser.Aliases =
                    userMailbox.Aliases
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(c => c.Trim()).ToList();
            }
            var server = new Server()
            {
                ConnectionType = ConnectionType.IMAP,
                Host = userMailbox.Server.ImapHost,
                Port = (int)userMailbox.Server.ImapPort,
                UseSsl = userMailbox.Server.RequaredSSL
            };
           
            var userMailboxEmailPassword =
                userMailbox.EmailPassword == DefaultPassword ? 
                    EncryptionHelper.DecryptPwd(userMailbox.PasswordEncoded):
                    userMailbox.EmailPassword;
            var mailBox = new MailBox(server, localUser)
            {
                Id = userMailbox.Id,
                LastStartTimeUtc = userMailbox.LastMailUpdate.ToUniversalTime(),
                Login = userMailbox.EmailLogin,
                Password =
                    StringCipher.Encrypt(userMailboxEmailPassword, userMailbox.EmailLogin)
            };

            _rabbitMqService.SendMessage(
                new JsonQueueObject<MailBox>(
                    mailBox,
                    "Mailbox",
                    QueueConstants.RoutingKeyMailBoxCmdDownload));
            // если не удалось отправить сообщение - не обновляем время чтения писем

            UpdateLastMailUpdate(userMailbox);
        }

        private static void UpdateLastMailUpdate(IUserMailbox userMailbox)
        {
            if (userMailbox.Id <= 0) return;
            var tp = Locator.GetServiceNotNull<ITransformationProvider>();
            try
            {
                tp.Update("UserMailbox",
                    new[] { nameof(IUserMailbox.LastMailUpdate) },
                    new object[] { DateTime.Now },
                    $"{tp.Dialect.QuoteIfNeeded(nameof(IUserMailbox.Id))} = {userMailbox.Id}");
            }
            catch
            {
                tp.RollbackTransaction();
            }
        }
    }
}