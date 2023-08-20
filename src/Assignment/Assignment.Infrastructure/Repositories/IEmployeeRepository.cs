using Assignment.Infrastructure.Entities;

using EmployeeModel = Assignment.Infrastructure.BusinessObjects.EmployeeModel;

namespace Assignment.Infrastructure.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
        Task<(IList<EmployeeModel> data, int total, int totalDisplay)> GetEmployees(int pageIndex,
           int pageSize, string searchText, int? id, string orderby);
    }
    
}
