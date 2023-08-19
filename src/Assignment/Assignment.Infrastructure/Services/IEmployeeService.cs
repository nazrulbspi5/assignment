using Assignment.Infrastructure.BusinessObjects;

namespace Assignment.Infrastructure.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);      
        void DeleteEmployee(int id);
        void EditEmployee(Employee employee);
        IList<Employee> GetEmployees();
       // Employee GetEmployee(int id);
    }
}