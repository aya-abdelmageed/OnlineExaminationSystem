using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using Nest;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using UI.AdminDashboard;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static UI.AdminDashboard.Form1;

namespace Front.popUpForms
{
    public partial class TrackForm : Form
    {
        // Properties to expose the input data
        public int? TrackId { get; private set; }
        public string TrackName { get; private set; }
        public string Department { get; private set; }
        private TrackRepo trackRepo;
        private TextBox trackIdTextBox;
        private TextBox trackNameTextBox;
        private TextBox departmentTextBox;
        private Button submitButton;
        DataGridView data;
        FormMode mode;
        public TrackForm(int _mode,TrackDTO track = null,DataGridView data = null)
        {
            InitializeComponent2();
            this.mode = (FormMode)_mode;
            trackRepo = new TrackRepo();
            this.data = data;
            this.trackIdTextBox.Visible = false;
            // Set the TrackId if provided (for edit mode)
            if (track != null)
               TrackId = track.TrackID;

            // Pre-fill the form with the passed values if it's in edit mode
            switch (mode)
            {
                case FormMode.Edit:
                    trackIdTextBox.Text = TrackId.ToString();
                    trackNameTextBox.Text = track.Name;
                    departmentTextBox.Text = track.Department;
                    submitButton.Text = "Save Changes";
                    break;
                case FormMode.Add:
                    submitButton.Text = "Add Track";
                    break;
                default:
                    trackIdTextBox.ReadOnly = true;
                    trackNameTextBox.ReadOnly = true;
                    departmentTextBox.ReadOnly = true;
                    trackIdTextBox.Text = TrackId.ToString();
                    trackNameTextBox.Text = track.Name;
                    departmentTextBox.Text = track.Department;
                    submitButton.Text = "Close";
                    break;
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
            trackIdLabel.Visible = false;
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
            if (mode == FormMode.Edit)
            {
                // Code to update the track in the database
                trackRepo.UpdateTrack(new TrackDTO
                {
                    TrackID = TrackId.Value,
                    Name = TrackName,
                    Department = Department
                });
                BindingList<TrackDTO> tracks = new BindingList<TrackDTO>(trackRepo.GetTracks(null));
                data.DataSource = tracks;
                MessageBox.Show($"Track {TrackId.Value} updated: {TrackName}, Department: {Department}");
            }
            else if (mode == FormMode.Add)
            {
                trackRepo.InsertTrack(new TrackDTO
                {
                    Name = TrackName,
                    Department = Department
                });
                BindingList<TrackDTO> tracks = new BindingList<TrackDTO>(trackRepo.GetTracks(null));
                data.DataSource = tracks;
                MessageBox.Show($"New track added: {TrackName}, Department: {Department}");
            }
            // Close the form after saving
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}