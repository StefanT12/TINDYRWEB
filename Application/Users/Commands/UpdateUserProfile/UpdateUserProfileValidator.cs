using FluentValidation;

namespace Application.Users.Commands.UpdateProfile
{
    public class UpdateUserProfileValidator: AbstractValidator<UpdateUserProfile>
    {
        public UpdateUserProfileValidator()
        {
            RuleFor(x => x.UserID).NotEmpty();
            RuleFor(x => x.FirstName).MaximumLength(60);
            RuleFor(x => x.LastName).MaximumLength(60);
            RuleFor(x => x.PhoneNumber).Length(0, 12);
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
