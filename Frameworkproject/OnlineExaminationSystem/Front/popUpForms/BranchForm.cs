using System;
using System.Windows.Forms;

namespace UI.AdminDashboard
{
    public partial class BranchForm : Form
    {
        // Properties to expose the input data
        public string BranchName { get; private set; }
        public int? BranchId { get; private set; }
        public string Phone { get; private set; }
        public string Location { get; private set; }

        private TextBox branchIdTextBox;
        private TextBox branchNameTextBox;
        private TextBox phoneTextBox;
        private TextBox locationTextBox;
        private Button submitButton;

        public BranchForm(int? branchId = null, string branchName = "", string phone = "", string location = "")
        {
            InitializeComponent2();

            // Set the BranchId if provided (for edit mode)
            BranchId = branchId;

            // Pre-fill the form with the passed values if it's in edit mode
            if (BranchId.HasValue)
            {
                branchIdTextBox.Text = BranchId.ToString();
                branchNameTextBox.Text = branchName;
                phoneTextBox.Text = phone;
                locationTextBox.Text = location;
                submitButton.Text = "Save Changes";
            }
            else
            {
                submitButton.Text = "Add Branch";
            }
        }

        private void InitializeComponent2()
        {
            this.Text = "Branch Form";
            this.Size = new System.Drawing.Size(400, 250);

            // Create Labels
            Label branchIdLabel = new Label
            {
                Text = "Branch ID:",
                Location = new System.Drawing.Point(50, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            Label branchNameLabel = new Label
            {
                Text = "Branch Name:",
                Location = new System.Drawing.Point(50, 60),
                Size = new System.Drawing.Size(100, 20)
            };

            Label phoneLabel = new Label
            {
                Text = "Phone:",
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(100, 20)
            };

            Label locationLabel = new Label
            {
                Text = "Location:",
                Location = new System.Drawing.Point(50, 140),
                Size = new System.Drawing.Size(100, 20)
            };

            // Create TextBoxes
            branchIdTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20),
                ReadOnly = true // Make ID read-only for edit mode
            };

            branchNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            phoneTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            locationTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(200, 20)
            };

            // Create Submit Button
            submitButton = new Button
            {
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(100, 30)
            };
            submitButton.Click += SubmitButton_Click;

            // Add controls to the form
            this.Controls.Add(branchIdLabel);
            this.Controls.Add(branchNameLabel);
            this.Controls.Add(phoneLabel);
            this.Controls.Add(locationLabel);
            this.Controls.Add(branchIdTextBox);
            this.Controls.Add(branchNameTextBox);
            this.Controls.Add(phoneTextBox);
            this.Controls.Add(locationTextBox);
            this.Controls.Add(submitButton);
        }

        // Event handler for the submit button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get values from the textboxes
            BranchName = branchNameTextBox.Text;
            Phone = phoneTextBox.Text;
            Location = locationTextBox.Text;

            // Handle validation (simple check here, you can improve it)
            if (string.IsNullOrEmpty(BranchName) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Location))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // If the ID exists, this is an edit, otherwise it is an insert
            if (BranchId.HasValue)
            {
                // Code to update the branch in the database or collection
                MessageBox.Show($"Branch {BranchId.Value} updated: {BranchName}, Phone: {Phone}, Location: {Location}");
            }
            else
            {
                // Code to add a new branch (insert logic)
                MessageBox.Show($"New branch added: {BranchName}, Phone: {Phone}, Location: {Location}");
            }

            // Close the form after saving
            this.DialogResult = DialogResult.OK;
            //Branches branch = new Branches();
              //  branch.Show();
            this.Hide();  // Hide Form1 instead of closing it
        }
    }
}