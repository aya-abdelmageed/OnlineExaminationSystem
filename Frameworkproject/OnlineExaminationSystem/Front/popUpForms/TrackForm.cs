using System;
using System.Windows.Forms;
using UI.AdminDashboard;

namespace Front.popUpForms
{
    public partial class TrackForm : Form
    {
        // Properties to expose the input data
        public int? TrackId { get; private set; }
        public string TrackName { get; private set; }
        public string Department { get; private set; }

        private TextBox trackIdTextBox;
        private TextBox trackNameTextBox;
        private TextBox departmentTextBox;
        private Button submitButton;

        public TrackForm(int? trackId = null, string trackName = "", string department = "")
        {
            InitializeComponent2();

            // Set the TrackId if provided (for edit mode)
            TrackId = trackId;

            // Pre-fill the form with the passed values if it's in edit mode
            if (TrackId.HasValue)
            {
                trackIdTextBox.Text = TrackId.ToString();
                trackNameTextBox.Text = trackName;
                departmentTextBox.Text = department;
                submitButton.Text = "Save Changes";
            }
            else
            {
                submitButton.Text = "Add Track";
            }
        }

        private void InitializeComponent2()
        {
            this.Text = "Track Form";
            this.Size = new System.Drawing.Size(400, 200);

            // Create Labels
            Label trackIdLabel = new Label
            {
                Text = "Track ID:",
                Location = new System.Drawing.Point(50, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            Label trackNameLabel = new Label
            {
                Text = "Track Name:",
                Location = new System.Drawing.Point(50, 60),
                Size = new System.Drawing.Size(100, 20)
            };

            Label departmentLabel = new Label
            {
                Text = "Department:",
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(100, 20)
            };

            // Create TextBoxes
            trackIdTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20),
                ReadOnly = true // Make ID read-only for edit mode
            };

            trackNameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            departmentTextBox = new TextBox
            {
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            // Create Submit Button
            submitButton = new Button
            {
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(100, 30)
            };
            submitButton.Click += SubmitButton_Click;

            // Add controls to the form
            this.Controls.Add(trackIdLabel);
            this.Controls.Add(trackNameLabel);
            this.Controls.Add(departmentLabel);
            this.Controls.Add(trackIdTextBox);
            this.Controls.Add(trackNameTextBox);
            this.Controls.Add(departmentTextBox);
            this.Controls.Add(submitButton);
        }

        // Event handler for the submit button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get values from the textboxes
            TrackName = trackNameTextBox.Text;
            Department = departmentTextBox.Text;

            // Handle validation
            if (string.IsNullOrEmpty(TrackName) || string.IsNullOrEmpty(Department))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // If the ID exists, this is an edit, otherwise it is an insert
            if (TrackId.HasValue)
            {
                // Code to update the track in the database
                MessageBox.Show($"Track {TrackId.Value} updated: {TrackName}, Department: {Department}");
            }
            else
            {
                // Code to add a new track (insert logic)
                MessageBox.Show($"New track added: {TrackName}, Department: {Department}");
            }

            // Close the form after saving
            this.DialogResult = DialogResult.OK;

            //Tracks tracks = new Tracks();   
            //this.Hide();
        }
    }
}