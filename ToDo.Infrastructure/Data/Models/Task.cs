using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Constants;

namespace ToDo.Infrastructure.Data.Models
{
    public class Task
    {
        public Task(string title, string? description, DateTime dueDate, Constants.Enums.TaskStatus taskStatus, string projectId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            TaskStatus = taskStatus;
            ProjectId = projectId;
        }

        [Key]
        public string Id { get; set; } = string.Empty;
        [Required]
        [MaxLength(TaskConstants.titleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(TaskConstants.descriptionMaxLength)]
        public string? Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public Constants.Enums.TaskStatus TaskStatus { get; set; }
        [Required]
        public string ProjectId { get; set; } = string.Empty;
        [ForeignKey(nameof(ProjectId))]
        public virtual Project? Project { get; set; }
        public List<Label> Labels { get; set; } = new List<Label>();
        public List<User> Participants { get; set; } = new List<User>();
    }
}
