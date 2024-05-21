using Employee_management_system.Entities;

namespace Employee_management_system.Repositorys
{
    public interface IEmployeeRepository
    {
        Task<List<object>> GetEmployees();
        Task PushEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
        Task<List<object>> SearchEmployee(string? search);
    }
}
