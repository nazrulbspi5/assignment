using Assignment.Infrastructure.Services;
using Assignment.Web.Models;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assignment.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILifetimeScope _scope;

        public EmployeeController(ILifetimeScope scope)
        {
            _scope = scope;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddEmployee()
        {
            EmployeeCreateModel model = _scope.Resolve<EmployeeCreateModel>();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(EmployeeCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                try
                {
                    await model.CreateEmployee();
                    
                    return RedirectToAction("Index");
                }               
                catch (Exception ex)
                {
                    
                }
            }            
            return View(model);
        }

    }
}
