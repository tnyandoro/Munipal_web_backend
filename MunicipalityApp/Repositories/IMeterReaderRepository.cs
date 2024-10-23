using System.Collections.Generic;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface IMeterReaderRepository
    {
        Task<MeterReader> GetByIdAsync(int id);
        Task<IEnumerable<MeterReader>> GetAllAsync();
        Task AddAsync(MeterReader meterReader);
        Task UpdateAsync(MeterReader meterReader);
        Task DeleteAsync(int id);
    }
}
