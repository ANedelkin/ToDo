using Microsoft.AspNetCore.Mvc;
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
    class TaskService : ITaskService
    {
        private readonly IRepository _repository;
        public TaskService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ListedTask>> GetProjectTasks(string projectId)
        {
            return (await _repository.GetByIdAsync<Project>(projectId)).Tasks.Select(t => new ListedTask(t)).ToList();
        }
        public async Task<TaskVM> GetTaskDetails(string taskId)
        {
            return new TaskVM(await _repository.GetByIdAsync<Infrastructure.Data.Models.Task>(taskId));
        }
        public async System.Threading.Tasks.Task AddTask(string projectId, TaskVM task, Constants.TaskStatus status)
        {
            await _repository.AddAsync<Infrastructure.Data.Models.Task>(new(task.Title, task.Description, task.DueDate, status, projectId));
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task UpdateTask(string taskId, TaskVM task)
        {
            Infrastructure.Data.Models.Task oldTask = await _repository.GetByIdAsync<Infrastructure.Data.Models.Task>(taskId);
            await _repository.UpdateAsync<Infrastructure.Data.Models.Task>(taskId, new(task.Title, task.Description, task.DueDate, oldTask.TaskStatus, oldTask.ProjectId));
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task ChangeTaskStatus(string taskId, Constants.TaskStatus newStatus)
        {
            Infrastructure.Data.Models.Task task = await _repository.GetByIdAsync<Infrastructure.Data.Models.Task>(taskId);
            task.TaskStatus = newStatus;
            await _repository.UpdateAsync<Infrastructure.Data.Models.Task>(taskId, task);
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteTask(string id)
        {
            await _repository.DeleteByIdAsync<Infrastructure.Data.Models.Task>(id);
            await _repository.SaveChangesAsync();
        }
    }
}
