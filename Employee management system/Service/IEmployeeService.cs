using Employee_management_system.Entities;

namespace Employee_management_system.Service
{
    public interface IEmployeeService
    {
        Task<List<object>> GetEmployees();
        Task PushEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
        Task<List<object>> SearchEmployee(string search);

    }
}
