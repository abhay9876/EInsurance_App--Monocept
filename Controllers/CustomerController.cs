using Microsoft.AspNetCore.Mvc;
using Monocept.Models;
using Monocept.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace Monocept.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IPolicyService _policyService;

        public CustomerController(ICustomerService service, IPolicyService policyService)
        {
            _service = service;
            _policyService = policyService;
        }
        
        // GET: Register Page
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register Form
        [HttpPost]
        public async Task<IActionResult> Register(Customer customer)
        {
            await _service.Register(customer);

            ViewBag.Message = "Registration Successful!";
            return View();
        }


        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> MyPolicies()
        {
            // 1. Get token from session
            var token = HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            // 2. Decode token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var email = jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("email"))?.Value;

            // 3. Get policies
            var policies = await _policyService.GetCustomerPolicies(email);

            return View(policies);
        }
    }
}