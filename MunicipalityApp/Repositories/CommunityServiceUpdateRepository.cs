using Microsoft.EntityFrameworkCore;
using MunicipalityApp.Data;
using MunicipalityApp.Models;

namespace MunicipalityApp.Repositories
{
    public class CommunityServiceUpdateRepository : ICommunityServiceUpdateRepository
    {
        private readonly ApplicationDbContext _context;

        public CommunityServiceUpdateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommunityServiceUpdate> GetByIdAsync(int id)
        {
            return await _context.CommunityServiceUpdates.FindAsync(id);
        }

        public async Task<IEnumerable<CommunityServiceUpdate>> GetAllAsync()
        {
            return await _context.CommunityServiceUpdates.ToListAsync();
        }

        public async Task AddAsync(CommunityServiceUpdate update)
        {
            await _context.CommunityServiceUpdates.AddAsync(update);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CommunityServiceUpdate update)
        {
            _context.CommunityServiceUpdates.Update(update);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var update = await GetByIdAsync(id);
            if (update != null)
            {
                _context.CommunityServiceUpdates.Remove(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
