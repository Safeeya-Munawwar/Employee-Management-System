using EmployeeApi.Models.Entities;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(AddEmployeeDTO addDto)
        {
            var employee = await _employeeService.AddEmployeeAsync(addDto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, UpdateEmployeeDTO updateDto)
        {
            var employee = await _employeeService.UpdateEmployeeAsync(id, updateDto);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<Employee>>> SearchEmployees([FromQuery] string keyword)
        {
            var employees = await _employeeService.SearchEmployeesAsync(keyword);
            return Ok(employees);
        }

        [HttpGet("high-salary")]
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetHighSalaryEmployees([FromQuery] decimal minSalary)
        {
            var employees = await _employeeService.GetHighSalaryEmployeesAsync(minSalary);
            return Ok(employees);
        }

    }
}
