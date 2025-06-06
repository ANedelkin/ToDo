using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
        public List<string> Participants { get; set; }
        public ProjectDetailsVM(Project project) : this(project.Title, project.Description, project.Participants.Select(p => p.Id).ToList()) { }
        public ProjectDetailsVM(string title, string description, List<string> participants)
        {
            Title = title;
            Description = description;
            Participants = participants;
        }
    }
}
