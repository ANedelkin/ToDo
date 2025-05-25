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
using ToDo.Infrastructure.Data.Models.Interfaces;

namespace ToDo.Infrastructure.Data.Models
{
    public class Role : IEntity
    {
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
    }
}
