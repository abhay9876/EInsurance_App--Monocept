using Monocept.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Repository.Interfaces
{
    public interface IPolicyRepository
    {
        Task<List<Policy>> GetPoliciesByCustomerId(int customerId);
        Task<List<Policy>> GetPoliciesByCustomerIds(List<int> customerIds);

        Task<List<Policy>> GetAll();

        Task<Policy> GetById(int id);

        Task Add(Policy policy);

        Task Update(Policy policy);

        Task Delete(int id);
    }
}