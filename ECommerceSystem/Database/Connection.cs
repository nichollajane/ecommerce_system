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

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = connect())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = connect())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                SqlDataReader reader = command.ExecuteReader();

                return reader;
            }
        }
    }
}