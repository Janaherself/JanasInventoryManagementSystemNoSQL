using JanasInventoryManagementSystem.ConsoleProgram;
using JanasInventoryManagementSystem.Product;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System.Xml.Linq;

namespace JanasInventoryManagementSystem.Database
{
    public class NoSQLInventory
    {
        private const string connectionString = "mongodb://127.0.0.1:27017";
        private const string databaseName = "Inventory";
        private const string ProductCollection = "Products";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task Add()
        {
            var productsCollection = ConnectToMongo<Product.Product>(ProductCollection);
            var product = ReadFromConsole();
            await productsCollection.InsertOneAsync(product);
            Console.WriteLine("Product added succefully!\n");
        }

        public Product.Product ReadFromConsole()
        {
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter new product price: ");
            decimal? price = decimal.TryParse(Console.ReadLine(), out decimal Price) ? Price : null;

            Console.Write("Enter new product quantity: ");
            int? quantity = int.TryParse(Console.ReadLine(), out int Quantity) ? Quantity : null;

            Console.WriteLine();

            return new Product.Product(name, price, quantity);
        }

        public async Task View()
        {
            var productsCollection = ConnectToMongo<Product.Product>(ProductCollection);
            var products = await productsCollection.Find(_ => true).ToListAsync();

            foreach (var product in products)
            {
                PrintItem(product);
            }
        }

        public async Task Edit()
        {
            var productsCollection = ConnectToMongo<Product.Product>(ProductCollection);

            var product = GetProductByID();
            if (product == null)
            {
                Console.WriteLine("Invalid ID!\n");
                return;
            }
            else
            {
                var filter = Builders<Product.Product>.Filter.Eq("Id", product.Id);

                var updatedProduct = GetNewValues();
                var updateDefinition = new List<UpdateDefinition<Product.Product>>();
                UpdateDefinition<Product.Product> combinedUpdate;

                CombineUpdates(updatedProduct, updateDefinition, out combinedUpdate);
                if (combinedUpdate == null)
                {
                    Console.WriteLine("No changes to update\n");
                }
                else
                {
                    var result = await productsCollection.UpdateOneAsync(filter, combinedUpdate);

                    if (result.ModifiedCount > 0)
                    {
                        Console.WriteLine("Product updated successfully\n");
                    }
                    else
                    {
                        Console.WriteLine("No products found or no changes made\n");
                    }
                }
            }
        }

        private static void CombineUpdates(Product.Product updatedProduct,
            List<UpdateDefinition<Product.Product>> updateDefinition,
            out UpdateDefinition<Product.Product> combinedUpdate)
        {
            if (!string.IsNullOrEmpty(updatedProduct.Name))
            {
                updateDefinition.Add(Builders<Product.Product>.Update.Set(u => u.Name, updatedProduct.Name));
            }
            if (updatedProduct.Price != null)
            {
                updateDefinition.Add(Builders<Product.Product>.Update.Set(u => u.Price, updatedProduct.Price));
            }
            if (updatedProduct.Quantity != null)
            {
                updateDefinition.Add(Builders<Product.Product>.Update.Set(u => u.Quantity, updatedProduct.Quantity));
            }
            if (!updateDefinition.Any())
            {
                combinedUpdate = null;
            }
            else
            {
                combinedUpdate = Builders<Product.Product>.Update.Combine(updateDefinition);
            }
        }

        public Product.Product GetProductByID()
        {
            var productsCollection = ConnectToMongo<Product.Product>(ProductCollection);

            Console.Write("Enter product ID: ");
            string? id = Console.ReadLine();
            Console.WriteLine();

            var filter = Builders<Product.Product>.Filter.Eq(u => u.Id, id);
            var document = productsCollection.Find(filter).SingleOrDefault();

            return document;
        }

        public async Task Delete()
        {
            var productsCollection = ConnectToMongo<Product.Product>(ProductCollection);
            var product = GetProductByID();
            if (product == null)
            {
                Console.WriteLine("Invalid ID!\n");
                return;
            }
            else
            {
                await productsCollection.DeleteOneAsync(c => c.Id == product.Id);
                Console.WriteLine("Product deleted succefully!\n");
            }
        }

        public async Task Search()
        {
            var productsCollection = ConnectToMongo<Product.Product>(ProductCollection);

            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();

            var filter = await productsCollection.Find(x => x.Name == name).ToListAsync();
            if (filter.Count == 0)
            {
                Console.WriteLine("No matching products!\n");
            }
            else
            {
                foreach (var item in filter)
                {
                    PrintItem(item);
                }
            }
        }

        public void ExitFromConsole()
        {
            Console.WriteLine("Exiting..\n");
        }

        public Product.Product GetNewValues()
        {
            Console.Write("Enter new product name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter new product price: ");
            decimal? price = decimal.TryParse(Console.ReadLine(), out decimal Price) ? Price : null;

            Console.Write("Enter new product quantity: ");
            int? quantity = int.TryParse(Console.ReadLine(), out int Quantity) ? Quantity : null;

            Console.WriteLine();

            return new Product.Product(name, price, quantity);
        }

        private void PrintItem(Product.Product product)
        {

            Console.WriteLine($"ID: {product.Id}\n" +
                $"Name: {product.Name}\n" +
                $"Quantity: {product.Quantity}\n" +
                $"Price: {product.Price}\n");
        }
    }
}
