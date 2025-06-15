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
        private readonly ITaskService _taskService;
        private readonly ILabelService _labelService;
        public TasksController(IProjectService projectService, ITaskService taskService, ILabelService labelService)
        {
            _projectService = projectService;
            _taskService = taskService;
            _labelService = labelService;
        }

        [Authorize]
        [HttpGet("/project-tasks/{projectId}")]
        public async Task<IActionResult> Index(string projectId)
        {
            return View(await _projectService.GetProjectTasks(projectId, User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
        [Authorize]
        [HttpPost("tasks/create")]
        public async Task<IActionResult> Create([FromForm] TaskVM task)
        {
            await _taskService.AddTask(task);
            return RedirectToAction("Index", new {projectId=task.ProjectId});
        }
        [Authorize]
        [HttpGet("/tasks/create/{projectId}/{status}")]
        public async Task<IActionResult> Create(string projectId, Constants.Enums.TaskStatus status)
        {
            return View("Details", new TaskVM() { AllLabels = await _labelService.GetProjectLabels(projectId), ProjectId = projectId});
        }
        [Authorize]
        [HttpGet("/edit-task/{id?}")]
        public async Task<IActionResult> Details(string id)
        {
            return View(await _taskService.GetTaskDetails(id));
        }
    }
}
