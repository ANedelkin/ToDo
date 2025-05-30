using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Infrastructure.Data.Models
{
    public class UserTask
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
        [Required]
        public string TaskId { get; set; } = string.Empty;
        [ForeignKey(nameof(TaskId))]
        public virtual Task? Task { get; set; }
    }
}
