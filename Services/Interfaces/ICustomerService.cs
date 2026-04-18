using Monocept.Models;
using System.Threading.Tasks;

namespace Monocept.Services.Interfaces
{
    public interface ICustomerService
    {
        Task Register(Customer customer);
    }
}