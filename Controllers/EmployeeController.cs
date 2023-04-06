using Microsoft.AspNetCore.Mvc;
using PayRollSystem.entity;
using PayRollSystem.Models;
using PayRollSystem.services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            employees.Select(e => new EmployeeIndexViewModel()
            {
                Id = e.Id,
                EmployeeNo = e.EmployeeNo,
                FullName = e.FullName,
                Role = e.Role,
                DateJoined = e.DateJoined,
                Gender = e.Gender,
                City = e.City,
            }).ToList();
            return View(employees);

        }
        // Create employee
        [HttpGet]
        public IActionResult Create()
        {
            var employee = new EmployeeCreateViewModel();
            return View(employee);
        }
        [HttpPost]
        public async Task < IActionResult > Create(EmployeeCreateViewModel model)
        {
            var employee = new Employee()
            {
                Address = model.Address,
                City = model.City,
                DateJoined = model.DateJoined,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeNo = model.EmployeeNo,
                FullName = model.FullName,
                Role = model.Role,
                Id = model.Id,
                MiddleName = model.MiddleName,
                NationalInsuranceNo = model.NationalInsuranceNo,
                PaymentMethod = model.PaymentMethod,
                PostCode = model.PostCode,

            };
           await _employeeService.CreateAsync(employee);
           return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var employee = _employeeService.GetById(id);
            if(employee == null)
                return NotFound();
            var employeeViewModel = new EmployeeEditViewModel()
            {
                City = employee.City,
                Address = employee.Address,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                Id = employee.Id,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                PostCode = employee.PostCode,
                Role = employee.Role,
                DateJoined = employee.DateJoined,
            };
            return View(employeeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            var employee = _employeeService.GetById(model.Id);
            if(employee == null) return NotFound(); 
            employee.NationalInsuranceNo = model.NationalInsuranceNo;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.MiddleName = model.MiddleName;
            employee.Email = model.Email;
            employee.Gender = model.Gender;
            employee.Address = model.Address;
            employee.City = model.City;
            employee.EmployeeNo = model.EmployeeNo;
            employee.DateJoined = model.DateJoined;
            employee.Role = model.Role;
            employee.PaymentMethod = model.PaymentMethod;
            employee.DateOfBirth = model.DateOfBirth;
            employee.PostCode = model.PostCode;

            await _employeeService.UpdateAsync(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if(employee == null) return NotFound();
            var model = new EmployeeDetailViewModel()
            {
                City = employee.City,
                Address = employee.Address,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                EmployeeNo = employee.EmployeeNo,
                Id = employee.Id,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                PostCode = employee.PostCode,
                Role = employee.Role,
                DateJoined = employee.DateJoined,
                FullName = employee.FullName,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        { 
            var model = new EmployeeDeleteViewModel() { Id = id };
            return View(model);
        }
        [HttpPost]
        public async Task <IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            await _employeeService.DeleteAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
