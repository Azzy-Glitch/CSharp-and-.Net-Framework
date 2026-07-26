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
using Employee_Management.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public LoginController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/Login/UserData
        [HttpGet("UserData")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.Logins
                .Select(x => new { x.Id, x.Email })
                .ToListAsync();

            if (!users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }

        // POST: api/Login/Authenticate
        [HttpPost("Authenticate")]
        public async Task<ActionResult> Authenticate(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Logins.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (user == null || !PasswordHelper.VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid email or password.");

            return Ok(new { user.Id, user.Email });
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.Logins.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound();

            user.Email = dto.Email;
            user.PasswordHash = PasswordHelper.HashPassword(dto.Password);

            await _context.SaveChangesAsync();

            return Ok(new { user.Id, user.Email });
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Logins.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound();

            _context.Logins.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User deleted successfully.");
        }

        // POST: api/Login/ResetAndSeed
        [HttpPost("ResetAndSeed")]
        public async Task<IActionResult> ResetAndSeed()
        {
            _context.Logins.RemoveRange(_context.Logins);
            await _context.SaveChangesAsync();

            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Logins', RESEED, 0)");

            await DbInitializer.SeedLogins(_context);

            return Ok("Logins reset and seeded.");
        }
    }
}