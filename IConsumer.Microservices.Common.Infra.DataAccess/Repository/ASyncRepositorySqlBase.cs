using IConsumer.Microservices.Common.Domain.Entity;
using IConsumer.Microservices.Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IConsumer.Microservices.Common.Infra.DataAccess.Repository
{
    public abstract class ASyncRepositorySqlBase<TId, T> : IAsyncRepository<TId, T>, IQueryRepository<TId, T> where T : TEntity<TId>
    {
        protected DbContext _context;
        public ASyncRepositorySqlBase(DbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(TId id)
        {
            _context.Set<T>().Remove(await ReadAsync(id));
        }

        public async Task<T> ReadAsync(TId id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
