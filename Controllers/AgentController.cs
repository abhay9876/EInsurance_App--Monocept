using Microsoft.AspNetCore.Mvc;

namespace Monocept.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}