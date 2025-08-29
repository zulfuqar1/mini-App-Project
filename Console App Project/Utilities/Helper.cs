using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Utilities
{
    internal static class Helper
    {
        public static void ShowMenu()
        {
            Console.WriteLine(
        "1.Create Product\r\n" +
        "2.Delete Product\r\n" +
        "3.Get Product By Id\r\n" +
        "3.Show All Product\r\n" +
        "4.Refill Product\r\n" +
        "5.Order Product\r\n" +
        "6.Shaw All Orders\r\n" +
        "7.Change Order Status");
        }

        //__--__--__--__--__ Method get user choice __--__--__--__--__\\
        
        //Get User Choice
        public static int GetUserChoice()
        {
            int choice = 0;
            string input = null;
            bool result = false;
            
            input = Console.ReadLine();
            result = int.TryParse(input, out choice);
            
            if (!result)
            {
                Console.WriteLine("Choice correct number");
            }
            return choice;
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

           public static double GetInteInput()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Please enter a valid number.");
            }
            return value;
        }

    }
}