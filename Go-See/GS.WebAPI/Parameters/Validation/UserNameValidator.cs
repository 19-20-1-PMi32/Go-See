using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class UserNameValidator : AbstractValidator<UserNameParam>
    {
        public UserNameValidator()
        {
            RuleFor(username => username.Value)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(255).WithMessage(ValidationErrors.ValueTooLong);
        }
    }
}
