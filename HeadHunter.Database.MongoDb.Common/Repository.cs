﻿using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Common
{
    public class Repository
    {
        private readonly IMongoDatabase _database;

        public Repository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<ReplaceOneResult> SaveAsync<T>(T item) where T : ICollection
        {
            var options = new ReplaceOptions { IsUpsert = true };

            return await GetCollection<T>().ReplaceOneAsync(element => element.Id == item.Id, item, options);
        }

        public async Task<List<T>> FindAsync<T>() where T : ICollection
        {
            return await GetCollection<T>().Find(item => true).ToListAsync();
        }

        public async Task<List<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : ICollection
        {
            return await GetCollection<T>().Find(predicate).ToListAsync();
        }

        public async Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate) where T : ICollection
        {
            return await GetCollection<T>().Find(predicate).FirstAsync<T>();
        }

        public async Task<bool> ContainsAsync<T>(Expression<Func<T, bool>> predicate) where T : ICollection
        {
            return (await GetCollection<T>().Find(predicate).FirstAsync<T>()) != null;
        }

        public async Task<T> FindByIdAsync<T>(ObjectId id) where T : ICollection
        {
            return await GetCollection<T>().Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveAsync<T>(ObjectId id) where T : ICollection
        {
            return await GetCollection<T>().DeleteOneAsync(item => item.Id == id);
        }

        private IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>((typeof(T)
            .GetCustomAttributes(typeof(MongoDbCollectionNameAttibute), true)[0] as MongoDbCollectionNameAttibute).Name);
    }
}
