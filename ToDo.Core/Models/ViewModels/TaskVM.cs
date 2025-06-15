using System.ComponentModel.DataAnnotations;
using ToDo.Constants;

namespace ToDo.Core.Models.ViewModels
{
    public class TaskVM
    {
        public string? Id { get; set; } = string.Empty;
        [Required]
        [MinLength(TaskConstants.titleMinLength)]
        [MaxLength(TaskConstants.titleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(TaskConstants.descriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public List<ListedLabel> Labels { get; set; } = new List<ListedLabel>();
        [Required]
        public List<ListedLabel> AllLabels { get; set; } = new List<ListedLabel>();
        [Required]
        public List<ListedUser> Participants { get; set; } = new List<ListedUser>();
        public Constants.Enums.TaskStatus Status { get; set; }
        public string ProjectId { get; set; }
        public TaskVM() { }
        public TaskVM(Infrastructure.Data.Models.Task task) : this(
            task.Title, 
            task.Description??"", 
            task.TaskStatus,
            task.ProjectId,
            task.DueDate,
            task.Labels.Select(l => new ListedLabel(l)).ToList(),
            task.Participants.Select(p => new ListedUser(p)).ToList()
        ) { }
        public TaskVM(string title, string? description, Constants.Enums.TaskStatus status, string projectId, DateTime dueDate, List<ListedLabel> labels, List<ListedUser> participants)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Labels = labels;
            Participants = participants;
        }
    }
}
