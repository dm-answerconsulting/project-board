using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectBoard.Core.Data.Contracts;
using ProjectBoard.Core.Service.Validation;

namespace ProjectBoard.Core.Service.ServiceResults
{
    public class ServiceResult<T> where T : class, IEntity<T>
    {
        #region .ctor

        public ServiceResult()
        {
            Success = true;
            ServiceErrors = new List<ServiceError>();
        }

        #endregion

        public void AddException(Exception exception)
        {
            Success = false;
            Exception = exception;
        }

        public void Update(ModelValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                Success = false;

                foreach (var error in validationResult.Errors)
                {
                    AddModelError(GetErrorFieldName(error), error.ErrorMessage);
                }
            }
        }

        private static string GetErrorFieldName(ValidationResult validationResult)
        {
            var result = validationResult.MemberNames.FirstOrDefault() ?? "";

            return result;
        }

        public void AddModelError(string errorMessage)
        {
            AddModelError("_FORM", errorMessage);
        }

        public void AddModelError(string fieldName, string errorMessage)
        {
            Success = false;

            var error = new ServiceError(fieldName, errorMessage);

            ServiceErrors.Add(error);
        }

        public bool HasErrors { get { return !Success; } }
        public bool Success { get; set; }
        public T Entity { get; set; }
        public Exception Exception { get; set; }
        public List<ServiceError> ServiceErrors { get; set; }
    }
}