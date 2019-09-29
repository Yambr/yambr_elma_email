using System;
using System.Collections.Generic;
using EleWise.ELMA.CRM.Models;
using EleWise.ELMA.Runtime.Db;
using EleWise.ELMA.Runtime.Db.Migrator.Framework;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Db
{
    /// <summary>
    /// Структура БД для модуля "Интеграция с Dadata"
    /// </summary>
    public class EmailDbStructure : DbStructureExtension
    {
        /// <summary>
        /// Uid провайдера БД (для всех)
        /// </summary>
        public override Guid ProviderUid => Guid.Empty;
        public override Type[] References => new[]
        {
            typeof(EmailDbStructure)
        };
        /// <summary>
        /// Создать индекс для поля Уникальный идентификатор по ЕГРЮЛ
        /// </summary>
        public void TrimEmailCreateIndex()
        {
            const string emailTableName = "Email";
            Transformation.ConvertColumnString(emailTableName, nameof(IEmail.EmailString), 320);
            Transformation.AddIndex(new Index
            {
                Name = "IX_Email_EmailString",
                TableName = emailTableName,
                Columns = new List<string>
                {
                    nameof(IEmail.EmailString)
                }
            });
        }

        /// <summary>
        /// Создать индекс 
        /// </summary>
        public void EmailMessageParticipantCreateIndex()
        {
            Transformation.AddIndex(new Index
            {
                Name = "IX_EmailMessageParticipant_EmailString",
                TableName = "EmailMessageParticipant",
                Columns = new List<string>
                {
                    nameof(IEmailMessageParticipant.EmailString)
                }
            });

        }

        /// <summary>
        /// Создать индекс 
        /// </summary>
        public void EmailMessageCreateIndex()
        {
            Transformation.AddIndex(new Index
            {
                Name = "IX_EmailMessage_DateUtc",
                TableName = "EmailMessage",
                Columns = new List<string>
                {
                    nameof(IEmailMessage.DateUtc),
                }
            });

            Transformation.AddIndex(new Index
            {
                Name = "IX_EmailMessage_IsDeleted",
                TableName = "EmailMessage",
                Columns = new List<string>
                {
                    nameof(IEmailMessage.IsDeleted),
                }
            });
        }

        public void UpdatePublicDomains()
        {
            PublicDomainManager.Instance.UpdateDomains();
        }
    }
}
