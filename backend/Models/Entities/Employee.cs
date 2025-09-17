namespace EmployeeApi.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Position { get; set; } 
        public decimal Salary { get; set; }
    }
}
