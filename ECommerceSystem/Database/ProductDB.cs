using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerceSystem.Models;

namespace ECommerceSystem.Database
{
    public class ProductDB
    {
        Connection connection = new Connection();

        public Product Create(Product product)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    INSERT INTO Product ( 
                        Product_Name, 
                        Product_SKU,
                        Product_Description,
                        Product_Price,
                        Product_Brand,
                        Product_Availability,
                        Product_Quantity,
                        Product_Color,
                        Product_Size,
                        Category_ID,
                        Product_Image
                    ) 
                    VALUES (
                        @Product_Name, 
                        @Product_SKU,
                        @Product_Description,
                        @Product_Price,
                        @Product_Brand,
                        @Product_Availability,
                        @Product_Quantity,
                        @Product_Color,
                        @Product_Size,
                        @Category_ID,
                        @Product_Image
                    );
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Product_Name", product.Product_Name);
                cmd.Parameters.AddWithValue("@Product_SKU", product.Product_SKU);
                cmd.Parameters.AddWithValue("@Product_Description", product.Product_Description);
                cmd.Parameters.AddWithValue("@Product_Price", product.Product_Price);
                cmd.Parameters.AddWithValue("@Product_Brand", product.Product_Brand);
                cmd.Parameters.AddWithValue("@Product_Availability", product.Product_Availability);
                cmd.Parameters.AddWithValue("@Product_Quantity", product.Product_Quantity);
                cmd.Parameters.AddWithValue("@Product_Color", product.Product_Color);
                cmd.Parameters.AddWithValue("@Product_Size", product.Product_Size);
                cmd.Parameters.AddWithValue("@Category_ID", product.Category_ID);

                cmd.Parameters.AddWithValue("@Product_Image", SqlDbType.Image).Value = product.Product_Image;

                cmd.ExecuteNonQuery();

                return product;
            }
        }

        public Product Update(Product product)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    UPDATE Product SET 
                        Product_Name = @Product_Name, 
                        Product_SKU = @Product_SKU, 
                        Product_Description = @Product_Description,
                        Product_Price = @Product_Price,
                        Product_Brand = @Product_Brand,
                        Product_Availability = @Product_Availability,
                        Product_Quantity = @Product_Quantity,
                        Product_Color = @Product_Color,
                        Product_Size = @Product_Size,
                        Product_Image = @Product_Image
                    WHERE Product_ID = @Product_ID
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Product_ID", product.Product_ID);
                cmd.Parameters.AddWithValue("@Product_Name", product.Product_Name);
                cmd.Parameters.AddWithValue("@Product_SKU", product.Product_SKU);
                cmd.Parameters.AddWithValue("@Product_Description", product.Product_Description);
                cmd.Parameters.AddWithValue("@Product_Price", product.Product_Price);
                cmd.Parameters.AddWithValue("@Product_Brand", product.Product_Brand);
                cmd.Parameters.AddWithValue("@Product_Availability", product.Product_Availability);
                cmd.Parameters.AddWithValue("@Product_Quantity", product.Product_Quantity);
                cmd.Parameters.AddWithValue("@Product_Color", product.Product_Color);
                cmd.Parameters.AddWithValue("@Product_Size", product.Product_Size);

                cmd.Parameters.AddWithValue("@Product_Image", SqlDbType.Image).Value = product.Product_Image;

                cmd.ExecuteNonQuery();

                return product;

            }
        }

        public DataTable List()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product ORDER BY Product_ID DESC", sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public Product Get(int Product_ID)
        {
            Product product = new Product();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Product INNER JOIN Category ON Product.Category_id = Category.Category_id WHERE Product_ID = @Product_ID";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@Product_ID", Product_ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    product.Product_ID = (int)reader["Product_ID"];
                    product.Product_Name = reader["Product_Name"].ToString();
                    product.Product_SKU = reader["Product_SKU"].ToString();
                    product.Product_Description = reader["Product_Description"].ToString();
                    product.Product_Price = (decimal)reader["Product_Price"];
                    product.Product_Brand = reader["Product_Brand"].ToString();
                    product.Product_Availability = reader["Product_Availability"].ToString();
                    product.Product_Quantity = (int)reader["Product_Quantity"];
                    product.Product_Color = reader["Product_Color"].ToString();
                    product.Product_Size = reader["Product_Size"].ToString();
                    product.Category_Name = reader["Category_Name"].ToString();

                    byte[] bytes = (byte[])reader["Product_Image"];
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                    product.Product_Image_Url = "data:image/png;base64," + base64String;

                }

                return product;
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Product ORDER BY Product_ID DESC", sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Product product = new Product();

                        product.Product_ID = (int)reader["Product_ID"];
                        product.Product_Name = (String)reader["Product_Name"];
                        product.Product_SKU = (String)reader["Product_SKU"];
                        product.Product_Description = (String)reader["Product_Description"];
                        product.Product_Price = (decimal)reader["Product_Price"];
                        product.Product_Brand = (String)reader["Product_Brand"];
                        product.Product_Availability = reader["Product_Availability"].ToString();
                        product.Product_Quantity = (int)reader["Product_Quantity"];
                        product.Product_Color = (String)reader["Product_Color"];
                        product.Product_Size = (String)reader["Product_Size"];

                        byte[] bytes = (byte[])reader["Product_Image"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                        product.Product_Image_Url = "data:image/png;base64," + base64String;

                        products.Add(product);
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

            return products;
        }

        public void Delete(Product product)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE Product_ID = @Product_ID", sqlConnection);

                cmd.Parameters.AddWithValue("@Product_ID", product.Product_ID);

                cmd.ExecuteNonQuery();
            }
        }
    }
}