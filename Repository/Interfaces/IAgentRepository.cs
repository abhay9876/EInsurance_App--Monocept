using Monocept.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Repository.Interfaces
{
    public interface IAgentRepository
    {
        Task<List<InsuranceAgent>> GetAll();
        Task<InsuranceAgent> GetById(int id);
        Task<InsuranceAgent> GetByEmail(string email);
        Task Add(InsuranceAgent agent);
        Task Delete(int id);
    }
}