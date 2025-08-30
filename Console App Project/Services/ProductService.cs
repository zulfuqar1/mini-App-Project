using Console_App_Project.Modles;
using Console_App_Project.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Services
{
    internal static class ProductService
    {
        static readonly string _path = Helper.DataFilePathFinder();
        public static void CreateProduct()
        {
            // Get Product Details from User

            // Name
            Console.Clear();
            Console.WriteLine("Enter New Product name");
            string ProductName = Helper.GetStringInput();

            // Price
            Console.Clear();
            Console.WriteLine("Enter Product Price");
            double ProductPrice = Helper.GetDoubleInput();

            // Stock
            Console.Clear();
            Console.WriteLine("Enter Product Stock");
            double ProductStock = Helper.GetDoubleInput();





            // Create Product Object
            
            Console.Clear();
            Product product = new Product(ProductName, ProductPrice, ProductStock);

            // Save Product to File

            string result = null;
            using ( StreamReader sr = new(_path))
            {
                result = sr.ReadToEnd();
            }

            List<Product> products=null;

            if (string.IsNullOrEmpty(result))
            {
                products = new List<Product>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<Product>>(result);
            }


            products.Add(product);
            string json = JsonConvert.SerializeObject(product);

            using (StreamWriter sw = new StreamWriter (_path))
            {
                sw.WriteLine(json);
            }


            Console.WriteLine("Product created");
            product.PrintInfo();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);


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
