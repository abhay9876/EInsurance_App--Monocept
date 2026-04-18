using Microsoft.EntityFrameworkCore;
using Monocept.Data;
using Monocept.Models;
using Monocept.Repository.Interfaces;
using System.Threading.Tasks;

namespace Monocept.Repository.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> GetByEmail(string email)
        {
            return await _context.Admins
                .FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task Add(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }
    }
}