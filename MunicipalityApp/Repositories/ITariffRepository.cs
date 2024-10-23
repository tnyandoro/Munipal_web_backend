using System.Collections.Generic;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface ITariffRepository
    {
        Task<Tariff> GetByIdAsync(int id);
        Task<IEnumerable<Tariff>> GetAllAsync();
        Task AddAsync(Tariff tariff);
        Task UpdateAsync(Tariff tariff);
        Task DeleteAsync(int id);
    }
}
