using Employee_management_system.Entities;
using Employee_management_system.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetDataList")]
        public async Task<List<object>> GetDepartments()
        {
            var result = await _departmentService.GetDepartments();
            return result;
        }

        [HttpPost("PushDepartment")]
        public async Task<IActionResult> PushDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            await _departmentService.PushDepartment(department);
            return Ok("added Successfully");
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public ActionResult DeleteDepartments(int id)
        {
            _departmentService.DeleteDepartment(id);
            return Ok("Delete Successfully");
        }
        [HttpPut("UpdateDepartment")]
        public ActionResult UpdateDepartment(Department department)
        {
            _departmentService.UpdateDepartment(department);
            return Ok("Update Successfully");
        }
        [HttpGet("SearchDepartment")]
        public async Task<ActionResult<List<object>>> SearchDepartment(string search)
        {
            var result = await _departmentService.SearchDepartment(search);
            return Ok(result);

        }
    }
}
