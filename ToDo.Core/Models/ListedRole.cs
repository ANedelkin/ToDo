using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Models
{
    public struct ListedRole
    {
        public readonly string id;
        public readonly string title;
        public readonly string? description;
        public readonly string colorHex;
        public ListedRole(Role role) : this(role.Id, role.Title, role.Description, role.ColorHex) { }
        public ListedRole(string id, string title, string? description, string colorHex)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.colorHex = colorHex;
        }
    }
}
