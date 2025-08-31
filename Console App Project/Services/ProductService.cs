using Console_App_Project.Modles;
using Console_App_Project.Repository;
using Console_App_Project.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console_App_Project.Services
{
    internal  class ProductService
    {


        public  readonly string _path = Helper.DataFilePathFinder();
        
        public  Repository<Product> ProductRepository { get; set; } = new Repository<Product>();


        public  void CreateProduct()
        {
            //Get Product Details from User


            // Load existing products from JSON file
            List<Product> products = ProductRepository.LoadOrCreateListFromJson(_path);

            Console.Clear();

            // Name
            Console.WriteLine("Enter New Product name");

            if (Helper.EscToCancer())
                return;

            string productName = Helper.GetStringInput();

            // Check for duplicate product names
            while (products.Any(p => p.Name == productName))
            {
                Console.Clear();

                Console.WriteLine("Product with this name already exists. Please choose a different name.");

                if (Helper.EscToCancer())
                {
                    return;
                }
                
                productName = Helper.GetStringInput();
            }


            // Price
            Console.Clear();
            Console.WriteLine("Enter Product Price");
            double ProductPrice = Helper.GetDoubleInput();

            // Stock
            Console.Clear();
            Console.WriteLine("Enter Product Stock");

            double ProductStock = Helper.GetDoubleInput();

            //Create Product Object
            Product product = new Product(productName, ProductPrice, ProductStock);
           
            // Add new product to list
            products.Add(product);

            // Serialize updated list back to JSON file
            ProductRepository.SerializeJson(_path, products);

            //Confirmation Message
            Console.Clear();
            Console.WriteLine("Product created");
            product.PrintInfo();
            Helper.Pause();


        }

        private static void AddProduct()
        {
            Console.WriteLine("Add Product functionality goes here.");
            // Implementation for adding a product
        }
        private static void ViewProducts()
        {
            Console.WriteLine("View Products functionality goes here.");
            // Implementation for viewing products
        }
        private static void UpdateProduct()
        {
            Console.WriteLine("Update Product functionality goes here.");
            // Implementation for updating a product
        }
        private static void DeleteProduct()
        {
            Console.WriteLine("Delete Product functionality goes here.");
            // Implementation for deleting a product
        }


    }
}
