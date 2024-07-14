using Core.DTO.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validator
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator() 
        {
            RuleFor(reg => reg.Email)
               .NotNull().WithMessage("Email is empty") //гарантуємо, що не буде порожній
               .NotEmpty().WithMessage("Email can't white space") //якщо це рядок, то не має бути пробілів
               .EmailAddress().WithMessage("Incorect email format");

            RuleFor(reg => reg.Password)
            .NotEmpty().WithMessage("Enter Password")
            .MinimumLength(5).WithMessage("The password cannot be less than 5 characters");
        }
    }
}
