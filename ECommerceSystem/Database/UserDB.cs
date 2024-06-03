using System.Data.SqlClient;
using System.Data;

namespace ECommerceSystem.Database
{
    public class UserDB
    {
        Connection connection = new Connection();

        public Models.User Create(Models.User user)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    INSERT INTO [User] (
                        User_Fullname, 
                        User_Type, 
                        User_Email, 
                        User_Password, 
                        User_Contact_No,
                        User_Gender, 
                        User_Home_No, 
                        User_Street, 
                        User_Barangay,
                        User_City,
                        User_Municipality,
                        User_Region,
                        User_Country, 
                        User_Zipcode
                    ) 
                    VALUES (
                        @User_Fullname, 
                        @User_Type, 
                        @User_Email, 
                        @User_Password, 
                        @User_Contact_No,
                        @User_Gender,
                        @User_Home_No,
                        @User_Street, 
                        @User_Barangay,
                        @User_City, 
                        @User_Municipality,  
                        @User_Region, 
                        @User_Country,
                        @User_Zipcode
                    );
                ";

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                    cmd.Parameters.AddWithValue("@User_Fullname", user.Fullname);
                    cmd.Parameters.AddWithValue("@User_Type", user.User_Type);
                    cmd.Parameters.AddWithValue("@User_Email", user.Email);
                    cmd.Parameters.AddWithValue("@User_Password", user.Password);
                    cmd.Parameters.AddWithValue("@User_Contact_No", user.Contact_No);
                    cmd.Parameters.AddWithValue("@User_Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@User_Home_No", user.Home_No);
                    cmd.Parameters.AddWithValue("@User_Street", user.Street);
                    cmd.Parameters.AddWithValue("@User_Barangay", user.Barangay);
                    cmd.Parameters.AddWithValue("@User_City", user.City);
                    cmd.Parameters.AddWithValue("@User_Municipality", user.Municipality);
                    cmd.Parameters.AddWithValue("@User_Region", user.Region);
                    cmd.Parameters.AddWithValue("@User_Country", user.Country);
                    cmd.Parameters.AddWithValue("@User_Zipcode", user.Zipcode);

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

                return user;
            }
        }

        public DataTable List()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [User] ORDER BY User_ID DESC", sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public Models.User Update(Models.User user)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = @"
                    UPDATE [User] SET 
                    User_Fullname = @User_Fullname, 
                    User_Type = @User_Type,
                    User_Email = @User_Email,
                    User_Password = @User_Password,
                    User_Contact_No = @User_Contact_No,
                    User_Gender = @User_Gender,
                    User_Home_No = @User_Home_No,
                    User_Street = @User_Street,
                    User_Barangay = @User_Barangay,
                    User_City = @User_City,
                    User_Municipality = @User_Municipality,
                    User_Region = @User_Region,
                    User_Country = @User_Country,
                    User_Zipcode = @User_Zipcode
                    WHERE @User_ID = @User_ID;
                ";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@User_Fullname", user.Fullname);
                cmd.Parameters.AddWithValue("@User_Type", user.User_Type);
                cmd.Parameters.AddWithValue("@User_Email", user.Email);
                cmd.Parameters.AddWithValue("@User_Password", user.Password);
                cmd.Parameters.AddWithValue("@User_Contact_No", user.Contact_No);
                cmd.Parameters.AddWithValue("@User_Gender", user.Gender);
                cmd.Parameters.AddWithValue("@User_Home_No", user.Home_No);
                cmd.Parameters.AddWithValue("@User_Street", user.Street);
                cmd.Parameters.AddWithValue("@User_Barangay", user.Barangay);
                cmd.Parameters.AddWithValue("@User_City", user.City);
                cmd.Parameters.AddWithValue("@User_Municipality", user.Municipality);
                cmd.Parameters.AddWithValue("@User_Region", user.Region);
                cmd.Parameters.AddWithValue("@User_Country", user.Country);
                cmd.Parameters.AddWithValue("@User_Zipcode", user.Zipcode);
                cmd.Parameters.AddWithValue("@User_ID", user.User_ID);

                cmd.ExecuteNonQuery();

                sqlConnection.Close();

                return user;
            }
        }

        public Models.User Get(int User_ID)
        {
            Models.User user = new Models.User();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT * FROM [User] WHERE User_ID = @User_ID";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@User_ID", User_ID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    user.User_ID = (int)reader["User_ID"];
                    user.Fullname = reader["User_Fullname"].ToString();
                    user.User_Type = reader["User_Type"].ToString();
                    user.Email = reader["User_Email"].ToString();
                    user.Password = reader["User_Password"].ToString();
                    user.Contact_No =(int)reader["User_Contact_No"];
                    user.Home_No = reader["User_Home_No"].ToString();
                    user.Street = reader["User_Street"].ToString();
                    user.Barangay = reader["User_Barangay"].ToString();
                    user.City = reader["User_City"].ToString();
                    user.Municipality = reader["User_Municipality"].ToString();
                    user.Region = reader["User_Region"].ToString();
                    user.Country = reader["User_Country"].ToString();
                    user.Zipcode = (int)reader["User_Zipcode"];
                }


                sqlConnection.Close();

                return user;
            }
        }


        public void Delete(Models.User user)
        {
            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string sql = "DELETE FROM [User] WHERE User_ID = @User_ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                try
                {
                    cmd.Parameters.AddWithValue("@User_ID", user.User_ID);

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

        public Models.User checkUser(string email, string password)
        {
            Models.User user = new Models.User();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT* FROM [User] WHERE User_Email = @User_Email AND User_Password = @User_Password";

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@User_Email", email);
                    cmd.Parameters.AddWithValue("@User_Password", password);

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            user.User_ID = (int)reader["User_ID"];
                            user.Fullname = reader["User_Fullname"].ToString();
                            user.User_Type = reader["User_Type"].ToString();
                            user.Email = reader["User_Email"].ToString();
                            user.Password = reader["User_Password"].ToString();
                            user.Contact_No = (int)reader["User_Contact_No"];
                            user.Home_No = reader["User_Home_No"].ToString();
                            user.Street = reader["User_Street"].ToString();
                            user.Barangay = reader["User_Barangay"].ToString();
                            user.City = reader["User_City"].ToString();
                            user.Municipality = reader["User_Municipality"].ToString();
                            user.Region = reader["User_Region"].ToString();
                            user.Country = reader["User_Country"].ToString();
                            user.Zipcode = (int)reader["User_Zipcode"];

                            return user;
                        }
                        else
                        {
                            return null;
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
            }
        }

        public bool checkUserEmailExists(string email)
        {
            Models.User user = new Models.User();

            using (SqlConnection sqlConnection = connection.connect())
            {
                sqlConnection.Open();

                string query = "SELECT* FROM [User] WHERE User_Email = @User_Email";

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@User_Email", email);

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        return reader.HasRows;
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
}