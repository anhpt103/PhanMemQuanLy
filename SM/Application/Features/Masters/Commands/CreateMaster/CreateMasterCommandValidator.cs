using Application.Features.Masters.Commands.CreateMaster;
using Application.Interfaces.Repositories;
using FluentValidation;

namespace Application.Features.Masters.Commands.CreateProduct
{
    public class CreateMasterCommandValidator : AbstractValidator<CreateMasterCommand>
    {
        private readonly IMasterRepositoryAsync masterRepository;

        public CreateMasterCommandValidator(IMasterRepositoryAsync masterRepository)
        {
            this.masterRepository = masterRepository;

            RuleFor(p => p.Key)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
