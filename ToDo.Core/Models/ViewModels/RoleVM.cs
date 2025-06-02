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
    public class RoleVM
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
        [Required]
        public List<ListedUser> Users { get; set; }
        public RoleVM(Role role) : this(role.Title, role.Description, role.ColorHex, role.Users.Select(u => new ListedUser(u)).ToList()) { }
        public RoleVM(string title, string? description, string colorHex, List<ListedUser> users)
        {
            Title = title;
            Description = description;
            ColorHex = colorHex;
            Users = users;
        }
    }
}
