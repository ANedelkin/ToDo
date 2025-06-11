using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Contracts;
using ToDo.Core.Models;
using ToDo.Infrastructure.Data.Common;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<ListedUser?> GetUserByUserName(string userName)
        {
            return await _repository.AllAsNoTrackingAsync<User>()
                                    .Where(x => x.UserName == userName)
                                    .Select(u => new ListedUser(u.Id, u.UserName))
                                    .FirstOrDefaultAsync();
                
        }
    }
}
