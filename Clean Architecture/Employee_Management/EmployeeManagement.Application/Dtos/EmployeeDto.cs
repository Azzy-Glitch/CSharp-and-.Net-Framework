using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        [RegularExpression(@"^(\+92|0)3\d{9}$", ErrorMessage = "Phone number must start with 03 and be 11 digits.")]
        public required string PhoneNumber { get; set; }

        public required string Department { get; set; }
        public required string Designation { get; set; }
        public required double Salary { get; set; }
    }
}
