using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.Contracts;
using ProjectBoard.Core.Service.ServiceResults;
using ProjectBoard.Core.Service.Validation;

namespace ProjectBoard.Core.Service
{
    public class UpdateService<TEntity> : BaseService<TEntity>, IUpdateService<TEntity> where TEntity : class, IEntity<TEntity>
    {
        #region .ctor

        public UpdateService(IRepository repository, ModelValidation validator)
            : base(repository, validator)
        {
        }

        #endregion

        public virtual ServiceResult<TEntity> Update(TEntity entity, params object[] id)
        {
            Validate(entity);
            ExecuteBusinessLogic(entity);
            GetEntity(id);
            UpdateEntity(entity);
            CommitChanges();

            return Result;
        }

        private void UpdateEntity(TEntity entity)
        {
            if (Result.HasErrors) return;

            Result.Entity.Update(entity);
        }

        private void GetEntity(params object[] key)
        {
            if (Result.HasErrors) return;

            Result.Entity = Repository.FindByKey<TEntity>(key);

            if (Result.Entity == null)
            {
                Result.AddModelError("Cannot find entity");
            }
        }

        protected virtual void ExecuteBusinessLogic(TEntity entity)
        {
        }
    }
}