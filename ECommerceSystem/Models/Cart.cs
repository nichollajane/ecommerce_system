using System;

namespace ECommerceSystem.Models
{
    public class Cart: Product
    {
        public int Cart_ID { get; set; }

        public int User_ID { get; set; }

        public int Quantity { get; set; }

        public Decimal Price { get; set; }

        public DateTime Date_Created { get; set; }

        public DateTime Last_Update { get; set; }

        public Decimal Total_Price { get; set; }
    }
}