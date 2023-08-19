
using Assignment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        //{
            
        //}
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
