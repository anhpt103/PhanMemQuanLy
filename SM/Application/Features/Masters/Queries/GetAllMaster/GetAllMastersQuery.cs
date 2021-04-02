using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Masters.Queries.GetAllMaster
{
    public class GetAllMastersQuery : IRequest<PagedResponse<IEnumerable<GetAllMastersViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllMastersQueryHandler : IRequestHandler<GetAllMastersQuery, PagedResponse<IEnumerable<GetAllMastersViewModel>>>
    {
        private readonly IMasterRepositoryAsync _masterRepository;
        private readonly IMapper _mapper;
        public GetAllMastersQueryHandler(IMasterRepositoryAsync masterRepository, IMapper mapper)
        {
            _masterRepository = masterRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllMastersViewModel>>> Handle(GetAllMastersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllMastersParameter>(request);
            var master = await _masterRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var masterViewModel = _mapper.Map<IEnumerable<GetAllMastersViewModel>>(master);
            return new PagedResponse<IEnumerable<GetAllMastersViewModel>>(masterViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
