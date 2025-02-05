using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UI.AdminDashboard;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static UI.AdminDashboard.Form1;

namespace Front.InstructorDashboard
{
    public class QuestionBank : InstructorDashboard
    {
        private QuestionsRepo questions;
        private ComboBox ChoicesComboBox;
        private QuestionChoiceRepo questionChoiceRepo;
        private DataGridView customGrid;
        internal ComboBox comboBoxQuestionsData;
        private Label Crs_Label;
        private CourseRepo coursesRepo;
        private Button addbutton;

        public QuestionBank()
        {
            coursesRepo = new CourseRepo();
            questions = new QuestionsRepo();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.ClientSize = new Size(1324, 600);
            customGrid = InitializeCustomGrid();
            InitializeComponent();
            addbutton = GenerateCustomButton();

            addbutton.Text = "Add Question";

            addbutton.Click += (s, e) =>
            {
                var newForm = new QuestionForm((int)FormMode.Add, null, customGrid);
                newForm.Show();

            };
            LoadData();
            // Load data into ComboBox and DataGridView
            LoadComboBoxData(); 
            AddActions(customGrid);
            // Handle ComboBox selection change
            comboBoxQuestionsData.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            //AddActions(customGrid);
            // Handle Click Events with Dynamic Detection
            customGrid.CellMouseClick += (s, e) =>
            {
                HandleActionClick(customGrid, e);
            };

        }
        private void InitializeComponent()
        {
            this.comboBoxQuestionsData = new ComboBox();
            this.Crs_Label = new Label();
            Crs_Label.Text = "Choose Your Course";
            this.SuspendLayout();
            // ComboBox
            this.comboBoxQuestionsData.FormattingEnabled = true;
            this.comboBoxQuestionsData.Location = new Point((this.ClientSize.Width - 600) / 2, 150); // Same position as search bar
            this.comboBoxQuestionsData.Size = new Size(600, 21); // Same size as search bar
            this.comboBoxQuestionsData.TabIndex = 2;

            // Label
            this.Crs_Label.AutoSize = true;
            this.Crs_Label.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.Crs_Label.Location = new Point(540, 120); // Above the ComboBox
            this.Crs_Label.Name = "Crs_Label";
            this.Crs_Label.Size = new Size(167, 20);
            this.Crs_Label.TabIndex = 3;
            this.Crs_Label.Text = "Choose The Course";

            // Form
            this.ClientSize = new Size(1040, 511);
            this.Controls.Add(this.Crs_Label);
            this.Controls.Add(this.comboBoxQuestionsData);
            this.Name = "QuestionBank";
            this.ResumeLayout(false);
            this.PerformLayout();
            comboBoxQuestionsData.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

        }

        private void LoadComboBoxData()
        {
            // Fetch data from the repository
            var courses = coursesRepo.GetCourses();

            // Format the display text (if needed)
            foreach (var course in courses)
            {
                course.Name = course.ID + " - " + course.Name;
            }

            // Bind the data to the ComboBox
            comboBoxQuestionsData.DataSource = courses;
            comboBoxQuestionsData.DisplayMember = "Name"; // The property to display
            comboBoxQuestionsData.ValueMember = "ID"; // The property to use as the value

            // Optional: Set the ComboBox to be non-editable
            comboBoxQuestionsData.DropDownStyle = ComboBoxStyle.DropDownList;

            // Set the first item as selected
            if (comboBoxQuestionsData.Items.Count > 0)
            {
                comboBoxQuestionsData.SelectedIndex = 0; // Select the first item
            }
        }

        internal void LoadData() // load viewing data 
        {
            var questionsList = questions.ALL_COURSE_QUESTION(null);

            // Bind the data to the DataGridView
            customGrid.DataSource = questionsList;

            // Optional: Configure the DataGridView columns
            customGrid.AutoGenerateColumns = true; // Automatically generate columns based on the data
            customGrid.Refresh(); // Refresh the DataGridView to display the data
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxQuestionsData.SelectedValue != null && int.TryParse(comboBoxQuestionsData.SelectedValue.ToString(), out int courseID))
            {
                // Call ALL_COURSE_QUESTION with selected course ID
                customGrid.DataSource = questions.ALL_COURSE_QUESTION(courseID);
            }
            else
            {
                // Load all data if no valid course is selected
                LoadData();
            }
        }


        private void HandleActionClick(DataGridView customGrid, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (e.ColumnIndex == customGrid.Columns["EditAction"].Index)
            {
                Console.WriteLine("Edit icon clicked!"); // Debugging
                EditRow(customGrid.Rows[e.RowIndex]);
            }
            else if (e.ColumnIndex == customGrid.Columns["ViewAction"].Index)
            {
                Console.WriteLine("View icon clicked!"); // Debugging
                ViewRow(customGrid.Rows[e.RowIndex]);

            }
            else if (e.ColumnIndex == customGrid.Columns["DeleteAction"].Index)
            {
                Console.WriteLine("Delete icon clicked!"); // Debugging
                DeleteRow(customGrid, e.RowIndex);

            }
        }

        private void DeleteRow(DataGridView customGrid, int rowIndex)
        {
            // Get the question ID from the selected row
            int id = Convert.ToInt32(customGrid.Rows[rowIndex].Cells["QuestionID"].Value);
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Delete the question using your repository
                    questions.DeleteQuestions(id);
                    BindingList<QuestionsDTO> question = new BindingList<QuestionsDTO>(questions.ALL_COURSE_QUESTION(null));
                    customGrid.DataSource = question;
                }
            }
            catch
            {
                MessageBox.Show("Sorry, you can't delete this row because it has dependent relationships.", "Failed");
            }

        }


        private void ViewRow(DataGridViewRow dataGridViewRow)
        {
            QuestionsDTO question = new QuestionsDTO
            {
                QuestionID = Convert.ToInt32(dataGridViewRow.Cells["QuestionID"].Value),
                Question = dataGridViewRow.Cells["Question"].Value.ToString(),
                Answer = dataGridViewRow.Cells["Answer"].Value.ToString(),
                Type = dataGridViewRow.Cells["Type"].Value.ToString(),
                Points = Convert.ToInt32(dataGridViewRow.Cells["Points"].Value),
                CourseID = Convert.ToInt32(dataGridViewRow.Cells["CourseID"].Value)
            };
            var Form = new QuestionForm((int)FormMode.View, question, customGrid);
            Form.Show();
        }

        private void EditRow(DataGridViewRow dataGridViewRow)
        {
            QuestionsDTO questions = new QuestionsDTO
            {
                QuestionID = Convert.ToInt32(dataGridViewRow.Cells["QuestionID"].Value),
                Question = dataGridViewRow.Cells["Question"].Value.ToString(),
                Answer = dataGridViewRow.Cells["Answer"].Value.ToString(),
                Type = dataGridViewRow.Cells["Type"].Value.ToString(),
                Points = Convert.ToInt32(dataGridViewRow.Cells["Points"].Value),
                CourseID = Convert.ToInt32(dataGridViewRow.Cells["CourseID"].Value)
            };
            var Form = new QuestionForm((int)FormMode.Edit, questions, customGrid);
            Form.Show();
        }
   
    }
}