using Microsoft.AspNetCore.Mvc;
using Monocept.Services.Interfaces;

namespace Monocept.Controllers
{
    public class AdminController : Controller
    {
       
        private readonly IPolicyService _policyService;

        public AdminController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult SearchCustomerPolicies()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchCustomerPolicies(string email)
        {
            var policies = await _policyService.GetPoliciesByCustomerEmail(email);

            ViewBag.Email = email;
            return View("CustomerPoliciesResult", policies);
        }
    }
}