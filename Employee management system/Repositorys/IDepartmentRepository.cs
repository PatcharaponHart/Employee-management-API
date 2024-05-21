using Employee_management_system.Entities;

namespace Employee_management_system.Repositorys
{
    public interface IDepartmentRepository
    {
        Task<List<object>> GetDepartments();
        Task PushDepartment(Department department);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
        Task<List<object>> SearchDepartment(string search);
    }
}
