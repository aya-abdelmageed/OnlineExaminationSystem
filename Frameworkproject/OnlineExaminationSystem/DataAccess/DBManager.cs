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

    }
}
