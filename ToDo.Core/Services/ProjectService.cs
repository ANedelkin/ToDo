using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Contracts;
using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;
using ToDo.Infrastructure.Data.Common;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository _repository;
        public ProjectService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ListedProject>> GetCreatedProjects(string userId)
        {
            User user = await _repository.AllAsync<User>().Include(u => u.CreatedProjects).FirstAsync(u => u.Id == userId);
            return user.CreatedProjects.Select(p => new ListedProject(p)).ToList();
        }
        public async Task<List<ListedProject>> GetParticipatedProjects(string userId)
        {
            User user = await _repository.AllAsync<User>().Include(u => u.ParticipatedProjects).FirstAsync(u => u.Id == userId);
            return user.ParticipatedProjects.Select(p => new ListedProject(p)).ToList();
        }
        public async Task<ProjectVM> GetProjectTasks(string projectId)
        {
            Project project = await _repository.GetByIdAsync<Project>(projectId);
            return new ProjectVM(projectId, new TasksVM(project.Title, project.Tasks.Select(t => new ListedTask(t)).ToList()));
        }
        public async Task<ProjectDetailsVMWithId> GetProjectDetails(string id)
        {
            Project project = await _repository.AllAsync<Project>().Include(p => p.Participants).FirstAsync(p => p.Id == id);
            return new ProjectDetailsVMWithId(project);
        }
        public async System.Threading.Tasks.Task CreateProject(string ownerId)
        {
            Project project = new Project("", "", ownerId);
            project.Id = Guid.NewGuid().ToString();
            (await _repository.GetByIdAsync<User>(ownerId)).CreatedProjects.Add(project);
            //await _repository.AddAsync<Project>(project);
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task EditProject(ProjectDetailsVMWithId projectDetails)
        {
            Project project = await _repository.AllAsync<Project>()
                                                .Include(p => p.Participants)
                                                .FirstAsync(p => p.Id == projectDetails.Id);
            project.Title = projectDetails.Title;
            project.Description = projectDetails.Description;
            project.Participants = projectDetails.Participants.Select(async u => await _repository.GetByIdAsync<User>(u.Id))
                                                              .Select(t => t.Result)
                                                              .ToList();
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task RemoveProject(string Id)
        {
            await _repository.DeleteByIdAsync<Project>(Id);
            await _repository.SaveChangesAsync();
        }
    }
}
