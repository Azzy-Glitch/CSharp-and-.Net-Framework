using Employee_Management.API.Data;
using Employee_Management.API.Dtos;
using Employee_Management.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //public static List<Login> users = new List<Login>();

        private readonly EmployeeDbContext _logger;

        public LoginController(EmployeeDbContext logger)
        {
            _logger = logger;
        }

        [HttpGet("UserData")]

        public List<Login> GetUsers()
        {
            if (!_logger.Logins.Any())
            {
                return new List<Login>();
            }

            return _logger.Logins.ToList();
        }

        [HttpPost("UserValidation")]
        public IActionResult AddUser(LoginDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var user = new Login
            {
                Email = dto.Email,
                Password = dto.Password
            };

            _logger.Logins.Add(user);
            _logger.SaveChanges();
            return Ok("User added successfully.");
        }
    }
}
