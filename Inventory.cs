namespace JanasInventoryManagementSystem
{
    public class Inventory
    {
        private readonly Dictionary<int, Product> _products = new();
        DataManager dataManager = new();
        ProgramHelper programHelper = new();

        public void Add(Product product)
        {
            _products.Add(product.Id, product);
            programHelper.PrintSuccessMessage(action.Added);
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
                foreach (KeyValuePair<int, Product> kvp in _products)
                {
                    PrintItem(kvp.Value);
                }
            }
        }

        public void Edit(int id)
        {
            if (_products.Count == 0)
            {
                programHelper.PrintFailureMessage();
            }
            else
            {
                var product = GetProduct(id);

                Console.WriteLine();

                if (product != null)
                {
                    var newProduct = dataManager.ReadFromConsole(product);

                    _products[id].Name = newProduct.Name;
                    _products[id].Quantity = Convert.ToInt32(newProduct.Quantity);
                    _products[id].Price = Convert.ToDecimal(newProduct.Price);

                    Console.WriteLine();

                    programHelper.PrintSuccessMessage(action.Edited);
                }
                else
                {
                    programHelper.PrintFailureMessage();                
                }
            }
        }

        public void Delete(int id)
        {
            if (_products.Count == 0)
            {
                programHelper.PrintFailureMessage();
            }
            else
            {
                var product = GetProduct(id);

                Console.WriteLine();

                if (product != null)
                {
                    _products.Remove(id);
                    programHelper.PrintSuccessMessage(action.Deleted);
                }
                else
                {
                    programHelper.PrintFailureMessage();
                }
            }
        }

        public void Search(int id)
        {
            var product = GetProduct(id);

            if (product != null)
            {
                PrintItem(_products[id]);
            }
            else
            {
                programHelper.PrintFailureMessage();
            }
        }

        private Product? GetProduct(int id)
        {
            if (_products.ContainsKey(id))
                return _products[id];
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
