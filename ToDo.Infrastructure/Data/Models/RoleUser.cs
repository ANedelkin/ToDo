using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Infrastructure.Data.Models
{
    public class RoleUser
    {
        [Required]
        public string RoleId { get; set; } = string.Empty;
        [ForeignKey(nameof(RoleId))]
        public virtual Role? Role { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
    }
}
