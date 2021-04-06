using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitCodes.Commands.DeleteUnitCodeById
{
    public class DeleteUnitCodeByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteUnitCodeByIdCommandHandler : IRequestHandler<DeleteUnitCodeByIdCommand, Response<int>>
        {
            private readonly IUnitCodeRepositoryAsync _unitCodeRepository;
            public DeleteUnitCodeByIdCommandHandler(IUnitCodeRepositoryAsync unitCodeRepository)
            {
                _unitCodeRepository = unitCodeRepository;
            }
            public async Task<Response<int>> Handle(DeleteUnitCodeByIdCommand command, CancellationToken cancellationToken)
            {
                var unitcode = await _unitCodeRepository.GetUnitCodeByIdAsync(command.Id);
                if (unitcode == null) throw new ApiException($"UnitCode Not Found.");
                await _unitCodeRepository.DeleteAsync(unitcode);
                return new Response<int>(unitcode.Id);
            }
        }
    }
}
