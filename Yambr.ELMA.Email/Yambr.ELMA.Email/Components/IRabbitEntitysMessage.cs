using System.Collections.Generic;
using EleWise.ELMA.Model.Entities;

namespace Yambr.ELMA.Email.Components
{
    public interface IRabbitEntitysMessage<TEnumerable, TEntity>
        where TEnumerable : IEnumerable<TEntity>
        where TEntity : IEntity<long>
    {
        TEnumerable ToEntity();
    }
}