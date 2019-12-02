using FluentValidation;

namespace GS.WebAPI.Parameters.Validation
{
    public class LogInValidator : AbstractValidator<LogInParam>
    {
        public LogInValidator()
        {
            RuleFor(loginParam => loginParam.Login)
                .NotEmpty().WithMessage(ValidationErrors.Required)
                .MaximumLength(255).WithMessage(ValidationErrors.ValueTooLong);

            RuleFor(loginParam => loginParam.Password)
                .NotEmpty().WithMessage(ValidationErrors.Required);
        }
    }
}
