using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Utilities
{
    internal static class Helper
    {

        //Path Finder\\

        public static string ProjectPathFinder()
        {
            string Path = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++) 
            {
                Path = Directory.GetParent(Path).FullName;
            }
            return Path;
        }

        public static string DataFilePathFinder()
        {
            return Path.Combine(ProjectPathFinder(), "Data", "Product.json");
        }






        //======================= Method Show Menu ======================= \\

        //Show Main Menu
        public static void ShowMenu()
        {
            Console.WriteLine(
        "1.Create Product\n" +
        "2.Delete Product\n" +
        "3.Get Product By Id\n" +
        "3.Show All Product\n" +
        "4.Refill Product\n" +
        "5.Order Product\n" +
        "6.Shaw All Orders\n" +
        "7.Change Order Status\n\n"+
        "0.Exit"
        );
        }

        //======================= Method get user choice ======================= \\


        //Get User Yes or NO Choice
        public static bool GetYesNoChoice()
        {
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "y" || choice == "yes")
            {
                return true;
            }

            else if (choice == "n" || choice == "no")
            {
                return false;
            }

            else
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                return GetYesNoChoice();
            }
        }


        //Get String Input
        public static string GetStringInput()
        {
            return Console.ReadLine();
        }


        //Get Int Input
        public static double GetDoubleInput()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Please enter a valid number.");
            }
            return value;
        }


        //Get Int Input
        public static int GetIntInput()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            { 
                Console.WriteLine("Please enter a valid number.");
            }
            return value;
        }

    }
}