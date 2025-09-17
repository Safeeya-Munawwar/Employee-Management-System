using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models.Entities
{
    public class UpdateEmployeeDTO
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public required string Email { get; set; }

        [Required]
        [StringLength(50)]
        public required string Position { get; set; }

        [Required]
        [Range(0.00, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
