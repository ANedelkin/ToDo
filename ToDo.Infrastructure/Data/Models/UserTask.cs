using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infrastructure.Data.Models
{
    public class UserTask
    {
        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
        [Required]
        public int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Task? Task { get; set; }
    }
}
