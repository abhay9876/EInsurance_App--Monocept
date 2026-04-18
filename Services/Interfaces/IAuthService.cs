using System.Threading.Tasks;

namespace Monocept.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string email, string password);
    }
}