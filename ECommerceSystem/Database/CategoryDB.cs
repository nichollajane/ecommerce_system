using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ECommerceSystem.Models;

namespace ECommerceSystem.Database
{
    public class CategoryDB
    {
        Connection connection = new Connection();

        public Category Create(Category category)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    INSERT INTO Category (Category_Name, Category_Description, Category_Image) 
                    VALUES (@Category_Name, @Category_Description, @Category_Image);
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Category_Name", category.Category_Name);
                cmd.Parameters.AddWithValue("@Category_Description", category.Category_Description);
                cmd.Parameters.AddWithValue("@Category_Image", SqlDbType.Image).Value = category.Category_Image;

                cmd.ExecuteNonQuery();

                return category;

            }
        }

        public Category Update(Category category)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    UPDATE Category SET
                    Category_Name = @Category_Name, 
                    Category_Description = @Category_Description
                    WHERE Category_ID = @Category_ID;
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Category_ID", category.Category_ID);
                cmd.Parameters.AddWithValue("@Category_Name", category.Category_Name);
                cmd.Parameters.AddWithValue("@category_Description", category.Category_Description);

                cmd.ExecuteNonQuery();

                return category;

            }
        }

        public DataTable List()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Category ORDER BY Category_ID DESC", sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public Category Get(int Category_ID)
        {
            Category category = new Category();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Category WHERE Category_ID = @Category_ID";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@Category_ID", Category_ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    category.Category_ID = int.Parse(reader["Category_ID"].ToString());
                    category.Category_Name = reader["Category_Name"].ToString();
                    category.Category_Description = reader["Category_Description"].ToString();
                }

                return category;
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Category", sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Category category = new Category();

                        category.Category_ID = (int)reader["Category_ID"];
                        category.Category_Name = (String)reader["Category_Name"];
                        category.Category_Description = (String)reader["Category_Description"];


                        categories.Add(category);
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

            return categories;
        }

        public void Delete(Category category)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = "DELETE FROM Category WHERE Category_ID = @Category_ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                
                try
                {
                    cmd.Parameters.AddWithValue("@Category_ID", category.Category_ID);

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