using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.Core.Contracts;
using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;
using ToDo.Constants.Enums;

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
        [HttpGet("/{projectsToGet?}")]
        public async Task<IActionResult> Index(ProjectsTab? projectsToGet)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(new ProjectsVM(User.Identity.Name, projectsToGet??ProjectsTab.Participated, await (projectsToGet == ProjectsTab.Created ? 
                                                                  _projectService.GetCreatedProjects(userId) : 
                                                                  _projectService.GetParticipatedProjects(userId))));
        }
        [Authorize]
        [HttpGet("projects/create")]
        public async Task<IActionResult> Create()
        {
            await _projectService.CreateProject(User.FindFirstValue(ClaimTypes.NameIdentifier), new ProjectDetailsVM("Project 1", "A projecty project", new List<string>()));
            return View("Index", new ProjectsVM(User.Identity.Name, ProjectsTab.Created, await _projectService.GetCreatedProjects(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
        [Authorize]
        [HttpGet("projects/delete{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _projectService.RemoveProject(id);
            return View("Index", new ProjectsVM(User.Identity.Name, ProjectsTab.Created, await _projectService.GetCreatedProjects(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
    }
}
