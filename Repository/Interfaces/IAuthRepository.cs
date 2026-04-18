using Monocept.Models;
using System.Threading.Tasks;

namespace Monocept.Repository
{
    public interface IAuthRepository
    {
        Task<object> FindUserByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}