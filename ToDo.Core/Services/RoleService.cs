using ToDo.Core.Models.ViewModels;
using ToDo.Core.Models;
using ToDo.Infrastructure.Data.Common;
using ToDo.Infrastructure.Data.Models;
using ToDo.Core.Contracts;

namespace ToDo.Core.Services
{
    class RoleService : IRoleService
    {
        private readonly IRepository _repository;
        public RoleService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ListedRole>> GetProjectRoles(string id)
        {
            return (await _repository.GetByIdAsync<Project>(id)).Roles.Select(r => new ListedRole(r)).ToList();
        }
        public async Task<RoleVM> GetRole(string id)
        {
            return new RoleVM(await _repository.GetByIdAsync<Role>(id));
        }
        public async System.Threading.Tasks.Task UpdateRole(string id, RoleVM newRole)
        {
            await _repository.UpdateAsync<Role>(id, new Role(newRole.Title, newRole.Description, newRole.ColorHex, (await _repository.GetByIdAsync<Role>(id)).ProjectId));
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task AddRole(string projectId, RoleVM role)
        {
            (await _repository.GetByIdAsync<Project>(projectId)).Roles.Add(new Role(role.Title, role.Description, role.ColorHex, projectId));
            await _repository.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteRole(string id)
        {
            await _repository.DeleteByIdAsync<Role>(id);
            await _repository.SaveChangesAsync();
        }
    }
}
