using Microsoft.AspNetCore.Mvc;

namespace Monocept.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}