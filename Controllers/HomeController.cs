using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Controllers;

public class HomeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public HomeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        
    }
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Employee> listOfEmployee = _employeeRepository.GetAllEmployee();
        return View(listOfEmployee);
    }

    [HttpGet]
    public IActionResult Create(){
        return View();
    }
    [HttpPost]
    public IActionResult Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department
                };
                _employeeRepository.AddEmployee(emp);
                return RedirectToAction("index", "home");
            }
            return View();

        }


    [HttpGet]
    public IActionResult Details(int id){
        Employee employee = _employeeRepository.GetEmployee(id);
        return View(employee);
    }

    [HttpGet]
    public IActionResult Edit(int id){
        Employee employee = _employeeRepository.GetEmployee(id);
        EditEmployeeViewModel model = new EditEmployeeViewModel(){
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Department = employee.Department
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(EditEmployeeViewModel model){
        Employee employee = new Employee(){
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
            Department = model.Department
        };
        _employeeRepository.EditEmployee(employee);
        return RedirectToAction("index");
    }

    [HttpGet]
    public IActionResult Delete(int id){
        // return View("Index");
        _employeeRepository.DeleteEmployee(id);
        return RedirectToAction("index");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
