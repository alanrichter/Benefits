using Benefits.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Benefits.DbContexts
{
    public class BenefitsContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Benefits");
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Dependent> Dependents { get; set; }
    }
}
