using System;
using System.Windows.Forms;

namespace UI.AdminDashboard
{
    public partial class CoursesForm : Form
    {
        // Properties to expose the input data
        public string CourseName { get; private set; }
        public int? CourseId { get; private set; }

        private TextBox courseIdTextBox;
        private TextBox courseNameTextBox;
        private Button submitButton;

        public CoursesForm(int? courseId = null, string courseName = "")
        {
            InitializeComponent2();

            // Set the CourseId if provided (for edit mode)
            CourseId = courseId;

            // Pre-fill the form with the passed values if it's in edit mode
            if (CourseId.HasValue)
            {
                courseIdTextBox.Text = CourseId.ToString();
                courseNameTextBox.Text = courseName;
                submitButton.Text = "Save Changes";
            }
            else
            {
                submitButton.Text = "Add Course";
            }
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
            if (CourseId.HasValue)
            {
                // Code to update the course in the database or collection
                MessageBox.Show($"Course {CourseId.Value} updated: {CourseName}");
            }
            else
            {
                // Code to add a new course (insert logic)
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