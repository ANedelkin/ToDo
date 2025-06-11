using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Contracts
{
    public interface IUserService
    {
        public Task<ListedUser?> GetUserByUserName(string userName);
    }
}
