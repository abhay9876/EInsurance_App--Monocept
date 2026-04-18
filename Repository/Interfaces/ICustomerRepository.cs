using Monocept.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> GetByEmail(string email);
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Delete(int id);
    }
}