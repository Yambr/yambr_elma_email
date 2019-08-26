using EleWise.ELMA.Model.Entities;

namespace Yambr.ELMA.Email.Components
{
    public interface IRabbitEntityMessage<TEntity> where TEntity : IEntity<long>
    {
        TEntity ToEntity();
    }
}