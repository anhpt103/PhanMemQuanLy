using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class MasterUnitRepositoryAsync : GenericRepositoryAsync<MasterUnit>, IMasterUnitRepositoryAsync
    {
        private readonly DbSet<MasterUnit> _masterUnit;
        public MasterUnitRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _masterUnit = dbContext.Set<MasterUnit>();
        }
    }
}
