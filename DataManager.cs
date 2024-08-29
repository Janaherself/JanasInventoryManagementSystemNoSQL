namespace JanasInventoryManagementSystem
{
    public class DataManager
    {
        public List<string> ReadFromConsole()
        {
            Console.Write("Enter product name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter product quantity: ");
            string? quantity = Console.ReadLine();

            Console.Write("Enter product price: ");
            string? price = Console.ReadLine();

            Console.WriteLine();

            List<string> product = new List<string> { name, quantity, price };

            return product;
        }

        public string GetName()
        {
            Console.WriteLine("Enter Product Name: ");
            string? name = Console.ReadLine();
            return name;
        }
    }
}
