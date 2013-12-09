using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.Contracts;
using ProjectBoard.Core.Service.ServiceResults;

namespace ProjectBoard.Core.Service
{
    public class RemoveService<TEntity> : BaseService<TEntity>, IRemoveService<TEntity> where TEntity : class, IEntity<TEntity>
    {
        #region .ctor

        public RemoveService(IRepository repository)
            : base(repository)
        {
        }

        #endregion

        public virtual ServiceResult<TEntity> Remove(params object[] key)
        {
            GetEntity(key);
            ExecuteBusinessLogic();
            RemoveEntity();
            CommitChanges();

            return Result;
        }

        protected virtual void ExecuteBusinessLogic()
        {
        }

        private void RemoveEntity()
        {
            if (Result.HasErrors) return;

            Repository.Remove(Result.Entity);
        }

        private void GetEntity(params object[] key)
        {
            if(Result.HasErrors) return;

            Result.Entity = Repository.FindByKey<TEntity>(key);

            if (Result.Entity == null)
            {
                Result.AddModelError("Cannot find entity");
            }
        }
    }
}