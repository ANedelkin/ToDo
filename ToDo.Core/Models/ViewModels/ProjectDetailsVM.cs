using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Constants;

namespace ToDo.Core.Models.ViewModels
{
    public class ProjectDetailsVM
    {
        [Required]
        [MinLength(ProjectConstants.titleMinLength)]
        [MaxLength(ProjectConstants.titleMaxLength)]
        public string Title { get; set; }
        [Required]
        [MinLength(ProjectConstants.descriptionMinLength)]
        [MaxLength(ProjectConstants.descriptionMaxLength)]
        public string Description { get; set; }
        [Required]
        public List<ListedUser> Participants { get; set; }
        public ProjectDetailsVM(string id, string title, string description, List<ListedUser> participants)
        {
            Id = id;
            Title = title;
            Description = description;
            Participants = participants;
        }
    }
}
