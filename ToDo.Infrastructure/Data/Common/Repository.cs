using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Data.Models.Interfaces;

namespace ToDo.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        private DbSet<T> DbSet<T>() where T : class, IEntity
        {
            return _context.Set<T>();
        }

        public IQueryable<T> AllAsync<T>() where T : class, IEntity
        {
            return DbSet<T>();
        }
        public IQueryable<T> AllAsNoTrackingAsync<T>() where T : class, IEntity
        {
            return DbSet<T>().AsNoTracking();
        }
        public async Task<bool> Exists<T>(string id) where T : class, IEntity
        {
            return await DbSet<T>().AnyAsync(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync<T>(string id) where T : class, IEntity
        {
            return await DbSet<T>().FindAsync(id) ?? throw new KeyNotFoundException();
        }
        public async Task AddAsync<T>(T entity) where T : class, IEntity
        {
            await DbSet<T>().AddAsync(entity);
        }
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            await DbSet<T>().AddRangeAsync(entities);
        }
        public async Task UpdateAsync<T>(T newEntity) where T : class, IEntity
        {
            T oldEntity = await GetByIdAsync<T>(newEntity.Id) ?? throw new KeyNotFoundException();
            _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            await SaveChangesAsync();
        }
        public async Task DeleteAsync<T>(string id) where T : class, IEntity
        {
            T entity = await GetByIdAsync<T>(id) ?? throw new KeyNotFoundException();
            DbSet<T>().Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}
