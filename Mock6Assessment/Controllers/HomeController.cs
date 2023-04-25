using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mock6Assessment.Models;
using System.Diagnostics;

namespace Mock6Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDbContext _db;

        public HomeController(EmployeeDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var employees = _db.Employees.ToList();
            ViewBag.RetirementLink = Url.Action("RetirementInfo", "Home");
            return View(employees);
        }

        public ActionResult RetirementInfo(int id)
        {
            var employee = _db.Employees.Find(id);
            var retirement = new Retirement();

            if (employee.Age > 60)
            {
                retirement.CanRetire = true;
            }
            else
            {
                retirement.CanRetire = false;
            }

            retirement.Benefits = employee.Salary * 0.6m;

            return View(retirement);
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
}