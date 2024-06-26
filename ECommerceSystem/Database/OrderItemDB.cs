﻿using System;
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
                    INSERT INTO Order_Item (
                        Order_ID,
                        Product_ID,
                        Order_Quantity, 
                        Unit_Price, 
                        Total_Price 
                     ) 
                    VALUES (
                        @Order_ID,
                        @Product_ID,
                        @Order_Quantity, 
                        @Unit_Price, 
                        @Total_Price
                    );
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Order_ID", orderitem.Order_ID);
                cmd.Parameters.AddWithValue("@Product_ID", orderitem.Product_ID);
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
                    UPDATE Order_Item SET
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

        public List<OrderItem> GetOrderItems(int Order_ID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Order_Item INNER JOIN Product ON Order_Item.Product_ID = Product.Product_ID WHERE Order_ID = @Order_ID", sqlConnection);

                cmd.Parameters.AddWithValue("@Order_ID", Order_ID);

                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        OrderItem orderItem = new OrderItem();

                        int quantity = (int)reader["Product_Quantity"];
                        decimal price = (decimal)reader["Product_Price"];

                        decimal totalPrice = price * quantity;

                        orderItem.Product_Name = reader["Product_Name"].ToString();
                        orderItem.Product_Price = price;
                        orderItem.Order_Quantity = (int)reader["Order_Quantity"];
                        orderItem.Total_Price = totalPrice;

                        byte[] bytes = (byte[])reader["Product_Image"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                        orderItem.Product_Image_Url = "data:image/png;base64," + base64String;

                        orderItems.Add(orderItem);
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

            return orderItems;
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

