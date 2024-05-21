using Employee_management_system.Entities;

namespace Employee_management_system.Service
{
    public interface IProjectService
    {
        Task<List<object>> GetProjects();
        Task PushProject(Project project);
        void DeleteProject(int id);
        void UpdateProject(Project project);
        Task<List<object>> SearchProject(string search);
    }
}
