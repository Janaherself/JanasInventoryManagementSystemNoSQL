namespace JanasInventoryManagementSystem
{
    public class DataManager
    {
        public Product ReadFromConsole()
        {
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter product quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            return new Product(name, price, quantity);
        }

        public Product ReadFromConsole(Product newProduct)
        {
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter product quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            if (!string.IsNullOrEmpty(newProduct.Name) &&
                !string.IsNullOrEmpty(Convert.ToString(newProduct.Quantity)) &&
                !string.IsNullOrEmpty(Convert.ToString(newProduct.Price))
                )
            {
                newProduct.Name = name;
                newProduct.Price = price;
                newProduct.Quantity = quantity;
            }

            return newProduct;
        }

        public int GetName()
        {
            Console.Write("Enter Product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
    }
}
