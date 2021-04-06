using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUnitCodeRepositoryAsync : IGenericRepositoryAsync<UnitCode>
    {
        Task<UnitCode> GetUnitCodeByIdAsync(string id);
        Task<string> GenerateUnitCode(string parent);
    }
}
