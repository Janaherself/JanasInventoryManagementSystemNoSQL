using System.Runtime.InteropServices;

namespace JanasInventoryManagementSystem
{
    public class Inventory
    {
        private readonly Dictionary<string, Product> _products = new();
        DataManager dataManager = new();
        ProgramHelper programHelper = new();

        public void Add(Product pr)
        {
            try
            {
                _products.Add(pr.Name, pr);
                programHelper.PrintSuccessMessage("Added");
            }
            catch
            {
                Console.WriteLine("You can't have two products with the same name!\n\n");
            }
        }

        public void View() 
        {
            if (_products.Count == 0)
            {
                programHelper.PrintFailureMessage();
            }
            else
            {
                Console.WriteLine("Products List:\n");
                foreach (KeyValuePair<string, Product> kvp in _products)
                {
                    PrintItem(kvp.Value);
                }
            }
        }

        public void Edit(string name)
        {
            if (_products.Count == 0)
            {
                programHelper.PrintFailureMessage();
            }
            else
            {
                var product = GetProduct(name);

                Console.WriteLine();

                if (product != null)
                {
                    var newProduct = dataManager.ReadFromConsole();

                    Console.WriteLine();

                    if (!_products.ContainsKey(newProduct[0]) && 
                        !string.IsNullOrEmpty(newProduct[0]) &&
                        !string.IsNullOrEmpty(newProduct[1]) && 
                        !string.IsNullOrEmpty(newProduct[2])
                        )
                    {
                        _products[name].Name = newProduct[0];
                        _products[name].Quantity = Convert.ToInt32(newProduct[1]);
                        _products[name].Price = Convert.ToDecimal(newProduct[2]);
                    }
                    programHelper.PrintSuccessMessage("Edited");
                }
                else
                {
                    programHelper.PrintFailureMessage();                
                }
            }
        }

        public void Delete(string name)
        {
            if (_products.Count == 0)
            {
                programHelper.PrintFailureMessage();
            }
            else
            {
                var product = GetProduct(name);

                Console.WriteLine();

                if (product != null)
                {
                    _products.Remove(name);
                    programHelper.PrintSuccessMessage("Deleted");
                }
                else
                {
                    programHelper.PrintFailureMessage();
                }
            }
        }

        public void Search(string name)
        {
            var product = GetProduct(name);

            if (product != null)
            {
                PrintItem(_products[product.Name]);
            }
            else
            {
                programHelper.PrintFailureMessage();
            }
        }

        private Product GetProduct(string name)
        {
            if (_products.ContainsKey(name))
                return _products[name];
            else 
                return null;
        }

        public void ExitFromConsole()
        {
            Console.WriteLine("Exiting..\n");
        }

        private void PrintItem(Product val)
        {
            Console.WriteLine($"{val.Id}. {val.Name}\n" +
                $"Quantity: {val.Quantity}\n" +
                $"Price: {val.Price}\n");
        
        }
    }
}
