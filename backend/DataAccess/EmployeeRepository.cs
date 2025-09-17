using EmployeeApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> AddEmployeeAsync(AddEmployeeDTO dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                Position = dto.Position,
                Salary = dto.Salary
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeeDTO dto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return null;

            employee.Name = dto.Name;
            employee.Email = dto.Email;
            employee.Position = dto.Position;
            employee.Salary = dto.Salary;

            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<Employee>> SearchEmployeesAsync(string keyword)
        {
            return await _context.Employees
                .Where(e => e.Name.Contains(keyword) || e.Email.Contains(keyword) || e.Position.Contains(keyword))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Employee>> GetHighSalaryEmployees(decimal minSalary)
        {
            return await _context.Employees
                .Where(e => e.Salary > minSalary)   
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

    }
}
