using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models.ViewModels;
using ToDo.Core.Models;

namespace ToDo.Core.Contracts
{
    interface IRoleService
    {
        public Task<List<ListedRole>> GetProjectRoles(string id);
        public Task<RoleVM> GetRole(string id);
        public Task UpdateRole(string id, RoleVM newRole);
        public Task AddRole(string projectId, RoleVM role);
        public Task DeleteRole(string id);
    }
}
