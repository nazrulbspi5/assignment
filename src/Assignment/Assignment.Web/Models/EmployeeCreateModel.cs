using Assignment.Infrastructure.BusinessObjects;
using Assignment.Infrastructure.Services;
using Autofac;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Web.Models
{
    public class EmployeeCreateModel : BaseModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }
       
        [Display(Name = "Manager Id")]
        public int? ManagerId { get; set; }
        [Required]
        public string? Postion { get; set; }
        [Required]
        [Display(Name = "Salary Amount")]
        public decimal SalaryAmount { get; set; }
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }
        public bool IsBonusAdded { get; set; }

        private IEmployeeService? _employeeService;

        public EmployeeCreateModel() : base()
        {

        }
        public EmployeeCreateModel(IEmployeeService employeeService, IMapper mapper) 
        {
            _employeeService = employeeService;
        }
        
        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _employeeService = _scope.Resolve<IEmployeeService>();
        }

        internal async Task CreateEmployee()
        {
            Employee employee = new Employee
            {
                Id = this.Id,
                Name = this.Name,
                JoiningDate = this.JoiningDate,
                ManagerId = this.ManagerId,
                Postion = this.Postion,
                SalaryAmount = this.SalaryAmount,
                IsBonusAdded = this.IsBonusAdded
            };

            _employeeService?.CreateEmployee(employee);
        }
    }
}
