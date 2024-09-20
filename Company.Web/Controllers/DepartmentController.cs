using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Services;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Company.Service.Interfaces.Department;
using Microsoft.AspNetCore.Authorization;

namespace Company.Web.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) {
        
            _departmentService=departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments=_departmentService.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentDto departmentDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(departmentDto);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);

         
            }
                return View(departmentDto);

        }
   
        public IActionResult Details(int? id , string ViewName="Details")
        {
            var department=_departmentService.GetById(id);
            if(department is null)
                return NotFound();
            return View(ViewName,department);
        }
        public IActionResult Update(int? id)
        {
        return Details(id,"Update");

        }
    [HttpPost]
    public IActionResult Update(int? id ,DepartmentDto departmentDto)
    {
        if (departmentDto.Id != id.Value)
            return NotFound();
        _departmentService.Update(departmentDto);
        return RedirectToAction(nameof(Index));

    }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department is null)
                return NotFound();
            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        }
    }
   

}
