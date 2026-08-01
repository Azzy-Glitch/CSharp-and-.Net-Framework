using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Mapping
{
    public static class LoginMappings
    {
        public static LoginSummaryDto ToSummaryDto(this Login login) => new()
        {
            Id = login.Id,
            Email = login.Email
        };
    }
}
