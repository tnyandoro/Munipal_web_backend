using Microsoft.EntityFrameworkCore;
using MunicipalityApp.Data;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly ApplicationDbContext _context;

        public BillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Bill> GetByIdAsync(int id)
        {
            return await _context.Bills.FindAsync(id);
        }

        public async Task<IEnumerable<Bill>> GetAllAsync()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task AddAsync(Bill bill)
        {
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bill = await GetByIdAsync(id);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
            }
        }
    }
}
