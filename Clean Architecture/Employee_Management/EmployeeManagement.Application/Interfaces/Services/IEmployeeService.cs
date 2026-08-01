using EmployeeManagement.Application.Dtos;

namespace EmployeeManagement.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<List<EmployeeDto>> SearchByNameAsync(string name);
        Task<EmployeeDto?> UpdateAsync(EmployeeDto employeeDto);
        Task<List<EmployeeDto>?> DeleteAsync(int id);

        Task ResetAndSeedAsync();
    }
}
