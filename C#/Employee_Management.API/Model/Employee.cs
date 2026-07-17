using Employee_Management.API.Helper;

namespace Employee_Management.API.Model
{
    public class Employee : Audittrial
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;  
        public double Salary { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
    }
}