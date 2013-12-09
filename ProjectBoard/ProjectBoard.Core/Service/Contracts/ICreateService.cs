using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.ServiceResults;

namespace ProjectBoard.Core.Service.Contracts
{
    public interface ICreateService<TEntity> where TEntity : class, IEntity<TEntity>
    {
        ServiceResult<TEntity> Create(TEntity entity);
    }
}