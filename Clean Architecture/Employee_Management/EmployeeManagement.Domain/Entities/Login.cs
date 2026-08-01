using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entities
{
    public class Login : Identity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
