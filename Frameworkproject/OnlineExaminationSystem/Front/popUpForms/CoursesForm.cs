using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static UI.AdminDashboard.Form1;

namespace UI.AdminDashboard
{
    public partial class CoursesForm : Form
    {
        // Properties to expose the input data
        public string CourseName { get; private set; }
        public int? CourseId { get; private set; }
        public int mode;
        private CourseRepo courseRepo;
        private TextBox courseIdTextBox;
        private TextBox courseNameTextBox;
        private Button submitButton;
        private DataGridView customGrid;
        public CoursesForm(int mode,CourseDTO course = null,DataGridView data = null)
        {
            InitializeComponent2();
            this.mode = mode;
            courseRepo = new CourseRepo();
            customGrid = data;
            // Set the CourseId if provided (for edit mode)
            if(course != null)
            {
                CourseId = course.ID;
            }
            courseIdTextBox.Visible = false;
            // Pre-fill the form with the passed values if it's in edit mode
            switch(mode)
            {
                case (int)FormMode.Edit:
                    courseIdTextBox.Text = CourseId.ToString();
                    courseNameTextBox.Text = course.Name;
                    submitButton.Text = "Save Changes";
                    break;
                case (int)FormMode.Add:
                    submitButton.Text = "Add Course";
                    break;
                case (int)FormMode.View:
                    courseIdTextBox.Text = CourseId.ToString();
                    courseNameTextBox.Text = course.Name;
                    courseIdTextBox.ReadOnly = true;
                    courseNameTextBox.ReadOnly = true;
                    submitButton.Text = "Close";
                    break;
            }
            this.BackColor = Color.FromArgb(247, 248, 253);
            this.submitButton.BackColor = Color.FromArgb(204, 8, 8);
            this.submitButton.ForeColor = Color.White;


        }

        private void InitializeComponent2()
        {
            this.Text = "Course Form";
            this.Size = new System.Drawing.Size(400, 200);

            // Create Labels
            Label courseIdLabel = new Label
            {
                Text = "Course ID:",
                Location = new System.Drawing.Point(50, 20),
                Size = new System.Drawing.Size(100, 20)
            };
            courseIdLabel.Visible = false;
            Label courseNameLabel = new Label
            {
                Text = "Course Name:",
                Location = new System.Drawing.Point(50, 60),
                Size = new System.Drawing.Size(100, 20)
            };

            // Create TextBoxes
            courseIdTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20),
                ReadOnly = true // Make ID read-only for edit mode
            };

            courseNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            // Create Submit Button
            submitButton = new Button
            {
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(100, 30)
            };
            submitButton.Click += SubmitButton_Click;

            // Add controls to the form
            this.Controls.Add(courseIdLabel);
            this.Controls.Add(courseNameLabel);
            this.Controls.Add(courseIdTextBox);
            this.Controls.Add(courseNameTextBox);
            this.Controls.Add(submitButton);
        }

        // Event handler for the submit button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get values from the textboxes
            CourseName = courseNameTextBox.Text;

            // Handle validation (simple check here, you can improve it)
            if (string.IsNullOrEmpty(CourseName))
            {
                MessageBox.Show("Please fill in the course name.");
                return;
            }

            // If the ID exists, this is an edit, otherwise it is an insert
            if (mode == (int)FormMode.Edit)
            {
                // Code to update the course in the database or collection
                courseRepo.updateCourses(new CourseDTO { ID = CourseId.Value, Name = CourseName });
                BindingList<CourseDTO> courses = new BindingList<CourseDTO>(courseRepo.GetCourses(null));
                customGrid.DataSource = courses;
                MessageBox.Show($"Course {CourseId.Value} updated: {CourseName}");
            }
            else if (mode == (int)FormMode.Add)
            {
                // Code to add a new course (insert logic)
                courseRepo.InsertCourses(new CourseDTO { Name = CourseName });
                BindingList<CourseDTO> courses = new BindingList<CourseDTO>(courseRepo.GetCourses(null));
                customGrid.DataSource = courses;
                MessageBox.Show($"New course added: {CourseName}");
            }

            // Close the form after saving
            this.DialogResult = DialogResult.OK;
            //Courses courses = new Courses();
            //courses.Show();
            this.Hide();  // Hide Form1 instead of closing it
        }
    }
}