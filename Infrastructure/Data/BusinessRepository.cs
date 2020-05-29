using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly StoreContext _context;
        public BusinessRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Business> GetBusinessByIdAsync(int id)
        {
            return await _context.Businesses.Include(p => p.BusinessCategory).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Business>> GetBusinessesAsync()
        {
            return await _context.Businesses.ToListAsync();
        }

        public async Task<IReadOnlyList<BusinessCategory>> GetBusinessesCategoriesAsync()
        {
            return await _context.BusinessCategories.ToListAsync();
        }
    }
}