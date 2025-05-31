using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Models
{
    public struct ListedProject
    {
        public readonly string id;
        public readonly string title;
        public readonly string? description;
        public ListedProject(Project project) : this(project.Id, project.Title, project.Description) { }
        public ListedProject(string id, string title, string? description)
        {
            this.id = id;
            this.title = title;
            this.description = description;
        }
    }
}
