using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Front.popUpForms
{
    public partial class StudentExamResult : Form
    {
        private readonly StudentExamRepo _studentExamRepo;
        private int studentId;
        private int examId;

        private Label lblCourse;
        private Label lblCorrect;
        private Label lblWrong;
        private Label lblPoints;
        private Label lblPercent;
        private PictureBox picStudent;
        private Button closeButton;

        public StudentExamResult(int studentId, int examId)
        {
            InitializeComponent2();
            _studentExamRepo = new StudentExamRepo();
            this.studentId = studentId;
            this.examId = examId;

            LoadStudentExamResults();
        }

        private void InitializeComponent2()
        {
            this.Text = "Student Exam Result";

            // Adjust the size of the form to accommodate the larger font sizes
            this.Size = new System.Drawing.Size(600, 500);  // Increased width and height
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Define font style with bigger size (e.g., 18) for labels
            Font labelFont = new Font("Arial", 18, FontStyle.Bold);

            // Adjust the position and size of the labels and controls accordingly
            Label lblCourseTitle = new Label { Text = "Course:", Location = new Point(30, 30), AutoSize = true, Font = labelFont };
            lblCourse = new Label { Location = new Point(150, 30), AutoSize = true, Font = labelFont };

            Label lblCorrectTitle = new Label { Text = "Correct Answers:", Location = new Point(30, 80), AutoSize = true, Font = labelFont };
            lblCorrect = new Label { Location = new Point(250, 80), AutoSize = true, Font = labelFont };

            Label lblWrongTitle = new Label { Text = "Wrong Answers:", Location = new Point(30, 130), AutoSize = true, Font = labelFont };
            lblWrong = new Label { Location = new Point(250, 130), AutoSize = true, Font = labelFont };

            Label lblPointsTitle = new Label { Text = "Total Points:", Location = new Point(30, 180), AutoSize = true, Font = labelFont };
            lblPoints = new Label { Location = new Point(250, 180), AutoSize = true, Font = labelFont };

            Label lblPercentTitle = new Label { Text = "Percentage:", Location = new Point(30, 230), AutoSize = true, Font = labelFont };
            lblPercent = new Label { Location = new Point(250, 230), AutoSize = true, Font = labelFont };

            picStudent = new PictureBox
            {
                Location = new Point(400, 30),
                Size = new Size(150, 150),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            closeButton = new Button
            {
                Text = "Close",
                Location = new Point(250, 350),
                Size = new Size(150, 40),  // Increased button size to match form size
                Font = new Font("Arial", 16, FontStyle.Bold)  // Larger font for the button
            };
            closeButton.Click += (sender, e) => this.Close();

            // Add all controls to the form
            this.Controls.Add(lblCourseTitle);
            this.Controls.Add(lblCourse);
            this.Controls.Add(lblCorrectTitle);
            this.Controls.Add(lblCorrect);
            this.Controls.Add(lblWrongTitle);
            this.Controls.Add(lblWrong);
            this.Controls.Add(lblPointsTitle);
            this.Controls.Add(lblPoints);
            this.Controls.Add(lblPercentTitle);
            this.Controls.Add(lblPercent);
            this.Controls.Add(picStudent);
            this.Controls.Add(closeButton);
            this.BackColor = Color.FromArgb(247, 248, 253);

        }

        private void LoadStudentExamResults()
        {
            try
            {
                List<StudentExamResultDTO> results = _studentExamRepo.GetStudentExamResults(studentId, examId);
                if (results.Count > 0)
                {
                    var result = results[0];
                    lblCourse.Text = result.CourseName;
                    lblCorrect.Text = $"{result.CorrectQuestions} ✅";
                    lblWrong.Text = $"{result.WrongQuestions} ❌";
                    lblCorrect.ForeColor = Color.Green;
                    lblWrong.ForeColor = Color.Red;
                    lblPoints.Text = $"{result.TotalMarks}";
                    lblPercent.Text = $"{((double)result.CorrectQuestions / (result.CorrectQuestions + result.WrongQuestions) * 100):0.00}%";

                    // Set font and style for labels dynamically
                    lblCourse.Font = new Font("Arial", 20, FontStyle.Bold);
                    lblCorrect.Font = new Font("Arial", 20, FontStyle.Bold);
                    lblWrong.Font = new Font("Arial", 20, FontStyle.Bold);
                    lblPoints.Font = new Font("Arial", 20, FontStyle.Bold);
                    lblPercent.Font = new Font("Arial", 20, FontStyle.Bold);

                    // Load student image if path exists
                    picStudent.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\party_13140511.png"));
                }
                else
                {
                    MessageBox.Show("No results found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching exam results: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
