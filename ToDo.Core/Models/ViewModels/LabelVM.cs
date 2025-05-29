using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Constants;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Models.ViewModels
{
    public class LabelVM
    {
        [Required]
        [MinLength(LabelConstants.titleMinLength)]
        [MaxLength(LabelConstants.titleMaxLength)]
        public string Title { get; set; }
        [MaxLength(TaskConstants.descriptionMaxLength)]
        public string? Description { get; set; }
        [Required]
        [RegularExpression("#[0-9a-fA-F]{6}\b")]
        public string ColorHex { get; set; }
        public LabelVM(Label label) : this(label.Title, label.Description, label.ColorHex) { }
        public LabelVM(string title, string? description, string colorHex)
        {
            Title = title;
            Description = description;
            ColorHex = colorHex;
        }
    }
}
