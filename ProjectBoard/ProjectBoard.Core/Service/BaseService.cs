using System;
using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.ServiceResults;
using ProjectBoard.Core.Service.Validation;

namespace ProjectBoard.Core.Service
{
    public abstract class BaseService<TEntity> where TEntity : class, IEntity<TEntity>
    {
        #region .ctor

        protected BaseService(IRepository repository)
        {
            Repository = repository;
            Result = new ServiceResult<TEntity>();
        }

        protected BaseService(IRepository repository, ModelValidation validator)
            : this(repository)
        {
            _validator = validator;
        }  

        #endregion

        protected void Validate<T>(T model)
        {
            var validationResult = _validator.Validate(model);

            Result.Update(validationResult);
        }        

        protected void CommitChanges()
        {
            if (Result.HasErrors) return;

            try
            {
                Repository.SaveChanges();
            }
            catch (Exception exception)
            {
                Result.AddException(exception);
            }
        }

        protected readonly IRepository Repository;

        protected readonly ServiceResult<TEntity> Result;

        private readonly ModelValidation _validator;
    }
}
