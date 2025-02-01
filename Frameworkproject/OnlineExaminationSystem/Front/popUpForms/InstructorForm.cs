using System;
using System.Windows.Forms;
using UI.AdminDashboard;

namespace Front.popUpForms
{
    public partial class InstructorForm : Form
    {
        // Properties to expose the input data
        public int? InstructorId { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Gender { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

        private TextBox instructorIdTextBox;
        private TextBox firstNameTextBox;
        private TextBox middleNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox emailTextBox;
        private ComboBox genderComboBox;
        private TextBox ageTextBox;
        private TextBox salaryTextBox;
        private Button submitButton;

        public InstructorForm(int? insId = null, string fName = "", string mName = "", string lName = "", string email = "", string gender = "", int age = 0, decimal salary = 0)
        {
            InitializeComponent2();

            // Set the InstructorId if provided (for edit mode)
            InstructorId = insId;

            // Pre-fill the form with the passed values if it's in edit mode
            if (InstructorId.HasValue)
            {
                instructorIdTextBox.Text = InstructorId.ToString();
                firstNameTextBox.Text = fName;
                middleNameTextBox.Text = mName;
                lastNameTextBox.Text = lName;
                emailTextBox.Text = email;
                genderComboBox.SelectedItem = gender;
                ageTextBox.Text = age.ToString();
                salaryTextBox.Text = salary.ToString();
                submitButton.Text = "Save Changes";
            }
            else
            {
                submitButton.Text = "Add Instructor";
            }
        }

        private void InitializeComponent2()
        {
            this.Text = "Instructor Form";
            this.Size = new System.Drawing.Size(450, 350);

            // Create Labels
            Label instructorIdLabel = new Label
            {
                Text = "Instructor ID:",
                Location = new System.Drawing.Point(50, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            Label firstNameLabel = new Label
            {
                Text = "First Name:",
                Location = new System.Drawing.Point(50, 60),
                Size = new System.Drawing.Size(100, 20)
            };

            Label middleNameLabel = new Label
            {
                Text = "Middle Name:",
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(100, 20)
            };

            Label lastNameLabel = new Label
            {
                Text = "Last Name:",
                Location = new System.Drawing.Point(50, 140),
                Size = new System.Drawing.Size(100, 20)
            };

            Label emailLabel = new Label
            {
                Text = "Email:",
                Location = new System.Drawing.Point(50, 180),
                Size = new System.Drawing.Size(100, 20)
            };

            Label genderLabel = new Label
            {
                Text = "Gender:",
                Location = new System.Drawing.Point(50, 220),
                Size = new System.Drawing.Size(100, 20)
            };

            Label ageLabel = new Label
            {
                Text = "Age:",
                Location = new System.Drawing.Point(50, 260),
                Size = new System.Drawing.Size(100, 20)
            };

            Label salaryLabel = new Label
            {
                Text = "Salary:",
                Location = new System.Drawing.Point(50, 300),
                Size = new System.Drawing.Size(100, 20)
            };

            // Create TextBoxes
            instructorIdTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20),
                ReadOnly = true // Make ID read-only for edit mode
            };

            firstNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            middleNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            lastNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(200, 20)
            };

            emailTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(200, 20)
            };

            genderComboBox = new ComboBox
            {
                Location = new System.Drawing.Point(150, 220),
                Size = new System.Drawing.Size(200, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            genderComboBox.Items.AddRange(new string[] { "Male", "Female", "Other" });

            ageTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 260),
                Size = new System.Drawing.Size(200, 20)
            };

            salaryTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 300),
                Size = new System.Drawing.Size(200, 20)
            };

            // Create Submit Button
            submitButton = new Button
            {
                Location = new System.Drawing.Point(150, 340),
                Size = new System.Drawing.Size(100, 30)
            };
            submitButton.Click += SubmitButton_Click;

            // Add controls to the form
            this.Controls.Add(instructorIdLabel);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(middleNameLabel);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(emailLabel);
            this.Controls.Add(genderLabel);
            this.Controls.Add(ageLabel);
            this.Controls.Add(salaryLabel);
            this.Controls.Add(instructorIdTextBox);
            this.Controls.Add(firstNameTextBox);
            this.Controls.Add(middleNameTextBox);
            this.Controls.Add(lastNameTextBox);
            this.Controls.Add(emailTextBox);
            this.Controls.Add(genderComboBox);
            this.Controls.Add(ageTextBox);
            this.Controls.Add(salaryTextBox);
            this.Controls.Add(submitButton);
        }

        // Event handler for the submit button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get values from the controls
            FirstName = firstNameTextBox.Text;
            MiddleName = middleNameTextBox.Text;
            LastName = lastNameTextBox.Text;
            Email = emailTextBox.Text;
            Gender = genderComboBox.SelectedItem?.ToString();
            int.TryParse(ageTextBox.Text, out int age);
            Age = age;
            decimal.TryParse(salaryTextBox.Text, out decimal salary);
            Salary = salary;

            // Handle validation
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Gender) || Age <= 0 || Salary <= 0)
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return;
            }

            // If the ID exists, this is an edit, otherwise it is an insert
            if (InstructorId.HasValue)
            {
                // Code to update the instructor in the database
                MessageBox.Show($"Instructor {InstructorId.Value} updated: {FirstName} {LastName}");
            }
            else
            {
                // Code to add a new instructor (insert logic)
                MessageBox.Show($"New instructor added: {FirstName} {LastName}");
            }

            // Close the form after saving
            this.DialogResult = DialogResult.OK;
            //Instructors instructors = new Instructors();
            //instructors.Show();
            this.Hide();
        }
    }
}