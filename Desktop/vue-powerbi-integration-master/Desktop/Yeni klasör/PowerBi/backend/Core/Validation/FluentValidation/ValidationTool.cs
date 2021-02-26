using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validation.FluentValidation
{
    public class ValidationTool
    {
        /// <summary>
        /// Entity validation operation
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="entity"></param>
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
