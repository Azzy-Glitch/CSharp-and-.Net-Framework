using Employee_Management.API.Helper;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.API.Model
{
    public class EmployeeDto: Identity
    {
        public required string Name { get; set; }
        [RegularExpression(@"^(\+92|0)3\d{9}$", ErrorMessage = "Phone number must start with 03 and be 11 digits.")]
        public required string phonenumber { get; set; }
        public required string Department { get; set; }
        public required string Designation { get; set; }
        public required double Salary { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}