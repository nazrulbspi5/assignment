using Assignment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }
    }
}
