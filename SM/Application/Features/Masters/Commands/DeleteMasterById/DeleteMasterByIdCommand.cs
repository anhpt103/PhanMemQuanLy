using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Masters.Commands.DeleteProductById
{
    public class DeleteMasterByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteMasterByIdCommandHandler : IRequestHandler<DeleteMasterByIdCommand, Response<int>>
        {
            private readonly IMasterRepositoryAsync _masterRepository;
            public DeleteMasterByIdCommandHandler(IMasterRepositoryAsync masterRepository)
            {
                _masterRepository = masterRepository;
            }
            public async Task<Response<int>> Handle(DeleteMasterByIdCommand command, CancellationToken cancellationToken)
            {
                var master = await _masterRepository.GetByIdAsync(command.Id);
                if (master == null) throw new ApiException($"Master Not Found.");
                await _masterRepository.DeleteAsync(master);
                return new Response<int>(master.Id);
            }
        }
    }
}
