using MagicVilla.DatabaseConfig.Data;
using MagicVilla.RepositoryConfig.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.RepositoryConfig.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MagicVillaDbContext _magicVillaDbContext;
        internal DbSet<T> dbSet;
        public Repository(MagicVillaDbContext magicVillaDbContext)
        {
            _magicVillaDbContext = magicVillaDbContext;
            this.dbSet = _magicVillaDbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, string? includeProperties = null, bool? NoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = NoTracking == true ? dbSet.AsNoTracking() : dbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string? includeProperties = null, bool? NoTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = NoTracking == true ? dbSet.AsNoTracking() : dbSet;
            query = query.Where(expression);
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            var data = await query.FirstOrDefaultAsync(cancellationToken);

            return data ?? throw new InvalidOperationException("Data not found.");
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(List<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
