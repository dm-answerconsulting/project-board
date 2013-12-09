using System.Linq;
using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.Contracts;
using ProjectBoard.Core.Service.ServiceResults;

namespace ProjectBoard.Core.Service
{
    public class Service<T> : IService<T> where T : class, IEntity<T>
    {
        #region .ctor

        public Service(
            IQueryService queryService, 
            ICreateService<T> createEntityService, 
            IUpdateService<T> updateEntityService, 
            IRemoveService<T> removeService
        )
        {
            _queryService = queryService;
            _createService = createEntityService;
            _updateService = updateEntityService;
            _removeService = removeService;
        }

        #endregion

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity<TEntity>
        {
            return _queryService.Query<TEntity>();
        }

        public TEntity Single<TEntity>(params object[] key) where TEntity : class, IEntity<TEntity>
        {
            return _queryService.Single<TEntity>(key);
        }

        public ServiceResult<T> Create(T entity)
        {
            return _createService.Create(entity);
        }

        public ServiceResult<T> Update(T entity, params object[] key)
        {
            return _updateService.Update(entity, key);
        }

        public ServiceResult<T> Remove(params object[] key)
        {
            return _removeService.Remove(key);
        }

        private readonly IQueryService _queryService;
        private readonly ICreateService<T> _createService;
        private readonly IUpdateService<T> _updateService;
        private readonly IRemoveService<T> _removeService;        
    }
}