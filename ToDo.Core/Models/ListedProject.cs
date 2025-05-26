using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models
{
    public struct ListedProject
    {
        readonly string id;
        readonly string title;
        readonly string description;
        ListedProject(string id, string title, string description)
        {
            this.id = id;
            this.title = title;
            this.description = description;
        }
    }
}
