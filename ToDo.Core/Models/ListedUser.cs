using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models
{
    public struct ListedUser
    {
        readonly string id;
        readonly string userName;
        public ListedUser(string id, string userName)
        {
            this.id = id;
            this.userName = userName;
        }
    }
}
