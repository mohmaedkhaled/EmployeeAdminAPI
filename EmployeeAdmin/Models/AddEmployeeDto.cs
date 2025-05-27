namespace EmployeeAdmin.Models
{
    public class AddEmployeeDto
    {
        public required string name { get; set; }
        public required string Email { get; set; }
        public string? phone { get; set; }
        public decimal Salary { get; set; }
    }
}
