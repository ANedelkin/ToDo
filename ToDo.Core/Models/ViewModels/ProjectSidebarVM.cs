using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models.ViewModels
{
    public class ProjectSidebarVM
    {
        public string Title { get;set; }
        public int SelectionIndex { get; set; }
        public string ProjectId { get; set; }
        public ProjectSidebarVM(string title, int selectionIndex, string projectId)
        {
            Title = title;
            SelectionIndex = selectionIndex;
            ProjectId = projectId;
        }
    }
}
