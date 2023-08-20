using Assignment.Infrastructure.BusinessObjects;
using Assignment.Infrastructure.UnitOfWorks;

using EmployeeBO = Assignment.Infrastructure.BusinessObjects.Employee;
using EmployeeEO = Assignment.Infrastructure.Entities.Employee;

namespace Assignment.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public EmployeeService( IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public void CreateEmployee(EmployeeBO employee)
        {
            EmployeeEO employeeEntity = new EmployeeEO()
            {
                Id = employee.Id,
                IsBonusAdded = employee.IsBonusAdded,
                SalaryAmount = employee.SalaryAmount,
                Postion = employee.Postion,
                ManagerId = employee.ManagerId,
                JoiningDate = employee.JoiningDate,
                Name = employee.Name
            };
            _applicationUnitOfWork.Employees.Add(employeeEntity);
            _applicationUnitOfWork.Save();
        }

        public void DeleteEmployee(int id)
        {
            _applicationUnitOfWork.Employees.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public void EditEmployee(EmployeeBO employee)
        {
            //var employeeEO = _applicationUnitOfWork.Employees.GetById(employee.Id);
            //if (employeeEO != null)
            //{
            //    employeeEO = _mapper.Map(employee, employeeEO);

            //    _applicationUnitOfWork.Save();
            //}
            //else
            //    throw new InvalidOperationException("Employee was not found");
        }


        //public EmployeeBO GetEmployee(int id)
        //{
        //    var employeeEO = _applicationUnitOfWork.Employees.GetById(id);

        //    //EmployeeBO EmployeeBO = _mapper.Map<EmployeeBO>(employeeEO);

        //    //return EmployeeBO;
        //}

        public async Task<(int total, int totalDisplay, IList<EmployeeModel> records)> GetEmployees(
            int pageIndex, int pageSize, string searchText, int? id, string orderby)
        {
            (IList<EmployeeModel> data, int total, int totalDisplay) results = await _applicationUnitOfWork
                .Employees.GetEmployees(pageIndex, pageSize, searchText, id, orderby);



            return (results.total, results.totalDisplay, results.data);
        }


        public IList<EmployeeBO> GetEmployees()
        {
            var employeesEO = _applicationUnitOfWork.Employees.GetAll();

            IList<EmployeeBO> employees = new List<EmployeeBO>();

            foreach (EmployeeEO employeeEO in employeesEO)
            {
                EmployeeBO employeeBO = new EmployeeBO
                {
                    Id=employeeEO.Id,
                    Name = employeeEO.Name,
                    Postion = employeeEO.Postion,
                    IsBonusAdded=employeeEO.IsBonusAdded,
                    SalaryAmount=employeeEO.SalaryAmount,
                    JoiningDate=employeeEO.JoiningDate,
                    ManagerId=employeeEO.ManagerId,

                };
                employees.Add(employeeBO);
            }

            return employees;
        }
    }
}
