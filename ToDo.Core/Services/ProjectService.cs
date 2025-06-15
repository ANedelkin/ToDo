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

        public async Task<bool> ProjectExists(string id)
        {
            return await _repository.Exists<Project>(id);
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
        public async Task<ProjectVM> GetProjectTasks(string projectId, string callerId)
        {
            Project project = await _repository.GetByIdAsync<Project>(projectId);
            return new ProjectVM(projectId, new TasksVM(project.Title, project.Tasks.Select(t => new ListedTask(t)).ToList())) { IsCreator = project.OwnerId == callerId };
        }
        public async Task<ProjectDetailsVM> GetProjectDetails(string id, string callerId)
        {
            Project project = await _repository.AllAsync<Project>().Include(p => p.Participants).FirstAsync(p => p.Id == id);
            return new ProjectDetailsVM(project) { IsCreator = project.OwnerId == callerId };
        }
        public async System.Threading.Tasks.Task CreateProject(string ownerId, ProjectDetailsVM details)
        {
            var users = details.Participants.Select(async u => await _repository.GetByIdAsync<User>(u.Id))
                                            .Select(t => t.Result);

            Project project = new Project(details.Title, details.Description, ownerId);
            project.Participants = users.Where(u => u != null)
                                        .Select(u => u!)
                                        .ToList();

            project.Id = Guid.NewGuid().ToString();
            (await _repository.GetByIdAsync<User>(ownerId))!.CreatedProjects.Add(project);
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task EditProject(ProjectDetailsVM projectDetails)
        {
            var users = projectDetails.Participants.Select(async u => await _repository.GetByIdAsync<User>(u.Id))
                                                   .Select(t => t.Result);
            Project project = await _repository.AllAsync<Project>()
                                                .Include(p => p.Participants)
                                                .FirstAsync(p => p.Id == projectDetails.Id);
            project.Title = projectDetails.Title;
            project.Description = projectDetails.Description;
            project.Participants = users.Where(u => u != null)
                                        .Select(u => u!)
                                        .ToList();
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task RemoveProject(string id)
        {
            _repository.DeleteRangeAsync(_repository.AllAsNoTrackingAsync<UserProject>().Where(up => up.ProjectId == id));

            await _repository.DeleteByIdAsync<Project>(id);
            await _repository.SaveChangesAsync();
        }
    }
}
