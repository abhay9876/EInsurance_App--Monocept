using Microsoft.AspNetCore.Mvc;
using Monocept.Models;
using Monocept.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Monocept.Repository.Interfaces;

namespace Monocept.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IPolicyService _policyService;
        private readonly ISchemeRepository _schemeRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IPolicyRepository _policyRepo;

        public CustomerController(
    ICustomerService service,
    IPolicyService policyService,
    ISchemeRepository schemeRepo,
    ICustomerRepository customerRepo,
    IPolicyRepository policyRepo)
        {
            _service = service;
            _policyService = policyService;
            _schemeRepo = schemeRepo;
            _customerRepo = customerRepo;
            _policyRepo = policyRepo;
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
            var token = HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var email = jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("email"))?.Value;
            var policies = await _policyService.GetCustomerPolicies(email);

            return View(policies);
        }

        public async Task<IActionResult> AvailablePolicies()
        {
            var schemes = await _schemeRepo.GetAll();
            return View(schemes);
        }

        public async Task<IActionResult> BuyPolicy(int id)
        {
            var scheme = await _schemeRepo.GetById(id);

            if (scheme == null)
                return NotFound();

            return View(scheme);
        }

        [HttpPost]
        public async Task<IActionResult> BuyPolicy(Policy policy)
        {
            var token = HttpContext.Session.GetString("JWToken");

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var email = jwt.Claims.FirstOrDefault(c => c.Type.Contains("email"))?.Value;

            var customer = await _customerRepo.GetByEmail(email);
            policy.CustomerID = customer.CustomerID;
            policy.DateIssued = DateTime.Now;
            policy.PolicyLapseDate = DateTime.Now.AddYears(policy.MaturityPeriod);

            await _policyRepo.Add(policy);

            return RedirectToAction("MyPolicies");
        }


    }
}