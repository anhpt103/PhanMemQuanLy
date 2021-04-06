using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitCodes.Commands.UpdateUnitCode
{
    public class UpdateUnitCodeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Parent { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Describe { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsDelete { get; set; }
        public class UpdateUnitCodeCommandHandler : IRequestHandler<UpdateUnitCodeCommand, Response<int>>
        {
            private readonly IUnitCodeRepositoryAsync _unitCodeRepository;
            public UpdateUnitCodeCommandHandler(IUnitCodeRepositoryAsync unitCodeRepository)
            {
                _unitCodeRepository = unitCodeRepository;
            }
            public async Task<Response<int>> Handle(UpdateUnitCodeCommand command, CancellationToken cancellationToken)
            {
                var unitcode = await _unitCodeRepository.GetUnitCodeByIdAsync(command.Id);

                if (unitcode == null)
                {
                    throw new ApiException($"UnitCode Not Found.");
                }
                else
                {
                    unitcode.Name = command.Name;
                    unitcode.Parent = command.Parent;
                    unitcode.PhoneNumber = command.PhoneNumber;
                    unitcode.Address = command.Address;
                    unitcode.Describe = command.Describe;
                    unitcode.IsDelete = command.IsDelete;

                    await _unitCodeRepository.UpdateAsync(unitcode);
                    return new Response<int>(unitcode.Id);
                }
            }
        }
    }
}
