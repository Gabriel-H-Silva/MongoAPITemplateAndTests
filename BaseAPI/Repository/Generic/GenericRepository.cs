using Mongo.Services;
using MongoDB.Driver;
using Repository.Interface;
using TasksManager.Model.Base;

namespace Repository.Generic
{
        public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, ICollectionNameProvider
        {
            private readonly IMongoCollection<T> _Collection;

            public GenericRepository(MongoDBService mongoDBService)
            {

                var collectionName = Activator.CreateInstance<T>()?.CollectionName;
                _Collection = mongoDBService.GetCollection<T>(collectionName);
            }
            public async Task<List<T>> Get() => await _Collection.Find(_ => true).ToListAsync();

            public async Task<T> GetById(string id)
            {
                var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
                return await _Collection.Find(filter).FirstOrDefaultAsync();
            }

            public async Task RemoveById(string id)
            {
                var filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
                await _Collection.DeleteOneAsync(filter);
            }

            public async Task<T> Save(T item)
            {
                if (string.IsNullOrEmpty(item.Id))
                {
                    await _Collection.InsertOneAsync(item);
                    return item;
                }
                else
                {
                    var filter = Builders<T>.Filter.Eq(doc => doc.Id, item.Id);

                    var updateResult = await _Collection.ReplaceOneAsync(filter, item);
                    return item;
                }
            }
        }
    
}
