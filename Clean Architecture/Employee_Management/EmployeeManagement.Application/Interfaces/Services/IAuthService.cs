using EmployeeManagement.Application.Dtos;

namespace EmployeeManagement.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto);
    }
}
