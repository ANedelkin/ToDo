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
    interface ITaskService
    {
        public Task<List<ListedTask>> GetProjectTasks(string projectId);
        public Task<TaskVM> GetTaskDetails(string taskId);
        public Task AddTask(string projectId, TaskVM task, Constants.TaskStatus status);
        public Task UpdateTask(string taskId, TaskVM task);
        public Task ChangeTaskStatus(string taskId, Constants.TaskStatus newStatus);
        public Task DeleteTask(string id);
    }
}
