using Microsoft.AspNetCore.Identity;

namespace ToDo.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        public List<Project> ParticipatedProjects { get; set; } = new List<Project>();
        public List<Project> CreatedProjects { get; set; } = new List<Project>();
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
