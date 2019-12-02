using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class FirstNameValidator : AbstractValidator<FirstNameParam>
    {
        public FirstNameValidator()
        {
            RuleFor(firstname => firstname.Value)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(255).WithMessage(ValidationErrors.ValueTooLong);
        }
    }
}
