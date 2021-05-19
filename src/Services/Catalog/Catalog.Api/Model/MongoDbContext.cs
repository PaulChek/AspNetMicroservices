using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Model {
    public class MongoDbContext<T> {
        public MongoDbContext(IConfiguration config) {
            var client = new MongoClient(config.GetValue<string>("MongoDbSettings:ConnectionString"));
            var db = client.GetDatabase(config.GetValue<string>("MongoDbSettings:DbName"));
            Collection = db.GetCollection<T>(config.GetValue<string>("MongoDbSettings:Collection"));
        }

        public IMongoCollection<T> Collection { get; }

    }
}
