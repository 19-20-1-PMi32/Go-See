using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class PasswordValidator : AbstractValidator<PasswordParam>
    {
        public PasswordValidator()
        {
            RuleFor(password => password.Value)
                .NotEmpty().WithMessage(ValidationErrors.Required);
        }
    }
}
