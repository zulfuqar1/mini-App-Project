using Console_App_Project.Enums;
using Console_App_Project.Modles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Utilities
{
    internal static class Helper
    {

        //-------------- Path Finders --------------\\

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
        public static string ProductDataFilePathFinder()
        {
            return Path.Combine(ProjectPathFinder(), "Data", "Product.json");
        }
        public static string OrderDataFilePathFinder()
        {
            return Path.Combine(ProjectPathFinder(), "Data", "Orders.json");
        }

        public static string UserDataFilePathFinder()
        {
            return Path.Combine(ProjectPathFinder(), "Data", "Users.json");
        }

        //-------------- Menu Methods --------------\\

        //Colored WriteLine
        public static void ColorfulWriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        //Colored Write
        public static void ColorfulWrite(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }

        //Logo
        public static void Logo()
        {

            string border = "╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗";
            string border2 = "╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝";
            string logo = @"
           ______     __         ______     ______     __  __        ______     __  __     ______   ______    
          /\  == \   /\ \       /\  __ \   /\  ___\   /\ \/ /       /\  == \   /\ \_\ \   /\__  _\ /\  ___\   
          \ \  __<   \ \ \____  \ \  __ \  \ \ \____  \ \  _""-.     \ \  __<   \ \____ \  \/_/\ \/ \ \  __\   
           \ \_____\  \ \_____\  \ \_\ \_\  \ \_____\  \ \_\ \_\     \ \_____\  \/\_____\    \ \_\  \ \_____\ 
            \/_____/   \/_____/   \/_/\/_/   \/_____/   \/_/\/_/      \/_____/   \/_____/     \/_/   \/_____/ 
   ";
            ColorfulWriteLine(border, ConsoleColor.DarkMagenta);
            ColorfulWriteLine(logo, ConsoleColor.DarkMagenta);
            ColorfulWriteLine(border2, ConsoleColor.DarkMagenta);
        }
        public static void LogoMini()
        {
            string thevoid = "                                ";
            
            string border = "╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗";
            string border2 = "╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝";
            string logo = @$"
  {thevoid}  ____  __           __      ____        __     
  {thevoid} / __ )/ /___ ______/ /__   / __ )__  __/ /____ 
 {thevoid} / __  / / __ `/ ___/ //_/  / __  / / / / __/ _ \
{thevoid} / /_/ / / /_/ / /__/ ,<    / /_/ / /_/ / /_/  __/
{thevoid}/_____/_/\__,_/\___/_/|_|  /_____/\__, /\__/\___/ 
{thevoid}                                 /____/             
                                                                 
   ";
            ColorfulWriteLine(border, ConsoleColor.DarkMagenta);
            ColorfulWriteLine(logo, ConsoleColor.DarkMagenta);
            ColorfulWriteLine(border2, ConsoleColor.DarkMagenta);

        }

        //Show Main Menu
        public static void ShowMenu()
        {
            //GPT : Menü çizmek yerine resmen console’da halı dokuma atölyesi açmışsın…

            string thevoid = "                                   ";
            //line 1
            Helper.ColorfulWriteLine($"{thevoid}╔════════════════════════════════════════════╗", ConsoleColor.DarkMagenta);
            //line 2 menu
            Helper.ColorfulWrite($"{thevoid}║                 ", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" MAIN MENU", ConsoleColor.Cyan);
            
            Helper.ColorfulWriteLine("                 ║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWriteLine($"{thevoid}╠════════════════════════════════════════════╣", ConsoleColor.DarkMagenta);
            //line 3
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("1", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]           ", ConsoleColor.White);
            Helper.ColorfulWrite("Create  Product", ConsoleColor.Blue);
            Helper.ColorfulWriteLine("              ║", ConsoleColor.DarkMagenta);
            //line 4
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("2", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]           ", ConsoleColor.White);
            Helper.ColorfulWrite("Delete  Product", ConsoleColor.DarkBlue);
            Helper.ColorfulWriteLine("              ║", ConsoleColor.DarkMagenta);
            //line 5
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("3", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]          ", ConsoleColor.White);
            Helper.ColorfulWrite("Get Product By Id", ConsoleColor.Blue);
            Helper.ColorfulWriteLine("             ║", ConsoleColor.DarkMagenta);
            //line 6
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("4", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]          ", ConsoleColor.White);
            Helper.ColorfulWrite("Show All Products", ConsoleColor.DarkBlue);
            Helper.ColorfulWriteLine("             ║", ConsoleColor.DarkMagenta);
            //line 7
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("5", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]            ", ConsoleColor.White);
            Helper.ColorfulWrite("Refill Product", ConsoleColor.Blue);
            Helper.ColorfulWriteLine("              ║", ConsoleColor.DarkMagenta);

            //line 8
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("6", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]            ", ConsoleColor.White);
            Helper.ColorfulWrite("Empty  product", ConsoleColor.DarkBlue);
            Helper.ColorfulWriteLine("              ║", ConsoleColor.DarkMagenta);

            //line 9
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("7", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]            ", ConsoleColor.White);
            Helper.ColorfulWrite("Order Product", ConsoleColor.Blue);
            Helper.ColorfulWriteLine("               ║", ConsoleColor.DarkMagenta);
            //line 10
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("8", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]           ", ConsoleColor.White);
            Helper.ColorfulWrite("Show All Orders", ConsoleColor.DarkBlue);
            Helper.ColorfulWriteLine("              ║", ConsoleColor.DarkMagenta);
            //line 11
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.White);
            Helper.ColorfulWrite("9", ConsoleColor.Cyan);
            Helper.ColorfulWrite("]         ", ConsoleColor.White);
            Helper.ColorfulWrite("Change Order Status", ConsoleColor.Blue);
            Helper.ColorfulWriteLine("            ║", ConsoleColor.DarkMagenta);
            //line 12
            Helper.ColorfulWriteLine($"{thevoid}╠════════════════════════════════════════════╣", ConsoleColor.DarkMagenta);
            //line 13
            Helper.ColorfulWrite($"{thevoid}║", ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite(" [", ConsoleColor.DarkYellow);
            Helper.ColorfulWrite("0", ConsoleColor.DarkRed);
            Helper.ColorfulWrite("]                 ", ConsoleColor.DarkYellow);
            Helper.ColorfulWrite("EXit", ConsoleColor.DarkRed);
            Helper.ColorfulWriteLine("                   ║", ConsoleColor.DarkMagenta);
            //line 14
            Helper.ColorfulWriteLine($"{thevoid}╚════════════════════════════════════════════╝", ConsoleColor.DarkMagenta);
        }

        //Show Order Status Menu
        public static void ShowOrderStatusMenu()
        {
            Helper.ColorfulWriteLine(
                "╔══════════════════════════════╗\n" +
                "║      CHANGE ORDER STATUS     ║", ConsoleColor.Magenta);
            Helper.ColorfulWriteLine(
                "╠══════════════════════════════╣\n" +
                "║ 1:        Pending            ║\n" +
                "║ 2:       Confirmed           ║\n" +
                "║ 3:       Completed           ║\n" +
                "╠══════════════════════════════╣", ConsoleColor.Magenta);
            Helper.ColorfulWriteLine(
                "║ 0:          Exit             ║\n" +
                "╚══════════════════════════════╝", ConsoleColor.DarkRed);
        }

        //Pause Console
        public static void Pause()
        {
            ColorfulWriteLine("Press any key to continue...", ConsoleColor.Magenta);
            Console.ReadKey(true);
        }
        //Esc to cancel
        public static bool EscToCancer()
        {

            Helper.ColorfulWrite("(press ESC to cancel or ", ConsoleColor.DarkRed);
            Helper.ColorfulWriteLine("(Press any key to continue):", ConsoleColor.Cyan);

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

        //Loading bar
        static void LoadingBar()
        {
            Console.WriteLine("Loading...");
            Console.ForegroundColor = ConsoleColor.Magenta;

            for (int i = 0; i <= 20; i++)
            {
                Console.Write("\r[" + new string('=', i) + new string(' ', 20 - i) + $"] {i * 5}%");
                Console.Beep(500 + i * 20, 50);
                Thread.Sleep(100);
            }

            Console.ResetColor();
            Console.WriteLine("\nREADY\n");
        }


        //--------- Method get user choice ---------\\


        //Get User Yes or NO Choice
        public static bool GetYesNoChoice()
        {
            ColorfulWriteLine("(Y / N)", ConsoleColor.Yellow);
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
            string value = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(value))
            {
                ColorfulWriteLine("Please enter a valid String.", ConsoleColor.DarkRed);
                value = Console.ReadLine();
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

        public static string GenerateOtpCode()
        {
            var random = new Random();
            return random.Next(1000, 9999).ToString();
        }


        public static void CodeSender(string email,string verifyCode) 
        {
            while (true)
            {
                try
                {
                    LoadingBar();

                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("zulfuqarapp@gmail.com", "uqxs fmfm qfsb xyro");

                    MailMessage mail = new MailMessage("zulfuqarapp@gmail.com", email, "Verify code", verifyCode);
                    client.Send(mail);
                    Helper.ColorfulWriteLine("\n═══════════════════════════════════════════════════════════════════╣",
              ConsoleColor.DarkMagenta);
                    Helper.ColorfulWriteLine("Verification code sent to your email ", ConsoleColor.Green);
                    break;

                }
                catch
                {
                    Helper.ColorfulWriteLine("\n═══════════════════════════════════════════════════════════════════╣",
                ConsoleColor.DarkMagenta);
                    Helper.ColorfulWriteLine(email, ConsoleColor.DarkYellow);

                    Helper.ColorfulWriteLine("Invalid email, please try again", ConsoleColor.DarkRed);
                    email = Helper.GetStringInput();
                }
            }
        }
    }
}