namespace ToDo.Core.Models
{
    public struct ListedTask
    {
        public readonly string id;
        public readonly string title;
        public readonly Constants.Enums.TaskStatus status;
        public ListedTask(Infrastructure.Data.Models.Task task) : this(task.Id, task.Title, task.TaskStatus) { }
        public ListedTask(string id, string title, Constants.Enums.TaskStatus status)
        {
            this.id = id;
            this.title = title;
            this.status = status;
        }
    }
}
