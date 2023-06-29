using Microsoft.AspNetCore.Mvc;
using Employees.Models; // app > models to use dbcontext
namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
       // private readonly HRDataBaseContact dbContext;

       /* public EmployeeController(HRDataBaseContact context)
        {
            dbContext = context;
        }*/

       HRDataBaseContact dbContext=new HRDataBaseContact();
        public IActionResult Index(String searchString)
        {
            //List<Models.Employees> employee=dbContext.Employees.ToList(); // because i used name app some name model (Models.Employees) to fix it
            var employees = (from employee in dbContext.Employees
                             join Department in dbContext.Departments on employee.DepartmentId equals Department.DepartmentId
                             select new Models.Employees
                             {
                                 EmployeeID = employee.EmployeeID,
                                 EmployeeName = employee.EmployeeName,
                                 EmployeeNumber = employee.EmployeeNumber,
                                 DOB = employee.DOB,
                                 GrossSalary = employee.GrossSalary,
                                 NetSalary = employee.NetSalary,
                                 HiringBirth = employee.HiringBirth,
                                 DepartmentId = employee.DepartmentId,
                                 DepartmentName = Department.DepartmentName,
                             }).ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.EmployeeName.Contains(searchString)).ToList();
            }
            
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Department = dbContext.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Employees Model)
        {
            ModelState.Remove("EmployeeID");
            ModelState.Remove("Department");
            ModelState.Remove("DepartmentName");
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(Model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = dbContext.Departments.ToList();
            return View();
        }
        public IActionResult Edit(int id)
        {
            Models.Employees data=dbContext.Employees.Where(e=>e.EmployeeID==id).FirstOrDefault();
            ViewBag.Department = dbContext.Departments.ToList();
            return View("Create",data);
        }

        [HttpPost]
        public IActionResult Edit(Models.Employees model)
        {
            ModelState.Remove("EmployeeID");
            ModelState.Remove("Department");
            ModelState.Remove("DepartmentName");
            if (ModelState.IsValid)
            {
                dbContext.Employees.Update(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = dbContext.Departments.ToList();
            return View("create",model);
        }

        public IActionResult Delete(int id)
        {
            Models.Employees data = dbContext.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            if (data != null)
            {
                dbContext.Employees.Remove(data);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
