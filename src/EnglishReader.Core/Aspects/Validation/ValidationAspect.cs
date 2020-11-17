using Castle.DynamicProxy;
using EnglishReader.Core.CrossCuttingConcerns.Validation;
using EnglishReader.Core.Utilities;
using EnglishReader.Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishReader.Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validator)
        {
            if (!typeof(IValidator).IsAssignableFrom(validator))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validator;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator2 = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator2, entity);
            }
        }
    }
}
