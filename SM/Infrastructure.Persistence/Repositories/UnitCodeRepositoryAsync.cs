using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitCodeRepositoryAsync : GenericRepositoryAsync<UnitCode>, IUnitCodeRepositoryAsync
    {
        private readonly DbSet<UnitCode> _unitCode;
        public UnitCodeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _unitCode = dbContext.Set<UnitCode>();
        }

        public async Task<string> GenerateUnitCode(string parent)
        {
            var maxUnitCode = await GetMaxUnitCode(parent);
            return GenerateNextUnitCode(maxUnitCode, parent);
        }

        public async Task<UnitCode> GetUnitCodeByIdAsync(string id)
        {
            return await _unitCode.FirstOrDefaultAsync(x => x.Id == id);
        }

        private async Task<string> GetMaxUnitCode(string parent)
        {
            if (string.IsNullOrEmpty(parent))
            {
                return await _unitCode.Where(x => x.Parent == null).MaxAsync(x => x.Id);
            }
            else
            {
                return await _unitCode.Where(x => x.Parent == parent).MaxAsync(x => x.Id);
            }
        }

        private string GenerateNextUnitCode(string maxUnitCode, string parent)
        {
            return IncrementUnitCode(maxUnitCode, parent);
        }

        private string IncrementUnitCode(string maxUnitCode, string parent)
        {
            int.TryParse(maxUnitCode, out int maxUnitInt);
            int lengthMaxUnit = maxUnitInt.ToString().Length;

            if (string.IsNullOrEmpty(parent))
            {
                switch (lengthMaxUnit)
                {
                    case 1:
                        maxUnitInt = maxUnitInt + 1;
                        return string.Format(@"{0}00", maxUnitInt);
                    case 3:
                        return string.Format(@"{0}", maxUnitInt += 100);
                    default:
                        return null;
                }
            }
            else
            {
                int.TryParse(parent, out int parentInt);
                switch (lengthMaxUnit)
                {
                    case 1:
                        return string.Format(@"{0}", parentInt + maxUnitInt + 1);
                    case 3:
                        return string.Format(@"{0}",  maxUnitInt + 1);
                    default:
                        return null;
                }
            }
        }
    }
}
