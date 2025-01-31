using BusinessLogic.DTO;
using BusinessLogic.Repositories;
using DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.AdminDashboard
{
    public partial class Instructors : Form1
    {
        private InstructorRepo instructorRepo;
        private DataGridView dataGridView1;
        public Instructors()
        {
            InitializeComponent();
            var congig = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            DBManager dbManager = new DBManager(congig);
            instructorRepo = new InstructorRepo(dbManager);
            dataGridView1 = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };
            this.Controls.Add(dataGridView1);
        }
        private void Instructors_Load(object sender, EventArgs e)
        {
            InstructorDTO instructor = new InstructorDTO
                {
                InstructorId = 11,
                FirstName = "walaa",
                LastName = "Doe",
                Email = "J@gmail.com",
                Gender = "F",
                MName = "D",
                age = 30,
                Salary = 5000,
            };
            //instructorRepo.InsertInstructor(instructor);
            //instructorRepo.UpdateInstructor(instructor);
            instructorRepo.DeleteInstructor(11);
            var instructors = instructorRepo.GetInstructors();
            if (instructors == null || instructors.Count == 0)
            {
                MessageBox.Show("No instructors found.");
            }
            else
            {
                // salary column is displayed 0 0 0 ........
                dataGridView1.DataSource = instructors;
                dataGridView1.Columns["InstructorId"].HeaderText = "Instructor ID";
                dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["MName"].HeaderText = "Middle Name";
                dataGridView1.Columns["Age"].HeaderText = "Age";
                dataGridView1.Columns["Gender"].HeaderText = "Gender";
                dataGridView1.Columns["Salary"].HeaderText = "Salary";
            }
            dataGridView1.DataSource = instructors;
        }
    }
}
