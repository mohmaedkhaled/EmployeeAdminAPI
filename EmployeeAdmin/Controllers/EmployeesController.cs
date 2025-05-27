using EmployeeAdmin.Data;
using EmployeeAdmin.Models;
using EmployeeAdmin.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public EmployeesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {

            return Ok(db.Employees.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = db.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult AddEmplotee(AddEmployeeDto addEmployeeDto)
        {
            var employeEntity = new Employee()
            {
                Name = addEmployeeDto.name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.phone,
                Salary = addEmployeeDto.Salary
            };

            db.Employees.Add(employeEntity);
            db.SaveChanges();
            return Ok(employeEntity);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id , UpdateEmployeeDto updateemployeedto)
        {
            var employee = db.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = updateemployeedto.name;
            employee.Email = updateemployeedto.Email;
            employee.Phone = updateemployeedto.phone;
            employee.Salary = updateemployeedto.Salary;

            db.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = db.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }
            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok();

        }


    }
}
