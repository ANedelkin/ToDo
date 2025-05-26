using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models.ViewModels
{
    public class ProjectVM
    {
        public TasksVM TasksVM { get; }
        public ProjectVM(TasksVM tasksVM)
        {
            TasksVM = tasksVM;
        }
    }
}
