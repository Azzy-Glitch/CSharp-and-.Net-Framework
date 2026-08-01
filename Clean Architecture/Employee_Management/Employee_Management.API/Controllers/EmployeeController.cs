using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees() =>
            Ok(await _employeeService.GetAllAsync());

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            return employee is null ? NotFound() : Ok(employee);
        }

        // GET: api/Employee/name/Ali
        [HttpGet("name/{name}")]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployeeByName(string name) =>
            Ok(await _employeeService.SearchByNameAsync(name));

        // PUT: api/Employee/UpdateEmployee
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _employeeService.UpdateAsync(employeeDto);
            return updated is null ? NotFound() : Ok(updated);
        }

        // DELETE: api/Employee/DeleteEmployee/1
        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult<List<EmployeeDto>>> DeleteEmployee(int id)
        {
            var remaining = await _employeeService.DeleteAsync(id);
            return remaining is null ? NotFound() : Ok(remaining);
        }

        // POST: api/Employee/ResetAndSeed
        [HttpPost("ResetAndSeed")]
        public async Task<IActionResult> ResetAndSeed()
        {
            await _employeeService.ResetAndSeedAsync();
            return Ok("Employees reset and seeded.");
        }
    }
}
