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
                Console.WriteLine("Welcome To Jana's Inventory Management system!\n" +
                    "You can choose one of the options below by typing its corresponding number.\n" +
                    "1. Add a Product\n" +
                    "2. View a List of Products\n" +
                    "3. Edit a Product\n" +
                    "4. Delete a Product\n" +
                    "5. Search for a Product\n" +
                    "6. Exit The App\n");
                Console.Write("Select an Option:");

                int option = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (option)
                {
                    case 1: inventory.Add(); break;
                    case 2: inventory.View(); break;
                    case 3: inventory.Edit(); break;
                    case 4: inventory.Delete(); break;
                    case 5: inventory.Search(); break;
                    case 6: 
                        exit = false; 
                        Console.WriteLine("Exiting..\n"); 
                        break;
                    default: 
                        Console.WriteLine("Invalid Option! Try Again Please.\n"); 
                        break;
                }

            }
        }
    }
}
