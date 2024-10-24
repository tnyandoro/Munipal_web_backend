using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Bill?> GetByIdAsync(int id)
        {
            return await _context
                .Bills.Include(b => b.Customer) // Include customer if needed
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Bill>> GetAllAsync()
        {
            return await _context
                .Bills.Include(b => b.Customer) // Include customer if needed
                .ToListAsync();
        }

        public async Task AddAsync(Bill bill)
        {
            // Validate that the customer exists
            var customerExists = await _context.Customers.AsNoTracking().AnyAsync(c => c.Id == bill.CustomerId);
            if (!customerExists)
            {
                throw new ArgumentException("Invalid Customer ID.");
            }

            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bill bill)
        {
            // Check if the bill exists
            var existingBill = await GetByIdAsync(bill.Id);
            if (existingBill == null)
            {
                throw new ArgumentException("Bill not found.");
            }

            // Ensure CustomerId is valid
            var customerExists = await _context.Customers.AsNoTracking().AnyAsync(c => c.Id == bill.CustomerId);
            if (!customerExists)
            {
                throw new ArgumentException("Invalid Customer ID.");
            }

            _context.Entry(existingBill).CurrentValues.SetValues(bill); // Use this to avoid tracking issues
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
