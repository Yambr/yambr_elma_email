using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.CRM.Models;
using EleWise.ELMA.Model.Metadata;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Runtime.Db.Migrator.Framework;
using EleWise.ELMA.Runtime.NH;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace Yambr.ELMA.Email.Services.Impl
{
    [Service]
    public  class EmailService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ISessionProvider _sessionProvider;
        private readonly ITransformationProvider _transformationProvider;

        public EmailService(ISessionProvider sessionProvider, ITransformationProvider transformationProvider)
        {
            _sessionProvider = sessionProvider;
            _transformationProvider = transformationProvider;
        }

        public ICollection<object> GetEntityesByEmails(IEnumerable<string> emails)
        {
            var emails = new List<string>() { "erg" };
            var session = _sessionProvider.GetSession("");
            var @join = string.Join(",", emails.Select(c => $"'{c}'"));
            var hqlQuery =
                session.CreateQuery(
                    $"FROM Contractor contractor where contractor.Email in ({@join})");
           Type type = null;
           
           var contractorCriteria = EmailCriterisIn(typeof(IContractor), session, emails);
           var contactCriteria = EmailCriterisIn(typeof(IContact), session, emails);
           var leadCriteria = EmailCriterisIn(typeof(ILead), session, emails);

        }

        private static ICriteria EmailCriterisIn( Type type, ISession session, IEnumerable<string> emails)
        {
            var criteria = session.CreateCriteria(type);
            foreach (var email in emails)
            {
                var dc = DetachedCriteria
                    .For(InterfaceActivator.TypeOf(type))
                    .CreateAlias("Email", "EmailAlias", JoinType.InnerJoin)
                    .Add(Restrictions.Eq("EmailAlias.EmailString", email))
                    .SetProjection(Projections.Property("Id"));
                criteria.Add(Subqueries.PropertyIn("Id", dc));
            }
            return criteria;
        }

        public ICollection<long> GetFilterPropertyList(ICriteria criteria, Type type, EntityPropertyMetadata property, object propertyValue, string nameReturnProperty)
        {
            IEnumerable<IEmail> enumerable = propertyValue as IEnumerable<IEmail>;
            if (enumerable != null && enumerable.Any())
            {
                List<long> list = new List<long>();
                foreach (IEmail item in enumerable)
                {
                    DetachedCriteria dc = DetachedCriteria
                        .For(InterfaceActivator.TypeOf(type))
                        .CreateAlias("Email", "EmailAlias", JoinType.InnerJoin)
                        .Add(Restrictions.Eq("EmailAlias.EmailString", item.EmailString))
                        .SetProjection(Projections.Property("Id"));
                    criteria.Add(Subqueries.PropertyIn("Id", dc));
                    criteria.SetProjection(Projections.ProjectionList().Add(Projections.Property(nameReturnProperty)));
                    list.AddRange(criteria.List<long>());
                }
                return list.Distinct().ToList();
            }
            return new List<long>();
        }
    }
}
