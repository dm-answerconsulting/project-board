using Demo.Data.Contracts;
using Demo.Domain.Entities;

namespace Demo.Service.Entities.
{
    public class CreateUserProfileService : CreateService<UserProfile>
    {
        #region .ctor

        public CreateUserProfileService(IRepository repository, ModelValidation validator) 
            :base(repository, validator)
        {            
        }

        #endregion

        protected override void ExecuteBusinessLogic(UserProfile entity)
        {
            if (Result.HasErrors) return;

            
        }        
    }
}