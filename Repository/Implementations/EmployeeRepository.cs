using Microsoft.EntityFrameworkCore;
using Monocept.Data;
using Monocept.Models;
using Monocept.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monocept.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees
                .Include(e => e.EmployeeSchemes)
                .ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees
                .Include(e => e.EmployeeSchemes)
                .FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<Employee> GetByEmail(string email)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task Add(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee emp)
        {
            var existing = await _context.Employees.FindAsync(emp.EmployeeID);

            if (existing != null)
            {
                existing.FullName = emp.FullName;
                existing.Email = emp.Email;
                existing.Username = emp.Username;
                existing.Role = emp.Role;
                await _context.SaveChangesAsync();
            }
            }

        public async Task Delete(int id)
        {
            var emp = await GetById(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}