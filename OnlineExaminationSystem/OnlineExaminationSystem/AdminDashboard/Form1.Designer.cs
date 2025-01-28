namespace UI.AdminDashboard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            Instructors = new Button();
            Reports = new Button();
            pictureBox1 = new PictureBox();
            Students = new Button();
            Dashboard = new Button();
            Courses = new Button();
            Tracks = new Button();
            Branches = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            notifyIcon1 = new NotifyIcon(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(Instructors);
            panel1.Controls.Add(Reports);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(Students);
            panel1.Controls.Add(Dashboard);
            panel1.Controls.Add(Courses);
            panel1.Controls.Add(Tracks);
            panel1.Controls.Add(Branches);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(212, 657);
            panel1.TabIndex = 0;
            // 
            // Instructors
            // 
            Instructors.BackColor = Color.White;
            Instructors.BackgroundImageLayout = ImageLayout.Zoom;
            Instructors.FlatAppearance.BorderSize = 0;
            Instructors.FlatStyle = FlatStyle.Flat;
            Instructors.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Instructors.ForeColor = Color.Black;
            Instructors.Image = (Image)resources.GetObject("Instructors.Image");
            Instructors.ImageAlign = ContentAlignment.MiddleLeft;
            Instructors.Location = new Point(32, 433);
            Instructors.Margin = new Padding(3, 4, 3, 4);
            Instructors.Name = "Instructors";
            Instructors.Size = new Size(205, 59);
            Instructors.TabIndex = 6;
            Instructors.Text = "Instructors";
            Instructors.UseVisualStyleBackColor = false;
            Instructors.Click += Instructors_Click;
            // 
            // Reports
            // 
            Reports.BackColor = Color.White;
            Reports.BackgroundImageLayout = ImageLayout.Zoom;
            Reports.FlatAppearance.BorderSize = 0;
            Reports.FlatStyle = FlatStyle.Flat;
            Reports.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Reports.ForeColor = Color.Black;
            Reports.Image = (Image)resources.GetObject("Reports.Image");
            Reports.ImageAlign = ContentAlignment.MiddleLeft;
            Reports.Location = new Point(26, 567);
            Reports.Margin = new Padding(3, 4, 3, 4);
            Reports.Name = "Reports";
            Reports.Size = new Size(205, 59);
            Reports.TabIndex = 8;
            Reports.Text = "Reports";
            Reports.UseVisualStyleBackColor = false;
            Reports.Click += Reports_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-29, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Students
            // 
            Students.BackColor = Color.White;
            Students.BackgroundImageLayout = ImageLayout.Zoom;
            Students.FlatAppearance.BorderSize = 0;
            Students.FlatStyle = FlatStyle.Flat;
            Students.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Students.ForeColor = Color.Black;
            Students.Image = (Image)resources.GetObject("Students.Image");
            Students.ImageAlign = ContentAlignment.MiddleLeft;
            Students.Location = new Point(26, 500);
            Students.Margin = new Padding(3, 4, 3, 4);
            Students.Name = "Students";
            Students.Size = new Size(211, 59);
            Students.TabIndex = 7;
            Students.Text = "Students";
            Students.UseVisualStyleBackColor = false;
            Students.Click += Students_Click;
            // 
            // Dashboard
            // 
            Dashboard.BackColor = Color.White;
            Dashboard.BackgroundImageLayout = ImageLayout.Zoom;
            Dashboard.FlatAppearance.BorderSize = 0;
            Dashboard.FlatStyle = FlatStyle.Flat;
            Dashboard.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Dashboard.ForeColor = Color.Black;
            Dashboard.Image = (Image)resources.GetObject("Dashboard.Image");
            Dashboard.ImageAlign = ContentAlignment.MiddleLeft;
            Dashboard.Location = new Point(35, 168);
            Dashboard.Margin = new Padding(3, 4, 3, 4);
            Dashboard.Name = "Dashboard";
            Dashboard.Size = new Size(205, 59);
            Dashboard.TabIndex = 2;
            Dashboard.Text = "Dashboard";
            Dashboard.UseVisualStyleBackColor = false;
            Dashboard.Click += Dashboard_Click;
            // 
            // Courses
            // 
            Courses.BackColor = Color.White;
            Courses.BackgroundImageLayout = ImageLayout.Zoom;
            Courses.FlatAppearance.BorderSize = 0;
            Courses.FlatStyle = FlatStyle.Flat;
            Courses.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Courses.ForeColor = Color.Black;
            Courses.Image = (Image)resources.GetObject("Courses.Image");
            Courses.ImageAlign = ContentAlignment.MiddleLeft;
            Courses.Location = new Point(35, 367);
            Courses.Margin = new Padding(3, 4, 3, 4);
            Courses.Name = "Courses";
            Courses.Size = new Size(205, 59);
            Courses.TabIndex = 5;
            Courses.Text = "Courses";
            Courses.UseVisualStyleBackColor = false;
            Courses.Click += Courses_Click;
            // 
            // Tracks
            // 
            Tracks.BackColor = Color.White;
            Tracks.BackgroundImageLayout = ImageLayout.Zoom;
            Tracks.FlatAppearance.BorderSize = 0;
            Tracks.FlatStyle = FlatStyle.Flat;
            Tracks.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Tracks.ForeColor = Color.Black;
            Tracks.Image = (Image)resources.GetObject("Tracks.Image");
            Tracks.ImageAlign = ContentAlignment.MiddleLeft;
            Tracks.Location = new Point(32, 301);
            Tracks.Margin = new Padding(3, 4, 3, 4);
            Tracks.Name = "Tracks";
            Tracks.Size = new Size(205, 59);
            Tracks.TabIndex = 4;
            Tracks.Text = "Tracks";
            Tracks.UseVisualStyleBackColor = false;
            Tracks.Click += Tracks_Click;
            // 
            // Branches
            // 
            Branches.BackColor = Color.Transparent;
            Branches.BackgroundImageLayout = ImageLayout.Zoom;
            Branches.FlatAppearance.BorderSize = 0;
            Branches.FlatStyle = FlatStyle.Flat;
            Branches.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Branches.ForeColor = Color.Black;
            Branches.Image = (Image)resources.GetObject("Branches.Image");
            Branches.ImageAlign = ContentAlignment.MiddleLeft;
            Branches.Location = new Point(32, 235);
            Branches.Margin = new Padding(3, 4, 3, 4);
            Branches.Name = "Branches";
            Branches.Size = new Size(208, 59);
            Branches.TabIndex = 3;
            Branches.Text = "Branches";
            Branches.UseVisualStyleBackColor = false;
            Branches.Click += Branches_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1324, 657);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "a";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button Dashboard;
        private Button Branches;
        private Button Tracks;
        private Button Courses;
        private Button Instructors;
        private Button Students;
        private Button Reports;
        private NotifyIcon notifyIcon1;
        private PictureBox pictureBox1;
    }
}
