using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class UserValidator : AbstractValidator<UserParam>
    {
        public UserValidator()
        {
            RuleFor(user => user.Login)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(255).WithMessage(ValidationErrors.ValueTooLong);

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(255).WithMessage(ValidationErrors.ValueTooLong);

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(255).WithMessage(ValidationErrors.ValueTooLong);

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(255).WithMessage(ValidationErrors.ValueTooLong)
                .EmailAddress().WithMessage(ValidationErrors.EmailNotValid);

            RuleFor(user => user.Phone)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(25).WithMessage(ValidationErrors.ValueTooLong)
                .Matches(@"^[\d \-+()]{1,25}$").WithMessage(ValidationErrors.PhoneNotValid);

            RuleFor(user => user.PasswordHash)
                .NotEmpty().WithMessage(ValidationErrors.Required);
        }
    }
}
