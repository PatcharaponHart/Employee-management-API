using Employee_management_system.Data;
using Employee_management_system.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_management_system.Repositorys
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<object>> GetEmployees()
        {
            var result = await (from emp in _context.Employees
                              join dept in _context.Departments on emp.DepartmentID equals dept.DepartmentID 
                              join pro in _context.Projects on emp.DepartmentID equals pro.DepartmentID
                              select new
                              {
                                  emp.FirstName,
                                  emp.LastName,
                                  emp.Email,
                                  emp.Gender,
                                  dept.DepartmentName,
                                  emp.JobTitle,
                                  pro.ProjectName,
                                 
                              }).ToListAsync<object>();
            return result;
        }
            public async Task PushEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public void DeleteEmployee(int id)
        {
            var employeeToDelete = _context.Employees.Find(id);
            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            var updateEmployee = _context.Employees.Find(employee.EmployeeID);
            updateEmployee.FirstName = employee.FirstName;
            updateEmployee.LastName = employee.LastName;
            updateEmployee.Email = employee.Email;
            updateEmployee.Gender = employee.Gender;
            updateEmployee.JobTitle = employee.JobTitle;
            

            _context.SaveChanges();
        }
        public async Task<List<object>> SearchEmployee(string? search)
        {

            var result = await (from emp in _context.Employees
                               join dept in _context.Departments on emp.DepartmentID equals dept.DepartmentID
                               join pro in _context.Projects on emp.DepartmentID equals pro.DepartmentID
                               where string.IsNullOrEmpty(search)
                || emp.FirstName.Contains(search) 
                || emp.LastName.Contains(search) 
                || emp.Email.Contains(search) 
                || emp.Gender.Contains(search) 
                || emp.JobTitle.Contains(search)
                select new
                {
                    emp.FirstName,
                    emp.LastName,
                    emp.Email,
                    emp.Gender,
                    emp.JobTitle,
                    dept.DepartmentName,
                    pro.ProjectName
                }).ToListAsync<object>();
                


            return result;
        }

    }
}
