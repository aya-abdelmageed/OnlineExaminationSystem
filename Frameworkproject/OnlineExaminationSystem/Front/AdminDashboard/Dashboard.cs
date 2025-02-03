using Front.InstructorDashboard;
using Front.StudentDashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccess;

namespace UI.AdminDashboard
{
    public partial class Dashboard:Form1
    {
        private DBManager dbManager;

        public Dashboard()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 657); // Set exact size (same as in the Designer)
            InitializeComponent();
            dbManager = new DBManager();
            panel3.Click += panel3_click;
            panel4.Click += panel4_Paint_Click;

        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rounded rectangle for panel2
            DrawRoundedPanelBorder(e, panel2, 20, Color.Black, 2);
        }

       
       
     




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    
        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel3, 20, Color.Black, 1);



        }

      
        private void panel3_click(object sender, EventArgs e)
        {
            var form = new InstructorDashboard();
            ShowForm(form);

        }
   
   

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel2, 20, Color.Black, 1);


        }

       
        private void panel4_Paint_Click(object sender, EventArgs e)
        {
            ShowForm(new StudentDashboard());


        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel5, 20, Color.Black, 1);


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel4, 20, Color.Black, 1);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                    dbManager.InitializeDatabaseConnection();
                    MessageBox.Show("Admin Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                selectData = "SELECT * FROM Student WHERE UserName=@UserName AND Password=@Password";
            }
            else if (userType == "Instructor")
            {
                selectData = "SELECT * FROM Instructor WHERE UserName=@UserName AND Password=@Password";
            }
            else
            {
                MessageBox.Show("Invalid selection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                    dbManager.InitializeDatabaseConnection();
                    MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dbManager.InitializeDatabaseConnection();
                    MessageBox.Show("Incorrect Username or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
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
    }
}
