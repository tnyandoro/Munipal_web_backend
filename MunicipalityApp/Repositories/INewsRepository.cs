using System.Collections.Generic;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface INewsRepository
    {
        Task<News> GetByIdAsync(int id);
        Task<IEnumerable<News>> GetAllAsync();
        Task AddAsync(News news);
        Task UpdateAsync(News news);
        Task DeleteAsync(int id);
    }
}
