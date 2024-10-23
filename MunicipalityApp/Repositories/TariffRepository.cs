using Microsoft.EntityFrameworkCore;
using MunicipalityApp.Data;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public class TariffRepository : ITariffRepository
    {
        private readonly ApplicationDbContext _context;

        public TariffRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tariff> GetByIdAsync(int id)
        {
            return await _context.Tariffs.FindAsync(id);
        }

        public async Task<IEnumerable<Tariff>> GetAllAsync()
        {
            return await _context.Tariffs.ToListAsync();
        }

        public async Task AddAsync(Tariff tariff)
        {
            await _context.Tariffs.AddAsync(tariff);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tariff tariff)
        {
            _context.Tariffs.Update(tariff);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tariff = await GetByIdAsync(id);
            if (tariff != null)
            {
                _context.Tariffs.Remove(tariff);
                await _context.SaveChangesAsync();
            }
        }
    }
}
