using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Constants;

namespace ToDo.Infrastructure.Data.Models
{
    public class Label
    {
        public Label(string title, string? description, string colorHex, string projectId)
        {
            Title = title;
            Description = description;
            ColorHex = colorHex;
            ProjectId = projectId;
        }

        [Key]
        public string Id { get; set; } = string.Empty;
        [Required]
        [MaxLength(LabelConstants.titleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(LabelConstants.descriptionMaxLength)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(CommonConstants.colorHexMaxLength)]
        public string ColorHex { get; set; } = string.Empty;
        [Required]
        public string ProjectId { get; set; } = string.Empty;
        [ForeignKey(nameof(ProjectId))]
        public virtual Project? Project { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
