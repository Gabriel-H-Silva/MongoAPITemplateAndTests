using BaseAPI.Infrastructure;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mongo.Services
{
    public class MongoDBService
    {

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            _client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            _database = _client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName)
        {
            return _database.GetCollection<TDocument>(collectionName);
        }

    }
}
