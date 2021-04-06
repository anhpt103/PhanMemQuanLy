using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitCodes.Commands.CreateUnitCode
{
    public partial class CreateUnitCodeCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Parent { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Describe { get; set; }
        public string CreatedBy { get; set; }
    }
    public class CreateUnitCodeCommandHandler : IRequestHandler<CreateUnitCodeCommand, Response<int>>
    {
        private readonly IUnitCodeRepositoryAsync _unitCodeRepository;
        private readonly IMapper _mapper;
        public CreateUnitCodeCommandHandler(IUnitCodeRepositoryAsync unitCodeRepository, IMapper mapper)
        {
            _unitCodeRepository = unitCodeRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUnitCodeCommand request, CancellationToken cancellationToken)
        {
            var unitcode = _mapper.Map<UnitCode>(request);
            await _unitCodeRepository.AddAsync(unitcode);

            return new Response<int>(unitcode.Id);
        }
    }
}
