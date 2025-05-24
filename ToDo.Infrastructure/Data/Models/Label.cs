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
    public class Label
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(LabelConstants.titleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(LabelConstants.descriptionMaxLength)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(CommonConstants.colorHexMaxLength)]
        public string ColorHex { get; set; } = string.Empty;
        [Required]
        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public virtual Project? Project { get; set; }
    }
}
