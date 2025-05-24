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
        public int LabelId { get; set; }
        [ForeignKey(nameof(LabelId))]
        public virtual Label? Label { get; set; }
        [Required]
        public int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Task? Task { get; set; }
    }
}
