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
        public Task<List<ListedProject>> GetCreatedProjects(string userId);
        public Task<List<ListedProject>> GetParticipatedProjects(string userId);
        public Task<ProjectVM> GetProjectTasks(string projectId);
        public Task<ProjectDetailsVM> GetProjectDetails(string id);
        public Task CreateProject(string ownerId);
        public Task EditProject(string id, ProjectDetailsVM projectDetails);
        public Task RemoveProject(string id);

    }
}
