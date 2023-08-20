using Assignment.Infrastructure.BusinessObjects;

using Assignment.Infrastructure.Services;
using Autofac;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Assignment.Web.Models
{
    public class EmployeeListModel : BaseModel
    {
        public EmployeeSearch EmployeeSearchItem { get; set; }
        //public int Id { get; set; }
        //[Required]
        //[Display(Name = "Name")]
        //public string? Name { get; set; }

        //[Display(Name = "Manager Id")]
        //public int? ManagerId { get; set; }
        //[Required]
        //public string? Postion { get; set; }
        //[Required]
        //[Display(Name = "Salary Amount")]
        //public decimal SalaryAmount { get; set; }
        //[Display(Name = "Joining Date")]
        //public DateTime JoiningDate { get; set; }
        //public bool IsBonusAdded { get; set; }

        private IEmployeeService? _employeeService;

        public EmployeeListModel() : base() { }

        public EmployeeListModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _employeeService = _scope.Resolve<IEmployeeService>();
        }

        internal async Task<object?> GetEmployeesPagedData(DataTablesAjaxRequestModel dataTablesModel)
        {

            var data = await _employeeService.GetEmployees(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                EmployeeSearchItem.Id,
                dataTablesModel.GetSortText(new string[] { "Id", "Name", "Position", "SalaryAmount", "JoiningDate" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name.ToString(),
                                record.Postion.ToString(),
                                record.SalaryAmount.ToString(),
                                record.JoiningDate.ToString(),
                        }
                    ).ToArray()
            };
        }
        internal IList<EmployeeListModel> GetEmployees()
        {
            IList<EmployeeListModel> employees = new List<EmployeeListModel>();

            var employeeList = _employeeService?.GetEmployees();
            foreach (Employee employeeBO in employeeList)
            {
                EmployeeListModel employee = new EmployeeListModel
                {
                    //Id = employeeBO.Id,
                    //Name = employeeBO.Name,
                    //Postion = employeeBO.Postion,
                    //IsBonusAdded = employeeBO.IsBonusAdded,
                    //SalaryAmount = employeeBO.SalaryAmount,
                    //JoiningDate = employeeBO.JoiningDate,
                    //ManagerId = employeeBO.ManagerId,

                };
                employees.Add(employee);


            }
            return employees;
        }
    }
}