using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Constants;

namespace ToDo.Infrastructure.Data.Models
{
    public class Project
    {
        public Project(string title, string description, string ownerId)
        {
            Title = title;
            Description = description;
            OwnerId = ownerId;
        }

        [Key]
        public string Id { get; set; } = string.Empty;
        [Required]
        [MaxLength(ProjectConstants.titleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(ProjectConstants.descriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string OwnerId { get; set; } = string.Empty;
        [ForeignKey(nameof(OwnerId))]
        public virtual User? Owner { get; set; }
        public List<User> Participants { get; set; } = new List<User>();
        public List<Label> Labels { get; set; } = new List<Label>();
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
