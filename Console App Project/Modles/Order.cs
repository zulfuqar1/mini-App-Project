
using Console_App_Project.Enums;
using Console_App_Project.Modles;
using Console_App_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Console_App_Project.Modles
{
    internal class Order : Base.BaseEntity
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal Total
        {
            get
            {
                return Items.Sum(i => i.SubTotal);
            }
        }
        public string Email { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;


        public Order(string email, OrderStatus status) : base()
        {
            Email = email;
            Status = status;
        }

        public void PrintInfo()
        {
            Helper.ColorfulWriteLine("\n╠══════════════════════════════════════════════════════════════════╣",
                ConsoleColor.DarkMagenta);
            Helper.ColorfulWriteLine("Oreder",ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite("ID:", ConsoleColor.Green);
            Helper.ColorfulWrite( Id, ConsoleColor.Cyan);

            Helper.ColorfulWrite(" | Email:", ConsoleColor.Green);
            Helper.ColorfulWriteLine( Email, ConsoleColor.Cyan);

            if (Status == OrderStatus.Completed)
            {
                Helper.ColorfulWrite("Status: ", ConsoleColor.Green);
                Helper.ColorfulWrite(" [", ConsoleColor.White);
                Helper.ColorfulWrite($"{Status}", ConsoleColor.Blue);
                Helper.ColorfulWrite("]", ConsoleColor.White);
            }
            else if (Status == OrderStatus.Confirmed)
            {
                Helper.ColorfulWrite("Status: ", ConsoleColor.Green);
                Helper.ColorfulWrite(" [", ConsoleColor.White);
                Helper.ColorfulWrite($"{Status}", ConsoleColor.Magenta);
                Helper.ColorfulWrite("]", ConsoleColor.White);
            }
            else
            {
               
                Helper.ColorfulWrite("Status: ", ConsoleColor.Green);
                Helper.ColorfulWrite(" [", ConsoleColor.White);
                Helper.ColorfulWrite($"{Status}", ConsoleColor.DarkYellow);
                Helper.ColorfulWrite("]", ConsoleColor.White);
            }


            Helper.ColorfulWrite(" | OrderedAt:", ConsoleColor.Green);
            Helper.ColorfulWrite($" {OrderedAt}", ConsoleColor.Yellow);

            Helper.ColorfulWrite(" | Total:", ConsoleColor.Green);
            Helper.ColorfulWriteLine($"{Total}\n", ConsoleColor.Yellow);


            Helper.ColorfulWriteLine("Items: ---------------------------------------------",
                ConsoleColor.DarkMagenta);
            foreach (var item in Items)
            {
                Helper.ColorfulWrite("Product:", ConsoleColor.Green);
                Helper.ColorfulWrite($"{item.Product.Name}", ConsoleColor.Cyan);

                Helper.ColorfulWrite(" | Count:", ConsoleColor.Green);
                Helper.ColorfulWrite($"{item.Count}", ConsoleColor.Cyan);

                Helper.ColorfulWrite(" | Price:", ConsoleColor.Green);
                Helper.ColorfulWrite($"${item.Price}", ConsoleColor.Cyan);

                Helper.ColorfulWrite(" | SubTotal:", ConsoleColor.Green);
                Helper.ColorfulWriteLine($"{item.SubTotal}", ConsoleColor.Cyan);
            }
        }




    }
}                                                                                             