using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Front.InstructorDashboard
{
    public partial class ExamView : Form
    {
        private ExamRepo repo;
        private int examId;
        public ExamView(int examId)
        {
            InitializeComponent();
            this.Size = new Size(1200, 800);
            this.Text = "Exam Viewer";
            repo = new ExamRepo();

            // Create the exam title panel with an icon
            Panel titlePanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.LightBlue
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

            // Load exam questions from the database using stored procedure
            LoadExam(scrollPanel, examId);
           
        }

        /// <summary>
        /// Loads exam questions into the scrollable panel.
        /// </summary>
        /// <param name="scrollPanel">The panel where questions will be displayed.</param>
        /// <param name="examID">The exam identifier.</param>
        private void LoadExam(Panel scrollPanel, int examID)
        {
            // Retrieve exam questions with choices from the database.
            List<ExamQuestionDetials> examQuestions = repo.GetExamQuestionsWithChoices(examID);

            int yOffset = 20;
            int questionNumber = 1;

            int containerWidth = (int)(scrollPanel.ClientSize.Width * 0.6);
            int containerX = (scrollPanel.ClientSize.Width - containerWidth) / 2;
            int verticalSpacing = 20;

            foreach (var q in examQuestions)
            {
                // Determine the height of the container based on the number of choices.
                int optionCount = q.Choices != null ? q.Choices.Count : 0;
                int totalAnswersHeight = optionCount * 35;
                int containerHeight = 50 + totalAnswersHeight + 40;

                // Question container panel (with rounded corners)
                Panel questionContainer = new Panel
                {
                    Location = new Point(containerX, yOffset),
                    Width = containerWidth,
                    Height = containerHeight,
                    BackColor = Color.FromArgb(248, 247, 253) // Light background color
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

                // Question number (red circle style)
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

                // Marks label (using the Points property)
                Label lblMarks = new Label
                {
                    Text = $"{q.Points} Marks",
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Location = new Point(questionContainer.Width - 90, 15)
                };
                questionContainer.Controls.Add(lblMarks);

                // Question text label
                Label lblQuestion = new Label
                {
                    Text = q.Question,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(50, 15),
                    AutoSize = true
                };
                questionContainer.Controls.Add(lblQuestion);

                int answerYOffset = 50;
                // Create a panel for each answer/choice.
                foreach (var answer in q.Choices)
                {
                    // Check if the current answer is the correct answer.
                    bool isCorrect = answer.Equals(q.CorrectAns, StringComparison.OrdinalIgnoreCase);
                    // Set default color based on correctness.
                    Color defaultColor = isCorrect ? Color.LightGreen : Color.White;

                    Panel answerPanel = new Panel
                    {
                        Width = questionContainer.Width - 60, // Slightly smaller than container
                        Height = 30,
                        BackColor = defaultColor,
                        Location = new Point(30, answerYOffset),
                        BorderStyle = BorderStyle.None,
                        Tag = defaultColor // Store the default color in Tag.
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

                    // Handle selection (highlighting) on mouse click.
                    answerPanel.MouseDown += AnswerPanel_MouseDown;
                    lblAnswer.MouseDown += (s, e) => { AnswerPanel_MouseDown(answerPanel, e); };

                    questionContainer.Controls.Add(answerPanel);
                    answerYOffset += 40;
                }

                yOffset += containerHeight + verticalSpacing;
                questionNumber++;
            }
        }

        /// <summary>
        /// Highlights the clicked answer panel.
        /// If the answer is not the correct one, it highlights with LightBlue,
        /// while preserving the default highlight for the correct answer.
        /// </summary>
        private void AnswerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            Panel questionContainer = clickedPanel.Parent as Panel;
            if (questionContainer == null) return;

            // Loop through all answer panels in the question container.
            foreach (Control ctrl in questionContainer.Controls)
            {
                if (ctrl is Panel panel && panel.Tag is Color defaultColor)
                {
                    // Reset to the panel's default color.
                    panel.BackColor = defaultColor;
                    SetRoundedRegion(panel, 10);
                }
            }

            // Get the default color for the clicked panel.
            Color clickedDefault = (Color)clickedPanel.Tag;
            // If the clicked answer is not the correct answer, highlight it.
            if (clickedDefault != Color.LightGreen)
            {
                clickedPanel.BackColor = Color.LightBlue;
            }
            // Otherwise, if it is the correct answer, leave it highlighted (LightGreen).
            SetRoundedRegion(clickedPanel, 10);
        }

        /// <summary>
        /// Applies a rounded region to a control.
        /// </summary>
        private void SetRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0) return;

            using (GraphicsPath path = GetRoundedRectanglePath(new Rectangle(0, 0, control.Width, control.Height), radius))
            {
                control.Region = new Region(path);
            }
        }

        /// <summary>
        /// Returns a GraphicsPath representing a rectangle with rounded corners.
        /// </summary>
        public static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            // Top-left arc
            path.AddArc(arcRect, 180, 90);
            // Top-right arc
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            // Bottom-right arc
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            // Bottom-left arc
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
