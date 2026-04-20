using Microsoft.EntityFrameworkCore;
using Monocept.Data;
using Monocept.Models;
using Monocept.Repository.Interfaces;

namespace Monocept.Repository.Implementations
{
    public class SchemeRepository : ISchemeRepository
    {
        private readonly AppDbContext _context;

        public SchemeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Scheme>> GetAll()
        {
            return await _context.Schemes.ToListAsync();
        }

        public async Task<Scheme> GetById(int id)
        {
            return await _context.Schemes.FindAsync(id);
        }
    }
}