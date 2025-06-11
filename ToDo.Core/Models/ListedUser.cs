using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Models
{
    public class ListedUser
    {
        public ListedUser(User user) : this(user.Id, user.UserName) { }
        public ListedUser(string id, string username)
        {
            Id = id;
            Username = username;
        }

        public string Id { get; set; }
        public string Username { get; set; }
    }
}
