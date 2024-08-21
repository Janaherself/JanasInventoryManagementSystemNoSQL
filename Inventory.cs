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
        }

        public void View() 
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No Products Found!\n");
            }

            foreach (Product product in products)
            {
                Console.WriteLine($"Products List:\n" +
                    $"{product.Id}. {product.Name}\n" +
                    $"Quantity: {product.Quantity}\n" +
                    $"Price: {product.Price}\n");
            }        
        }

        public void Delete()
        {

        }

        public void Edit()
        {

        }

        public void Search()
        {

        }
    }
}
