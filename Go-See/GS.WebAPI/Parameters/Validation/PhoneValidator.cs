using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class PhoneValidator : AbstractValidator<PhoneParam>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone.Value)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(25)
                .Matches(@"^[\d \-+()]{1,25}$");
        }
    }
}
