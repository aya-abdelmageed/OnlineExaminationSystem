using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            this.Size = new System.Drawing.Size(400, 350);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblCourseTitle = new Label { Text = "Course:", Location = new Point(30, 20), AutoSize = true };
            lblCourse = new Label { Location = new Point(120, 20), AutoSize = true };

            Label lblCorrectTitle = new Label { Text = "Correct Answers:", Location = new Point(30, 60), AutoSize = true };
            lblCorrect = new Label { Location = new Point(150, 60), AutoSize = true };

            Label lblWrongTitle = new Label { Text = "Wrong Answers:", Location = new Point(30, 100), AutoSize = true };
            lblWrong = new Label { Location = new Point(150, 100), AutoSize = true };

            Label lblPointsTitle = new Label { Text = "Total Points:", Location = new Point(30, 140), AutoSize = true };
            lblPoints = new Label { Location = new Point(150, 140), AutoSize = true };

            Label lblPercentTitle = new Label { Text = "Percentage:", Location = new Point(30, 180), AutoSize = true };
            lblPercent = new Label { Location = new Point(150, 180), AutoSize = true };

            picStudent = new PictureBox
            {
                Location = new Point(250, 20),
                Size = new Size(100, 100),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            closeButton = new Button
            {
                Text = "Close",
                Location = new Point(150, 250),
                Size = new Size(100, 30)
            };
            closeButton.Click += (sender, e) => this.Close();

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
                    lblPoints.Text = $"{result.TotalMarks}";
                    lblPercent.Text = $"{((double)result.CorrectQuestions / (result.CorrectQuestions + result.WrongQuestions) * 100):0.00}%";

                    // Load student image if path exists
                    string imagePath = "path_to_image"; // Replace with actual logic
                    if (System.IO.File.Exists(imagePath))
                        picStudent.Image = Image.FromFile(imagePath);
                    else
                        picStudent.Image = null;
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
