using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> AllAsync<T>() where T : class;
        IQueryable<T> AllAsNoTrackingAsync<T>() where T : class;
        Task<bool> Exists<T>(string id) where T : class;
        Task<T> GetByIdAsync<T>(string id) where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;
        Task UpdateAsync<T>(string Id, T newEntity) where T : class;
        Task DeleteAsync<T>(string id) where T : class;
        Task<int> SaveChangesAsync();
    }
}
