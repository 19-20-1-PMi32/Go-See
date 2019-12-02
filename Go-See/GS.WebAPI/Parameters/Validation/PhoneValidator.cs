using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class PhoneValidator : AbstractValidator<PhoneParam>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone.Value)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(25).WithMessage(ValidationErrors.ValueTooLong)
                .Matches(@"^[\d \-+()]{1,25}$").WithMessage(ValidationErrors.PhoneNotValid);
        }
    }
}
