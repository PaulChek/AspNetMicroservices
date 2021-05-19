using Catalog.Api.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.Api.Repository {
    public class Repository<T> : IRepository<T> where T : IEntity {
        private readonly IMongoCollection<T> _dbContext;
        private readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

        public Repository(MongoDbContext<T> dbContext) {
            _dbContext = dbContext.GetType().GetProperty("Collection").GetValue(dbContext) as IMongoCollection<T>;




        }




        public Task<T> GetAsync(string id) {
            return _dbContext.Find(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter) {
            return await _dbContext.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<T>> GetAllAsync() {
            return await _dbContext.Find(v => true).ToListAsync();
        }
        public async Task<bool> AddAsync(T item) {
            await _dbContext.InsertOneAsync(item);
            return true;
        }
        public async Task<bool> DeleteAsync(string id) {
            var res = await _dbContext.DeleteOneAsync(id);
            return res.DeletedCount > 0;
        }

        public async Task<bool> UpdateAsync(T item) {
            var filter = _filterBuilder.Eq(v => v.Id, item.Id);
            var res = await _dbContext.ReplaceOneAsync(filter, item);
            return res.ModifiedCount > 0;
        }
    }
}
