using Assignment.Infrastructure.DbContexts;
using Assignment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IEmployeeRepository Employees { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IEmployeeRepository employeeRepository) : base((DbContext)dbContext)
        {
            Employees = employeeRepository;
        }
    }
}
