using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;
using ToDo.Infrastructure.Data.Common;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Contracts
{
    class ProjectService : IProjectService
    {
        private readonly IRepository _repository;
        public ProjectService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ListedProject>> GetUserProjects(string userId)
        {
            return (await _repository.GetByIdAsync<User>(userId)).CreatedProjects.Select(p => new ListedProject(p)).ToList();
        }
        public async Task<ProjectVM> GetProjectTasks(string projectId)
        {
            Project project = await _repository.GetByIdAsync<Project>(projectId);
            return new ProjectVM(new TasksVM(project.Title, project.Tasks.Select(t => new ListedTask(t)).ToList()));
        }
        public async Task<ProjectDetailsVM> GetProjectDetails(string id)
        {
            Project project = await _repository.GetByIdAsync<Project>(id);
            return new ProjectDetailsVM(project);
        }
        public async System.Threading.Tasks.Task CreateProject(string ownerId, ProjectDetailsVM projectDetails)
        {
            Project project = new Project()
            {
                Title = projectDetails.Title,
                Description = projectDetails.Description,
                OwnerId = ownerId
            };
            await _repository.AddAsync<Project>(project);
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task EditProject(string Id, ProjectDetailsVM projectDetails)
        {
            Project project = new Project()
            {
                Title = projectDetails.Title,
                Description = projectDetails.Description,
                OwnerId = (await _repository.GetByIdAsync<Project>(Id)).OwnerId
            };
            await _repository.UpdateAsync<Project>(Id, project);
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task RemoveProject(string Id)
        {
            await _repository.DeleteByIdAsync<Project>(Id);
            await _repository.SaveChangesAsync();
        }

    }
}
