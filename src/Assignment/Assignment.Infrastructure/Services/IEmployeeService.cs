using Assignment.Infrastructure.BusinessObjects;

namespace Assignment.Infrastructure.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);      
        void DeleteEmployee(int id);
        void EditEmployee(Employee employee);
        IList<Employee> GetEmployees();
        Task<(int total, int totalDisplay, IList<EmployeeModel> records)> GetEmployees(int pageIndex,
           int pageSize, string searchText,  int? id, string orderby);
        // Employee GetEmployee(int id);
    }
}