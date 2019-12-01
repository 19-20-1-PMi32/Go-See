using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class LastNameValidator : AbstractValidator<LastNameParam>
    {
        public LastNameValidator()
        {
            RuleFor(lastname => lastname.Value)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(255).WithMessage(ValidationErrors.ValueTooLong);
        }
    }
}
