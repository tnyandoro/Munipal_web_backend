using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public interface ICustomerRepository
    {
         Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
        
    
}