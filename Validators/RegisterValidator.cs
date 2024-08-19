using FluentValidation;
using WebApplication5.Dtos.Account;

namespace WebApplication5.Validators;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
        public RegisterValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
        }
    
}