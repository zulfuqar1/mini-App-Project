using Console_App_Project.Modles;
using Console_App_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Services
{
    internal static class ProductService
    {



        public static void CreateProduct()
        {


            Console.WriteLine("Enter New Product name");
            string ProductName = Helper.GetStringInput();

            Console.WriteLine("Enter New Product Price");
            double ProductPrice = Helper.GetIntInput();

            Console.WriteLine("Enter New Product Stock");
            double ProductStock = Helper.GetIntInput();

            Product newProduct = new Product(ProductName, ProductPrice, ProductStock);


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
