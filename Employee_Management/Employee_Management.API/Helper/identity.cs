using System.ComponentModel.DataAnnotations;

namespace Employee_Management.API.Helper
{
    public class Identity
    {
        [Required]
        public int Id { get; set; }
    }
}
