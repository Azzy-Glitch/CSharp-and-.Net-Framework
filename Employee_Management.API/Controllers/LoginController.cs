//using Employee_Management.API.Data;
//using Employee_Management.API.Dtos;
//using Employee_Management.API.Model;
//using Microsoft.AspNetCore.Mvc;

//namespace Employee_Management.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        //public static List<Login> users = new List<Login>();

//        private readonly EmployeeDbContext _logger;

//        public LoginController(EmployeeDbContext logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet("UserData")]

//        public List<Login> GetUsers()
//        {
//            if (!_logger.Logins.Any())
//            {
//                return new List<Login>();
//            }

//            return _logger.Logins.ToList();
//        }

//        [HttpPost("UserValidation")]
//        public IActionResult AddUser(LoginDto dto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var user = new Login
//            {
//                Email = dto.Email,
//                Password = dto.Password
//            };

//            _logger.Logins.Add(user);
//            _logger.SaveChanges();
//            return Ok("User added successfully.");
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteUser(int id)
//        {
//            var user = _logger.Logins.Find(id);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            _logger.Logins.Remove(user);
//            _logger.SaveChanges();
//            return Ok("User deleted successfully.");
//        }
//    }
//}

using Employee_Management.API.Data;
using Employee_Management.API.Dtos;
using Employee_Management.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EmployeeDbContext _logger;

        public LoginController(EmployeeDbContext logger)
        {
            _logger = logger;
        }

        [HttpGet("UserData")]
        public async Task<ActionResult<List<Login>>> GetUsers()
        {
            if (!await _logger.Logins.AnyAsync())
            {
                return BadRequest("No users found.");
            }

            var users = await _logger.Logins.ToListAsync();
            return Ok(users);
        }

        //[HttpPost("UserValidation")]
        //public async Task<ActionResult> AddUser(LoginDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new Login
        //    {
        //        Email = dto.Email,
        //        PasswordHash = dto.Password
        //    };

        //    await _logger.Logins.AddAsync(user);
        //    await _logger.SaveChangesAsync();

        //    return Ok("User added successfully.");
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<Login>> UpdateUser(int id, LoginDto dto)
        {
            var user = await _logger.Logins.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Email = dto.Email;
            user.PasswordHash = dto.Password;

            await _logger.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Login>> DeleteUser(int id)
        {
            var user = await _logger.Logins.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _logger.Logins.Remove(user);
            await _logger.SaveChangesAsync();

            return Ok("User deleted successfully.");
        }

        [HttpPost("ResetAndSeed")]
        public async Task<IActionResult> ResetAndSeed()
        {
            _logger.Employees.RemoveRange(_logger.Employees);
            await _logger.SaveChangesAsync();

            await _logger.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Logins', RESEED, 0)");

            await DbInitializer.SeedLogins(_logger);

            return Ok("Database reset and seeded.");
        }
    }
}