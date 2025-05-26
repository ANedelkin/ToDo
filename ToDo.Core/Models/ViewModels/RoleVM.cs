using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Constants;

namespace ToDo.Core.Models.ViewModels
{
    public class RoleVM
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [MinLength(LabelConstants.titleMinLength)]
        [MaxLength(LabelConstants.titleMaxLength)]
        public string Title { get; set; }
        [MaxLength(TaskConstants.descriptionMaxLength)]
        public string Description { get; set; }
        [Required]
        [RegularExpression("#[0-9a-fA-F]{6}\b")]
        public string ColorHex { get; set; }
        [Required]
        public List<ListedUser> Users { get; set; }
        public RoleVM(string id, string title, string description, string colorHex, List<ListedUser> users)
        {
            Id = id;
            Title = title;
            Description = description;
            ColorHex = colorHex;
            Users = users;
        }
    }
}
