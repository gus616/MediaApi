using FluentValidation;
using MediaApi.DTOs;

namespace MediaApi.Validators
{
    public class AlbumInsertValidator : AbstractValidator<AlbumInsertDto>
    {
        public AlbumInsertValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Title can not be less than 3");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Title can not be greater than 100");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id required");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("User Id must be greater than 0");
        }
    }
}
