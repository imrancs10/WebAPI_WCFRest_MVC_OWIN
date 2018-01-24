using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EmployeeApi.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext() : base("EmpContext")
        {
        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}