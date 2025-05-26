using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models.ViewModels
{
    public class RolesVM
    {
        public string ProjectName { get; }
        public List<ListedRole> Roles { get; }
        public RolesVM(string projectName, List<ListedRole> roles)
        {
            ProjectName = projectName;
            Roles = roles;
        }
    }
}
