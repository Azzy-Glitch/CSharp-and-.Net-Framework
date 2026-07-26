using Employee_Management.API.Data;
using Employee_Management.API.Model;
using Employee_Management.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Management.API.Helpers;


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

                Login = login
            };


            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();


            return Ok(new
            {
                Message = "Registration Successful",
                Employee = employee
            });

        }


    }

}