using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Models.ViewModels
{
    public class ProjectDetailsVMWithId : ProjectDetailsVM
    {
        [Required]
        public string Id { get; set; }
        public ProjectDetailsVMWithId() { }
        public ProjectDetailsVMWithId(Project project) : this(project.Id, project.Title, project.Description, project.Participants.Select(p => new ListedUser(p)).ToList()) { }
        public ProjectDetailsVMWithId(string id, string title, string description, List<ListedUser> participants) : base(title, description, participants)
        {
            Id = id;
        }
    }
}
