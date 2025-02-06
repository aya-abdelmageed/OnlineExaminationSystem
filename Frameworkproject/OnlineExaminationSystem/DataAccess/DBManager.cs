using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DataAccess
    {
        public class DBManager
        {

        private SqlConnection connect;


        string _connectionString = "Server=DESKTOP-S3ETNPJ;Database=Online_Examination_System;User Id=Exam;Password=123456;";
        

        // Constructor that takes the connection string as a parameter
        public DBManager()
        {

        }
        //Method to get connect with DataBase
        public void InitializeDatabaseConnection()
        {
            try
            {
                connect = new SqlConnection(_connectionString);
                connect.Open();
                MessageBox.Show("Connection Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed: " + ex.Message);
            }
        }

        public int AuthenticateUser(string username, string password, string userType)
        {
            string query = "";

            if (userType == "Student")
            {
                query = "SELECT Student_ID FROM Student WHERE UserName COLLATE SQL_Latin1_General_CP1_CS_AS = @UserName AND Password COLLATE SQL_Latin1_General_CP1_CS_AS = @Password";
            }
            else if (userType == "Instructor")
            {
                query = "SELECT INS_ID FROM Instructor WHERE UserName COLLATE SQL_Latin1_General_CP1_CS_AS = @UserName AND Password COLLATE SQL_Latin1_General_CP1_CS_AS = @Password";
            }

            SqlParameter[] parameters =
            {
                new SqlParameter("@UserName", username),
                new SqlParameter("@Password", password)
            };

            DataTable resultTable = ExecuteQuery(query, parameters);

            if (resultTable.Rows.Count > 0)
            {
                return Convert.ToInt32(resultTable.Rows[0][0]); // Return user ID
            }
            return -1; // Return -1 if authentication fails
        }

        // Method to execute a stored procedure and return a DataTable
        public DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    DataTable resultTable = new DataTable();

                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(resultTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (log them, rethrow, etc.)
                        throw new Exception($"Error executing stored procedure {procedureName}", ex);
                    }

                    return resultTable;
                }
            }

            // Method to execute a stored procedure that doesn't return data (e.g., INSERT, UPDATE, DELETE)
            public int ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        throw new Exception($"Error executing stored procedure {procedureName}", ex);
                    }
                }
            }

            // Method to execute a scalar stored procedure (returns a single value)
            public object ExecuteScalar(string procedureName, SqlParameter[] parameters)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        connection.Open();
                        return command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        throw new Exception($"Error executing stored procedure {procedureName}", ex);
                    }
                }
            }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                DataTable resultTable = new DataTable();

                try
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(resultTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return resultTable;
            }
        }

        public int GetConnect(string query)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
               
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        count = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching branch count: " + ex.Message);
                }
            }
            return count;

        }

        public DataTable GetReportData(string storedProc, string _param1, string _param2)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(storedProc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add required parameter1
                    cmd.Parameters.AddWithValue("@parameter1", _param1);

                    // Only add parameter2 if it's not empty/null and if the stored procedure expects it
                    if (!string.IsNullOrEmpty(_param2))
                    {
                        cmd.Parameters.AddWithValue("@parameter2", _param2);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }


    }
} 
      