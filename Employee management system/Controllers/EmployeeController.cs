using Employee_management_system.Entities;
using Employee_management_system.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetDataList")]
        public async Task<List<object>> GetEmployees()
        {
            var result = await _employeeService.GetEmployees();
            return result;
        }
        [HttpPost("PushEmployee")]
        public async Task<IActionResult> PushEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            await _employeeService.PushEmployee(employee);
            return Ok("added Successfully");
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok("Delete Successfully");
        }
        [HttpPut("UpdateEmployee")]
        public ActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok("Update Successfully");
        }
        [HttpGet("SearchEmployee")]
        public async Task<ActionResult<List<object>>> SearchEmployee(string search)
        {
            var result = await _employeeService.SearchEmployee(search);
            return Ok(result);

        }
        
    }

}
