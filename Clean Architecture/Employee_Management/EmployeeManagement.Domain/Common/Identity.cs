using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Common
{
    public class Identity
    {
        [Required]
        public int Id { get; set; }
    }
}
