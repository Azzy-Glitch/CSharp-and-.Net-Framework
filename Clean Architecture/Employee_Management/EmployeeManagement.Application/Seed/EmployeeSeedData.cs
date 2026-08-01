using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Seed
{
    public static class EmployeeSeedData
    {
        public static Employee CreateDefaultAdmin() => new()
        {
            Name = "Admin",
            Department = "IT",
            Designation = "Manager",
            Salary = 99090
        };
    }
}
