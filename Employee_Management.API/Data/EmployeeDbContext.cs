using Employee_Management.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.API.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Login> Logins => Set<Login>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Designation)
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Employee>()
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Login>()
                .Property(x => x.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<Login>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Employee>()
               .HasOne(e => e.Login)
               .WithOne(l => l.Employee)
               .HasForeignKey<Login>(l => l.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}