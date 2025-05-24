using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Constants;

namespace ToDo.Infrastructure.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(ProjectConstants.nameMaxLength)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string OwnerId { get; set; } = string.Empty;
        [ForeignKey(nameof(OwnerId))]
        public virtual User? Owner { get; set; }
    }
}
