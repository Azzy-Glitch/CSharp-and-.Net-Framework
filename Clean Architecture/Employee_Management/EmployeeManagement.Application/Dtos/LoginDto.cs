using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.Dtos
{
    public class LoginDto
    {
        public int Id { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [RegularExpression(@"^[A-Z].{7,}$",
            ErrorMessage = "Password must start with a capital letter and be at least 8 characters long.")]
        public required string Password { get; set; }
    }
}
