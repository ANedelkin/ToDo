using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models.ViewModels
{
    public class ProjectVM
    {
        public string Id { get; }
        public TasksVM TasksVM { get; }
        public bool IsCreator { get; set; }
        public ProjectVM(string id, TasksVM tasksVM)
        {
            Id = id;
            TasksVM = tasksVM;
        }
    }
}
