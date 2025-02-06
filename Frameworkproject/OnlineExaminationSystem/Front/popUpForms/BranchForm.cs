using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static UI.AdminDashboard.Form1;

namespace UI.AdminDashboard
{
    public partial class BranchForm : Form
    {
        BranchRepo branchRepo = new BranchRepo();
        // Properties to expose the input data
        public string BranchName { get; private set; }
        public int? BranchId { get; private set; }
        public string Phone { get; private set; }
        public string Location { get; private set; }
        public int mode;
        private TextBox branchIdTextBox;
        private TextBox branchNameTextBox;
        private TextBox phoneTextBox;
        private TextBox locationTextBox;
        private Button submitButton;
        private DataGridView customGrid;

        public BranchForm(int mode, BranchDTO branch = null,DataGridView gridView = null)
        {
            InitializeComponent2();
            customGrid = gridView;
            this.mode = mode;
            branchIdTextBox.Visible = false;
            // Set the BranchId if provided (for edit mode)
            if (branch != null)
            {
                BranchId = branch.BranchID;
            }

            // Pre-fill the form with the passed values if it's in edit mode
            if (mode == (int)FormMode.Edit)
            {
                branchIdTextBox.Text = BranchId.ToString();
                branchNameTextBox.Text = branch.Name;
                phoneTextBox.Text = branch.Phone;
                locationTextBox.Text = branch.Location;
                submitButton.Text = "Save Changes";
            }
            else if(mode == (int)FormMode.Add)
            {
                submitButton.Text = "Add Branch";
            }
            else
            {
                branchIdTextBox.Text = BranchId.ToString();
                branchNameTextBox.Text = branch.Name;
                phoneTextBox.Text = branch.Phone;
                locationTextBox.Text = branch.Location;
                branchIdTextBox.ReadOnly = true;
                branchNameTextBox.ReadOnly = true;
                phoneTextBox.ReadOnly = true;
                locationTextBox.ReadOnly = true;
                submitButton.Text = "Close";
            }
            this.BackColor = Color.White;
            this.submitButton.BackColor = Color.FromArgb(204, 8, 8);
            this.submitButton.ForeColor = Color.White;
            this.Height = 300;


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
            branchIdLabel.Visible = false;
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
            if (mode == (int)FormMode.Edit)
            {
                // Code to update the branch in the database or collection
                branchRepo.UpdateBranch(new BranchDTO
                {
                    BranchID = BranchId.Value,
                    Name = BranchName,
                    Phone = Phone,
                    Location = Location
                });
                BindingList<BranchDTO> branches = new BindingList<BranchDTO>(branchRepo.GetBranches(null));
                customGrid.DataSource = branches;
                MessageBox.Show($"Branch {BranchId.Value} updated: {BranchName}, Phone: {Phone}, Location: {Location}");
            }
            else if(mode == (int)FormMode.Add)
            {
                branchRepo.InsertBranch(new BranchDTO
                {
                    Name = BranchName,
                    Phone = Phone,
                    Location = Location
                });
                BindingList<BranchDTO> branches = new BindingList<BranchDTO>(branchRepo.GetBranches(null));
                customGrid.DataSource = branches;
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