using Console_App_Project.Modles;
using Console_App_Project.Services;
using Console_App_Project.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Console_App_Project
{
    internal class ManagmentApplication
    {




        public void Run()
        {
            var userService = new UserService();
            var productService = new ProductService();
            var orederService = new OrderService();
            Helper.LogoMini();


            Helper.ColorfulWrite("Enter Account Name: ", ConsoleColor.Cyan);
            string name = Helper.GetStringInput();
            name = name.ToUpper();

            Helper.ColorfulWrite("Enter Account Email: ", ConsoleColor.Cyan);
            string email = Helper.GetStringInput();

            while (!userService.CehckUser(name, email))
            {
                Console.Clear();
                Helper.LogoMini();
                Helper.ColorfulWriteLine("\n-------------------------------------------------------------------------------------",
                ConsoleColor.DarkMagenta);

                Helper.ColorfulWriteLine("An account with this email already exists. Please use another one.", ConsoleColor.DarkRed);

                Helper.ColorfulWrite("Enter Account Name: ", ConsoleColor.Cyan);
                name = Helper.GetStringInput().ToUpper();

                Helper.ColorfulWrite("Enter Account Email: ", ConsoleColor.Cyan);
                email = Helper.GetStringInput();
            }
            if(userService.CehckUser(name, email))
            {
                userService.VerificationSender(name, email);
            }
            Console.Clear();

            while (true)
            {
                
                Helper.Logo();
                Helper.ShowMenu();

                switch (Helper.GetIntInput())
                {
                    case 1:
                        //Create Product
                        productService.CreateProduct();
                        break;
                    case 2:
                        //Delete Product
                        productService.DeleteProduct();
                        break;
                    case 3:
                        //Get Product By Id
                        productService.GetProductById();
                        break;
                    case 4:
                        //Show All Products
                        Console.Clear();
                        productService.ShowAllProducts();
                        Helper.Pause();
                        Console.Clear();
                        break;
                    case 5:
                        productService.RefilProducts();

                        break;
                    case 6:
                        productService.RemoveProduct();

                        break;
                    case 7:
                        //Order Product
                        orederService.OrderProduct(email);
                        break;

                    case 8:
                        //Show all Product
                        orederService.ShowAllOrders();
                        break;

                    case 9:
                        orederService.ChangeStatus();
                        break;


                    case 0:
                        //Exit
                        Console.Clear();
                        Helper.ColorfulWriteLine("Are you sure you want to exit the application ? :(",ConsoleColor.Yellow);

                        if (Helper.GetYesNoChoice())
                        {
                            Console.Clear();
                            Helper.ColorfulWriteLine("Exiting the application. Goodbye!", ConsoleColor.Red);
                            return;
                        }
                        Console.Clear();
                        break;

                    default:
                        //Defoult
                        Console.Clear();
                        Helper.ColorfulWriteLine("Invalid choice. Please try again.", ConsoleColor.Red);
                        break;
                }
            }
        }

    }
}