using EmployeeManagement.Application.Interfaces.Repositories;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync() =>
            await _context.Employees.ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) =>
            await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Employee>> SearchByNameAsync(string name) =>
            await _context.Employees
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

        public async Task AddAsync(Employee employee) =>
            await _context.Employees.AddAsync(employee);

        public Task RemoveAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            return Task.CompletedTask;
        }

        public async Task RemoveAllAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            _context.Employees.RemoveRange(employees);
        }

        public async Task<bool> AnyAsync() => await _context.Employees.AnyAsync();

        public async Task ResetIdentityAsync() =>
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Employees', RESEED, 0)");

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
