using Employee_management_system.Data;
using Employee_management_system.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_management_system.Repositorys
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<object>> GetProjects()
        {
            var result = await (from pro in _context.Projects
                                join dept in _context.Departments on pro.DepartmentID equals dept.DepartmentID
                                join emp in _context.Employees on pro.DepartmentID equals emp.DepartmentID
                                select new
                                {
                                    pro.ProjectID,
                                    pro.ProjectName,
                                    dept.ManagerID,
                                    emp.FirstName,
                                    emp.JobTitle,
                                    StartDate = pro.StartDate != null ? pro.StartDate.Value.ToString("yyyy-MM-dd HH:mm") : null,
                                    EndDate = pro.EndDate != null ? pro.EndDate.Value.ToString("yyyy-MM-dd HH:mm") : null

                                }).ToListAsync<object>();
            return result;
        }
        public async Task PushProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }
        public void DeleteProject(int id)
        {
            var projectToDelete = _context.Projects.Find(id);
            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                _context.SaveChanges();
            }
        }
        public void UpdateProject(Project project)
        {
            var updateProject = _context.Projects.Find(project.ProjectID);
            if (updateProject != null)
            {
                Console.WriteLine($"Updating project ID: {project.ProjectID}"); // เพิ่มบรรทัดนี้เพื่อตรวจสอบว่า method ถูกเรียกกี่ครั้ง
                updateProject.ProjectName = project.ProjectName;
                updateProject.StartDate = project.StartDate;
                updateProject.EndDate = project.EndDate;
                updateProject.DepartmentID = project.DepartmentID; // เพิ่มบรรทัดนี้ถ้าคุณต้องการอัปเดต DepartmentID ด้วย
                _context.SaveChanges();
            }
        }

        public async Task<List<object>> SearchProject(string? search)
        {

            var result = await (from pro in _context.Projects
                                join dept in _context.Departments on pro.DepartmentID equals dept.DepartmentID
                                join emp in _context.Employees on pro.DepartmentID equals emp.DepartmentID
                                where string.IsNullOrEmpty(search)
                 || pro.ProjectName.Contains(search) 
                                select new
                                {
                                    emp.FirstName,
                                    emp.LastName,
                                    emp.JobTitle,
                                    dept.DepartmentName,
                                    pro.ProjectName
                                }).ToListAsync<object>();



            return result;
        }
    }
}
