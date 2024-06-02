using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerceSystem.Models;

namespace ECommerceSystem.Database
{
    public class CartItemDB
    {
        Connection connection = new Connection();

        public CartItem Create(CartItem cartitem)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    INSERT INTO CartItem (Quantity, Price) 
                    VALUES (@Quantity, Price);
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Quantity", cartitem.Quantity);
                cmd.Parameters.AddWithValue("@Price", cartitem.Price);

                cmd.ExecuteNonQuery();

                return cartitem;

            }
        }

        public CartItem Update(CartItem cartitem)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    UPDATE Cart SET
                    Quantity = Quantity, 
                    Price = Price
                    WHERE Cart_ID = @Cart_ID;
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@CartItem_ID", cartitem.Cart_Item_ID);
                cmd.Parameters.AddWithValue("@Card_ID", cartitem.Cart_ID);
                cmd.Parameters.AddWithValue("@Product_ID", cartitem.Product_ID);
                cmd.Parameters.AddWithValue("@Quantity", cartitem.Quantity);
                cmd.Parameters.AddWithValue("@Price", cartitem.Price);

                cmd.ExecuteNonQuery();

                return cartitem;

            }
        }

        public DataTable List()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CartItem ORDER BY CartItem_ID DESC", sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public CartItem Get(int CartItem_ID)
        {
            CartItem cartitem = new CartItem();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM CartItem WHERE CartItem_ID = @CartItem_ID";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@CartItem_ID", CartItem_ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    cartitem.Cart_Item_ID = int.Parse(reader["CartItem_ID"].ToString());
                    cartitem.Cart_ID = int.Parse(reader["Cart_ID"].ToString());
                    cartitem.Product_ID = int.Parse(reader["Product_ID"].ToString());
                    cartitem.Quantity = int.Parse(reader["Quantity"].ToString());
                    cartitem.Price = decimal.Parse(reader["Price"].ToString());

                }

                return cartitem;
            }
        }

        public List<CartItem> GetCartItems()
        {
            List<CartItem> cartitems = new List<CartItem>();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM CartItem", sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        CartItem cartitem = new CartItem();

                        cartitem.Cart_Item_ID = (int)reader["CartItem_ID"];
                        cartitem.Cart_ID = (int)reader["Cart_ID"];
                        cartitem.Product_ID = (int)reader["Product_ID"];
                        cartitem.Quantity = (int)reader["Quantity"];
                        cartitem.Price = (int)reader["Price"];


                        cartitems.Add(cartitem);
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

            return cartitems;
        }

        public void Delete(CartItem cartitem)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = "DELETE FROM CartItem WHERE CartItem_ID = @CartItem_ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                try
                {
                    cmd.Parameters.AddWithValue("@CartItem_ID", cartitem.Cart_Item_ID);

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
