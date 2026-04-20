using Monocept.Models;

namespace Monocept.Repository.Interfaces
{
    public interface ISchemeRepository
    {
        Task<List<Scheme>> GetAll();
        Task<Scheme> GetById(int id);
    }
}