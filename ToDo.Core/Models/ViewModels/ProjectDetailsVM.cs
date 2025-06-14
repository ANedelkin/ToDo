﻿using System;
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
        public string? Id { get; set; } = string.Empty;
        public bool IsCreator { get; set; }
        [MinLength(ProjectConstants.titleMinLength)]
        [MaxLength(ProjectConstants.titleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(ProjectConstants.descriptionMinLength)]
        [MaxLength(ProjectConstants.descriptionMaxLength)]
        public string Description { get; set; } = string.Empty;
        public List<ListedUser> Participants { get; set; }
        public ProjectDetailsVM() { }
        public ProjectDetailsVM(Project project) : this(project.Title, project.Description, project.Participants.Select(p => new ListedUser(p)).ToList()) { }
        public ProjectDetailsVM(string title, string description, List<ListedUser> participants)
        {
            Title = title;
            Description = description;
            Participants = participants;
        }
    }
}
