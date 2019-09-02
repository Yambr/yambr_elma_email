using EleWise.ELMA.Model.Entities;

namespace Yambr.ELMA.Email.Components.Queue
{
    public abstract class AbstractRabbitEntityHandler<TMessage, TEntity> : AbstractRabbitMessageHandler<TMessage, long?>
        where TEntity : IEntity<long>
        where TMessage : class, IRabbitEntityMessage<TEntity>
    {
        public sealed override long? Run(TMessage message)
        {
            var entity = message.ToEntity();
            if (entity != null) //TODO: V3111 https://www.viva64.com/en/w/v3111/ Checking value of 'entity' for null will always return false when generic type is instantiated with a value type.
            {
                return entity.Id;
            }
            return null;
        }
    }
}
