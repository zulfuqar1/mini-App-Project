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
    }
}