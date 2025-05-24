using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Constants;

namespace ToDo.Infrastructure.Data.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(RoleConstants.titleMaxlength)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(RoleConstants.descriptionMaxlength)]
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
