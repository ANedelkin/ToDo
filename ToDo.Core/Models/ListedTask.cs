using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models
{
    public struct ListedTask
    {
        readonly string id;
        readonly string title;
        readonly TaskStatus status;
        ListedTask(string id, string title, TaskStatus status)
        {
            this.id = id;
            this.title = title;
            this.status = status;
        }
    }
}
