using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models.Interfaces;

namespace ToDo.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> AllAsync<T>() where T : class, IEntity;
        IQueryable<T> AllAsNoTrackingAsync<T>() where T : class, IEntity;
        Task<bool> Exists<T>(string id) where T : class, IEntity;
        Task<T> GetByIdAsync<T>(string id) where T : class, IEntity;
        Task AddAsync<T>(T entity) where T : class, IEntity;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class, IEntity;
        Task UpdateAsync<T>(T newEntity) where T : class, IEntity;
        Task DeleteAsync<T>(string id) where T : class, IEntity;
        Task<int> SaveChangesAsync();
    }
}
