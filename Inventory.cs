using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanasInventoryManagementSystem
{
    public class Inventory
    {
        private List<Product>? products = new List<Product>();

        public void Add(Inventory inventory)
        {
            Console.Write("Enter product name:");
            string name = Console.ReadLine();

            Console.Write("Enter product price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter product quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Product product = new Product(name, price, quantity);
            products.Add(product);

            Console.WriteLine("Product Added Succefully!");
        }

        public void View(Inventory inventory) 
        {
        
        }

        public void Delete(Inventory inventory)
        {

        }

        public void Edit(Inventory inventory)
        {

        }

        public void Search(Inventory inventory)
        {

        }
    }
}
