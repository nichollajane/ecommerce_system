using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceSystem
{
    public static class Helpers
    {
        public static byte[] GetImage(HttpPostedFile file)
        {
            byte[] imageData = new byte[file.ContentLength];
            file.InputStream.Read(imageData, 0, file.ContentLength);

            return imageData;
        }

        public static bool IsImage(HttpPostedFile file)
        {
            string[] mimeTypes = {
                "image/jpeg",
                "image/png",
                "image/jpg",
            };

            return mimeTypes.Contains(file.ContentType.ToLower());
        }
    }
}