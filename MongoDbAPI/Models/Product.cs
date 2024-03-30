using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAPI.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Category { get; set; }

        public Product()
        {

        }

    }
}
