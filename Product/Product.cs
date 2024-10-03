using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JanasInventoryManagementSystem.Product
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }


        public Product(string? name, decimal? price, int? quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
