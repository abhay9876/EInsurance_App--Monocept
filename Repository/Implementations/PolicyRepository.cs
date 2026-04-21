using Microsoft.EntityFrameworkCore;
using Monocept.Data;
using Monocept.Models;
using Monocept.Repository.Interfaces;

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

        public async Task<List<Policy>> GetPoliciesByCustomerIds(List<int> customerIds)
        {
            return await _context.Policies
                .Where(p => customerIds.Contains(p.CustomerID))
                .ToListAsync();
        }

        public async Task<List<Policy>> GetAll()
        {
            return await _context.Policies
                .Include(p => p.Scheme)
                .ToListAsync();
        }

        public async Task<Policy> GetById(int id)
        {
            return await _context.Policies
                .Include(p => p.Scheme)
                .FirstOrDefaultAsync(p => p.PolicyID == id);
        }
        public async Task Add(Policy policy)
        {
            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Policy policy)
        {
            var existing = await _context.Policies.FindAsync(policy.PolicyID);

            if (existing != null)
            {
                existing.PolicyDetails = policy.PolicyDetails;
                existing.Premium = policy.Premium;
                existing.MaturityPeriod = policy.MaturityPeriod;

                await _context.SaveChangesAsync();
            }
        }

   
        public async Task Delete(int id)
        {
            var policy = await _context.Policies.FindAsync(id);

            if (policy != null)
            {
                _context.Policies.Remove(policy);
                await _context.SaveChangesAsync();
            }
        }
    }
}