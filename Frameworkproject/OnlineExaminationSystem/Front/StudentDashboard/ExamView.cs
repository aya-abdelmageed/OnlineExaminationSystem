using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using Front.InstructorDashboard;
using UI.AdminDashboard;

namespace Front.StudentDashboard
{
    public partial class ExamView : Form
    {
        private StudentExamRepo studentRepo;
        private Timer examTimer;
        private int remainingTime; // Time in seconds
        private Button btnSubmit;
        private int studentId;
        private int examId;
        private Label lblTimer;
        private ExamQuestionStudentRepo questionStudentRepo;    
        public ExamView(int studentId, int examId)
        {
            // Initialize student repository
            studentRepo = new StudentExamRepo();
            questionStudentRepo = new ExamQuestionStudentRepo();    

            // Set form properties
            InitializeComponent();
            this.Size = new Size(1200, 800);
            this.Text = "Exam Viewer";
            this.studentId = studentId;
            this.examId = examId;

            // Set exam duration (30 minutes)
            remainingTime = 30 * 60;

            // Initialize and start exam timer
            examTimer = new Timer
            {
                Interval = 1000 // 1 second interval
            };
            examTimer.Tick += ExamTimer_Tick;
            examTimer.Start();

            // Title Panel
            Panel titlePanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.LightBlue
            };
            this.Controls.Add(titlePanel);

            // Exam Title Label
            Label lblTitle = new Label
            {
                Text = "Exam Viewer",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(60, 15)
            };
            titlePanel.Controls.Add(lblTitle);

            // ** Timer Label **
            lblTimer = new Label
            {
                Text = "Time Left: 30:00",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(300, 18)
            };
            titlePanel.Controls.Add(lblTimer);

            // Submit Button
            btnSubmit = new Button
            {
                Text = "Submit Exam",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Red,
                Width = 150,
                Height = 40,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(titlePanel.Width - 180, 10)
            };
            btnSubmit.Click += BtnSubmit_Click;
            titlePanel.Controls.Add(btnSubmit);

            // Scrollable Panel for Questions
            Panel scrollPanel = new Panel
            {
                Location = new Point(0, titlePanel.Height),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - titlePanel.Height),
                AutoScroll = true,
                BackColor = Color.White
            };
            this.Controls.Add(scrollPanel);

            // Load Exam Questions
            LoadExam(scrollPanel);
        }

        // ** Updated Timer Tick Event **
        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                int minutes = remainingTime / 60;
                int seconds = remainingTime % 60;
                lblTimer.Text = $"Time Left: {minutes:D2}:{seconds:D2}"; // Update the label instead of the form title
            }
            else
            {
                examTimer.Stop();
                MessageBox.Show("Time is up! Submitting your exam.", "Exam Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubmitExam();
            }
        }



        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to submit?", "Submit Exam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SubmitExam();
            }
        }

        private void SubmitExam()
        {
            examTimer.Stop();
            MessageBox.Show("Your exam has been submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void LoadExam(Panel scrollPanel)
        {
            // Fetch exam data
            List<StudentExamDetialsDTO> examDetails = studentRepo.GetStudentExamDetails(studentId, examId);

            if (examDetails.Count == 0)
            {
                MessageBox.Show("No questions found for this exam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int yOffset = 20;
            int questionNumber = 1;
            int containerWidth = (int)(scrollPanel.ClientSize.Width * 0.6);
            int containerX = (scrollPanel.ClientSize.Width - containerWidth) / 2;
            int verticalSpacing = 20;

            foreach (var exam in examDetails)
            {
                foreach (var q in exam.Questions)
                {
                    int optionCount = q.Choices.Count;
                    int totalAnswersHeight = optionCount * 35;
                    int containerHeight = 50 + totalAnswersHeight + 40;

                    Panel questionContainer = new Panel
                    {
                        Location = new Point(containerX, yOffset),
                        Width = containerWidth,
                        Height = containerHeight,
                        BackColor = Color.LightGray
                    };
                    SetRoundedRegion(questionContainer, 15);
                    scrollPanel.Controls.Add(questionContainer);

                    Label lblNumber = new Label
                    {
                        Text = questionNumber.ToString(),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = Color.LightBlue,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Width = 30,
                        Height = 30,
                        Location = new Point(10, 10)
                    };
                    questionContainer.Controls.Add(lblNumber);

                    Label lblMarks = new Label
                    {
                        Text = $"{q.Points} Marks",
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.Black,
                        AutoSize = true,
                        Location = new Point(questionContainer.Width - 90, 15)
                    };
                    questionContainer.Controls.Add(lblMarks);

                    Label lblQuestion = new Label
                    {
                        Text = q.QuestionText,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        Location = new Point(50, 15),
                        AutoSize = true
                    };
                    questionContainer.Controls.Add(lblQuestion);

                    // Retrieve the saved answer for this question
                    string savedAnswer = q.StudentAnswer.ToString();

                    int answerYOffset = 50;
                    foreach (var choice in q.Choices)
                    {
                        Panel answerPanel = new Panel
                        {
                            Width = questionContainer.Width - 60,
                            Height = 30,
                            BackColor = (savedAnswer == choice) ? Color.LightBlue : Color.White, // Highlight if previously selected
                            Location = new Point(30, answerYOffset),
                            BorderStyle = BorderStyle.None,
                            Tag = q.QuestionID // Store question ID in the Tag property
                        };
                        SetRoundedRegion(answerPanel, 10);

                        Label lblAnswer = new Label
                        {
                            Text = choice,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Padding = new Padding(5, 0, 0, 0),
                            Font = new Font("Arial", 10, FontStyle.Regular),
                            BackColor = Color.Transparent
                        };
                        answerPanel.Controls.Add(lblAnswer);

                        answerPanel.MouseDown += AnswerPanel_MouseDown;
                        lblAnswer.MouseDown += (s, e) => { AnswerPanel_MouseDown(answerPanel, e); };

                        questionContainer.Controls.Add(answerPanel);
                        answerYOffset += 40;
                    }

                    yOffset += containerHeight + verticalSpacing;
                    questionNumber++;
                }
            }
        }



        public static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            path.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void SetRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0) return;

            using (GraphicsPath path = GetRoundedRectanglePath(new Rectangle(0, 0, control.Width, control.Height), radius))
            {
                control.Region = new Region(path);
            }
        }
        private void AnswerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            Panel questionContainer = clickedPanel.Parent as Panel;
            if (questionContainer == null) return;

            // Reset all answer panels in the question container
            foreach (Control ctrl in questionContainer.Controls)
            {
                if (ctrl is Panel)
                {
                    ctrl.BackColor = Color.White;
                    SetRoundedRegion(ctrl, 10);
                }
            }

            // Highlight selected answer
            clickedPanel.BackColor = Color.LightBlue;
            SetRoundedRegion(clickedPanel, 10);

            // Get the selected answer text
            Label selectedLabel = clickedPanel.Controls[0] as Label;
            if (selectedLabel == null) return;

            string selectedAnswer = selectedLabel.Text;
            // **Fix: Get the correct Question ID**
            if (clickedPanel.Tag == null)
            {
                MessageBox.Show("Question ID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get question ID
            int questionId = Convert.ToInt32(clickedPanel.Tag); // Assuming we store questionId in Tag property

            // **Insert into the database**
            questionStudentRepo.InsertQuestionStudent(studentId, examId, questionId, selectedAnswer);

            MessageBox.Show($"Answer '{selectedAnswer}' saved for Question {questionId}.", "Answer Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}


