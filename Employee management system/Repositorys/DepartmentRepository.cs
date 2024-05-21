using Employee_management_system.Data;
using Employee_management_system.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_management_system.Repositorys
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetDepartments()
        {
            var result = await (from dept in _context.Departments
                                join pro in _context.Projects on dept.DepartmentID equals pro.DepartmentID
                                select new
                               
                                {
                                    dept.DepartmentName,
                                    dept.ManagerID,
                                    pro.ProjectName

                                }).ToListAsync<object>();
            return result;
        }

        public async Task PushDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }
        public void DeleteDepartment(int id)
        {
            var departmentToDelete = _context.Departments.Find(id);
            if (departmentToDelete != null)
            {
                _context.Departments.Remove(departmentToDelete);
                _context.SaveChanges();
            }
        }
        public void UpdateDepartment(Department department)
        {
            var updateDepartment = _context.Departments.Find(department.DepartmentID);
            {
                updateDepartment.DepartmentName = department.DepartmentName;
                updateDepartment.ManagerID = department.ManagerID;
                _context.SaveChanges();
            }
        }

        
        public async Task<List<object>> SearchDepartment(string? search)
        {

            var result = await (from dept in _context.Departments
                                join pro in _context.Projects on dept.DepartmentID equals pro.DepartmentID
                                where string.IsNullOrEmpty(search)
                 || dept.DepartmentName.Contains(search)
                 || pro.ProjectName.Contains(search)
                                select new
                                {
                                    dept.DepartmentName,
                                    dept.ManagerID,
                                    pro.ProjectName
                                    
                                }).ToListAsync<object>();

            return result;
        }
    }
}
