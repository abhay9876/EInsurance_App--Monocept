
using Microsoft.EntityFrameworkCore;
using Monocept.Data;
using Monocept.Models;
using System.Threading.Tasks;

namespace Monocept.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        public AuthRepository(AppDbContext context) => _context = context;

        public async Task<object> FindUserByEmailAsync(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
            if (customer != null) return customer;

            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == email);
            if (admin != null) return admin;

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            if (employee != null) return employee;

            var agent = await _context.InsuranceAgents.FirstOrDefaultAsync(i => i.Email == email);
            return agent;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email == email) ||
                   await _context.Admins.AnyAsync(a => a.Email == email) ||
                   await _context.Employees.AnyAsync(e => e.Email == email) ||
                   await _context.InsuranceAgents.AnyAsync(i => i.Email == email);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}