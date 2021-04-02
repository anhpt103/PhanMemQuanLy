using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Masters.Commands.CreateMaster
{
    public partial class CreateMasterCommand : IRequest<Response<int>>
    {
        public int TypeMasters { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public long? Parent { get; set; }
        public string Describe { get; set; }
    }
    public class CreateMasterCommandHandler : IRequestHandler<CreateMasterCommand, Response<int>>
    {
        private readonly IMasterRepositoryAsync _masterRepository;
        private readonly IMasterUnitRepositoryAsync _masterUnitRepository;
        private readonly IMapper _mapper;
        public CreateMasterCommandHandler(IMasterRepositoryAsync masterRepository, IMasterUnitRepositoryAsync masterUnitRepository, IMapper mapper)
        {
            _masterRepository = masterRepository;
            _masterUnitRepository = masterUnitRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMasterCommand request, CancellationToken cancellationToken)
        {
            if (_masterRepository.IsExistMasterAsync(request.TypeMasters, request.Key).Result) throw new ApiException($"Master is allready exist.");
            var master = _mapper.Map<Master>(request);
            await _masterRepository.AddAsync(master);

            var masterUnit = new MasterUnit
            {
                MasterId = master.Id,
                UnitCode = master.UnitCode
            };
            await _masterUnitRepository.AddAsync(masterUnit);

            return new Response<int>(master.Id);
        }
    }
}
