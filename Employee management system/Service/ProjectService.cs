using Employee_management_system.Entities;
using Employee_management_system.Repositorys;

namespace Employee_management_system.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<object>> GetProjects()
        {
            var result = await _projectRepository.GetProjects();
            return result;
        }
        public async Task PushProject(Project project)
        {
            await _projectRepository.PushProject(project);
        }
        public void DeleteProject(int id)
        {
            _projectRepository.DeleteProject(id);
        }
        public void UpdateProject(Project project)
        {
            _projectRepository.UpdateProject(project);
        }

        public async Task<List<object>> SearchProject(string search)
        {
            var result = await _projectRepository.SearchProject(search);
            return result;
        }
    }
}
