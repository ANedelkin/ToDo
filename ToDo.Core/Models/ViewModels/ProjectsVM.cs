using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models.ViewModels
{
    public class ProjectsVM
    {
        public string UserName { get; }
        public List<ListedProject> Projects { get; }
        public ProjectsVM(string userName, List<ListedProject> projects)
        {
            UserName = userName;
            Projects = projects;
        }
    }
}
