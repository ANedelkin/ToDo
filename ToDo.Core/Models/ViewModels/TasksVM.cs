using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models.ViewModels
{
    public class TasksVM
    {
        public string ProjectName { get; }
        public List<ListedTask> Tasks { get; }
        public TasksVM(string projectName, List<ListedTask> tasks)
        {
            ProjectName = projectName;
            Tasks = tasks;
        }
    }
}
