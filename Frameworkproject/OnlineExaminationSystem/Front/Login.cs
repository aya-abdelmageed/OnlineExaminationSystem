using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using UI.AdminDashboard;
using Front.AdminDashboard;
using Front.InstructorDashboard;
using Front.StudentDashboard;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace Front
{
    public partial class Login : Form
    {
        private DBManager dbManager;
        public Login()
        {
            dbManager = new DBManager();
           
            InitializeComponent();
        }
        public void ShowForm(Form form)
        {
            //form.StartPosition = FormStartPosition.Manual;
            this.StartPosition = FormStartPosition.CenterScreen;
            form.Location = this.Location;
            this.Hide(); // Hide Login form instead of closing it

            form.Show(); // Ensure the new form is shown

            form.FormClosed += (sender, e) => this.Close(); // Close Login when new form closes
        }

      
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
              
             if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
                checkBox1.Text = "Hide Password";
            }
            else
            {
                textBox2.PasswordChar = '*';
                checkBox1.Text = "Show Password";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string userType = comboBox1.Text.Trim();

            if (userType == "Admin")
            {
                if (username == "Admin.System" && password == "159951")
                {
                    MessageBox.Show("Admin Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowForm(new Dashboard(0,null)); // Open the dashboard
                    return;
                }
                else
                {
                    MessageBox.Show("Incorrect Admin Username or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string selectData = "";
            if (userType == "Student")
            {
                selectData = "SELECT Student_ID FROM Student WHERE UserName COLLATE SQL_Latin1_General_CP1_CS_AS = @UserName AND Password COLLATE SQL_Latin1_General_CP1_CS_AS = @Password";
            }
            else if (userType == "Instructor")
            {
                selectData = "SELECT INS_ID FROM Instructor WHERE UserName COLLATE SQL_Latin1_General_CP1_CS_AS = @UserName AND Password COLLATE SQL_Latin1_General_CP1_CS_AS = @Password";
            }

            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@UserName", username),
               new SqlParameter("@Password", password)
            };

            try
            {
                DataTable table = dbManager.ExecuteQuery(selectData, parameters);

                if (table.Rows.Count >= 1)
                {
                    int userId = Convert.ToInt32(table.Rows[0][0]); // Get the ID from the first column
                    MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Pass user ID to the next form
                    if (userType == "Instructor")
                    {
                        ShowForm(new InstructorDashboard.InstructorDashboard(userId, userType));
                    }
                    else if (userType == "Student")
                    {
                        ShowForm(new StudentDashboard.StudentDashboard(userId, userType));
                    }
                    else if (userType == "Admin")
                    {
                        ShowForm(new Dashboard(userId, userType));
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
