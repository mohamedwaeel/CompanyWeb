using Microsoft.AspNetCore.Mvc;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee;
using Company.Data.Entities;
using Microsoft.AspNetCore.Authorization;
namespace Company.Web.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService) {

            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index(string searchInp)
        {
            ViewBag.Message = "hello from employee index";
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
            {
                 employees=_employeeService.GetAll();
            }
            else
            {
                employees = _employeeService.GetEmployeeByName(searchInp);
            }
            return View(employees);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Department = _departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return View();
        }
    }
}
