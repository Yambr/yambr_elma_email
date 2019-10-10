using System;
using System.Linq;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Common.Models;
using Yambr.ELMA.Email.Managers;

namespace Yambr.ELMA.Email.Components.Queue
{
    [Component]
    public class ContractorHandler : AbstractRabbitMessageHandler<Contractor, EleWise.ELMA.CRM.Models.IContractor>
    {
      
        public override string[] Model => new[] { "Contractor" };
        public override EleWise.ELMA.CRM.Models.IContractor Run(Contractor contractor)
        {
            var domain = contractor.Domains.FirstOrDefault()?.DomainString;
            if (string.IsNullOrWhiteSpace(domain))
            {
                throw new ArgumentNullException("domain.DomainString", $"{contractor.Name} пришел с пустым domain");
            }

            var mailboxDomain = MailboxDomainManager.Instance.Load(domain);
            var mailboxDomainContractor = mailboxDomain?.Contractor;
            if (mailboxDomainContractor == null)
            {
                var settings = Locator.GetServiceNotNull<YambrEmailSettingsModule>().Settings;
                if (settings.AutoCreateContractors)
                {
                    mailboxDomainContractor = EmailMessageParticipantManager.CreateContractor(domain);
                }
            }

            if (mailboxDomainContractor != null)
            {
                UpdateByContractor(mailboxDomainContractor, contractor, domain);
            }


            return mailboxDomainContractor;
        }
        private static void UpdateByContractor(EleWise.ELMA.CRM.Models.IContractor contractor, Contractor newContractor, string domain)
        {
            if (!string.IsNullOrWhiteSpace(newContractor.Name) || 
                (domain == contractor.Name && !string.IsNullOrWhiteSpace(newContractor.Name)))
            {
                contractor.Name = newContractor.Name;
            }
            
            if (string.IsNullOrWhiteSpace(contractor.INN) && 
                !string.IsNullOrWhiteSpace(newContractor.INN))
                contractor.INN = newContractor.INN;

            /*    if (!string.IsNullOrWhiteSpace(newContractor.OGRN))
                {
                    if (contractor.CastAsRealType() is IContractorLegal contractorLegal && 
                        string.IsNullOrWhiteSpace(contractorLegal.OGRN))
                        contractorLegal.OGRN = newContractor.OGRN;
                }*/

            if (string.IsNullOrWhiteSpace(contractor.Site) && 
                !string.IsNullOrWhiteSpace(newContractor.Site))
                contractor.Site = newContractor.Site;

            if (string.IsNullOrWhiteSpace(contractor.Description) && 
                !string.IsNullOrWhiteSpace(newContractor.Description))
                contractor.Description = newContractor.Description;
        }

    }
}

