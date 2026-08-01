using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Mapping
{
    public static class EmployeeMappings
    {
        public static EmployeeDto ToDto(this Employee employee) => new()
        {
            Id = employee.Id,
            Name = employee.Name,
            PhoneNumber = employee.PhoneNumber,
            Department = employee.Department,
            Designation = employee.Designation,
            Salary = employee.Salary
        };

        public static void ApplyUpdate(this Employee employee, EmployeeDto dto)
        {
            employee.Name = dto.Name;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Department = dto.Department;
            employee.Designation = dto.Designation;
            employee.Salary = dto.Salary;
        }
    }
}
