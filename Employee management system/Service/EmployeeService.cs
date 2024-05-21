using Employee_management_system.Entities;
using Employee_management_system.Repositorys;

namespace Employee_management_system.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<object>>GetEmployees()
        {
            var result = await _employeeRepository.GetEmployees();
            return result;
        }
        public async Task PushEmployee(Employee employee)
        {
            await _employeeRepository.PushEmployee(employee);
        }
        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }
        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }

        public async Task<List<object>> SearchEmployee(string search)
        {
            var result = await _employeeRepository.SearchEmployee(search);
            return result;
        }
    }
}
