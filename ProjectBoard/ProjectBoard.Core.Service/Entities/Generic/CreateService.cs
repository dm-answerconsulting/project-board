using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.Contracts;
using ProjectBoard.Core.Service.Entities.Validation;
using ProjectBoard.Core.Service.Entities.ServiceResults;

namespace ProjectBoard.Core.Service.Entities
{
    public class CreateService<TEntity> : BaseService<TEntity>, ICreateService<TEntity> where TEntity : class, IEntity<TEntity>
    {
        #region .ctor

        public CreateService(IRepository repository, ModelValidation validator)
            : base(repository, validator)
        {
        }

        #endregion

        public virtual ServiceResult<TEntity> Create(TEntity entity)
        {
            Validate(entity);
            ExecuteBusinessLogic(entity);
            CreateEntity(entity);
            CommitChanges();

            return Result;
        }

        private void CreateEntity(TEntity entity)
        {
            if (Result.HasErrors) return;

            Result.Entity = entity;

            Repository.Add(Result.Entity);
        }

        protected virtual void ExecuteBusinessLogic(TEntity entity)
        {
        }
    }
}