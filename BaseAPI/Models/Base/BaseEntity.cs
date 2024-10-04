using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TasksManager.Model.Base
{
    [BsonIgnoreExtraElements]
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
