using System.Linq;
using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.Contracts;

namespace ProjectBoard.Core.Service.Entities
{
    public class QueryService : IQueryService
    {
        #region .ctor

        public QueryService(IRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public IQueryable<T> Query<T>() where T : class, IEntity<T>
        {
            return _repository.Query<T>();
        }

        public T Single<T>(params object[] key) where T : class, IEntity<T>
        {
            var entity = _repository.FindByKey<T>(key);

            return entity;
        }

        private readonly IRepository _repository;
    }
}