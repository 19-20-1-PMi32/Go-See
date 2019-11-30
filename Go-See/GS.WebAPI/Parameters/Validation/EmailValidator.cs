using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class EmailValidator : AbstractValidator<EmailParam>
    {
        public EmailValidator()
        {
            RuleFor(email => email.Value)
                .NotEmpty()
                .MaximumLength(320)
                .EmailAddress();
        }
    }
}
