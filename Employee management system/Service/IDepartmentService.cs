using Employee_management_system.Entities;

namespace Employee_management_system.Service
{
    public interface IDepartmentService
    {
        Task<List<object>> GetDepartments();
        Task PushDepartment(Department department);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
        Task<List<object>> SearchDepartment(string search);

    }
}
