using Console_App_Project.Services;
using Console_App_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project
{
    internal class ManagmentApplication
    {
        public void Run()
        {
            int choice = 0;
            string input = null;
            bool result = false;

            while (!result)
            {
                Helper.ShowMenu();

                input = Console.ReadLine();
                result = int.TryParse(input, out choice);
                if (!result)
                {
                    Console.WriteLine("Choice correct number");
                }


                switch (choice)
                {
                    case 1:
                        ProductService.CreateProduct();

                        break;

                    case 2:
                        Console.WriteLine("2");
                        break;
                    case 3:
                        Console.WriteLine("3");
                        break;
                    case 4:
                        Console.WriteLine("4");
                        break;
                    case 5:
                        Console.WriteLine("5");
                        break;
                    case 6:
                        Console.WriteLine("6");
                        break;
                    case 7:
                        Console.WriteLine("7");
                        break;
                }
            }
        }
    }
}
