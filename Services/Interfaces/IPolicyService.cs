using Monocept.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<List<Policy>> GetCustomerPolicies(string email);
        Task<List<Policy>> GetPoliciesByCustomerEmail(string email);
    }
}