using System;

namespace ECommerceSystem.Models
{
    public class OrderItem
    {
        public int Order_Item_ID { get; set; }

        public int Order_ID { get; set; }

        public int Product_ID { get; set; }

        public int Order_Quantity { get; set; }

        public Decimal Unit_Price { get; set; }

        public Decimal Total_Price { get; set; }
    }
}