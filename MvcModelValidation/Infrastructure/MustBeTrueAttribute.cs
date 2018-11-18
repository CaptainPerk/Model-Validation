using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcModelValidation.Infrastructure
{
    public class MustBeTrueAttribute : Attribute, IModelValidator
    {
        public bool IsRequired => true;

        public string ErrorMessage { get; set; } = "This value must be true";

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var value = context.Model as bool?;

            if (!value.HasValue || value.Value == false)
            {
                return new List<ModelValidationResult>
                {
                    new ModelValidationResult("", ErrorMessage)
                };
            }

            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}
