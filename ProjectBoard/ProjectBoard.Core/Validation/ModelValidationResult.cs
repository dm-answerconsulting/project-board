using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectBoard.Core.Service.Validation
{
    public class ModelValidationResult
    {
        #region .ctor

        public ModelValidationResult()
        {
            Errors = new List<ValidationResult>();
        }

        #endregion

        public bool IsValid { get; set; }
        public IList<ValidationResult> Errors { get; set; }
    }
}