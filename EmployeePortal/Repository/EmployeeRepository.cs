using EmployeePortal.Data;
using EmployeePortal.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext db) 
        { 
            this.db = db;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task SaveEmployee(Employee employee)
        {
            await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
        }
    }
}
