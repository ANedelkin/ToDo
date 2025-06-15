using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models.ViewModels
{
    public class SidebarVM : Dictionary<string, string>
    {
        public string Title { get; set; }
        public int SelectionIndex { get; set; }
        public SidebarVM(string title, int selectionIndex)
        {
            Title = title;
            SelectionIndex = selectionIndex;
        }
    }
}
