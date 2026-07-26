using Employee_Management.API.Data;
using Employee_Management.API.Helpers;
using Employee_Management.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public RegisterController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var emailTaken = await _context.Logins.AnyAsync(x => x.Email == dto.Email)
            //    || await _context.Employees.AnyAsync(x => x.Email == dto.Email);

            //if (emailTaken)
            //    return Conflict("An account with this email already exists.");

            var login = new Login
            {
                Email = dto.Email,
                PasswordHash = PasswordHelper.HashPassword(dto.Password)
            };

            var employee = new Employee
            {
                Name = dto.Name,
                Department = dto.Department,
                Designation = dto.Designation,
                Salary = (double)dto.Salary,
                PhoneNumber = dto.PhoneNumber,
                //Email = dto.Email,
                Login = login
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Registration Successful",
                Employee = new
                {
                    employee.Id,
                    employee.Name,
                    employee.PhoneNumber,
                    employee.Department,
                    employee.Designation,
                    employee.Salary
                    //employee.Email
                }
            });
        }
    }
}