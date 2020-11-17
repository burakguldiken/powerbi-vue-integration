using EnglishReader.Entities.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishReader.Business.Validation.FluentValidation
{
    public class UserRegisterValidation : AbstractValidator<User>
    {
        public UserRegisterValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Surname).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
