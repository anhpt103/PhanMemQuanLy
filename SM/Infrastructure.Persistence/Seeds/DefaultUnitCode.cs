using Application.Constants;
using Application.Interfaces.Repositories;
using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public static class DefaultUnitCode
    {
        public static async Task SeedAsync(IUnitCodeRepositoryAsync unitCodeRepository)
        {
            // Seed Default UnitCode
            var defaultUnicode = new UnitCode
            {
                Id = UnitCodes.ROOT_UNITCODE,
                Name = "Quản trị phần mềm",
                PhoneNumber = "033.248.7344",
                Address = "Thanh Trì - Hà Nội",
                Describe = "Quản trị phần mềm"
            };

            var unitCode = await unitCodeRepository.GetUnitCodeByIdAsync(defaultUnicode.Id);
            if (unitCode == null)
            {
                await unitCodeRepository.AddAsync(defaultUnicode);
            }
        }
    }
}
