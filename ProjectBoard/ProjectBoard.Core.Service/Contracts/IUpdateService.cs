using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.Entities.ServiceResults;

namespace ProjectBoard.Core.Service.Contracts
{
    public interface IUpdateService<TEntity> where TEntity : class, IEntity<TEntity>
    {
        ServiceResult<TEntity> Update(TEntity entity, params object[] key);
    }
}