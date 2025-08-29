using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Modles
{
    internal class Product: Base.IEntity
    {

        string Name {get; set;}
        double Price {get; set; }
        double Stock {get; set; }



        public Product(string name, double price, double stock)
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
