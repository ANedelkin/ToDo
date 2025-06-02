using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Models
{
    public struct ListedUser
    {
        public readonly string id;
        public readonly string userName;
        public ListedUser(User user) : this(user.Id, user.UserName) { }
        public ListedUser(string id, string userName)
        {
            this.id = id;
            this.userName = userName;
        }
    }
}
