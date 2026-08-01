using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Repositories;
using EmployeeManagement.Application.Interfaces.Security;
using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.Mapping;
using EmployeeManagement.Application.Seed;

namespace EmployeeManagement.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IPasswordHasher _passwordHasher;

        public LoginService(ILoginRepository loginRepository, IPasswordHasher passwordHasher)
        {
            _loginRepository = loginRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<List<LoginSummaryDto>> GetAllAsync()
        {
            var logins = await _loginRepository.GetAllAsync();
            return logins.Select(l => l.ToSummaryDto()).ToList();
        }

        public async Task<LoginSummaryDto?> UpdateAsync(int id, LoginDto loginDto)
        {
            var login = await _loginRepository.GetByIdAsync(id);
            if (login is null)
                return null;

            login.Email = loginDto.Email;
            login.PasswordHash = _passwordHasher.Hash(loginDto.Password);

            await _loginRepository.SaveChangesAsync();

            return login.ToSummaryDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var login = await _loginRepository.GetByIdAsync(id);
            if (login is null)
                return false;

            await _loginRepository.RemoveAsync(login);
            await _loginRepository.SaveChangesAsync();

            return true;
        }

        public async Task ResetAndSeedAsync()
        {
            await _loginRepository.RemoveAllAsync();
            await _loginRepository.SaveChangesAsync();
            await _loginRepository.ResetIdentityAsync();

            await _loginRepository.AddAsync(LoginSeedData.CreateDefaultLogin());
            await _loginRepository.SaveChangesAsync();
        }
    }
}
