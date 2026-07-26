using Employee_Management.API.Helper;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.API.Model
{
    public class Login : Identity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public Employee? Employee { get; set; }
    }
}
