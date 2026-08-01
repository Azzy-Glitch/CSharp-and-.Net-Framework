using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: api/Login/UserData
        [HttpGet("UserData")]
        public async Task<ActionResult<List<LoginSummaryDto>>> GetUsers()
        {
            var users = await _loginService.GetAllAsync();
            return users.Count == 0 ? NotFound("No users found.") : Ok(users);
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LoginSummaryDto>> UpdateUser(int id, LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _loginService.UpdateAsync(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _loginService.DeleteAsync(id);
            return deleted ? Ok("User deleted successfully.") : NotFound();
        }

        // POST: api/Login/ResetAndSeed
        [HttpPost("ResetAndSeed")]
        public async Task<IActionResult> ResetAndSeed()
        {
            await _loginService.ResetAndSeedAsync();
            return Ok("Logins reset and seeded.");
        }
    }
}
