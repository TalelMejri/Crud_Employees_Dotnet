using Microsoft.EntityFrameworkCore;

namespace Employees.Models
{
    public class HRDataBaseContact : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employees> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=Desktop-d1jfgmm\sqlexpress; initial catalog=EmployeesDB; integrated security=SSPI;TrustServerCertificate=True");
        }
    }
}
