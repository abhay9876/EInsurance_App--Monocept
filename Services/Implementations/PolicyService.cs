using Monocept.Models;
using Monocept.Repository.Interfaces;
using Monocept.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Services.Implementations
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepo;
        private readonly ICustomerRepository _customerRepo;

        public PolicyService(IPolicyRepository policyRepo, ICustomerRepository customerRepo)
        {
            _policyRepo = policyRepo;
            _customerRepo = customerRepo;
        }

        public async Task<List<Policy>> GetCustomerPolicies(string email)
        {
            var customer = await _customerRepo.GetByEmail(email);

            if (customer == null)
                return new List<Policy>();
            return await _policyRepo.GetPoliciesByCustomerId(customer.CustomerID);
        }


        public async Task<List<Policy>> GetPoliciesByCustomerEmail(string email)
        {
            var customer = await _customerRepo.GetByEmail(email);

            if (customer == null)
                return new List<Policy>();

            return await _policyRepo.GetPoliciesByCustomerId(customer.CustomerID);
        }
    }
}