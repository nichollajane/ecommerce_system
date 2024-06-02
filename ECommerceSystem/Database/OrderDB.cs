using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerceSystem.Models;

namespace ECommerceSystem.Database
{
    public class OrderDB
    {
        Connection connection = new Connection();

        public Order Create(Order order)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    INSERT INTO [Order] (
                        Order_No, 
                        User_ID,
                        Order_Date, 
                        Order_Quantity, 
                        Order_Price, 
                        Payment_Method, 
                        Shipping_Address, 
                        Order_Status
                     ) 
                    VALUES (
                        @Order_No, 
                        @User_ID,
                        @Order_Date, 
                        @Order_Quantity, 
                        @Order_Price, 
                        @Payment_Method, 
                        @Shipping_Address, 
                        @Order_Status
                    );
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Order_No", order.Order_No);
                cmd.Parameters.AddWithValue("@User_ID", order.User_ID);
                cmd.Parameters.AddWithValue("@Order_Date", SqlDbType.DateTime).Value = (System.Data.SqlTypes.SqlDateTime)order.Order_Date;
                cmd.Parameters.AddWithValue("@Order_Quantity", order.Order_Quantity);
                cmd.Parameters.AddWithValue("@Order_Price", order.Order_Price);
                cmd.Parameters.AddWithValue("@Payment_Method", order.Payment_Method);
                cmd.Parameters.AddWithValue("@Shipping_Address", order.Shipping_Address);
                cmd.Parameters.AddWithValue("@Order_Status", order.Order_Status);

                cmd.ExecuteNonQuery();

                return order;

            }
        }

        public Order Update(Order order)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    UPDATE [Order] SET
                    Order_No = @Order_No, 
                    Order_Date = @Order_Date,
                    Order_Quantity = @Order_Quantity
                    Order_Price = @Order_Price
                    Payment_Method = @Payment_Method
                    Shipping_Address = @Shipping_Address
                    Order_Status = @Order_Status

                    WHERE Order_ID = @Order_ID;
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Order_ID", order.Order_ID);
                cmd.Parameters.AddWithValue("@User_ID", order.User_ID);
                cmd.Parameters.AddWithValue("@Order_No", order.Order_No);
                cmd.Parameters.AddWithValue("@Order_Date", order.Order_Date);
                cmd.Parameters.AddWithValue("@Order_Quantity", order.Order_Quantity);
                cmd.Parameters.AddWithValue("@Order_Price", order.Order_Price);
                cmd.Parameters.AddWithValue("@Payment_Method", order.Payment_Method);
                cmd.Parameters.AddWithValue("@Order_Status", order.Order_Status);

                cmd.ExecuteNonQuery();

                return order;

            }
        }

        public DataTable List(int User_ID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Order] WHERE User_ID = @User_ID ORDER BY Order_ID DESC", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@User_ID", User_ID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public Order Get(int Order_No)
        {
            Order order = new Order();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM [Order] WHERE Order_No = @Order_No";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@Order_No", Order_No);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    order.Order_ID = int.Parse(reader["Order_ID"].ToString());
                    order.User_ID = int.Parse(reader["User_ID"].ToString());
                    order.Order_No = int.Parse(reader["Order_No"].ToString());
                    order.Order_Date = DateTime.Parse(reader["Order_Date"].ToString());
                    order.Order_Quantity = int.Parse(reader["Order_Quantity"].ToString());
                    order.Order_Price = Decimal.Parse(reader["Order_Price"].ToString());
                    order.Payment_Method = reader["Payment_Method"].ToString();
                    order.Shipping_Address = reader["Shipping_Address"].ToString();
                    order.Order_Status = reader["Order_Status"].ToString();

                }

                return order;
            }
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM [Order]", sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Order order = new Order();

                        order.Order_ID = (int)reader["Order_ID"];
                        order.User_ID = (int)reader["User_ID"];
                        order.Order_No = (int)reader["Order_No"];
                        order.Order_Date = (DateTime)reader["Order_Date"];
                        order.Order_Price = (decimal)reader["Order_Price"];
                        order.Order_Price = (decimal)reader["Order_Price"];
                        order.Payment_Method = (string)reader["Payment_Method"];
                        order.Shipping_Address = (string)reader["Shipping_Address"];
                        order.Order_Status = (string)reader["Order_Status"];

                        orders.Add(order);
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

            return orders;
        }

        public void Delete(Order order)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = "DELETE FROM [Order] WHERE Order_ID = @Order_ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                try
                {
                    cmd.Parameters.AddWithValue("@Order_ID", order.Order_ID);

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
