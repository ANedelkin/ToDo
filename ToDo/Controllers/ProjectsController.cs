using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.Core.Contracts;
using ToDo.Core.Models.ViewModels;

namespace ToDo.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Authorize]
        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            return View(new ProjectsVM(User.Identity.Name, await _projectService.GetUserProjects(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
    }
}
