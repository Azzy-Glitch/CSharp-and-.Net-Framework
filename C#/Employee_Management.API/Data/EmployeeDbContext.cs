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

            //modelBuilder.Entity<Login>().HasData(
            //    new Login
            //    {
            //        Id = 1,
            //        Email = "admin@test.com",
            //        Password = "admin123"
            //    });

                    //modelBuilder.Entity<Employee>().HasData(
                    //    new Employee
                    //    {
                    //        Id = 1,
                    //        Name = "Ali",
                    //        Email = "ali@gmail.com",
                    //        Designation = "Software Engineer",
                    //        Department = "IT",
                    //        Salary = 50000,
                    //        IsDeleted = false
                    //    },
                    //    new Employee
                    //    {
                    //        Id = 2,
                    //        Name = "Ahmed",
                    //        Email = "ahmed@gmail.com",
                    //        Designation = "HR Manager",
                    //        Department = "Human Resources",
                    //        Salary = 40000,
                    //        IsDeleted = false
                    //    },
                    //    new Employee
                    //    {
                    //        Id = 3,
                    //        Name = "Sara",
                    //        Email = "sara@gmail.com",
                    //        Designation = "Finance Officer",
                    //        Department = "Finance",
                    //        Salary = 60000,
                    //        IsDeleted = false
                    //    }
                    //);
                }
    }
}