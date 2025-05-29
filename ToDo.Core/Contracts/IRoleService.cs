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
        public Task<List<ListedRole>> GetProjectRoles(string Id);
        public Task<RoleVM> GetRole(string Id);
        public Task<IActionResult> UpdateRole(string Id, RoleVM newRole);
        public Task<IActionResult> AddRole(RoleVM role);
        public Task<IActionResult> DeleteRole(string Id);
    }
}
