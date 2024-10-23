using Microsoft.EntityFrameworkCore;
using MunicipalityApp.Data;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public class MeterRepository : IMeterRepository
    {
        private readonly ApplicationDbContext _context;

        public MeterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Meter> GetByIdAsync(int id)
        {
            return await _context.Meters.FindAsync(id);
        }

        public async Task<IEnumerable<Meter>> GetAllAsync()
        {
            return await _context.Meters.ToListAsync();
        }

        public async Task AddAsync(Meter meter)
        {
            await _context.Meters.AddAsync(meter);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Meter meter)
        {
            _context.Meters.Update(meter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var meter = await GetByIdAsync(id);
            if (meter != null)
            {
                _context.Meters.Remove(meter);
                await _context.SaveChangesAsync();
            }
        }
    }
}
