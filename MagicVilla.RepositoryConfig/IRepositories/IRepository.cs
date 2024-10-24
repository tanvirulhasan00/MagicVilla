using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.RepositoryConfig.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, string? includeProperties = null, bool? NoTracking = true, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, string? includeProperties = null, bool? NoTracking = true, CancellationToken cancellationToken = default);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
    }
}
