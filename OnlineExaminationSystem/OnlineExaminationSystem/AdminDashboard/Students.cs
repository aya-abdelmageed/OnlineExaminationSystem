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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace UI.AdminDashboard
{
    public partial class Students : Form1
    {
        private DataGridView dataGridView1;
        private StudentRepo _studentRepository;
        public Students()
        {
            InitializeComponent();
            var config = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();
            DBManager dBManager = new DBManager(config);
            _studentRepository = new StudentRepo(dBManager);
            dataGridView1 = new DataGridView
            {
                Dock = DockStyle.Fill, // Fill the entire form
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true, // Read-only mode
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            // Add DataGridView to the form
            this.Controls.Add(dataGridView1);
        }
        public void student_Load(object sender, EventArgs e)
        {
            _studentRepository.InsertStudent(new StudentDTO
            {
                Birthdate = DateTime.Now,
                FName = "aliiiiii",
                Gender = "M",
                LName = "aliiiiii",
                MName = "aliiiiii",
                Phone = "123456789",
                trackID = 1
            });
            var students = _studentRepository.GetStudents(1);
            dataGridView1.DataSource = students;

        }
    } }
