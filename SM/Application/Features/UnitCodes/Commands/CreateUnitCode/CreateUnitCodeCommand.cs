using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitCodes.Commands.CreateUnitCode
{
    public partial class CreateUnitCodeCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Parent { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Describe { get; set; }
        public string CreatedBy { get; set; }
    }
    public class CreateUnitCodeCommandHandler : IRequestHandler<CreateUnitCodeCommand, Response<string>>
    {
        private readonly IUnitCodeRepositoryAsync _unitCodeRepository;
        private readonly IMapper _mapper;
        public CreateUnitCodeCommandHandler(IUnitCodeRepositoryAsync unitCodeRepository, IMapper mapper)
        {
            _unitCodeRepository = unitCodeRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateUnitCodeCommand request, CancellationToken cancellationToken)
        {
            var unitcode = _mapper.Map<UnitCode>(request);
            unitcode.Id = await _unitCodeRepository.GenerateUnitCode(unitcode.Parent);

            await _unitCodeRepository.AddAsync(unitcode);

            return new Response<string>(unitcode.Id);
        }
    }
}
