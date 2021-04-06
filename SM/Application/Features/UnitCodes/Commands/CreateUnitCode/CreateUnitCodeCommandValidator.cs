using Application.Interfaces.Repositories;
using FluentValidation;

namespace Application.Features.UnitCodes.Commands.CreateUnitCode
{
    public class CreateUnitCodeCommandValidator : AbstractValidator<CreateUnitCodeCommand>
    {
        private readonly IUnitCodeRepositoryAsync unitCodeRepository;

        public CreateUnitCodeCommandValidator(IUnitCodeRepositoryAsync unitCodeRepository)
        {
            this.unitCodeRepository = unitCodeRepository;

            //RuleFor(m => m.Id)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(3).WithMessage("{PropertyName} must not exceed 3 characters.")
            //    .Matches(@"^\d+$").WithMessage("{PropertyName} does not allow special character.");

            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters.");

            RuleFor(m => m.PhoneNumber)
                .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15 characters.");

            RuleFor(m => m.Address)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(m => m.Describe)
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters.");
        }
    }
}
