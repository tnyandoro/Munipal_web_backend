using System.Collections.Generic;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface ICommunityServiceUpdateRepository
    {
        Task<CommunityServiceUpdate> GetByIdAsync(int id);
        Task<IEnumerable<CommunityServiceUpdate>> GetAllAsync();
        Task AddAsync(CommunityServiceUpdate update);
        Task UpdateAsync(CommunityServiceUpdate update);
        Task DeleteAsync(int id);
    }
}
