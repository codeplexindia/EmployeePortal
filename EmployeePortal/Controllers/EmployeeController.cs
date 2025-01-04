using EmployeePortal.Model;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
                this._employeeRepository = employeeRepository;
        }

        public async Task<ActionResult> GetEmployees() 
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return Ok(employees);
        }

        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            await _employeeRepository.SaveEmployee(employee);
            return Ok(employee);
        }
    }
}
