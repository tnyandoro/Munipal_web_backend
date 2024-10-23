using System.Collections.Generic;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface IMeterRepository
    {
        Task<Meter> GetByIdAsync(int id);
        Task<IEnumerable<Meter>> GetAllAsync();
        Task AddAsync(Meter meter);
        Task UpdateAsync(Meter meter);
        Task DeleteAsync(int id);
    }
}
