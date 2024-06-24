using Core.DTO.Authentication;
using FluentValidation;

namespace Core.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
       
        public RegisterValidator()
        {            
            RuleFor(reg => reg.Email)
            .NotNull().WithMessage("Email не може бути порожній") //гарантуємо, що не буде порожній
            .NotEmpty().WithMessage("Email не може містити пробілів") //якщо це рядок, то не має бути пробілів
            .EmailAddress().WithMessage("Неправильний email формат");

            RuleFor(reg => reg.Password)
            .NotEmpty().WithMessage("Введіть пароль")
            .MinimumLength(5).WithMessage("Пароль не може містити менше 5 символів");

            RuleFor(reg => reg.ConfirmPassword)
            .NotEmpty().WithMessage("Поле порожнє")
            .MinimumLength(5).WithMessage("Не може бути менше 5 символів")
            .Equal(reg => reg.Password).WithMessage("Паролі не співпадають");

            RuleFor(reg => reg.FirstName)
            .NotEmpty().WithMessage("Поле порожнє")
            .NotNull().WithMessage("Ім'я не може бути порожнім")
            .MaximumLength(24).WithMessage("Ім'я не може бути більшим за 24 символи")
            .MinimumLength(5).WithMessage("Ім'я не може мати менше 5 символів")
            .Matches("[A-Z]").WithMessage("Ім'я повинно містити хоч одну велику літеру")
            .Matches("[a-z]").WithMessage("Ім'я повинно містити хоч одну малу літеру");

            RuleFor(reg => reg.LastName)
            .NotEmpty().WithMessage("Поле порожнє")
            .NotNull().WithMessage("Прізвище не може бути порожнім")
            .MaximumLength(24).WithMessage("Прізвище не може бути більшим за 24 символи")
            .MinimumLength(5).WithMessage("Прізвище не може мати менше 5 символів")
            .Matches("[A-Z]").WithMessage("Прізвище повинно містити хоч одну велику літеру")
            .Matches("[a-z]").WithMessage("Прізвище повинно містити хоч одну малу літеру");

            RuleFor(reg => reg.PhoneNumber)
            .NotEmpty().WithMessage("Поле порожнє")
            .NotNull().WithMessage("Телефон не може бути порожнім")
            .MaximumLength(30).WithMessage("Телефон  не може бути більшим за 30 символи")
            .MinimumLength(5).WithMessage("Телефон не може мати менше 5 символів")
            .Matches(@"^\d+$").WithMessage("Номер телефону повинен містити тільки цифри");
        }        
    }
}
