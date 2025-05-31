using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;

namespace ToDo.Core.Contracts
{
    interface IProjectService
    {
        public Task<List<ListedProject>> GetUserProjects(string userId);
        public Task<ProjectVM> GetProjectTasks(string projectId);
        public Task<ProjectDetailsVM> GetProjectDetails(string id);
        public Task CreateProject(string ownerId, ProjectDetailsVM projectDetails);
        public Task EditProject(string id, ProjectDetailsVM projectDetails);
        public Task RemoveProject(string id);

    }
}
