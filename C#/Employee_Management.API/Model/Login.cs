using Employee_Management.API.Helper;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.API.Model
{
    public class Login : Identity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
