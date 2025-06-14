using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.Core.Contracts;
using ToDo.Core.Models.ViewModels;

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
            return View(await _projectService.GetProjectTasks(projectId, User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
    }
}
