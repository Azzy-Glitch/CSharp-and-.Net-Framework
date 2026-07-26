//using Employee_Management.API.Model;
//using Microsoft.AspNetCore.Mvc;

//namespace Employee_Management.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        // GET: api/Employee
//        [HttpGet]
//        public List<Employee> GetEmployees()
//        {
//            List<Employee> employee = new List<Employee>();

//            employee.Add(new Employee
//            {
//                Id = 1,
//                Name = "Ali",
//                Department = "IT",
//                Salary = 50000
//            });

//            employee.Add(new Employee
//            {
//                Id = 2,
//                Name = "Ahmed",
//                Department = "HR",
//                Salary = 40000
//            });

//            employee.Add(new Employee
//            {
//                Id = 3,
//                Name = "Sara",
//                Department = "Finance",
//                Salary = 60000
//            });

//            return employee;
//        }

//        // GET: api/Employee/1
//        [HttpGet("{id}")]
//        public Employee GetEmployeeById(int id)
//        {
//            var employees = new List<Employee>();

//            employees.Add(new Employee
//            {
//                Id = 1,
//                Name = "Ali",
//                Department = "IT",
//                Salary = 50000
//            });

//            employees.Add(new Employee
//            {
//                Id = 2,
//                Name = "Ahmed",
//                Department = "HR",
//                Salary = 40000
//            });

//            employees.Add(new Employee
//            {
//                Id = 3,
//                Name = "Sara",
//                Department = "Finance",
//                Salary = 60000
//            });

//            return employees.FirstOrDefault(x => x.Id == id);
//        }

//        // GET: api/Employee/name/Ali
//        [HttpGet("name/{name}")]
//        public List<Employee> GetEmployeeByName(string name)
//        {
//            var employees = new List<Employee>();

//            employees.Add(new Employee
//            {
//                Id = 1,
//                Name = "Ali",
//                Department = "IT",
//                Salary = 50000
//            });

//            employees.Add(new Employee
//            {
//                Id = 2,
//                Name = "Ahmed",
//                Department = "HR",
//                Salary = 40000
//            });

//            employees.Add(new Employee
//            {
//                Id = 3,
//                Name = "Sara",
//                Department = "Finance",
//                Salary = 60000
//            });

//            // Case-insensitive search
//            return employees
//                .Where(x => x.Name.ToLower() == name.ToLower())
//                .ToList();
//        }
//    }
//}

//namespace Employee_Management.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        private static List<Employee> employees = new List<Employee>
//        {
//            new Employee { Id = 1, Name = "Ali", Department = "IT", Salary = 50000, Email = "ali@gmail.com" },
//            new Employee { Id = 2, Name = "Ahmed", Department = "HR", Salary = 40000, Email = "ahmed@gmail.com" },
//            new Employee { Id = 3, Name = "Sara", Department = "Finance", Salary = 60000, Email = "Sara@gmail.com" }
//        };

//        List<EmployeeDto> employeesDto = new List<EmployeeDto>();

//        // GET: api/Employee
//        [HttpGet]
//        public List<Employee> GetEmployees()
//        {
//            return employees;
//        }

//        // GET: api/Employee/1
//        [HttpGet("{id}")]
//        public Employee GetEmployeeById(int id)
//        {
//            return employees.FirstOrDefault(x => x.Id == id);
//        }

// GET: api/Employee/name/Ali
//[HttpGet("name/{name}")]
//public List<Employee> GetEmployeeByName(string name)
//{
//    return employees
//        .Where(x => x.Name.ToLower().Contains(name.ToLower()))
//        .ToList();
//}

//[HttpPost("AddEmployee")]
//public List<Employee> AddEmployee(Employee employee)
//{
//    employee.Id = employees.Max(x => x.Id) + 1;
//    employees.Add(employee);
//    return employees;
//}

//        [HttpPost("AddEmployee")]
//        public List<Employee> AddEmployee(EmployeeDto employeeDto)
//        {
//            Employee employee = new Employee();

//            employee.Id = (employees.Count == 0) ? 1 : employees.Max(x => x.Id) + 1;
//            employee.Name = employeeDto.Name;
//            employee.Department = employeeDto.Department;
//            employee.Salary = employeeDto.Salary;
//            employee.Email = employeeDto.Email;

//            employees.Add(employee);

//            return employees;
//        }

//        [HttpPut("UpdateEmployee")]
//        public  List<Employee> UpdateEmployee(Employee employee)
//        {
//            var existingEmployee = employees.FirstOrDefault(x => x.Id == employee.Id);

//            if (existingEmployee != null)
//            {
//                existingEmployee.Name = employee.Name;
//                existingEmployee.Department = employee.Department;
//                existingEmployee.Salary = employee.Salary;
//            }
//            return employees;
//        }

//        [HttpDelete("DeleteEmployee/{id}")]
//        public List<Employee> DeleteEmployee(int id)
//        {
//            var employeeToRemove = employees.FirstOrDefault(x => x.Id == id);
//            if (employeeToRemove != null)
//            {
//                employees.Remove(employeeToRemove);
//            }
//            return employees;
//        }
//    }
//}

//using Employee_Management.API.Data;
//using Employee_Management.API.Model;
//using Microsoft.AspNetCore.Mvc;


//namespace Employee_Management.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        private readonly EmployeeDbContext _context;

//        public EmployeeController(EmployeeDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Employee
//        [HttpGet]
//        public List<Employee> GetEmployees()
//        {
//            return _context.Employees.ToList();
//        }

//        // GET: api/Employee/1
//        [HttpGet("{id}")]
//        public Employee GetEmployeeById(int id)
//        {
//            return _context.Employees.FirstOrDefault(x => x.Id == id);
//        }

//        // GET: api/Employee/name/Ali
//        [HttpGet("name/{name}")]
//        public List<Employee> GetEmployeeByName(string name)
//        {
//            return _context.Employees
//                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
//                .ToList();
//        }

//        // POST: api/Employee/AddEmployee
//        [HttpPost("AddEmployee")]
//        public List<Employee> AddEmployee(EmployeeDto employeeDto)
//        {
//            var employee = new Employee
//            {
//                Name = employeeDto.Name,
//                Department = employeeDto.Department,
//                Designation = employeeDto.Department,
//                Salary = employeeDto.Salary,
//                Email = employeeDto.Email
//            };

//            _context.Employees.Add(employee);
//            _context.SaveChanges();

//            return _context.Employees.ToList();
//        }

//        // PUT: api/Employee/UpdateEmployee
//        [HttpPut("UpdateEmployee")]
//        public List<Employee> UpdateEmployee(Employee employee)
//        {
//            var existingEmployee = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);

//            if (existingEmployee != null)
//            {
//                existingEmployee.Name = employee.Name;
//                existingEmployee.Department = employee.Department;
//                existingEmployee.Salary = employee.Salary;
//                existingEmployee.Email = employee.Email;

//                _context.SaveChanges();
//            }

//            return _context.Employees.ToList();
//        }

//        // DELETE: api/Employee/DeleteEmployee/1
//        [HttpDelete("DeleteEmployee/{id}")]
//        public List<Employee> DeleteEmployee(int id)
//        {
//            var employeeToRemove = _context.Employees.FirstOrDefault(x => x.Id == id);

//            if (employeeToRemove != null)
//            {
//                _context.Employees.Remove(employeeToRemove);
//                _context.SaveChanges();
//            }

//            return _context.Employees.ToList();
//        }
//    }
//}


using Employee_Management.API.Data;
using Employee_Management.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // GET: api/Employee/name/Ali
        [HttpGet("name/{name}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeByName(string name)
        {
            var employees = await _context.Employees
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            return Ok(employees);
        }

        // POST: api/Employee/AddEmployee
        //[HttpPost("AddEmployee")]
        //public async Task<ActionResult<List<Employee>>> AddEmployee(EmployeeDto employeeDto)
        //{
        //    var employee = new Employee
        //    {
        //        Name = employeeDto.DName,
        //        Department = employeeDto.DDepartment,
        //        Designation = employeeDto.DDesignation,
        //        Salary = employeeDto.DSalary,
        //        Email = employeeDto.DEmail
        //    };

        //    await _context.Employees.AddAsync(employee);
        //    await _context.SaveChangesAsync();

        //    var employees = await _context.Employees.ToListAsync();

        //    return Ok(employees);
        //}

        // PUT: api/Employee/UpdateEmployee
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(EmployeeDto employeeDto)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeDto.Id);

            if (existingEmployee == null)
                return NotFound();

            existingEmployee.Name = employeeDto.Name;
            existingEmployee.Department = employeeDto.Department;
            existingEmployee.Salary = employeeDto.Salary;
            //existingEmployee.Email = employeeDto.Email;

            await _context.SaveChangesAsync();

            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        // DELETE: api/Employee/DeleteEmployee/1
        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var employeeToRemove = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employeeToRemove == null)
                return NotFound();

            _context.Employees.Remove(employeeToRemove);
            await _context.SaveChangesAsync();

            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost("ResetAndSeed")]
        public async Task<IActionResult> ResetAndSeed()
        {
            _context.Employees.RemoveRange(_context.Employees);
            await _context.SaveChangesAsync();

            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Employees', RESEED, 0)");

            await DbInitializer.SeedEmployees(_context);

            return Ok("Database reset and seeded.");
        }
    }
}