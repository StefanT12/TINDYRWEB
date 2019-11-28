using FluentValidation;
namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserID).NotEmpty();
            RuleFor(x => x.UserName).MaximumLength(60);
            RuleFor(x => x.UserPass).MaximumLength(60);
            RuleFor(x => x.Role).IsInEnum();
        }
    }
}
