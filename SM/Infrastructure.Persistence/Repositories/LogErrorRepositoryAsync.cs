using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class LogErrorRepositoryAsync : GenericRepositoryAsync<LogError>, ILogErrorRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        public LogErrorRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task WriteLog(string LogContent, string ProcessContent)
        {
            var item = new LogError
            {
                LogContent = LogContent.Length > 2000 ? LogContent.Substring(0, 2000) : LogContent,
                ProcessContent = ProcessContent
            };
            await _dbContext.Set<LogError>().AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
