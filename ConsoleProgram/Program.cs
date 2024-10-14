using JanasInventoryManagementSystem.Database;

namespace JanasInventoryManagementSystem.ConsoleProgram
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            NoSQLInventory inventory = new();
            DataManager dataManager = new();

            bool exit = true;

            while (exit)
            {
                Console.WriteLine("Welcome To Jana's Inventory Management system!\n" +
                    "You can choose one of the options below by typing its corresponding number.\n" +
                    "1. Add a Product\n" +
                    "2. View a List of Products\n" +
                    "3. Edit a Product\n" +
                    "4. Delete a Product\n" +
                    "5. Search for a Product\n" +
                    "6. Exit The App\n");
                Console.Write("Select an Option: ");

                string? option = Console.ReadLine();

                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        await inventory.Add();
                        break;
                    case "2":
                        await inventory.View();
                        break;
                    case "3":
                        await inventory.Edit();
                        break;
                    case "4":
                        await inventory.Delete();
                        break;
                    case "5":
                        await inventory.Search();
                        break;
                    case "6":
                        inventory.ExitFromConsole();
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option! Try Again Please.\n");
                        break;
                }
            }
        }
    }
}
