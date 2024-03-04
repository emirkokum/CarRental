using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FulentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2).NotEmpty();
        }
    }
}
