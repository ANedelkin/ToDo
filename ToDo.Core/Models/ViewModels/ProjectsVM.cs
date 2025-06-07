using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Constants.Enums;


namespace ToDo.Core.Models.ViewModels
{
    public class ProjectsVM
    {
        public string UserName { get; }
        public ProjectsTab ProjectsTab { get; }
        public List<ListedProject> Projects { get; }
        public ProjectsVM(string userName, ProjectsTab projectsTab, List<ListedProject> projects)
        {
            UserName = userName;
            ProjectsTab = projectsTab;
            Projects = projects;
        }
    }
}
