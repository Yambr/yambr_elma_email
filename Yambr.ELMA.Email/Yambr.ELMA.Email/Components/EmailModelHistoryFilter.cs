using System;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Events.Audit;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Components
{
    [Component]
    internal class EmailModelHistoryFilter : EntityModelHistoryEventsFilterBase
    {
        protected override Type[] ExcludeTypes => new[]
        {
            typeof(IEmailMessage),
            typeof(IEmailMessageParticipant),
            typeof(IEmailMessageParticipantContact),
            typeof(IEmailMessageParticipantUser),
            typeof(IMailboxDomain),
            typeof(IUserMailbox),
            typeof(IUserMailServer),
            typeof(IPublicDomain)
        };
    }
}