using EmployeeApplication.Business.Entities;
using EmployeeApplication.Business.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeService;
        public EmployeeController()
        {
        }
        public EmployeeController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<ActionResult> Index()
        {
            List<Employee> employees = await _employeeService.GetEmployees();
            return View(employees);
        }
        public async Task<ActionResult> Details()
        {
            Employee employee = await _employeeService.GetEmployeeById(1);
            return View(employee);
        }
    }
}
