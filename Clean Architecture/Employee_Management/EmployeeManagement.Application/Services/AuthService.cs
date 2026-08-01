using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Repositories;
using EmployeeManagement.Application.Interfaces.Security;
using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IEmployeeRepository employeeRepository, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto)
        {
            var login = new Login
            {
                Email = registerDto.Email,
                PasswordHash = _passwordHasher.Hash(registerDto.Password)
            };

            var employee = new Employee
            {
                Name = registerDto.Name,
                Department = registerDto.Department,
                Designation = registerDto.Designation,
                Salary = (double)registerDto.Salary,
                PhoneNumber = registerDto.PhoneNumber,
                Login = login
            };

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();

            return new RegisterResultDto
            {
                Message = "Registration Successful",
                EmployeeId = employee.Id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Department = employee.Department,
                Designation = employee.Designation,
                Salary = employee.Salary
            };
        }
    }
}
