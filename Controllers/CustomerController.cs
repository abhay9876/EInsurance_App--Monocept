using Microsoft.AspNetCore.Mvc;
using Monocept.Models;
using Monocept.Services.Interfaces;

namespace Monocept.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
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
    }
}