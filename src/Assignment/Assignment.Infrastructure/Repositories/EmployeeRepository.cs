
using Assignment.Infrastructure.DbContexts;
using Assignment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeModel = Assignment.Infrastructure.BusinessObjects.EmployeeModel;
namespace Assignment.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
        public async Task<(IList<EmployeeModel> data, int total, int totalDisplay)> GetEmployees(
          int pageIndex, int pageSize, string searchText, int? id, string orderby)
        {
            var result = await QueryWithStoredProcedureAsync<EmployeeModel>("proc_GetEmployees", new Dictionary<string, object>
            {
                {"Id", id},
                {"PageIndex", pageIndex},
                {"PageSize", pageSize},
                {"SearchText", searchText},
                {"OrderBy", orderby }
            },
            new Dictionary<string, Type>
            {
                {"Total", typeof(int)},
                {"TotalDisplay", typeof(int)}
            });

            return (result.result, int.Parse(result.outValues.ElementAt(0).Value.ToString()), int.Parse(result.outValues.ElementAt(1).Value.ToString()));
        }

    }
}
