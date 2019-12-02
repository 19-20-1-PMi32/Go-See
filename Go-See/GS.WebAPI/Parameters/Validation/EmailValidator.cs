using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class EmailValidator : AbstractValidator<EmailParam>
    {
        public EmailValidator()
        {
            RuleFor(email => email.Value)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(320).WithMessage(ValidationErrors.ValueTooLong)
                .EmailAddress().WithMessage(ValidationErrors.EmailNotValid);
        }
    }
}
