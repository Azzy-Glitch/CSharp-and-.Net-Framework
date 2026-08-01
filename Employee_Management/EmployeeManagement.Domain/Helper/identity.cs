using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Helper
{
    public class Identity
    {
        [Required]
        public int Id { get; set; }
    }
}
