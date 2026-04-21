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
        private readonly ICustomerRepository _customerRepo;
        private readonly IPolicyRepository _policyRepo;

        public AdminService(IEmployeeRepository empRepo, IAgentRepository agentRepo, ICustomerRepository customerRepo, IPolicyRepository policyRepo)
        {
            _empRepo = empRepo;
            _agentRepo = agentRepo;
            _customerRepo = customerRepo;
            _policyRepo = policyRepo;
        }

        public async Task CreateEmployee(Employee emp)
        {
            //emp.Password = BCrypt.Net.BCrypt.HashPassword(emp.Password);
            await _empRepo.Add(emp);
        }

        public async Task CreateAgent(InsuranceAgent agent)
        {
            //agent.Password = BCrypt.Net.BCrypt.HashPassword(agent.Password);
            await _agentRepo.Add(agent);
        }


        public async Task<(double total, double commission)> CalculateCommission(int agentId)
        {
            var customers = await _customerRepo.GetAllByAgentID(agentId);

            var customerIds = customers.Select(c => c.CustomerID).ToList();

            var policies = await _policyRepo.GetPoliciesByCustomerIds(customerIds);

            double total = (double)policies.Sum(p => p.Premium);
            double commission = total * 0.10;

            return (total, commission);
        }
    }
}