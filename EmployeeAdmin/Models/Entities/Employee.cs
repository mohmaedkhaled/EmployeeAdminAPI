using System.ComponentModel.DataAnnotations;

namespace EmployeeAdmin.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}