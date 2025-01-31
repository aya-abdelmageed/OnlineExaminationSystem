using BusinessLogi.DTO;
using BusinessLogi.Repositories;
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
    public partial class Courses : Form1
    {
        private DataGridView dataGridView1;
        private CourseRepo courseRepo;
        public Courses()
        {
            InitializeComponent();
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            DBManager dbManager = new DBManager(config);
            courseRepo = new CourseRepo(dbManager);
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
        private void Courses_Load(object sender, EventArgs e)
        {
            CourseDTO course = new CourseDTO
            {
                Name = "French",
            };
            //courseRepo.InsertCourses(branch);
            //courseRepo.updateCourses(course); // by name edit
            //courseRepo.DeleteCourses(); // by name delete
            var courses = courseRepo.GetCourses();

            if (courses == null || courses.Count == 0)
            {
                MessageBox.Show("No courses found.");
            }
            else
            {
                dataGridView1.DataSource = courses;
                dataGridView1.Columns["ID"].HeaderText = "Course ID";
                dataGridView1.Columns["Name"].HeaderText = "Course Name";
            }

        }
    }
}
