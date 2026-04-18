using Monocept.Repository.Interfaces;
using Monocept.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace Monocept.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAdminRepository _adminRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IAgentRepository _agentRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IConfiguration _config;

        public AuthService(
            IAdminRepository adminRepo,
            ICustomerRepository customerRepo,
            IAgentRepository agentRepo,
            IEmployeeRepository employeeRepo,
            IConfiguration config)
        {
            _adminRepo = adminRepo;
            _customerRepo = customerRepo;
            _agentRepo = agentRepo;
            _employeeRepo = employeeRepo;
            _config = config;
        }

        public async Task<string> Login(string email, string password)
        {
            // Check Admin
            var admin = await _adminRepo.GetByEmail(email);
            if (admin != null )
                return GenerateToken(admin.Email, "Admin");

            // Check Employee
            var emp = await _employeeRepo.GetByEmail(email);
            if (emp != null )
                return GenerateToken(emp.Email, "Employee");

            // Check Agent
            var agent = await _agentRepo.GetByEmail(email);
            if (agent != null)
                return GenerateToken(agent.Email, "Agent");

            // Customer 
            var customer = await _customerRepo.GetByEmail(email);
            if (customer != null && BCrypt.Net.BCrypt.Verify(password, customer.Password))
            {
                return GenerateToken(customer.Email, "Customer");
            }

            return null;
        }

        private string GenerateToken(string email, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}