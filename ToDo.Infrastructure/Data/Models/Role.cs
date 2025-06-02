using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Constants;

namespace ToDo.Infrastructure.Data.Models
{
    public class Role
    {
        public Role(string title, string? description, string colorHex, string projectId)
        {
            Title = title;
            Description = description;
            ColorHex = colorHex;
            ProjectId = projectId;
        }

        [Key]
        public string Id { get; set; } = string.Empty;
        [Required]
        [MaxLength(RoleConstants.titleMaxlength)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(RoleConstants.descriptionMaxlength)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(CommonConstants.colorHexMaxLength)]
        public string ColorHex { get; set; } = string.Empty;
        [Required]
        public string ProjectId { get; set; } = string.Empty;
        [ForeignKey(nameof(ProjectId))]
        public virtual Project? Project { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
