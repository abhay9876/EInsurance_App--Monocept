using Microsoft.AspNetCore.Mvc;
using Monocept.Models;
using Monocept.Repository.Interfaces;
using Monocept.Services.Interfaces;

namespace Monocept.Controllers
{
    public class AdminController : Controller
    {
       
        private readonly IPolicyService _policyService;
        private readonly IAdminService _adminService;
        private readonly IEmployeeRepository _empRepo;
        private readonly IAgentRepository _agentRepo;

        public AdminController(IPolicyService policyService, IAdminService adminService,IEmployeeRepository empRepo,IAgentRepository agentRepo)
        {
            _policyService = policyService;
            _adminService = adminService;
            _empRepo = empRepo;
            _agentRepo = agentRepo;
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

        public IActionResult ManageUsers()
        {
            return View();
        }
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee emp)
        {
            await _adminService.CreateEmployee(emp);
            return RedirectToAction("ManageUsers");
        }
        public IActionResult CreateAgent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgent(InsuranceAgent agent)
        {
            await _adminService.CreateAgent(agent);
            return RedirectToAction("ManageUsers");
        }

        public async Task<IActionResult> Employees()
        {
            var employees = await _empRepo.GetAll();
            return View(employees);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _empRepo.Delete(id);
            return RedirectToAction("Employees");
        }

        public async Task<IActionResult> Agents()
        {
            var agents = await _agentRepo.GetAll();
            return View(agents);
        }

       
        public async Task<IActionResult> DeleteAgent(int id)
        {
            await _agentRepo.Delete(id);
            return RedirectToAction("Agents");
        }

        public async Task<IActionResult> EditEmployee(int id)
        {
            var emp = await _empRepo.GetById(id);
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee emp)
        {
            await _empRepo.Update(emp);
            return RedirectToAction("Employees");
        }

        public async Task<IActionResult> EditAgent(int id)
        {
            var agent = await _agentRepo.GetById(id);
            return View(agent);
        }

        [HttpPost]
        public async Task<IActionResult> EditAgent(InsuranceAgent agent)
        {
            await _agentRepo.Update(agent);
            return RedirectToAction("Agents");
        }
    }
}