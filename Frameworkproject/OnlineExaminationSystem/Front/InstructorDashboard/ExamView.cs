using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Front.InstructorDashboard
{
    public partial class ExamView : Form
    {
        public ExamView()
        {
            InitializeComponent();
            this.Size = new Size(1200, 800);
            this.Text = "Exam Viewer";

            // Create the exam title panel with an icon
            Panel titlePanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.LightBlue // Dark blue background
            };
            this.Controls.Add(titlePanel);

            // Exam icon (emoji used for demonstration)
            Label lblIcon = new Label
            {
                Text = "📘",
                Font = new Font("Arial", 24),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 10)
            };
            titlePanel.Controls.Add(lblIcon);

            // Exam title label
            Label lblTitle = new Label
            {
                Text = "Exam Viewer",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(60, 15)
            };
            titlePanel.Controls.Add(lblTitle);

            // Scrollable panel for questions
            Panel scrollPanel = new Panel
            {
                Location = new Point(0, titlePanel.Height),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - titlePanel.Height),
                AutoScroll = true,
                BackColor = Color.White
            };
            this.Controls.Add(scrollPanel);

            LoadExam(scrollPanel);
        }

        private void LoadExam(Panel scrollPanel)
        {
            List<Question> questions = GetSampleQuestions();
            int yOffset = 20;
            int questionNumber = 1;

            int containerWidth = (int)(scrollPanel.ClientSize.Width * 0.6);
            int containerX = (scrollPanel.ClientSize.Width - containerWidth) / 2;
            int verticalSpacing = 20;

            foreach (var q in questions)
            {
                int optionCount = (q.Type == QuestionType.TrueFalse) ? 2 : 4;
                int totalAnswersHeight = optionCount * 35;
                int containerHeight = 50 + totalAnswersHeight + 40;

                // **Question Container (Now Colored)**
                Panel questionContainer = new Panel
                {
                    Location = new Point(containerX, yOffset),
                    Width = containerWidth,
                    Height = containerHeight,
                    BackColor = Color.FromArgb(248, 247, 253)//Light Yellow
            };
                SetRoundedRegion(questionContainer, 15);
                questionContainer.Paint += (s, e) =>
                {
                    using (GraphicsPath path = GetRoundedRectanglePath(new Rectangle(0, 0, questionContainer.Width - 1, questionContainer.Height - 1), 15))
                    {
                        e.Graphics.DrawPath(Pens.Gray, path);
                    }
                };
                scrollPanel.Controls.Add(questionContainer);

                // **Question Number (Red Circle)**
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
                lblNumber.Region = new Region(new Rectangle(0, 0, lblNumber.Width, lblNumber.Height));
                questionContainer.Controls.Add(lblNumber);

                // **Marks Label**
                Label lblMarks = new Label
                {
                    Text = $"{q.Marks} Marks",
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Location = new Point(questionContainer.Width - 90, 15)
                };
                questionContainer.Controls.Add(lblMarks);

                // **Question Text**
                Label lblQuestion = new Label
                {
                    Text = q.Text,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(50, 15),
                    AutoSize = true
                };
                questionContainer.Controls.Add(lblQuestion);

                int answerYOffset = 50;
                foreach (var answer in q.Answers)
                {
                    Panel answerPanel = new Panel
                    {
                        Width = questionContainer.Width - 60, // Make it smaller
                        Height = 30,
                        BackColor = Color.White,
                        Location = new Point(30, answerYOffset),
                        BorderStyle = BorderStyle.None
                    };
                    SetRoundedRegion(answerPanel, 10);
                    answerPanel.Paint += (s, e) =>
                    {
                        using (GraphicsPath path = GetRoundedRectanglePath(new Rectangle(0, 0, answerPanel.Width - 1, answerPanel.Height - 1), 10))
                        {
                            e.Graphics.DrawPath(Pens.Gray, path);
                        }
                    };

                    Label lblAnswer = new Label
                    {
                        Text = answer,
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

        private void AnswerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            Panel questionContainer = clickedPanel.Parent as Panel;
            if (questionContainer == null) return;

            foreach (Control ctrl in questionContainer.Controls)
            {
                if (ctrl is Panel)
                {
                    ctrl.BackColor = Color.White;
                    SetRoundedRegion(ctrl, 10);
                }
            }

            clickedPanel.BackColor = Color.LightBlue;
            SetRoundedRegion(clickedPanel, 10);
        }

        private void SetRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0) return;

            using (GraphicsPath path = GetRoundedRectanglePath(new Rectangle(0, 0, control.Width, control.Height), radius))
            {
                control.Region = new Region(path);
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

        private List<Question> GetSampleQuestions()
        {
            return new List<Question>
            {
                new Question { Text = "What is 2 + 2?", Marks = 5, Type = QuestionType.MCQ, Answers = new List<string> { "3", "4", "5", "6" } },
                new Question { Text = "The Sun rises in the east.", Marks = 2, Type = QuestionType.TrueFalse, Answers = new List<string> { "True", "False" } }
            };
        }
    }

    public enum QuestionType { MCQ, TrueFalse }

    public class Question
    {
        public string Text { get; set; }
        public int Marks { get; set; }
        public QuestionType Type { get; set; }
        public List<string> Answers { get; set; }
    }
}
