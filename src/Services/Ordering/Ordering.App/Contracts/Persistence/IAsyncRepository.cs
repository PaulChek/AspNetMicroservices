using Ordering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ordering.App.Contracts.Persistence {
    public interface IAsyncRepository<T> where T : ModelBase {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> filter);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string inclideString, bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            List<Expression<Func<T, object>>> includes,
            string includeString, bool disableTracking = true);

        Task<T> GetAsync(int Id);
        Task<T> AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeletAsync(int Id);
    }
}
