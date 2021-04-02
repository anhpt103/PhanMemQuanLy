using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IMasterRepositoryAsync : IGenericRepositoryAsync<Master>
    {
        Task<bool> IsExistMasterAsync(int TypeMaster, string Key);
    }
}
