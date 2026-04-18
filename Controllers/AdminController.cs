using Microsoft.AspNetCore.Mvc;

namespace Monocept.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}