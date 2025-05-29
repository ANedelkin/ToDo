using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public List<ListedLabel> Labels { get; set; }
        [Required]
        public List<ListedUser> Participants { get; set; }
        public TaskVM(string title, string description, DateTime dueDate, List<ListedLabel> labels, List<ListedUser> participants)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Labels = labels;
            Participants = participants;
        }
    }
}
