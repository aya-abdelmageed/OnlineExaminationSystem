using AutoMapper;
using BusinessLogic.Repositories;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly InstructorRepo _instructorRepo; // InstructorRepo instance
        private DataGridView dataGridView1;              // DataGridView instance

        // Injecting InstructorRepo into the form via constructor
        public Form1(InstructorRepo instructorRepo)
        {
            InitializeComponent();
            _instructorRepo = instructorRepo; // Store the injected InstructorRepo
            InitializeDataGridView(); // Initialize the DataGridView
        }



        private void InitializeDataGridView()
        {
            dataGridView1 = new DataGridView();
            dataGridView1.Size = new System.Drawing.Size(958, 528);
            dataGridView1.Location = new System.Drawing.Point(286, 81);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dataGridView1);

        }
        //---------------------------------------------------------------------------------------
        private void Dashboard_Click(object sender, EventArgs e)
        {
            // Hide all controls first
            foreach (Control control in this.Controls)
            {
                // If the control is not one of the panels for the dashboard content, hide it
                if (control != panel2 && control != panel3 && control != panel4 && control != panel5)
                {
                    control.Visible = false;
                }
            }

            // Show only the panels for the dashboard content
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
        }

        //---------------------------------------------------------------------------------------
        // Function to fetch data from the Branch table and display it in DataGridView
        private void LoadBranchData()
        {
            try
            {
                dataGridView1.Location = new Point(400, 250);

                dataGridView1.Width = 580;  // Set the width to 500 pixels
                dataGridView1.Height = 300; // Set the height to 300 pixels
                dataGridView1.BorderStyle = BorderStyle.None;


                var instructors = _instructorRepo.GetInstructors();
                dataGridView1.BackgroundColor = Color.White;


                dataGridView1.DataSource = instructors;  // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }

        private void Branches_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control != panel1 && control != dataGridView1)
                {
                    control.Visible = false;
                }
            }

            // Ensure DataGridView is initialized and visible
            if (dataGridView1 == null)
            {
                InitializeDataGridView();
            }

            dataGridView1.Visible = true;
            dataGridView1.BringToFront();  // Bring DataGridView to the front
            LoadBranchData();
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            string countQuery1 = "SELECT COUNT(*) FROM Branch";

            // Update label2 with the total count of branches
        }
        //----------------------------------------------------------------------------------------
        private void LoadTrackData()
        {
            try
            {
                string query = "SELECT * FROM Track";
                DataTable dt = new DataTable();

                dataGridView1.DataSource = dt;  // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
            // First hide all controls except panel1 and dataGridView1
            foreach (Control control in this.Controls)
            {
                if (control != panel1 && control != dataGridView1)
                {
                    control.Visible = false;
                }
            }

            // Ensure DataGridView is initialized and visible
            if (dataGridView1 == null)
            {
                InitializeDataGridView();
            }

            dataGridView1.Visible = true;
            dataGridView1.BringToFront();  // Bring DataGridView to the front
            LoadTrackData();
        }


        //----------------------------------------------------------------------------------------
        private void LoadCourseData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // First hide all controls except panel1 and dataGridView1
            foreach (Control control in this.Controls)
            {
                if (control != panel1 && control != dataGridView1)
                {
                    control.Visible = false;
                }
            }

            // Ensure DataGridView is initialized and visible
            if (dataGridView1 == null)
            {
                InitializeDataGridView();
            }

            dataGridView1.Visible = true;
            dataGridView1.BringToFront();  // Bring DataGridView to the front
            LoadCourseData();

        }
        //-----------------------------------------------------------------------------------------
        private void LoadInstructorData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // First hide all controls except panel1 and dataGridView1
            foreach (Control control in this.Controls)
            {
                if (control != panel1 && control != dataGridView1)
                {
                    control.Visible = false;
                }
            }

            // Ensure DataGridView is initialized and visible
            if (dataGridView1 == null)
            {
                InitializeDataGridView();
            }

            dataGridView1.Visible = true;
            dataGridView1.BringToFront();  // Bring DataGridView to the front
            LoadInstructorData();

        }
        private void label3_Paint_1(object sender, PaintEventArgs e)
        {
            string countQuery2 = "SELECT COUNT(*) FROM Instructor";

            // Update label2 with the total count of branches
        }
        //------------------------------------------------------------------------------------------
        private void LoadStudentData()
        {
            try
            {
                string query = "SELECT * FROM Student";
                DataTable dt = new DataTable();

                dataGridView1.DataSource = dt;  // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // First hide all controls except panel1 and dataGridView1
            foreach (Control control in this.Controls)
            {
                if (control != panel1 && control != dataGridView1)
                {
                    control.Visible = false;
                }
            }

            // Ensure DataGridView is initialized and visible
            if (dataGridView1 == null)
            {
                InitializeDataGridView();
            }

            dataGridView1.Visible = true;
            dataGridView1.BringToFront();  // Bring DataGridView to the front
            LoadStudentData();
        }

        private void label5_Paint(object sender, PaintEventArgs e)
        {

            // Update label2 with the total count of branches
        }
        //------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


    }
}

//----------------------------------------------------------------

