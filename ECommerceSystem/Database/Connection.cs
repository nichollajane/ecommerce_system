using System.Data.SqlClient;
using System.Data;
using System;

namespace ECommerceSystem.Database
{
    public class Connection
    {
        public SqlConnection connect()
        {
            return new SqlConnection("Data Source = DESKTOP-TN77M3V\\SQLEXPRESS01; Initial Catalog = ECommerce_System; Integrated Security = True");
        }
    }
}