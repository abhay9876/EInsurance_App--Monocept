using Monocept.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Repository.Interfaces
{
    public interface IPolicyRepository
    {
        Task<List<Policy>> GetPoliciesByCustomerId(int customerId);
    }
}