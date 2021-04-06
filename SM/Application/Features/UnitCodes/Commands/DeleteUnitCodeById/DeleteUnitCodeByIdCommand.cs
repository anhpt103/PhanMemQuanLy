using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitCodes.Commands.DeleteUnitCodeById
{
    public class DeleteUnitCodeByIdCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public class DeleteUnitCodeByIdCommandHandler : IRequestHandler<DeleteUnitCodeByIdCommand, Response<string>>
        {
            private readonly IUnitCodeRepositoryAsync _unitCodeRepository;
            public DeleteUnitCodeByIdCommandHandler(IUnitCodeRepositoryAsync unitCodeRepository)
            {
                _unitCodeRepository = unitCodeRepository;
            }
            public async Task<Response<string>> Handle(DeleteUnitCodeByIdCommand command, CancellationToken cancellationToken)
            {
                var unitcode = await _unitCodeRepository.GetUnitCodeByIdAsync(command.Id);
                if (unitcode == null) throw new ApiException($"UnitCode Not Found.");
                await _unitCodeRepository.DeleteAsync(unitcode);
                return new Response<string>(unitcode.Id);
            }
        }
    }
}
