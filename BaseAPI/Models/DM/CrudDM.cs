using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace DataModels.CrudDM
{
    public class CrudDM
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? CreatedDate { get; set; }

        public CrudDM(string? id, string? name, string? age, string? gender, string? email, string? createdDate)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Email = email;
            CreatedDate = createdDate;
        }
    }
}
