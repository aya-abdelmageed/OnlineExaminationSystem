using System;
using System.Windows.Forms;
using UI.AdminDashboard;

namespace Front.popUpForms
{
    public partial class StudentesForm : Form
    {
        // Properties to expose the input data
        public int? StudentId { get; private set; }
        public string Gender { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public DateTime Birthdate { get; private set; }
        public int TrackId { get; private set; }

        private TextBox studentIdTextBox;
        private ComboBox genderComboBox;
        private TextBox firstNameTextBox;
        private TextBox middleNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox phoneTextBox;
        private DateTimePicker birthdatePicker;
        private TextBox trackIdTextBox;
        private Button submitButton;

        public StudentesForm(int? studentId = null, string gender = "", string fName = "", string mName = "", string lName = "", string phone = "", DateTime? birthdate = null, int trackId = 0)
        {
            InitializeComponent2();

            // Set the StudentId if provided (for edit mode)
            StudentId = studentId;

            // Pre-fill the form with the passed values if it's in edit mode
            if (StudentId.HasValue)
            {
                studentIdTextBox.Text = StudentId.ToString();
                genderComboBox.SelectedItem = gender;
                firstNameTextBox.Text = fName;
                middleNameTextBox.Text = mName;
                lastNameTextBox.Text = lName;
                phoneTextBox.Text = phone;
                birthdatePicker.Value = birthdate ?? DateTime.Now;
                trackIdTextBox.Text = trackId.ToString();
                submitButton.Text = "Save Changes";
            }
            else
            {
                submitButton.Text = "Add Student";
            }
        }

        private void InitializeComponent2()
        {
            this.Text = "Student Form";
            this.Size = new System.Drawing.Size(450, 350);

            // Create Labels
            Label studentIdLabel = new Label
            {
                Text = "Student ID:",
                Location = new System.Drawing.Point(50, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            Label genderLabel = new Label
            {
                Text = "Gender:",
                Location = new System.Drawing.Point(50, 60),
                Size = new System.Drawing.Size(100, 20)
            };

            Label firstNameLabel = new Label
            {
                Text = "First Name:",
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(100, 20)
            };

            Label middleNameLabel = new Label
            {
                Text = "Middle Name:",
                Location = new System.Drawing.Point(50, 140),
                Size = new System.Drawing.Size(100, 20)
            };

            Label lastNameLabel = new Label
            {
                Text = "Last Name:",
                Location = new System.Drawing.Point(50, 180),
                Size = new System.Drawing.Size(100, 20)
            };

            Label phoneLabel = new Label
            {
                Text = "Phone:",
                Location = new System.Drawing.Point(50, 220),
                Size = new System.Drawing.Size(100, 20)
            };

            Label birthdateLabel = new Label
            {
                Text = "Birthdate:",
                Location = new System.Drawing.Point(50, 260),
                Size = new System.Drawing.Size(100, 20)
            };

            Label trackIdLabel = new Label
            {
                Text = "Track ID:",
                Location = new System.Drawing.Point(50, 300),
                Size = new System.Drawing.Size(100, 20)
            };

            // Create TextBoxes and Controls
            studentIdTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20),
                ReadOnly = true // Make ID read-only for edit mode
            };

            genderComboBox = new ComboBox
            {
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            genderComboBox.Items.AddRange(new string[] { "Male", "Female", "Other" });

            firstNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            middleNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(200, 20)
            };

            lastNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(200, 20)
            };

            phoneTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 220),
                Size = new System.Drawing.Size(200, 20)
            };

            birthdatePicker = new DateTimePicker
            {
                Location = new System.Drawing.Point(150, 260),
                Size = new System.Drawing.Size(200, 20),
                Format = DateTimePickerFormat.Short
            };

            trackIdTextBox = new TextBox
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
            this.Controls.Add(studentIdLabel);
            this.Controls.Add(genderLabel);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(middleNameLabel);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(phoneLabel);
            this.Controls.Add(birthdateLabel);
            this.Controls.Add(trackIdLabel);
            this.Controls.Add(studentIdTextBox);
            this.Controls.Add(genderComboBox);
            this.Controls.Add(firstNameTextBox);
            this.Controls.Add(middleNameTextBox);
            this.Controls.Add(lastNameTextBox);
            this.Controls.Add(phoneTextBox);
            this.Controls.Add(birthdatePicker);
            this.Controls.Add(trackIdTextBox);
            this.Controls.Add(submitButton);
        }

        // Event handler for the submit button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get values from the controls
            FirstName = firstNameTextBox.Text;
            MiddleName = middleNameTextBox.Text;
            LastName = lastNameTextBox.Text;
            Phone = phoneTextBox.Text;
            Gender = genderComboBox.SelectedItem?.ToString();
            Birthdate = birthdatePicker.Value;
            int.TryParse(trackIdTextBox.Text, out int trackId);
            TrackId = trackId;

            // Handle validation
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Gender) || TrackId <= 0)
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return;
            }

            // If the ID exists, this is an edit, otherwise it is an insert
            if (StudentId.HasValue)
            {
                // Code to update the student in the database
                MessageBox.Show($"Student {StudentId.Value} updated: {FirstName} {LastName}");
            }
            else
            {
                // Code to add a new student (insert logic)
                MessageBox.Show($"New student added: {FirstName} {LastName}");
            }

            // Close the form after saving
            this.DialogResult = DialogResult.OK;
            //Students students = new Students(); 
            //students.Show();    
            this.Hide();    
        }
    }
}