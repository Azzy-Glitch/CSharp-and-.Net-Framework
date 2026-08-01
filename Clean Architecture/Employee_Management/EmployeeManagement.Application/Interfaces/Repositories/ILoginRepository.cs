using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAllAsync();
        Task<Login?> GetByIdAsync(int id);
        Task<Login?> GetByEmailAsync(string email);
        Task AddAsync(Login login);
        Task RemoveAsync(Login login);
        Task RemoveAllAsync();
        Task<bool> AnyAsync();

        Task ResetIdentityAsync();

        Task SaveChangesAsync();
    }
}
