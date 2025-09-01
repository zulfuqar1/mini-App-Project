using Console_App_Project.Modles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Utilities
{
    internal static class Helper
    {


        //-------------- Path Finders --------------\\

        // Get Project Path
        public static string ProjectPathFinder()
        {
            string Path = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                Path = Directory.GetParent(Path).FullName;
            }
            return Path;
        }

        // Get Data File Path
        public static string DataFilePathFinder()
        {
            return Path.Combine(ProjectPathFinder(), "Data", "Product.json");
        }


        //-------------- Menu Methods --------------\\

        //Colored WriteLine
        public static void ColorfulWriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        //Show Main Menu
        public static void ShowMenu()
        {
            Helper.ColorfulWriteLine(
                "╔══════════════════════════════╗\n" +
                "║          MAIN  MENU          ║", ConsoleColor.DarkGreen);
            Helper.ColorfulWriteLine(
                "╠══════════════════════════════╣\n" +
                "║ 1:    Create  Product        ║\n" +
                "║ 2:    Delete  Product        ║\n" +
                "║ 3:   Get Product By Id       ║\n" +
                "║ 4:   Show All Products       ║\n" +
                "║ 5:     Refill Product        ║\n" +
                "║ 6:     Order Product         ║\n" +
                "║ 7:    Show All Orders        ║\n" +
                "║ 8:  Change Order Status      ║\n" +
                "╠══════════════════════════════╣",ConsoleColor.Green);
            Helper.ColorfulWriteLine(
                "║ 0:          Exit             ║\n" +
                "╚══════════════════════════════╝" ,ConsoleColor.DarkRed);
        }

        //Pause Console
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        public static bool EscToCancer()
        {

            Helper.ColorfulWriteLine("(press ESC to cancel or Press any key to continue):", ConsoleColor.DarkRed);

            var keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Helper.ColorfulWriteLine("Operation cancelled", ConsoleColor.DarkRed);
                Helper.Pause();
                Console.Clear();
                return true;
            }

            return false;
        }



        //--------- Method get user choice ---------\\


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
                ColorfulWriteLine("Invalid input. Please enter 'Yes' or 'No' ", ConsoleColor.DarkRed);
                return GetYesNoChoice();
            }
        }

        //Get String Input
        public static string GetStringInput()
        {
            string value = null;
            while (string.IsNullOrWhiteSpace(value))
            {
                value = Console.ReadLine();
                ColorfulWriteLine("Please enter a valid String.", ConsoleColor.DarkRed);
            }
            return value;
        }

        //Get Decimal Input
        public static decimal GetDecimalInput()
        {
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                ColorfulWriteLine("Please enter a valid number.", ConsoleColor.DarkRed);
            }
            return value;
        }

        //Get Int Input
        public static int GetIntInput()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                ColorfulWriteLine("Please enter a valid number.", ConsoleColor.DarkRed);

            }
            return value;
        }
 





        //--------- Check Input Methods ---------\\


        //Check Email Validity


        //public static bool IsValidEmail(string email)
        //{
        //    return email.Contains("@") && email.Contains(".");
        //}

        //Check Positive Number
        public static decimal IsPositiveDecilamNumber()
        {
            while (true)
            {
                decimal value = GetDecimalInput();
                if (value < 0)
                {
                    Console.Clear();
                    ColorfulWriteLine("Invalid input. Please enter a positive number.", ConsoleColor.DarkRed);
                }
                else
                    return value;

            }
        }

        public static int IsPositiveIntNumber()
        {
            while (true)
            {
                int value = GetIntInput();
                if (value < 0)
                {
                    Console.Clear();
                    ColorfulWriteLine("Invalid input. Please enter a positive number.", ConsoleColor.DarkRed);
                }
                else
                    return value;
            }
        }



        //Json Reader
        public static string ReadJson(string path)
        {

            if (!File.Exists(path))
                return null;

            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}