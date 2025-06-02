using System.ComponentModel.DataAnnotations;
using ToDo.Constants;

namespace ToDo.Core.Models.ViewModels
{
    public class TaskVM
    {
        [Required]
        [MinLength(TaskConstants.titleMinLength)]
        [MaxLength(TaskConstants.titleMaxLength)]
        public string Title { get; set; }
        [MaxLength(TaskConstants.descriptionMaxLength)]
        public string? Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public List<ListedLabel> Labels { get; set; }
        [Required]
        public List<ListedUser> Participants { get; set; }
        public TaskVM(Infrastructure.Data.Models.Task task) : this(
            task.Title, 
            task.Description, 
            task.DueDate, 
            task.Labels.Select(l => new ListedLabel(l)).ToList(),
            task.Participants.Select(p => new ListedUser(p)).ToList()
        ) { }
        public TaskVM(string title, string? description, DateTime dueDate, List<ListedLabel> labels, List<ListedUser> participants)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Labels = labels;
            Participants = participants;
        }
    }
}
