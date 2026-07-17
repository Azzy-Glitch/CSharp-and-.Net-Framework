using Employee_Management.API.Model;
using Microsoft.AspNetCore.Mvc;

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

using Employee_Management.API.Data;

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
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        // GET: api/Employee/name/Ali
        [HttpGet("name/{name}")]
        public List<Employee> GetEmployeeByName(string name)
        {
            return _context.Employees
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        // POST: api/Employee/AddEmployee
        [HttpPost("AddEmployee")]
        public List<Employee> AddEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Department = employeeDto.Department,
                Designation = employeeDto.Department,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return _context.Employees.ToList();
        }

        // PUT: api/Employee/UpdateEmployee
        [HttpPut("UpdateEmployee")]
        public List<Employee> UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.Email = employee.Email;

                _context.SaveChanges();
            }

            return _context.Employees.ToList();
        }

        // DELETE: api/Employee/DeleteEmployee/1
        [HttpDelete("DeleteEmployee/{id}")]
        public List<Employee> DeleteEmployee(int id)
        {
            var employeeToRemove = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (employeeToRemove != null)
            {
                _context.Employees.Remove(employeeToRemove);
                _context.SaveChanges();
            }

            return _context.Employees.ToList();
        }
    }
}
