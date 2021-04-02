using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class MasterRepositoryAsync : GenericRepositoryAsync<Master>, IMasterRepositoryAsync
    {
        private readonly DbSet<Master> _master;
        public MasterRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _master = dbContext.Set<Master>();
        }

        public Task<bool> IsExistMasterAsync(int TypeMaster, string Key)
        {
            return _master.AnyAsync(m => m.TypeMasters == TypeMaster && m.Key == Key);
        }
    }
}
