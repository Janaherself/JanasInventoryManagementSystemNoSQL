using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanasInventoryManagementSystem
{
    public class Inventory
    {
        private static List<Product>? products = new List<Product>();

        public void Add()
        {
            Console.Write("Enter product name:");
            string name = Console.ReadLine();

            Console.Write("Enter product price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter product quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Product product = new Product(name, price, quantity);
            products.Add(product);

            Console.WriteLine("Product Added Succefully!\n");
            Console.WriteLine("--------------------------------------\n");
        }

        public void View() 
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No Products Found!\n");
                Console.WriteLine("--------------------------------------\n");
            }
            else
            {
                Console.WriteLine($"Products List:");

                foreach (Product product in products)
                {
                    Console.WriteLine($"{product.Id}. {product.Name}\n" +
                        $"Quantity: {product.Quantity}\n" +
                        $"Price: {product.Price}\n");
                }

                Console.WriteLine("--------------------------------------\n");

            }
        }

        public void Edit()
        {
            Console.Write("Enter The Product Name to Edit:");
            string name = Console.ReadLine();

            var product = GetProduct(name);

            if (product != null) 
            {
                Console.WriteLine("Enter The New Name:\n(press enter to keep it unchanged)");
                var newName = Console.ReadLine();

                Console.WriteLine("Enter The New Quantity:\n(press enter to keep it unchanged)");
                var newQuantity = Console.ReadLine();

                Console.WriteLine("Enter The New Price:\n(press enter to keep it unchanged)");
                var newPrice = Console.ReadLine();

                if (!string.IsNullOrEmpty(newName))
                {
                    product.Name = newName;
                }

                if (!string.IsNullOrEmpty(newQuantity))
                {
                    product.Quantity = Convert.ToInt32(newQuantity);
                }

                if (!string.IsNullOrEmpty(newPrice))
                {
                    product.Price = Convert.ToDecimal(newPrice);
                }

                Console.WriteLine("Product Updated Successfully!\n");
                Console.WriteLine("--------------------------------------\n");
            }

        }

        public void Delete()
        {
            Console.Write("Enter The Product Name to Delete:");
            string name = Console.ReadLine();

            var product = GetProduct(name);

            if (name != null)
            {
                products.Remove(product);
                Console.WriteLine("Product Was Deleted successfully!\n");
                Console.WriteLine("--------------------------------------\n");
            }
            else 
            {
                Console.WriteLine("Product With This Name Wasn't Found!\n");
                Console.WriteLine("--------------------------------------\n"); 
            }
        }

        public void Search()
        {

        }

        private Product GetProduct(string name)
        {
            return products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
