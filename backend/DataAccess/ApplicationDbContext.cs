using EmployeeApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
