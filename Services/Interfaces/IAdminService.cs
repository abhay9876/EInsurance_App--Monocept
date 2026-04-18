using Monocept.Models;
using System.Threading.Tasks;

namespace Monocept.Services.Interfaces
{
    public interface IAdminService
    {
        Task CreateEmployee(Employee emp);
        Task CreateAgent(InsuranceAgent agent);
    }
}