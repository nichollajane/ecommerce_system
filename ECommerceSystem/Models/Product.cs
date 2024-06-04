using System;

namespace ECommerceSystem.Models
{
    public class Product: Category
    {
        public int Product_ID { get; set; }

        public String Product_SKU { get; set; }

        public String Product_Name { get; set; }

        public String Product_Description { get; set; }

        public Decimal Product_Price { get; set; }

        public String Product_Brand { get; set; }

        public Byte[] Product_Image { get; set; }

        public String Product_Image_Url { get; set; }

        public String Product_Availability { get; set; }

        public int Product_Quantity { get; set; }

        public String Product_Color { get; set; }

        public String Product_Size { get; set; }
    }
}