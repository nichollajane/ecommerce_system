using System;

namespace ECommerceSystem.Models
{
    public class CartItem
    {
        public int Cart_Item_ID { get; set; }

        public int Cart_ID { get; set; }

        public int Product_ID { get; set; }

        public int Quantity { get; set; }

        public Decimal Price { get; set; }

    }
}