using System;
using System.Windows.Forms;

namespace UI.AdminDashboard
{

    public partial class BranchForm : Form
    {
        // Properties to expose the input data
        public string BranchName { get; private set; }
        public string BranchLocation { get; private set; }
        public int? BranchId { get; private set; }

        private TextBox branchNameTextBox;
        private TextBox branchLocationTextBox;
        private Button submitButton;


        public BranchForm(int? branchId = null, string branchName = "")
        {
            InitializeComponent2();

            // Set the BranchId if provided (for edit mode)
            BranchId = branchId;

            // Pre-fill the form with the passed values if it's in edit mode
            if (BranchId.HasValue)
            {
                branchNameTextBox.Text = branchName;
                submitButton.Text = "Save Changes";
            }
            else
            {
                submitButton.Text = "Add Branch";
            }
            InitializeComponent();

        }
        public void ShowForm(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;



            form.FormClosed += (sender, e) => this.Close(); // Close Form1 when the new form is closed
            form.Show();
            this.Hide();  // Hide Form1 instead of closing it
        }
        private void InitializeComponent2()
        {
            this.Text = "Branch Form";
            this.Size = new System.Drawing.Size(400, 300);

            // Create Labels
            Label branchNameLabel = new Label
            {
                Text = "Branch Name:",
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(100, 20)
            };

            Label branchLocationLabel = new Label
            {
                Text = "Branch Location:",
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(100, 20)
            };

            // Create TextBoxes
            branchNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 50),
                Size = new System.Drawing.Size(200, 20)
            };

            branchLocationTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            // Create Submit Button
            submitButton = new Button
            {
                Location = new System.Drawing.Point(150, 150),
                Size = new System.Drawing.Size(100, 30)
            };
            submitButton.Click += SubmitButton_Click;

            // Add controls to the form
            this.Controls.Add(branchNameLabel);
            this.Controls.Add(branchLocationLabel);
            this.Controls.Add(branchNameTextBox);
            this.Controls.Add(branchLocationTextBox);
            this.Controls.Add(submitButton);
        }

        // Event handler for the submit button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get values from the textboxes
            BranchName = branchNameTextBox.Text;
            BranchLocation = branchLocationTextBox.Text;

            // Handle validation (simple check here, you can improve it)
            if (string.IsNullOrEmpty(BranchName) || string.IsNullOrEmpty(BranchLocation))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // If the ID exists, this is an edit, otherwise it is an insert
            if (BranchId.HasValue)
            {
                // Code to update the branch in the database or collection
                MessageBox.Show($"Branch {BranchId.Value} updated: {BranchName}, {BranchLocation}");
            }
            else
            {
                // Code to add a new branch (insert logic)
                MessageBox.Show($"New branch added: {BranchName}, {BranchLocation}");
            }

            // Close the form after saving
            this.DialogResult = DialogResult.OK;

            ShowForm(new Branches());


        }
    }
}
