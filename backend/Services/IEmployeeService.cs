using EmployeeApi.Models.Entities;

namespace EmployeeApi.Services
{
    public interface IEmployeeService
    {
        Task<IReadOnlyList<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(AddEmployeeDTO dto);
        Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeeDTO dto);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<IReadOnlyList<Employee>> SearchEmployeesAsync(string keyword);
        Task<IReadOnlyList<Employee>> GetHighSalaryEmployeesAsync(decimal minSalary);
    }
}
