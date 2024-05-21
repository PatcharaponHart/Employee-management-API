using Employee_management_system.Entities;
using Employee_management_system.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetDataList")]
        public async Task<List<object>> GetProject()
        {
            var result = await _projectService.GetProjects();
            return result;
        }
        [HttpPost("PushProject")]
        public async Task<IActionResult> PushProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            await _projectService.PushProject(project);
            return Ok("added Successfully");
        }

        [HttpDelete("DeleteProject/{id}")]
        public ActionResult DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
            return Ok("Delete Successfully");
        }
        [HttpPut("UpdateProject")]
        public ActionResult UpdateProject(Project project)
        {
            _projectService.UpdateProject(project);
            return Ok("Update Successfully");
        }
        [HttpGet("SearchProject")]
        public async Task<ActionResult<List<object>>> SearchProject(string search)
        {
            var result = await _projectService.SearchProject(search);
            return Ok(result);

        }
    }
}
