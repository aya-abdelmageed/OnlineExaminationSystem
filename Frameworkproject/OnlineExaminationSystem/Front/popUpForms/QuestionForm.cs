using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using Front.InstructorDashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static UI.AdminDashboard.Form1;

namespace UI.AdminDashboard
{
    public partial class QuestionForm : Form
    {
        // Properties to expose the input data
        public int? QuestionId { get; private set; }
        public int Mode { get; private set; }
        public TextBox QBankIdTextBox { get; private set; }
        public TextBox QBankNameTextBox { get; private set; }
        public TextBox AnswerTextBox { get; private set; }
        public TextBox PointsTextBox { get; private set; }
        public TextBox TypeTextBox { get; private set; }
        public TextBox CrsIDTextBox { get; private set; }

        private QuestionChoiceRepo questionChoiceRepo;
        private QuestionsRepo questionsRepo;
        private Button submitButton;
        // Removed ChoicesComboBox since we will use only textboxes.
        // private ComboBox ChoicesComboBox;

        // Use a FlowLayoutPanel to host dynamic choice controls.
        private FlowLayoutPanel choicesPanel;
        // Button to add a new choice row.
        private Button addChoiceButton;
        // Keep track of added choice textboxes (if needed for later use)
        private List<TextBox> choiceTextBoxes;
        DataGridView customView;
        public QuestionForm(int mode, QuestionsDTO question = null, DataGridView data = null)
        {
            Mode = mode;
            questionsRepo = new QuestionsRepo();
            questionChoiceRepo = new QuestionChoiceRepo();
            choiceTextBoxes = new List<TextBox>();
            customView = data;
            // Set the QuestionId if provided (for edit mode)
            if (question != null)
            {
                QuestionId = question.QuestionID;
            }

            InitializeComponent2();

            // In edit/view mode, hide the addChoiceButton if not needed
            if (Mode != (int)FormMode.Add)
            {
                addChoiceButton.Visible = false;
            }

            // Pre-fill the form with the passed values if it's in edit or view mode
            switch (mode)
            {
                case (int)FormMode.Edit:
                    QBankIdTextBox.Text = QuestionId.ToString();
                    QBankNameTextBox.Text = question.Question;
                    AnswerTextBox.Text = question.Answer;
                    PointsTextBox.Text = question.Points.ToString();
                    TypeTextBox.Text = question.Type;
                    CrsIDTextBox.Text = question.CourseID.ToString();
                    submitButton.Text = "Save Changes";
                    LoadChoices(QuestionId.Value);
                    break;
                case (int)FormMode.Add:
                    addChoiceButton.Text = "Add Choice";
                    submitButton.Text = "Add Question";
                    break;
                case (int)FormMode.View:
                    QBankIdTextBox.Text = QuestionId.ToString();
                    QBankNameTextBox.Text = question.Question;
                    AnswerTextBox.Text = question.Answer;
                    PointsTextBox.Text = question.Points.ToString();
                    TypeTextBox.Text = question.Type;
                    CrsIDTextBox.Text = question.CourseID.ToString();
                    CrsIDTextBox.ReadOnly = true;
                    QBankIdTextBox.ReadOnly = true;
                    QBankNameTextBox.ReadOnly = true;
                    TypeTextBox.ReadOnly = true;
                    AnswerTextBox.ReadOnly = true;
                    PointsTextBox.ReadOnly = true;
                    submitButton.Text = "Close";
                    LoadChoices(QuestionId.Value);
                    break;
            }
            this.BackColor = Color.White;
            this.submitButton.BackColor = Color.FromArgb(204, 8, 8);
            this.submitButton.ForeColor = Color.White;


        }

        private void InitializeComponent2()
        {
            this.Text = "Question Bank Form";
            this.Size = new Size(500, 600); // Increase the form size to accommodate dynamic controls
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScroll = true; // Enable scrolling if needed

            // Create Labels
            Label QBankIdLabel = new Label
            {
                Text = "Question ID:",
                Location = new Point(50, 20),
                Size = new Size(100, 20),
                Visible = false // Hide if you don't want to show the ID
            };

            Label QBankNameLabel = new Label
            {
                Text = "Question Text:",
                Location = new Point(50, 60),
                Size = new Size(100, 20)
            };

            Label AnswerLabel = new Label
            {
                Text = "Answer:",
                Location = new Point(50, 100),
                Size = new Size(100, 20)
            };

            Label PointsLabel = new Label
            {
                Text = "Points:",
                Location = new Point(50, 140),
                Size = new Size(100, 20)
            };

            Label TypeLabel = new Label
            {
                Text = "Type:",
                Location = new Point(50, 180),
                Size = new Size(100, 20)
            };

            Label CrsIDLabel = new Label
            {
                Text = "Course ID:",
                Location = new Point(50, 220),
                Size = new Size(100, 20)
            };

            // Create TextBoxes
            QBankIdTextBox = new TextBox
            {
                Location = new Point(150, 20),
                Size = new Size(200, 20),
                ReadOnly = true,
                Visible = false
            };

            QBankNameTextBox = new TextBox
            {
                Location = new Point(150, 60),
                Size = new Size(250, 20)
            };

            AnswerTextBox = new TextBox
            {
                Location = new Point(150, 100),
                Size = new Size(250, 20)
            };

            PointsTextBox = new TextBox
            {
                Location = new Point(150, 140),
                Size = new Size(250, 20)
            };

            TypeTextBox = new TextBox
            {
                Location = new Point(150, 180),
                Size = new Size(250, 20)
            };

            CrsIDTextBox = new TextBox
            {
                Location = new Point(150, 220),
                Size = new Size(250, 20)
            };

            // Create a FlowLayoutPanel to hold dynamic choice controls.
            choicesPanel = new FlowLayoutPanel
            {
                Location = new Point(50, 260),
                Size = new Size(400, 150),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Create the "Add Choice" button.
            addChoiceButton = new Button
            {
                Text = "Add Choice",
                Location = new Point(50, 420),
                Size = new Size(100, 30)
            };
            addChoiceButton.Click += AddChoiceButton_Click;

            // Create the Submit/Close button.
            submitButton = new Button
            {
                Location = new Point(350, 500),
                Size = new Size(100, 30)
            };
            submitButton.Click += SubmitButton_Click;

            // Add controls to the form.
            this.Controls.Add(QBankIdLabel);
            this.Controls.Add(QBankNameLabel);
            this.Controls.Add(AnswerLabel);
            this.Controls.Add(PointsLabel);
            this.Controls.Add(TypeLabel);
            this.Controls.Add(CrsIDLabel);

            this.Controls.Add(QBankIdTextBox);
            this.Controls.Add(QBankNameTextBox);
            this.Controls.Add(AnswerTextBox);
            this.Controls.Add(PointsTextBox);
            this.Controls.Add(TypeTextBox);
            this.Controls.Add(CrsIDTextBox);

            // Add the FlowLayoutPanel for dynamic choices and the "Add Choice" button.
            this.Controls.Add(choicesPanel);
            this.Controls.Add(addChoiceButton);

            this.Controls.Add(submitButton);
        }

        // Event handler for the "Add Choice" button.
        private void AddChoiceButton_Click(object sender, EventArgs e)
        {
            AddNewChoiceRow(string.Empty);
        }

        /// <summary>
        /// Adds a new choice row (a Panel containing a label and a TextBox) to the FlowLayoutPanel.
        /// </summary>
        /// <param name="choiceText">Optional initial text for the choice.</param>
        private void AddNewChoiceRow(string choiceText)
        {
            // Create a Panel for each choice row.
            Panel choiceRow = new Panel
            {
                Size = new Size(choicesPanel.Width - 25, 30)
            };

            Label choiceLabel = new Label
            {
                Text = "Choice:",
                Location = new Point(0, 5),
                Size = new Size(60, 20)
            };

            TextBox choiceTextBox = new TextBox
            {
                Text = choiceText,
                Location = new Point(70, 3),
                Size = new Size(choiceRow.Width - 80, 20)
            };

            // If in view mode, make the textbox read-only.
            if (Mode == (int)FormMode.View)
            {
                choiceTextBox.ReadOnly = true;
            }

            // Add controls to the panel.
            choiceRow.Controls.Add(choiceLabel);
            choiceRow.Controls.Add(choiceTextBox);

            // Add the new textbox to the list.
            choiceTextBoxes.Add(choiceTextBox);

            // Add the new row to the FlowLayoutPanel.
            choicesPanel.Controls.Add(choiceRow);
        }

        // Event handler for the Submit/Close button.
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // In view mode, simply close the form.
            if (Mode == (int)FormMode.View)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // Get values from the textboxes.
            string questionText = QBankNameTextBox.Text;
            string answer = AnswerTextBox.Text;
            if (!int.TryParse(PointsTextBox.Text, out int points))
            {
                MessageBox.Show("Please enter a valid number for Points.");
                return;
            }
            string type = TypeTextBox.Text;
            if (!int.TryParse(CrsIDTextBox.Text, out int courseID))
            {
                MessageBox.Show("Please enter a valid Course ID.");
                return;
            }

            // Simple validation.
            if (string.IsNullOrEmpty(questionText))
            {
                MessageBox.Show("Please fill in the question text.");
                return;
            }

            // In Edit mode, update the question (and choices if needed).
            if (Mode == (int)FormMode.Edit)
            {
                int questionID = int.Parse(QBankIdTextBox.Text);
                questionsRepo.UpdateQuestions(new QuestionsDTO
                {
                    QuestionID = questionID,
                    Question = questionText,
                    Type = type,
                    Points = points,
                    CourseID = courseID
                });

                // If you want to update the choices based on the dynamic TextBoxes,
                // you can loop through them and call your repository update methods.
                // Example:
                var q = questionChoiceRepo.GetQuestionChoices(questionID);
                int i = 0;
                foreach (TextBox tb in choiceTextBoxes)
                {
                    tb.Text = q[i++].Choice;
                }
                MessageBox.Show($"Question {questionID} updated: {questionText}, Points: {points}, Answer: {answer}");
                BindingList<QuestionsDTO> qs = new BindingList<QuestionsDTO>(questionsRepo.ALL_COURSE_QUESTION(null));
                customView.DataSource = qs;
            }
            // In Add mode, first insert the question and then its choices.
            else if (Mode == (int)FormMode.Add)
            {
                // Insert the question. Assume that InsertQuestions returns the new QuestionID.
                int newQuestionID = questionsRepo.InsertQuestions(new QuestionsDTO
                {
                    Question = questionText,
                    Answer = answer,
                    Type = type,
                    Points = points,
                    CourseID = courseID
                });

                // Now insert each choice associated with the new question.
                foreach (TextBox tb in choiceTextBoxes)
                {
                    if (!string.IsNullOrWhiteSpace(tb.Text))
                    {
                        questionChoiceRepo.InsertQuestionChoice(newQuestionID, tb.Text);
                    }
                }
                BindingList<QuestionsDTO> qs = new BindingList<QuestionsDTO>(questionsRepo.ALL_COURSE_QUESTION(null));
                customView.DataSource = qs;
                MessageBox.Show($"New Question added: {questionText}, answer: {answer}, points: {points}");
            }
            this.DialogResult = DialogResult.OK;
            this.Hide();

        }

        private void LoadChoices(int id)
        {
            // Fetch choices from the database.
            var choices = questionChoiceRepo.GetQuestionChoices(id);

            if (choices != null && choices.Count > 0)
            {
                // Clear any existing controls and list.
                choicesPanel.Controls.Clear();
                choiceTextBoxes.Clear();

                // For each fetched choice, add a new row with its text.
                foreach (var choice in choices)
                {
                    AddNewChoiceRow(choice.Choice);
                }
            }
        }
    }
}
