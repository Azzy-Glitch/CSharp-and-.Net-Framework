using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<List<Employee>> SearchByNameAsync(string name);
        Task AddAsync(Employee employee);
        Task RemoveAsync(Employee employee);
        Task RemoveAllAsync();
        Task<bool> AnyAsync();
        Task ResetIdentityAsync();
        Task SaveChangesAsync();
    }
}
