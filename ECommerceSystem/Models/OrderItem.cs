using System;

namespace ECommerceSystem.Models
{
    public class OrderItem: Product
    {
        public int Order_Item_ID { get; set; }

        public int Order_ID { get; set; }

        public int Order_Quantity { get; set; }

        public Decimal Unit_Price { get; set; }

        public Decimal Total_Price { get; set; }

        public String Total { get; set; }
    }
}