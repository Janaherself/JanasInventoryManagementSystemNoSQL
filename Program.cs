using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanasInventoryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            bool exit = true;

            while (exit) 
            {
                Console.WriteLine("\nWelcome To Jana's Inventory Management system!\n" +
                    "You can choose one of the options below by typing its corresponding number.\n" +
                    "1. Add a Product\n" +
                    "2. View a List of Products\n" +
                    "3. Edit a Product\n" +
                    "4. Delete a Product\n" +
                    "5. Search for a Product\n" +
                    "6. Exit The App\n");
                Console.Write("Choose an Option:");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1: inventory.Add(inventory); break;
                    case 2: inventory.View(inventory); break;
                    case 3: inventory.Edit(inventory); break;
                    case 4: inventory.Delete(inventory); break;
                    case 5: inventory.Search(inventory); break;
                    case 6: 
                        exit = false; 
                        Console.WriteLine("Exiting.."); 
                        break;
                    default: 
                        Console.WriteLine("Invalid Option! Try Again Please."); 
                        break;
                }

            }
        }
    }
}
