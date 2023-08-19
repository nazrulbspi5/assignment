using Assignment.Infrastructure.Repositories;

namespace Assignment.Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
    }
}