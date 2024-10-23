using Microsoft.EntityFrameworkCore;
using MunicipalityApp.Data;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public class FaultRepository : IFaultRepository
    {
        private readonly ApplicationDbContext _context;

        public FaultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fault> GetByIdAsync(int id)
        {
            return await _context.Faults.FindAsync(id);
        }

        public async Task<IEnumerable<Fault>> GetAllAsync()
        {
            return await _context.Faults.ToListAsync();
        }

        public async Task AddAsync(Fault fault)
        {
            await _context.Faults.AddAsync(fault);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fault fault)
        {
            _context.Faults.Update(fault);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fault = await GetByIdAsync(id);
            if (fault != null)
            {
                _context.Faults.Remove(fault);
                await _context.SaveChangesAsync();
            }
        }
    }
}
