using FluentValidation;
using NexCart.Users.DTO;

namespace NexCart.Users.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Please enter a valid email address");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a valid password");
    }
}