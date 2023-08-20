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
            EmployeeListModel model = _scope.Resolve<EmployeeListModel>();
            return View(model.GetEmployees());

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

        public async Task<JsonResult> GetEmployeeData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<EmployeeListModel>();
            model.EmployeeSearchItem = _scope.Resolve<EmployeeSearch>();           
            if(!string.IsNullOrWhiteSpace(Request.Query["SearchItem[Id]"].FirstOrDefault()))
                model.EmployeeSearchItem.Id= int.Parse(Request.Query["SearchItem[Id]"].FirstOrDefault());

           

            return Json(await model.GetEmployeesPagedData(dataTableModel));
        }

    }
}
