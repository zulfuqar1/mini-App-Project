using Console_App_Project.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Modles
{
    internal class Product: Base.BaseEntity
    {
        [JsonProperty]
        public string Name {get; set;}
        [JsonProperty]
        public decimal Price {get; set;}
        [JsonProperty]
        public  int Stock {get; set;}



        public Product(string name, decimal price, int stock): base()
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void PrintInfo()
        {
            Helper.ColorfulWriteLine("\n╠══════════════════════════════════════════════════════════════════╣",
              ConsoleColor.DarkMagenta);

            Helper.ColorfulWrite("ID: ", ConsoleColor.Green);
            Helper.ColorfulWriteLine(Id, ConsoleColor.Cyan);

            Helper.ColorfulWrite("Name: ", ConsoleColor.Green);
            Helper.ColorfulWrite(Name, ConsoleColor.Cyan);

            Helper.ColorfulWrite(" | Price:", ConsoleColor.Green);
            Helper.ColorfulWriteLine($"{Price}", ConsoleColor.Cyan);

            Helper.ColorfulWrite(" | Stock:", ConsoleColor.Green);
            Helper.ColorfulWriteLine($"{Stock}", ConsoleColor.Cyan);

        }
    }
}
