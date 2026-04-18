using Monocept.Models;
using Monocept.Repository.Interfaces;
using Monocept.Services.Interfaces;
using BCrypt.Net;
using System.Threading.Tasks;

namespace Monocept.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IAgentRepository _agentRepo;

        public AdminService(IEmployeeRepository empRepo, IAgentRepository agentRepo)
        {
            _empRepo = empRepo;
            _agentRepo = agentRepo;
        }

        public async Task CreateEmployee(Employee emp)
        {
            emp.Password = BCrypt.Net.BCrypt.HashPassword(emp.Password);
            await _empRepo.Add(emp);
        }

        public async Task CreateAgent(InsuranceAgent agent)
        {
            agent.Password = BCrypt.Net.BCrypt.HashPassword(agent.Password);
            await _agentRepo.Add(agent);
        }
    }
}