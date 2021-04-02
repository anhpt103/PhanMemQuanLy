using Application.Interfaces.Repositories;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Masters.Commands.CreateMaster
{
    public class CreateMasterCommandValidator : AbstractValidator<CreateMasterCommand>
    {
        private readonly IMasterRepositoryAsync masterRepository;

        public CreateMasterCommandValidator(IMasterRepositoryAsync masterRepository)
        {
            this.masterRepository = masterRepository;

            RuleFor(p => p.TypeMasters)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Key)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsExistMasterAsync(int TypeMaster, string Key, CancellationToken cancellationToken)
        {
            return await masterRepository.IsExistMasterAsync(TypeMaster, Key);
        }
    }
}
