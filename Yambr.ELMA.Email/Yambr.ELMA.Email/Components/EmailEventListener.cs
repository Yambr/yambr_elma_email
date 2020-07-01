using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Runtime.NH.Listeners;
using NHibernate.Event;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Models;

namespace Yambr.ELMA.Email.Components
{

    [Component]
    public class EmailEventListener : EntityEventsListener
    {
        public override bool OnPreInsert(PreInsertEvent @event)
        {
            UpdateMailBox(@event.Entity);
            return false;
        }

        public override bool OnPreUpdate(PreUpdateEvent @event)
        {
            UpdateMailBox(@event.Entity);
            return false;
        }

        private static void UpdateMailBox(object eventEntity)
        {
            if (eventEntity is IUserMailbox)
            {
                UserMailboxManager.UpdateMailBox((IUserMailbox) eventEntity);
            }
        }
    }
}
