using EmployeePortal.Data;
using EmployeePortal.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repository
{
    public class EmployeeRepository(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task SaveEmployee(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(id);
            if(existingEmployee == null)
            {
                throw new Exception("Employee not found");
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Mobile = employee.Mobile;
            existingEmployee.Age = employee.Age;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Status = employee.Status;
            await _dbContext.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task DeleteEmployee(int id)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                throw new Exception("Employee not found");
            }
            _dbContext.Employees.Remove(existingEmployee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
