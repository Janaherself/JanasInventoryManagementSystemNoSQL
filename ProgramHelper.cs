namespace JanasInventoryManagementSystem
{
    public class ProgramHelper
    {
        // this works just fine.
        //public Action<Enum> PrintSuccessMessage = (action) => Console.WriteLine($"{action} Successfully!\n");
        
        // but this requires the caller of it to pass an object to work well.
        // i find the method downwards more conveient so i'll go with them.
        //public Action<object> PrintFailureMessage = _ => Console.WriteLine("No Products Found!\n");


        public void PrintSuccessMessage(Enum @enum)
        {
            Console.WriteLine($"{@enum} Successfully!");
            Console.WriteLine("--------------------------------------\n");
        }

        public void PrintFailureMessage()
        {
            Console.WriteLine($"No Products Found!");
            Console.WriteLine("--------------------------------------\n");
        }
    }
}
