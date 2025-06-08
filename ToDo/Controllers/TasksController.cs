using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Contracts;

namespace ToDo.Controllers
{
    public class TasksController : Controller
    {
        private readonly IProjectService _projectService;
        public TasksController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Authorize]
        [HttpGet("/project-tasks/{projectId}")]
        public async Task<IActionResult> Index(string projectId)
        {
            return View(await _projectService.GetProjectTasks(projectId));
        }
    }
}
