using Console_App_Project.Enums;
using Console_App_Project.Modles;
using Console_App_Project.Repository;
using Console_App_Project.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Console_App_Project.Services
{
    internal  class ProductService
    {

        public  readonly string _path = Helper.ProductDataFilePathFinder();
        public  Repository<Product> ProductRepository { get; set; } = new Repository<Product>();


        //Create Product
        public void CreateProduct()
        {
            //Get Product Details from User
            // Load existing products from JSON file
            List<Product> products = ProductRepository.LoadOrCreateListFromJson(_path);

            Console.Clear();
            Helper.LogoMini();
            // Name
            Helper.ColorfulWriteLine("Product Createing", ConsoleColor.Green);
            if (Helper.EscToCancer())
                return;
            Helper.ColorfulWriteLine("Enter New Product name", ConsoleColor.Green);

            string productName = Helper.GetStringInput();

            // Check for duplicate product names
            while (products.Any(p => p.Name == productName))
            {
                Console.Clear();
                Helper.LogoMini();
                Console.WriteLine("Product with this name already exists. Please choose a different name.");

                if (Helper.EscToCancer())
                {
                    return;
                }
                
                productName = Helper.GetStringInput();
            }


            // Price
            Console.Clear();
            Helper.LogoMini();
            Helper.ColorfulWriteLine("Enter Product Price", ConsoleColor.Green);
            decimal ProductPrice;

            while (true)
            {
                ProductPrice = Helper.IsPositiveDecilamNumber();

                if (ProductPrice == 0)
                {
                    Console.Clear();
                    Helper.LogoMini();
                    Helper.ColorfulWriteLine("Price cannot be 0.", ConsoleColor.DarkRed);   
                }
                else
                {
                    break;
                }

            }

            // Stock
            Console.Clear();
            Helper.LogoMini();
            Helper.ColorfulWriteLine("Enter Product Stock", ConsoleColor.Green);
            int ProductStock = Helper.IsPositiveIntNumber();

            //Create Product Object
            Product product = new Product(productName, ProductPrice, ProductStock);
           
            // Add new product to list
            products.Add(product);

            // Serialize updated list back to JSON file
            ProductRepository.SerializeJson(_path, products);

            //Confirmation Message
            Console.Clear();
            Helper.LogoMini();
            product.PrintInfo();
            Helper.ColorfulWriteLine("Product created", ConsoleColor.Green);
            Helper.Pause();
            Console.Clear();


        }

        //Delete Product
        public  void DeleteProduct()
        {
            Console.Clear();
            Helper.LogoMini();

            ShowAllProducts();
            if( Helper.EscToCancer())
                 return;
            Helper.ColorfulWriteLine("Enter Product Id to delete", ConsoleColor.Cyan);




            string id = Helper.GetStringInput();
            
            List<Product> products = ProductRepository.LoadOrCreateListFromJson(_path);

            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                Helper.LogoMini();
                Console.Clear();
                Helper.ColorfulWrite("Do you want to remove this product?", ConsoleColor.Green);
                if (Helper.GetYesNoChoice())
                {
                    products.Remove(product);
                    Console.Clear();
                    Helper.LogoMini();
                    ProductRepository.SerializeJson(_path, products);
                    Helper.ColorfulWrite("Deleted product with ID:", ConsoleColor.Green);
                    Helper.ColorfulWriteLine(id, ConsoleColor.Green);
                }
                else
                {
                    Helper.ColorfulWriteLine(" Operation canceled", ConsoleColor.Green);
                }
                   
               
            }
            else
            {
                Console.Clear();
                Helper.LogoMini();
                Helper.ColorfulWriteLine("Product not found.", ConsoleColor.DarkRed);
            }
            Helper.Pause();
            Console.Clear();
        }

        //Get Product By Id
        public void GetProductById()
        {
            Console.Clear ();
            Helper.LogoMini();
            Helper.ColorfulWriteLine("---------------------------------------------------", ConsoleColor.Magenta);
            Helper.ColorfulWriteLine("Enter Product Id", ConsoleColor.Green);

            string id = Helper.GetStringInput();

            List<Product> products = ProductRepository.LoadOrCreateListFromJson(_path);

            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                string stockStatus;
                Helper.ColorfulWrite("ID:", ConsoleColor.Green);
                Helper.ColorfulWrite(product.Id, ConsoleColor.Cyan);
                Helper.ColorfulWrite(" | Name:", ConsoleColor.Green);
                Helper.ColorfulWrite(product.Name, ConsoleColor.Cyan);
                Helper.ColorfulWrite(" | Price:", ConsoleColor.Green);
                Helper.ColorfulWrite($"${product.Price}", ConsoleColor.Cyan);
                Helper.ColorfulWrite(" | Stock:", ConsoleColor.Green);

                if (product.Stock > 0)
                {
                    stockStatus = product.Stock.ToString();

                    Helper.ColorfulWriteLine(stockStatus, ConsoleColor.Cyan);
                }
                else
                {
                    stockStatus = "Out of Stock";
                    Helper.ColorfulWriteLine(stockStatus, ConsoleColor.DarkRed);
                }
            }
            else
            {
                Console.Clear();
                Helper.LogoMini();
                Helper.ColorfulWriteLine("Product not found.", ConsoleColor.DarkRed);
            }
            Helper.Pause();
            Console.Clear();
        }

        //Show All Products
        public void ShowAllProducts()
        {
            Console.Clear();
            Helper.LogoMini();
            List<Product> products = ProductRepository.LoadOrCreateListFromJson(_path);
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }
            foreach (var product in products)
            {
                string stockStatus;

                Helper.ColorfulWrite("ID:", ConsoleColor.Green);
                Helper.ColorfulWrite(product.Id, ConsoleColor.Cyan);
                Helper.ColorfulWrite(" | Name:", ConsoleColor.Green);
                Helper.ColorfulWrite(product.Name, ConsoleColor.Cyan);
                Helper.ColorfulWrite(" | Price:", ConsoleColor.Green);
                Helper.ColorfulWrite($"${product.Price}", ConsoleColor.Cyan);
                Helper.ColorfulWrite(" | Stock:", ConsoleColor.Green);

                if (product.Stock > 0)
                {
                    stockStatus = product.Stock.ToString();
                    Helper.ColorfulWriteLine(stockStatus, ConsoleColor.Cyan);
                }
                else
                {
                    stockStatus = "Out of Stock";
                    Helper.ColorfulWriteLine(stockStatus, ConsoleColor.DarkRed);
                }
            }
        }

        //Refil Products
        public void RefilProducts()
        {
            Console.Clear();
            Helper.LogoMini();
            Helper.ColorfulWrite("--------------------------------------------------------------", ConsoleColor.Cyan);
            ShowAllProducts();
            if (Helper.EscToCancer())
                return;

            Helper.ColorfulWrite("\nEnter the ID of the product you want to refill:", ConsoleColor.Cyan);
            string id = Helper.GetStringInput();
            //
            List<Product> products = ProductRepository.LoadOrCreateListFromJson(_path);
            //Serach By Id
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                Console.WriteLine("Product not found!");
            }
            else
            {
                Helper.ColorfulWriteLine($"Current stock for {product.Name}: {product.Stock}", ConsoleColor.DarkYellow);
                Helper.ColorfulWriteLine("Enter amount to add:",ConsoleColor.Cyan);
                int refillAmount = Helper.IsPositiveIntNumber();

                product.Stock += refillAmount;

                //Info
                Helper.ColorfulWriteLine($"New stock for {product.Name}: {product.Stock}",ConsoleColor.Cyan);

                // Serialize updated list back to JSON file
                ProductRepository.SerializeJson(_path, products);
            }

            Helper.Pause();
            Console.Clear();
        }


        public void RemoveProduct()
        {
            Console.Clear();
            Helper.LogoMini();
            ShowAllProducts();

            if (Helper.EscToCancer())
                return;

            Helper.ColorfulWrite("\nEnter the ID of the product you want to remove:", ConsoleColor.Cyan);
            string id = Helper.GetStringInput();
            //
            List<Product> products = ProductRepository.LoadOrCreateListFromJson(_path);
            //Serach By Id
            Product product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                Helper.ColorfulWriteLine("Product not found!", ConsoleColor.DarkRed);
            }
            else
            {

                if(product.Stock <= 0) 
                {
                    Helper.ColorfulWriteLine($"No stock left for {product.Name}. Cannot remove any more.", ConsoleColor.DarkRed);
                    Helper.Pause();
                    Console.Clear ();
                    return;
                }
                Helper.ColorfulWriteLine($"Current stock for {product.Name}: {product.Stock}", ConsoleColor.DarkYellow);
                Helper.ColorfulWriteLine("Enter amount to remove:", ConsoleColor.Cyan);
                while (true)
                {
                    
                    int removeAmount = Helper.IsPositiveIntNumber();

                   
                    if (product.Stock < removeAmount)
                    {
                        Helper.ColorfulWriteLine($"Cannot remove {removeAmount}. Only {product.Stock} in stock.", ConsoleColor.DarkRed);
                        if (Helper.EscToCancer())
                            return;
                    }
                    else
                    {
                        product.Stock -= removeAmount;
                        Helper.ColorfulWrite($"{removeAmount}", ConsoleColor.Green);
                        Helper.ColorfulWrite($" units removed from ", ConsoleColor.Cyan);
                        Helper.ColorfulWrite($"{product.Name}. ", ConsoleColor.Green);
                        Helper.ColorfulWrite($" New stock:", ConsoleColor.Cyan);
                        Helper.ColorfulWriteLine($"{product.Stock}", ConsoleColor.Green);
                        break;
                    }
                }
                //Info
                Helper.ColorfulWriteLine($"New stock for {product.Name}: {product.Stock}", ConsoleColor.Cyan);

                // Serialize updated list back to JSON file
                ProductRepository.SerializeJson(_path, products);
            }

            Helper.Pause();
            Console.Clear();
        }
    }
}
