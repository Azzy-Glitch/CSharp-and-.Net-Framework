using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Repositories;
using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.Mapping;
using EmployeeManagement.Application.Seed;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => e.ToDto()).ToList();
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return employee?.ToDto();
        }

        public async Task<List<EmployeeDto>> SearchByNameAsync(string name)
        {
            var employees = await _employeeRepository.SearchByNameAsync(name);
            return employees.Select(e => e.ToDto()).ToList();
        }

        public async Task<EmployeeDto?> UpdateAsync(EmployeeDto employeeDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeDto.Id);
            if (employee is null)
                return null;

            employee.ApplyUpdate(employeeDto);
            await _employeeRepository.SaveChangesAsync();

            return employee.ToDto();
        }

        public async Task<List<EmployeeDto>?> DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee is null)
                return null;

            await _employeeRepository.RemoveAsync(employee);
            await _employeeRepository.SaveChangesAsync();

            return await GetAllAsync();
        }

        public async Task ResetAndSeedAsync()
        {
            await _employeeRepository.RemoveAllAsync();
            await _employeeRepository.SaveChangesAsync();
            await _employeeRepository.ResetIdentityAsync();

            await _employeeRepository.AddAsync(EmployeeSeedData.CreateDefaultAdmin());
            await _employeeRepository.SaveChangesAsync();
        }
    }
}
