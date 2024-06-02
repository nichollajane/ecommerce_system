using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerceSystem.Models;

namespace ECommerceSystem.Database
{
    public class CartDB
    {
        Connection connection = new Connection();

        public Cart Create(Cart cart)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    INSERT INTO Cart (User_ID, Product_ID, Quantity, Price, Date_Created, Last_Update) 
                    VALUES (@User_ID, @Product_ID, @Quantity, @Price, @Date_Created, @Last_Update);
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@User_ID", cart.User_ID);
                cmd.Parameters.AddWithValue("@Product_ID", cart.Product_ID);
                cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                cmd.Parameters.AddWithValue("@Price", cart.Price);
                cmd.Parameters.AddWithValue("@Date_Created", cart.Date_Created);
                cmd.Parameters.AddWithValue("@Last_Update", cart.Last_Update);

                cmd.ExecuteNonQuery();

                return cart;

            }
        }

        public Cart Update(Cart cart)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    UPDATE Cart SET
                    Quantity = @Quantity, 
                    Price = @Price,
                    Last_Update = @Last_Update
                    WHERE Cart_ID = @Cart_ID;
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Cart_ID", cart.Cart_ID);
                cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                cmd.Parameters.AddWithValue("@Price", cart.Price);
                cmd.Parameters.AddWithValue("@Last_Update", cart.Last_Update);

                cmd.ExecuteNonQuery();

                return cart;

            }
        }

        public DataTable List()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Cart ORDER BY Cart_ID DESC", sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public Cart Get(int Cart_ID)
        {
            Cart cart = new Cart();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Cart WHERE Cart_ID = @Cart_ID";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@Cart_ID", Cart_ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    cart.Cart_ID = int.Parse(reader["Cart_ID"].ToString());
                    cart.User_ID = int.Parse(reader["User_ID"].ToString());
                    cart.Product_ID = int.Parse(reader["Product_ID"].ToString());
                    cart.Quantity = int.Parse(reader["Quantity"].ToString());
                    cart.Price = decimal.Parse(reader["Price"].ToString());
                    cart.Date_Created = DateTime.Parse(reader["Date_Created"].ToString());
                    cart.Last_Update = DateTime.Parse(reader["Last_Update"].ToString());
                }

                return cart;
            }
        }

        public Cart CheckCartProductExists(int Product_ID, int User_ID)
        {
            Cart cart = null;

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Cart WHERE Product_ID = @Product_ID AND User_ID = @User_ID";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@Product_ID", Product_ID);
                cmd.Parameters.AddWithValue("@User_ID", User_ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    cart = new Cart();

                    cart.Cart_ID = int.Parse(reader["Cart_ID"].ToString());
                    cart.User_ID = int.Parse(reader["User_ID"].ToString());
                    cart.Product_ID = int.Parse(reader["Product_ID"].ToString());
                    cart.Quantity = int.Parse(reader["Quantity"].ToString());
                    cart.Price = decimal.Parse(reader["Price"].ToString());
                    cart.Date_Created = DateTime.Parse(reader["Date_Created"].ToString());
                    cart.Last_Update = DateTime.Parse(reader["Last_Update"].ToString());

                    return cart;
                }
            }

            return null;
        }

        public List<Cart> GetCarts(int User_ID, Cart cart = null)
        {
            List<Cart> carts = new List<Cart>();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = "SELECT * FROM Cart INNER JOIN Product ON Cart.Product_ID = Product.Product_ID WHERE User_ID = @User_ID";

                if (cart != null)
                {
                    sql += " AND Cart_ID = @Cart_ID";
                }

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@User_ID", User_ID);

                if (cart != null)
                {
                    cmd.Parameters.AddWithValue("@Cart_ID", cart.Cart_ID);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        cart = new Cart();

                        int quantity = (int)reader["Quantity"];
                        decimal price = (decimal)reader["Product_Price"];

                        cart.Cart_ID = (int)reader["Cart_ID"];
                        cart.User_ID = (int)reader["User_ID"];
                        cart.Quantity = quantity;
                        cart.Product_ID = (int)reader["Product_ID"];
                        cart.Product_Name = reader["Product_Name"].ToString();
                        cart.Product_SKU = reader["Product_SKU"].ToString();
                        cart.Product_Description = reader["Product_Description"].ToString();
                        cart.Product_Price = price;
                        cart.Product_Brand = reader["Product_Brand"].ToString();
                        cart.Product_Availability = reader["Product_Availability"].ToString();
                        cart.Product_Quantity = (int)reader["Product_Quantity"];
                        cart.Product_Color = reader["Product_Color"].ToString();
                        cart.Product_Size = reader["Product_Size"].ToString();

                        byte[] bytes = (byte[])reader["Product_Image"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                        cart.Product_Image_Url = "data:image/png;base64," + base64String;
                        cart.Total_Price = price * quantity;

                        carts.Add(cart);
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

            return carts;
        }

        public void Delete(Cart cart)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = "DELETE FROM Cart WHERE Cart_ID = @Cart_ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                try
                {
                    cmd.Parameters.AddWithValue("@Cart_ID", cart.Cart_ID);

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
