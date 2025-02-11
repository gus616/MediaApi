using FluentValidation;
using MediaApi.DTOs;

namespace MediaApi.Validators
{
    public class UserInsertValidator : AbstractValidator<UserInsertDto>
    {
        public UserInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name can not be less than 3");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name can not be greater than 100");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Age).GreaterThan(18).GreaterThan(0).WithMessage("Age must be greater than 18");
        }
    }
}
