using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateMasterCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public long? Parent { get; set; }
        public string Describe { get; set; }
        public class UpdateMasterCommandHandler : IRequestHandler<UpdateMasterCommand, Response<int>>
        {
            private readonly IMasterRepositoryAsync _masterRepository;
            public UpdateMasterCommandHandler(IMasterRepositoryAsync masterRepository)
            {
                _masterRepository = masterRepository;
            }
            public async Task<Response<int>> Handle(UpdateMasterCommand command, CancellationToken cancellationToken)
            {
                var master = await _masterRepository.GetByIdAsync(command.Id);

                if (master == null)
                {
                    throw new ApiException($"Master Not Found.");
                }
                else
                {
                    master.Value = command.Value;
                    master.Parent = command.Parent;
                    master.Describe = command.Describe;
                    await _masterRepository.UpdateAsync(master);
                    return new Response<int>(master.Id);
                }
            }
        }
    }
}
