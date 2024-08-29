namespace JanasInventoryManagementSystem
{
    public class ProgramHelper
    {
        //Action<string> PrintMessage = (action) => Console.WriteLine($"{action} successfully!");

        public void PrintSuccessMessage(string action)
        {
            Console.WriteLine($"{action} Successfully!");
            Console.WriteLine("--------------------------------------\n");
        }

        public void PrintFailureMessage()
        {
            Console.WriteLine($"No Products Found!");
            Console.WriteLine("--------------------------------------\n");
        }
    }
}
