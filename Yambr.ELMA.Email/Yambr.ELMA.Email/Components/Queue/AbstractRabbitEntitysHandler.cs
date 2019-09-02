using System.Collections.Generic;
using System.Linq;
using EleWise.ELMA.Model.Entities;

namespace Yambr.ELMA.Email.Components.Queue
{
    public abstract class AbstractRabbitEntitysHandler<TMessage, TEntity> : AbstractRabbitMessageHandler<TMessage, IEnumerable<long>>
        where TEntity : IEntity<long>
        where TMessage : class, IRabbitEntitysMessage<IEnumerable<TEntity>, TEntity>
    {
        public sealed override IEnumerable<long> Run(TMessage message)
        {
            var entitys = message.ToEntity();
            var enumerable = entitys != null ? entitys.ToList() : null;
            if (enumerable != null && enumerable.Any())
            {
                return enumerable.Select(c => c.Id).ToList();
            }
            return null;
        }
    }
}