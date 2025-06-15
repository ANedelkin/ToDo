using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> AllAsync<T>() where T : class
        {
            return DbSet<T>();
        }
        public IQueryable<T> AllAsNoTrackingAsync<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }
        public async Task<bool> Exists<T>(string id) where T : class
        {
            return await DbSet<T>().FindAsync(id) != null;
        }

        public async Task<T?> GetByIdAsync<T>(string id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }
        public async Task UpdateAsync<T>(string id, T newEntity) where T : class
        {
            T oldEntity = await GetByIdAsync<T>(id) ?? throw new KeyNotFoundException();
            _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }
        public async Task DeleteByIdAsync<T>(string id) where T : class
        {
            T entity = await GetByIdAsync<T>(id) ?? throw new KeyNotFoundException();
            DbSet<T>().Remove(entity);
        }
        public void DeleteRangeAsync<T>(IEnumerable<T> objects) where T : class
        {
            _context.RemoveRange(objects);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
