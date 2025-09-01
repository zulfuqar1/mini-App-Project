
using Console_App_Project.Enums;
using Console_App_Project.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine($"ID: {id} | Email: {Email} | Status: {Status} | OrderedAt: {OrderedAt} | Total: {Total}");
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                Console.WriteLine($"\tProduct: {item.Product.Name} | Count: {item.Count} | Price: {item.Price} | SubTotal: {item.SubTotal}");
            }
        }
    }
}




//List<OrderItem> Items
//Total
//Email  - sifarish eden shexsin emaili
//OrderStatus Status
//DateTime OrderedAt

//PrintInfo()