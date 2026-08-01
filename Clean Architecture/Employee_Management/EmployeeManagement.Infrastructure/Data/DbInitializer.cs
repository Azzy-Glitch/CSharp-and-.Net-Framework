using EmployeeManagement.Application.Seed;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedEmployees(EmployeeDbContext context)
        {
            if (await context.Employees.AnyAsync())
                return;

            await context.Employees.AddAsync(EmployeeSeedData.CreateDefaultAdmin());
            await context.SaveChangesAsync();
        }

        public static async Task SeedLogins(EmployeeDbContext context)
        {
            if (await context.Logins.AnyAsync())
                return;

            await context.Logins.AddAsync(LoginSeedData.CreateDefaultLogin());
            await context.SaveChangesAsync();
        }
    }
}
