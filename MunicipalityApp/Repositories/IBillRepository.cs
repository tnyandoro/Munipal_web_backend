using System.Collections.Generic;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface IBillRepository
    {
        Task<Bill> GetByIdAsync(int id);
        Task<IEnumerable<Bill>> GetAllAsync();
        Task AddAsync(Bill bill);
        Task UpdateAsync(Bill bill);
        Task DeleteAsync(int id);
    }
}
