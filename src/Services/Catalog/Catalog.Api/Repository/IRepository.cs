using Catalog.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.Api.Repository {
    public interface IRepository<T> where T : IEntity {
        Task<T> GetAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<bool> AddAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateAsync(T item);
    }
}
