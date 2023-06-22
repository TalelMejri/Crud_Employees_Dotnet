using Microsoft.AspNetCore.Mvc;
using Employees.Models; // app > models to use dbcontext
namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {

        HRDataBaseContact dbContext=new HRDataBaseContact();
        public IActionResult Index()
        {
            List<Models.Employees> employee=dbContext.Employees.ToList(); // because i used name app some name model (Models.Employees) to fix it
            return View(employee);
        }
    }
}
