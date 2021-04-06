using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
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


        public async Task<UnitCode> GetUnitCodeByIdAsync(int id)
        {
            return await _unitCode.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
