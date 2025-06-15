using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;

namespace ToDo.Core.Contracts
{
    public interface IProjectService
    {
        public Task<bool> ProjectExists(string id);
        public Task<List<ListedProject>> GetCreatedProjects(string userId);
        public Task<List<ListedProject>> GetParticipatedProjects(string userId);
        public Task<ProjectVM> GetProjectTasks(string projectId, string callerId);
        public Task<ProjectDetailsVM> GetProjectDetails(string id, string callerId);
        public Task CreateProject(string ownerId, ProjectDetailsVM details);
        public Task EditProject(ProjectDetailsVM projectDetails);
        public Task RemoveProject(string id);

    }
}
