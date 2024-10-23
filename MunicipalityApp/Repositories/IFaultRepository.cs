using System.Collections.Generic;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface IFaultRepository
    {
        Task<Fault> GetByIdAsync(int id);
        Task<IEnumerable<Fault>> GetAllAsync();
        Task AddAsync(Fault fault);
        Task UpdateAsync(Fault fault);
        Task DeleteAsync(int id);
    }
}
