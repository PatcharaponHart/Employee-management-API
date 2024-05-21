using Employee_management_system.Entities;
using Employee_management_system.Repositorys;

namespace Employee_management_system.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<object>> GetDepartments()
        {
            var result = await _departmentRepository.GetDepartments();
            return result;
        }

        public async Task PushDepartment(Department department)
        {
            await _departmentRepository.PushDepartment(department);
        }
        public void DeleteDepartment(int id)
        {
            _departmentRepository.DeleteDepartment(id);
        }
        public void UpdateDepartment(Department department)
        {
            _departmentRepository.UpdateDepartment(department);
        }

        public async Task<List<object>> SearchDepartment(string search)
        {
            var result = await _departmentRepository.SearchDepartment(search);
            return result;
        }
    }
}
