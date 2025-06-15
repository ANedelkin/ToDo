using ToDo.Core.Models;
using ToDo.Core.Models.ViewModels;
using ToDo.Infrastructure.Data.Common;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Contracts
{
    public class TaskService : ITaskService
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
        public async Task<TaskVM?> GetTaskDetails(string taskId)
        {
            var task = await _repository.GetByIdAsync<Infrastructure.Data.Models.Task>(taskId);
            return new TaskVM(task);
        }
        public async System.Threading.Tasks.Task AddTask(TaskVM details)
        {
            var users = details.Participants.Select(async u => await _repository.GetByIdAsync<User>(u.Id))
                                            .Select(t => t.Result);

            var task = new Infrastructure.Data.Models.Task(details.Title, details.Description, details.DueDate, details.Status, details.ProjectId);
            task.Participants = users.Where(u => u != null)
                                        .Select(u => u!)
                                        .ToList();

            task.Id = Guid.NewGuid().ToString();
            await _repository.AddAsync<Infrastructure.Data.Models.Task>(task);
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task UpdateTask(string taskId, TaskVM task)
        {
            var oldTask = await _repository.GetByIdAsync<Infrastructure.Data.Models.Task>(taskId);
            await _repository.UpdateAsync<Infrastructure.Data.Models.Task>(taskId, new(task.Title, task.Description, task.DueDate, oldTask.TaskStatus, oldTask.ProjectId));
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task ChangeTaskStatus(string taskId, Constants.Enums.TaskStatus newStatus)
        {
            var task = await _repository.GetByIdAsync<Infrastructure.Data.Models.Task>(taskId);
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
