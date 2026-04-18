using Microsoft.EntityFrameworkCore;
using Monocept.Data;
using Monocept.Models;
using Monocept.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Repository.Implementations
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext _context;

        public AgentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InsuranceAgent>> GetAll()
        {
            return await _context.InsuranceAgents.ToListAsync();
        }

        public async Task<InsuranceAgent> GetById(int id)
        {
            return await _context.InsuranceAgents
                .FirstOrDefaultAsync(a => a.AgentID == id);
        }

        public async Task<InsuranceAgent> GetByEmail(string email)
        {
            return await _context.InsuranceAgents
                .FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task Add(InsuranceAgent agent)
        {
            await _context.InsuranceAgents.AddAsync(agent);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var agent = await GetById(id);
            if (agent != null)
            {
                _context.InsuranceAgents.Remove(agent);
                await _context.SaveChangesAsync();
            }
        }
    }
}