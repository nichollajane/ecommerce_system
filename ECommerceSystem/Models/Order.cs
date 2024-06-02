using System;
using System.Data.SqlTypes;

namespace ECommerceSystem.Models
{
    public class Order
    {
        public int Order_ID { get; set; }

        public int User_ID { get; set; }

        public int Order_No { get; set; }

        public DateTime Order_Date { get; set; }

        public int Order_Quantity { get; set; }

        public Decimal Order_Price { get; set; }

        public string Payment_Method { get; set; }

        public string Shipping_Address { get; set; }

        public string Order_Status { get; set; }
    }
}