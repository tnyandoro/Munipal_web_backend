using Microsoft.EntityFrameworkCore;
using MunicipalityApp.Data;
using MunicipalityApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MunicipalityApp.Repositories
{
    public class MeterReaderRepository : IMeterReaderRepository
    {
        private readonly ApplicationDbContext _context;

        public MeterReaderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MeterReader> GetByIdAsync(int id)
        {
            return await _context.MeterReaders.FindAsync(id);
        }

        public async Task<IEnumerable<MeterReader>> GetAllAsync()
        {
            return await _context.MeterReaders.ToListAsync();
        }

        public async Task AddAsync(MeterReader meterReader)
        {
            await _context.MeterReaders.AddAsync(meterReader);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MeterReader meterReader)
        {
            _context.MeterReaders.Update(meterReader);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var meterReader = await GetByIdAsync(id);
            if (meterReader != null)
            {
                _context.MeterReaders.Remove(meterReader);
                await _context.SaveChangesAsync();
            }
        }
    }
}
