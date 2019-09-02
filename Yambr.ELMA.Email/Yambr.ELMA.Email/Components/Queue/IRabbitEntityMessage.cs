using EleWise.ELMA.Model.Entities;

namespace Yambr.ELMA.Email.Components.Queue
{
    public interface IRabbitEntityMessage<TEntity> where TEntity : IEntity<long>
    {
        TEntity ToEntity();
    }
}