using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Constants;
using ToDo.Infrastructure.Data.Models.Interfaces;

namespace ToDo.Infrastructure.Data.Models
{
    public class Project : IEntity
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        [Required]
        [MaxLength(ProjectConstants.nameMaxLength)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string OwnerId { get; set; } = string.Empty;
        [ForeignKey(nameof(OwnerId))]
        public virtual User? Owner { get; set; }
    }
}
