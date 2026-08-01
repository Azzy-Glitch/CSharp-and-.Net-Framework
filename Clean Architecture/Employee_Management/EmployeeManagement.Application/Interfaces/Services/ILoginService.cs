using EmployeeManagement.Application.Dtos;

namespace EmployeeManagement.Application.Interfaces.Services
{
    public interface ILoginService
    {
        Task<List<LoginSummaryDto>> GetAllAsync();
        Task<LoginSummaryDto?> UpdateAsync(int id, LoginDto loginDto);
        Task<bool> DeleteAsync(int id);
        Task ResetAndSeedAsync();
    }
}
