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
    public partial class Reports : Form1
    {
        private DataGridView dataGridView1;
        private QuestionsRepo questionsRepo;
        public Reports()
        {
            InitializeComponent();
            var config = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();
            questionsRepo = new QuestionsRepo(new DBManager(config));
            dataGridView1 = new DataGridView
            {
                Dock = DockStyle.Fill, // Fill the entire form
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true, // Read-only mode
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };
            this.Controls.Add(dataGridView1);
        }
        public void report_Load(object sender, EventArgs e)
        {
            //var questions = questionsRepo.GetQuestionsByID(9, 1);
            var question = new QuestionsDTO
            {
                QuestionID = 59,
                Question = "hello",
                Answer = "1",
                Points = 3,
                Type = "MCQ",
                CourseID = 1
            };
            //questionsRepo.InsertQuestions(question);
            //questionsRepo.UpdateQuestions(question);
            questionsRepo.DeleteQuestions(59);
            var questions = questionsRepo.ALL_COURSE_QUESTION(1);
            dataGridView1.DataSource = questions;
        }

    }
}
