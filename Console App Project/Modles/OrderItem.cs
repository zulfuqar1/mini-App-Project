using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Modles
{
    internal class OrderItem : Base.BaseEntity
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal => Price * Count;

        public OrderItem(Product product, int count, decimal price,decimal subtotal):base()
        {
            Product = product;

            Count = count;
            
            Price = price;
        }
    }
}

//Product Product
//Count  - bu mehsuldan ne qeder sifarish olunub
//Price  - mehsulun qiymeti
//SubTotal - bu mehsulun say-a gore umumi tutari