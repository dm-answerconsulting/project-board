using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.ServiceResults;

namespace ProjectBoard.Core.Service.Contracts
{
    public interface IRemoveService<TEntity> where TEntity : class, IEntity<TEntity>
    {
        ServiceResult<TEntity> Remove(params object[] key);
    }
}