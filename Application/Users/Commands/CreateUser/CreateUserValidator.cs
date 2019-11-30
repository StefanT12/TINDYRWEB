using FluentValidation;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            //RuleFor(x => x.UserID).NotEmpty();
            RuleFor(x => x.UserName).MaximumLength(60);
            RuleFor(x => x.UserPass).MaximumLength(60);
            RuleFor(x => x.Role).IsInEnum();
        }
    }
}
