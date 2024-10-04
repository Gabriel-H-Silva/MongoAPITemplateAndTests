using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Repository.Interface;
using System.Text.Json.Serialization;
using TasksManager.Model.Base;

namespace Models.CrudModel
{
    [BsonIgnoreExtraElements]
    public class CrudModel : BaseEntity, ICollectionNameProvider
    {
        [JsonIgnore]
        public string CollectionName => "CRUD";

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("age")]
        [JsonPropertyName("age")]
        public string Age { get; set; }

        [BsonElement("gender")]
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [BsonElement("createdDate")]
        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }

        public CrudModel(string name, string age, string gender, string email, string createdDate)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Email = email;
            CreatedDate = createdDate;
        }
    }
}
