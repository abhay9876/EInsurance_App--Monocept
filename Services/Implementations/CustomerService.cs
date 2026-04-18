using Monocept.Models;
using Monocept.Repository.Interfaces;
using Monocept.Services.Interfaces;
using BCrypt.Net;
using System.Threading.Tasks;

namespace Monocept.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task Register(Customer customer)
        {
           
             customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);

            await _repo.Add(customer);
        }
    }
}