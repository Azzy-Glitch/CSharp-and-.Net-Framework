namespace EmployeeManagement.Application.Dtos
{
    public class RegisterResultDto
    {
        public string Message { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public double Salary { get; set; }
    }
}
