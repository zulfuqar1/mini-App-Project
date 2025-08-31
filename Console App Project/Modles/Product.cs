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
        public double Price {get; set;}
        [JsonProperty]
        public  double Stock {get; set;}



        public Product(string name, double price, double stock): base()
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ID: {id} | Name: {Name} | Price: {Price} | Stock: {Stock}");
        }
    }
}
