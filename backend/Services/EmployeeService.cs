using EmployeeApi.DataAccess;
using EmployeeApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllEmployeesAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> AddEmployeeAsync(AddEmployeeDTO dto)
        {
            return await _repository.AddEmployeeAsync(dto);
        }

        public async Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeeDTO dto)
        {
            return await _repository.UpdateEmployeeAsync(id, dto);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _repository.DeleteEmployeeAsync(id);
        }

        public async Task<IReadOnlyList<Employee>> SearchEmployeesAsync(string keyword)
        {
            return await _repository.SearchEmployeesAsync(keyword);
        }

        public async Task<IReadOnlyList<Employee>> GetHighSalaryEmployeesAsync(decimal minSalary)
        {
            return await _repository.GetHighSalaryEmployees(minSalary);
        }

    }
}
