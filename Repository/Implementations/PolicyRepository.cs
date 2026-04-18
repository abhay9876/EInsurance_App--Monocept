using Microsoft.EntityFrameworkCore;
using Monocept.Data;
using Monocept.Models;
using Monocept.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monocept.Repository.Implementations
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly AppDbContext _context;

        public PolicyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Policy>> GetPoliciesByCustomerId(int customerId)
        {
            return await _context.Policies
                .Where(p => p.CustomerID == customerId)
                .Include(p => p.Scheme)
                .Include(p => p.Payments)
                .ToListAsync();
        }
    }
}