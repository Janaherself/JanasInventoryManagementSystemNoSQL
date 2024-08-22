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
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter product quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Product product = new Product(name, price, quantity);
            products.Add(product);

            Console.WriteLine("Product Added Successfully!\n");
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

            if (products.Count == 0)
            {
                Console.WriteLine("No Products to Edit!\n");
                Console.WriteLine("--------------------------------------\n");
            }
            else
            {
                Console.Write("Enter The Product Name to Be Edited: ");
                string name = Console.ReadLine();

                var product = GetProduct(name);

                Console.WriteLine();

                if (product != null && product.GetType() == typeof(Product))
                {
                    Console.Write("Enter The New Name (or press enter to keep it unchanged): ");
                    var newName = Console.ReadLine();

                    Console.Write("Enter The New Quantity (or press enter to keep it unchanged): ");
                    var newQuantity = Console.ReadLine();

                    Console.Write("Enter The New Price (or press enter to keep it unchanged): ");
                    var newPrice = Console.ReadLine();

                    Console.WriteLine();

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
                else
                {
                    Console.WriteLine("Product With This Name Wasn't Found!\n");
                    Console.WriteLine("--------------------------------------\n");
                }
            }
        }

        public void Delete()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No Products to Delete!\n");
                Console.WriteLine("--------------------------------------\n");
            }
            else
            {
                Console.Write("Enter The Product Name to Be Deleted: ");
                string name = Console.ReadLine();

                var product = GetProduct(name);

                Console.WriteLine();

                if (product != null && product.GetType() == typeof(Product))
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
        }

        public void Search()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.WriteLine();    

            var product = GetProduct(name);

            if (product != null)
            {
                Console.WriteLine("Product Found!");
                Console.WriteLine($"{product.Id}. {product.Name}\n" +
                    $"Quantity: {product.Quantity}\n" +
                    $"Price: {product.Price}\n");
                Console.WriteLine("--------------------------------------\n");
            }
            else
            {
                Console.WriteLine("Product Wasn't Found!\n");
                Console.WriteLine("--------------------------------------\n");
            }
        }

        private Product GetProduct(string name)
        {
            return products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
