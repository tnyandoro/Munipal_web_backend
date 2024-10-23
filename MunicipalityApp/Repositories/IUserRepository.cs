using System.Collections.Generic;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
