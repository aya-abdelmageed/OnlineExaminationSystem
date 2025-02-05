using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic.Repositories;
using BusinessLogic.DTO;
using BusinessLogi.Repositories;
using Front.InstructorDashboard;

namespace Front.popUpForms
{
    public partial class AssignToTrack : Form
    {
        private readonly ExamTrackRepo _examTrackRepo;
        private readonly TrackRepo _trackRepo;
        private ComboBox cmbTracks;
        private Button btnAssign;
        private int ExamId;
        public AssignToTrack(int examId)
        {
            InitializeComponent2();
            this.Show();
            _examTrackRepo = new ExamTrackRepo();
            _trackRepo = new TrackRepo();
            LoadTracks();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(450, 300);
            this.ExamId = examId;   
        }

        private void InitializeComponent2()
        {
            this.Text = "Assign Exam to Track";

            Label trackLabel = new Label { Text = "Select Track:", Location = new System.Drawing.Point(50, 60), Size = new System.Drawing.Size(100, 20) };
            cmbTracks = new ComboBox { Location = new System.Drawing.Point(150, 60), Size = new System.Drawing.Size(200, 20), DropDownStyle = ComboBoxStyle.DropDownList };


            btnAssign = new Button { Text = "Assign", Location = new System.Drawing.Point(150, 160), Size = new System.Drawing.Size(100, 30) };
            btnAssign.Click += BtnAssign_Click;

            this.Controls.Add(trackLabel);
            this.Controls.Add(cmbTracks);
            this.Controls.Add(btnAssign);
        }

        private class ComboBoxItem
        {
            // Property to hold the display text (e.g., track name)
            public string DisplayText { get; }

            // Property to hold the underlying value (e.g., track ID)
            public int Value { get; }

            // Constructor to set both properties
            public ComboBoxItem(string displayText, int value)
            {
                DisplayText = displayText;
                Value = value;
            }

            // Override ToString so the ComboBox shows the DisplayText
            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void LoadTracks()
        {
            var tracks = _trackRepo.GetTracks(null);  // Adjust to your method of retrieving tracks
            var trackItems = tracks.Select(x => new { x.TrackID, x.Name }) // Assuming tracks have an ID and Name
                                   .ToArray();

            cmbTracks.Items.Clear();
            foreach (var track in trackItems)
            {
                cmbTracks.Items.Add(new ComboBoxItem(track.Name, track.TrackID));
            }
        }
        private void BtnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTracks.SelectedItem == null )
                {
                    MessageBox.Show("Please select both a Track and an Exam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedTrackItem = (ComboBoxItem)cmbTracks.SelectedItem;
                int selectedTrackID = selectedTrackItem.Value;  // Get the TrackID

                // Call the method to assign the exam to the selected track

                    _examTrackRepo.InsertExamTrack(ExamId, selectedTrackID);  // Assuming 1 is the instructor ID

            
                MessageBox.Show("Exam assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sorry, you cannot assign a track to an exam more than once.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
