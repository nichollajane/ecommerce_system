using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerceSystem.Models;

namespace ECommerceSystem.Database
{
    public class OrderItemDB
    {
        Connection connection = new Connection();

        public OrderItem Create(OrderItem orderitem)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    INSERT INTO Order (
                        Order_Quantity, 
                        Unit_Price, 
                        Total_Price 
                     ) 
                    VALUES (
                        @Order_Quantity, 
                        @Unit_Price, 
                        @Total_Price, 
                    );
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Order_Quantity", orderitem.Order_Quantity);
                cmd.Parameters.AddWithValue("@Unit_Price", orderitem.Unit_Price);
                cmd.Parameters.AddWithValue("@Total_Price", orderitem.Total_Price);

                cmd.ExecuteNonQuery();

                return orderitem;

            }
        }

        public OrderItem Update(OrderItem orderitem)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    UPDATE Order SET
                    Order_Quantity = Order_Quantity, 
                    Unit_Price = Unit_Price,
                    Total_Price = Total_Price

                    WHERE Order_Item_ID = @Order_Item_ID;
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Order_Item_ID", orderitem.Order_Item_ID);
                cmd.Parameters.AddWithValue("@Order_ID", orderitem.Order_ID);
                cmd.Parameters.AddWithValue("@Product_ID", orderitem.Product_ID);
                cmd.Parameters.AddWithValue("@Order_Quantity", orderitem.Order_Quantity);
                cmd.Parameters.AddWithValue("@Unit_Price", orderitem.Unit_Price);
                cmd.Parameters.AddWithValue("@Total_Price", orderitem.Total_Price);

                cmd.ExecuteNonQuery();

                return orderitem;

            }
        }

        public DataTable List()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM OrderItem ORDER BY Order_Item_ID DESC", sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public OrderItem Get(int Order_Item_ID)
        {
            OrderItem orderitem = new OrderItem();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM OrderItem WHERE Order_Item_ID = @Order_Item_ID";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@Order_Item_ID", Order_Item_ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    orderitem.Order_Item_ID = int.Parse(reader["Order_Item_ID"].ToString());
                    orderitem.Order_ID = int.Parse(reader["Order_ID"].ToString());
                    orderitem.Product_ID = int.Parse(reader["Product_ID"].ToString());
                    orderitem.Order_Quantity = int.Parse(reader["Order_Quantity"].ToString());
                    orderitem.Unit_Price = Decimal.Parse(reader["Unit_Price"].ToString());
                    orderitem.Total_Price = int.Parse(reader["Total_Price"].ToString());

                }

                return orderitem;
            }
        }

        public List<OrderItem> GetOrderItems()
        {
            List<OrderItem> orderitems = new List<OrderItem>();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM OrderItem", sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        OrderItem orderitem = new OrderItem();

                        orderitem.Order_Item_ID = (int)reader["Order_Item_ID"];
                        orderitem.Order_ID = (int)reader["Order_ID"];
                        orderitem.Product_ID = (int)reader["Product-ID"];
                        orderitem.Order_Quantity = (int)reader["Order_Quantity"];
                        orderitem.Unit_Price = (decimal)reader["Unit_Price"];
                        orderitem.Total_Price = (decimal)reader["Total_Price"];

                        orderitems.Add(orderitem);
                    }
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return orderitems;
        }

        public void Delete(OrderItem orderitem)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = "DELETE FROM OrderItem WHERE Order_Item_ID = @Order_Item_ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                try
                {
                    cmd.Parameters.AddWithValue("@Order_Item_ID", orderitem.Order_Item_ID);

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}

