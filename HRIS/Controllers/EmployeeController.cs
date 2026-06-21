using HRIS.Data;
using HRIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace HRIS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searchEmployee)
        {
            // 1. Starts with a query for ALL employees
            var employees = from e in _context.Employees select e;

            // 2. If searchString is EMPTY, this IF statement evaluates to FALSE
            if (!string.IsNullOrEmpty(searchEmployee))
            {
                // This filtering block is completely skipped!
                employees = employees.Where(e => e.FirstName == searchEmployee);
                return View(employees.ToList());
            }
            return View(_context.Employees.ToList());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            _context.Employees.Add(employee);
           _context.SaveChanges();
        
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
                             
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {

            var employee = _context.Employees.Find(id);

            if(employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }



            return View();
        }
    }
}
