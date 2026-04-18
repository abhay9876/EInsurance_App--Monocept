using Monocept.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> GetByEmail(string email);
        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(int id);
    }
}