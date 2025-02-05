using Front.InstructorDashboard;
using Front.popUpForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    partial class CustomCard : UserControl
    {
        private PictureBox iconPictureBox, dateIcon, timeIcon, mcqIcon, tfIcon;
        private Label titleLabel, descriptionLabel, dateLabel, timeLabel, mcqLabel, tfLabel;
        private Button trackButton, viewDetailsButton;

        public CustomCard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.iconPictureBox = new PictureBox();
            this.dateIcon = new PictureBox();
            this.timeIcon = new PictureBox();
            this.mcqIcon = new PictureBox();
            this.tfIcon = new PictureBox();

            this.titleLabel = new Label();
            this.descriptionLabel = new Label();
            this.dateLabel = new Label();
            this.timeLabel = new Label();
            this.mcqLabel = new Label();
            this.tfLabel = new Label();

            this.trackButton = new Button();
            this.viewDetailsButton = new Button();

            // Load icons (Ensure the paths are correct)
            Image editIcon = Image.FromFile(@"..\..\Resources\calendar.png");
            Image calendarIcon = Image.FromFile(@"..\..\Resources\icons8-date-24.png");
            Image timerIcon = Image.FromFile(@"..\..\Resources\icons8-time-50 (1).png");
            Image mcqIconImg = Image.FromFile(@"..\..\Resources\icons8-book-48.png");
            Image tfIconImg = Image.FromFile(@"..\..\Resources\icons8-file-24.png");

            // Main icon
            this.iconPictureBox.Image = editIcon;
            this.iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.iconPictureBox.Location = new Point(10, 10);
            this.iconPictureBox.Size = new Size(40, 40);

            // Title
            this.titleLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.titleLabel.Location = new Point(55, 10);
            this.titleLabel.Size = new Size(250, 20);
            this.titleLabel.Text = "Course Title";

            // Description
            this.descriptionLabel.Font = new Font("Segoe UI", 8);
            this.descriptionLabel.Location = new Point(55, 30);
            this.descriptionLabel.Size = new Size(250, 30);
            this.descriptionLabel.Text = "Exam description goes here.";

            // Date Icon & Label
            this.dateIcon.Image = calendarIcon;
            this.dateIcon.SizeMode = PictureBoxSizeMode.Zoom;
            this.dateIcon.Location = new Point(10, 65);
            this.dateIcon.Size = new Size(14, 14);

            this.dateLabel.Font = new Font("Segoe UI", 8);
            this.dateLabel.Location = new Point(28, 64);
            this.dateLabel.Size = new Size(120, 15);
            this.dateLabel.Text = "02/02/2025";

            // Time Icon & Label
            this.timeIcon.Image = timerIcon;
            this.timeIcon.SizeMode = PictureBoxSizeMode.Zoom;
            this.timeIcon.Location = new Point(10, 85);
            this.timeIcon.Size = new Size(14, 14);

            this.timeLabel.Font = new Font("Segoe UI", 8);
            this.timeLabel.Location = new Point(28, 84);
            this.timeLabel.Size = new Size(150, 15);
            this.timeLabel.Text = "9:00 AM - 12:00 PM";

            // MCQ Icon & Label (Moved Down Slightly for Visibility)
            this.mcqIcon.Image = mcqIconImg;
            this.mcqIcon.SizeMode = PictureBoxSizeMode.Zoom;
            this.mcqIcon.Location = new Point(10, 105);  // Adjusted Y Position
            this.mcqIcon.Size = new Size(14, 14);

            this.mcqLabel.Font = new Font("Segoe UI", 8);
            this.mcqLabel.Location = new Point(28, 104);  // Adjusted Y Position
            this.mcqLabel.Size = new Size(80, 15);
            this.mcqLabel.Text = "MCQs: 20";

            // T/F Icon & Label (Moved Down Slightly)
            this.tfIcon.Image = tfIconImg;
            this.tfIcon.SizeMode = PictureBoxSizeMode.Zoom;
            this.tfIcon.Location = new Point(110, 105);  // Adjusted X & Y Position
            this.tfIcon.Size = new Size(14, 14);

            this.tfLabel.Font = new Font("Segoe UI", 8);
            this.tfLabel.Location = new Point(128, 104);  // Adjusted Y Position
            this.tfLabel.Size = new Size(80, 15);
            this.tfLabel.Text = "T/F: 10";

            // Buttons
            this.trackButton.Font = new Font("Segoe UI", 8);
            this.trackButton.Text = "Assign";
            this.trackButton.Size = new Size(70, 25);
            this.trackButton.BackColor = System.Drawing.Color.White;    
            this.trackButton.Location = new Point(10, 130);
            this.trackButton.Click += TrackButton_Click;

            this.viewDetailsButton.Font = new Font("Segoe UI", 8);
            this.viewDetailsButton.Text = "Details";
            this.viewDetailsButton.Size = new Size(70, 25);
            this.viewDetailsButton.Location = new Point(90, 130);
            this.viewDetailsButton.BackColor= Color.FromArgb(204, 8, 8);
            this.viewDetailsButton.Click += ViewDetailsButton_Click;
            this.viewDetailsButton.Name = "Details";
            this.trackButton.Name = "Assign";


            // Add controls
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.dateIcon);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.timeIcon);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.mcqIcon);
            this.Controls.Add(this.mcqLabel);
            this.Controls.Add(this.tfIcon);
            this.Controls.Add(this.tfLabel);
            this.Controls.Add(this.trackButton);
            this.Controls.Add(this.viewDetailsButton);

            // Set control size and styles
            this.Size = new Size(250, 170);  // Increased Height for Spacing
            this.BackColor =  Color.LightGray;
           
            this.BorderStyle = BorderStyle.None;

            // Rounded Corners
            this.Region = new Region(new Rectangle(0, 0, this.Width, this.Height));           
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = 10;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        public void SetCardData(string title, string description, DateTime examDate, string startTime, string endTime, int noTF, int noMCQ, int maxMarks)
        {
            this.titleLabel.Text = title;
            this.descriptionLabel.Text = description;
            this.dateLabel.Text = examDate.ToString("MM/dd/yyyy");
            this.timeLabel.Text = $"{startTime} - {endTime}";
            this.mcqLabel.Text = $"MCQs: {noMCQ}";
            this.tfLabel.Text = $"T/F: {noTF}";
        }
        public void ShowForm(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
        }

        private void TrackButton_Click(object sender, EventArgs e)
        {
            ShowForm(new AssignToTrack());
        }

        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {


            ShowForm(new ExamView());
        }
    }
}
