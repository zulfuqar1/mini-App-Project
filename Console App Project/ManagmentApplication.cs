using Console_App_Project.Modles;
using Console_App_Project.Services;
using Console_App_Project.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project
{
    internal class ManagmentApplication
    {
        public void Run()
        {
            while (true)
            {
                Helper.ShowMenu();

                int choice = Helper.GetIntInput();

                switch (choice)
                {
                    case 1:
                        var productService = new ProductService();
                        productService.CreateProduct();
                        break;


                    case 2:
                        Console.WriteLine("2 key is ready");
                        Console.WriteLine("Press any key to continue...");

   
                        Console.ReadKey(true);
                        break;
                    
                    
                    case 3:
                        Console.WriteLine("3");
                        string result = File.ReadAllText(Helper.DataFilePathFinder());


                        List<Product> products = string.IsNullOrEmpty(result)? new List<Product>(): JsonConvert.DeserializeObject<List<Product>>(result);

                        if (products == null)
                        {
                            Console.WriteLine("Deserialize null döndü");
                            products = new List<Product>();
                        }
                        else
                        {
                            Console.WriteLine("Deserialize başarılı, count: " + products.Count);
                        }

                        string json = JsonConvert.SerializeObject(products);
                        Console.WriteLine("Dosyaya yazılacak JSON: " + json);
                        File.WriteAllText(Helper.DataFilePathFinder(), json);








                        Console.WriteLine("Okunan JSON: " + result);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    
                    
                    case 4:
                        Console.WriteLine("4");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    
                    
                    case 5:
                        Console.WriteLine("5");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    
                    
                    case 6:
                        Console.WriteLine("6");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    
                    
                    case 7:
                        Console.WriteLine("7");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    
                    
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to exit the application ? (Y/N)");

                        if (Helper.GetYesNoChoice())
                        {
                            Console.Clear();
                            Console.WriteLine("Exiting the application. Goodbye!");
                            return;
                        }
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }
        }
    }
}
