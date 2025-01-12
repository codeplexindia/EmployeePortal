using EmployeePortal.Model;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(EmployeeRepository employeeRepository) : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository = employeeRepository;

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            await _employeeRepository.SaveEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployee(id, employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
