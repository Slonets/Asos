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
               .NotNull().WithMessage("Email не може бути порожній") //гарантуємо, що не буде порожній
               .NotEmpty().WithMessage("Email не може містити пробілів") //якщо це рядок, то не має бути пробілів
               .EmailAddress().WithMessage("Неправильний email формат");

            RuleFor(reg => reg.Password)
            .NotEmpty().WithMessage("Введіть пароль")
            .MinimumLength(5).WithMessage("Пароль не може містити менше 5 символів");
        }
    }
}
