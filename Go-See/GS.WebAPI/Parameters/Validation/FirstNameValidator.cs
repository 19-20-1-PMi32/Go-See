using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class FirstNameValidator : AbstractValidator<FirstNameParam>
    {
        public FirstNameValidator()
        {
            RuleFor(firstname => firstname.Value)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
