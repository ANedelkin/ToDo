using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models
{
    public struct ListedRole
    {
        readonly string id;
        readonly string title;
        readonly string description;
        readonly string colorHex;
        ListedRole(string id, string title, string description, string colorHex)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.colorHex = colorHex;
        }
    }
}
