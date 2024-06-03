using System;

namespace ECommerceSystem.Models
{
    public class Category
    {
        public int Category_ID { get; set; }

        public string Category_Name { get; set; }

        public string Category_Description { get; set; }

        public Byte[] Category_Image { get; set; }

        public String Category_Image_Url { get; set; }
    }
}