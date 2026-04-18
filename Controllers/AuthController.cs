using Microsoft.AspNetCore.Mvc;
using Monocept.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Monocept.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: Login Page
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login Form Submit
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var token = await _authService.Login(Email, Password);

            if (token == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View();
            }

            HttpContext.Session.SetString("JWToken", token);

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var role = jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("role"))?.Value;
            if (role == "Admin")
                return RedirectToAction("Dashboard", "Admin");

            if (role == "Employee")
                return RedirectToAction("Dashboard", "Employee");

            if (role == "Agent")
                return RedirectToAction("Dashboard", "Agent");

            if (role == "Customer")
                return RedirectToAction("Dashboard", "Customer");

            return RedirectToAction("Login");
        }
    }
}