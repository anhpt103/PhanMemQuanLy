using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ILogErrorRepositoryAsync : IGenericRepositoryAsync<LogError>
    {
        Task WriteLog(string LogContent, string ProcessContent);
    }
}
