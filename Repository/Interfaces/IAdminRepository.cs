using Monocept.Models;
using System.Threading.Tasks;

namespace Monocept.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin> GetByEmail(string email);
        Task Add(Admin admin);
    }
}