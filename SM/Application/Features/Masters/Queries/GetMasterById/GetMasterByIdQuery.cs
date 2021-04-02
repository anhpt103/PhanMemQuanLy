using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Masters.Queries.GetMasterById
{
    public class GetMasterByIdQuery : IRequest<Response<Master>>
    {
        public int Id { get; set; }
        public class GetMasterByIdQueryHandler : IRequestHandler<GetMasterByIdQuery, Response<Master>>
        {
            private readonly IMasterRepositoryAsync _masterRepository;
            public GetMasterByIdQueryHandler(IMasterRepositoryAsync masterRepository)
            {
                _masterRepository = masterRepository;
            }
            public async Task<Response<Master>> Handle(GetMasterByIdQuery query, CancellationToken cancellationToken)
            {
                var master = await _masterRepository.GetByIdAsync(query.Id);
                if (master == null) throw new ApiException($"Master Not Found.");
                return new Response<Master>(master);
            }
        }
    }
}
