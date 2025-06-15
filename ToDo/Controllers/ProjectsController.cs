using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.Core.Contracts;
using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;
using ToDo.Constants.Enums;
using System.Runtime.CompilerServices;
using ToDo.Infrastructure.Data.Models;
using Azure.Core;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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
        [HttpGet] 
        public async Task<IActionResult> Index(ProjectsTab? projectsToGet)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(new ProjectsVM(User.Identity.Name, projectsToGet??ProjectsTab.Participated, await (projectsToGet == ProjectsTab.Created ? 
                                                                  _projectService.GetCreatedProjects(userId) : 
                                                                  _projectService.GetParticipatedProjects(userId))));
        }
        [Authorize]
        [HttpGet("/projects/create")]
        public async Task<IActionResult> Create()
        {
            return View("Details", new ProjectDetailsVM());
        }
        [Authorize]
        [HttpPost("projects/create")]
        public async Task<IActionResult> Create([FromForm] ProjectDetailsVM details)
        {
            details.Participants = Request.Form["Participants"].ToString()
                                                               .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                                               .Where(id => id != User.FindFirstValue(ClaimTypes.NameIdentifier))
                                                               .Select(id => new ListedUser(id, ""))
                                                               .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _projectService.CreateProject(User.FindFirstValue(ClaimTypes.NameIdentifier), details);
            return View("Index", new ProjectsVM(User.Identity.Name, ProjectsTab.Created, await _projectService.GetCreatedProjects(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
        [Authorize]
        [HttpGet("/projects/delete{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!(await _projectService.ProjectExists(id)))
            {
                return NotFound();
            }
            await _projectService.RemoveProject(id);
            return View("Index", new ProjectsVM(User.Identity.Name, ProjectsTab.Created, await _projectService.GetCreatedProjects(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
        [Authorize]
        [HttpGet("project-details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            ProjectDetailsVM projectDetails = await _projectService.GetProjectDetails(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
            projectDetails.Id = id;
            if(projectDetails.IsCreator) return View(projectDetails);
            return View("DetailsReadOnly", projectDetails);
        }
        [Authorize]
        [HttpPost("/projects/update")]
        public async Task<IActionResult> Update([FromForm] ProjectDetailsVM details)
        {
            details.Participants = Request.Form["Participants"].ToString()
                                                               .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                                               .Where(id => id != User.FindFirstValue(ClaimTypes.NameIdentifier))
                                                               .Select(id => new ListedUser(id, ""))
                                                               .ToList();

            if (!(await _projectService.ProjectExists(details.Id)))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _projectService.EditProject(details);
            return RedirectToAction("Index", "Tasks", new { projectId=details.Id});
        }

    }
}
