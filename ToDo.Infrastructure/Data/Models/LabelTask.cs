using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infrastructure.Data.Models
{
    public class LabelTask
    {
        [Required]
        public string LabelId { get; set; } = string.Empty;
        [ForeignKey(nameof(LabelId))]
        public virtual Label? Label { get; set; }
        [Required]
        public string TaskId { get; set; } = string.Empty;
        [ForeignKey(nameof(TaskId))]
        public virtual Task? Task { get; set; }
    }
}
