using System.Drawing;
using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Instructors = new System.Windows.Forms.Button();
            this.Reports = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Students = new System.Windows.Forms.Button();
            this.Dashboard = new System.Windows.Forms.Button();
            this.Courses = new System.Windows.Forms.Button();
            this.Tracks = new System.Windows.Forms.Button();
            this.Branches = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.Exit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.Instructors);
            this.panel1.Controls.Add(this.Reports);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Students);
            this.panel1.Controls.Add(this.Dashboard);
            this.panel1.Controls.Add(this.Courses);
            this.panel1.Controls.Add(this.Tracks);
            this.panel1.Controls.Add(this.Branches);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 526);
            this.panel1.TabIndex = 0;
            // 
            // Instructors
            // 
            this.Instructors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.Instructors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Instructors.FlatAppearance.BorderSize = 0;
            this.Instructors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Instructors.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.Instructors.ForeColor = System.Drawing.Color.Black;
            this.Instructors.Image = ((System.Drawing.Image)(resources.GetObject("Instructors.Image")));
            this.Instructors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Instructors.Location = new System.Drawing.Point(32, 346);
            this.Instructors.Name = "Instructors";
            this.Instructors.Size = new System.Drawing.Size(177, 47);
            this.Instructors.TabIndex = 6;
            this.Instructors.Text = "Instructors";
            this.Instructors.UseVisualStyleBackColor = false;
            this.Instructors.Click += new System.EventHandler(this.Instructors_Click);
            // 
            // Reports
            // 
            this.Reports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Reports.FlatAppearance.BorderSize = 0;
            this.Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reports.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.Reports.ForeColor = System.Drawing.Color.Black;
            this.Reports.Image = ((System.Drawing.Image)(resources.GetObject("Reports.Image")));
            this.Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Reports.Location = new System.Drawing.Point(32, 454);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(159, 47);
            this.Reports.TabIndex = 8;
            this.Reports.Text = "Reports";
            this.Reports.UseVisualStyleBackColor = false;
            this.Reports.Click += new System.EventHandler(this.Reports_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-29, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Students
            // 
            this.Students.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.Students.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Students.FlatAppearance.BorderSize = 0;
            this.Students.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Students.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.Students.ForeColor = System.Drawing.Color.Black;
            this.Students.Image = ((System.Drawing.Image)(resources.GetObject("Students.Image")));
            this.Students.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Students.Location = new System.Drawing.Point(32, 400);
            this.Students.Name = "Students";
            this.Students.Size = new System.Drawing.Size(159, 47);
            this.Students.TabIndex = 7;
            this.Students.Text = "Students";
            this.Students.UseVisualStyleBackColor = false;
            this.Students.Click += new System.EventHandler(this.Students_Click);
            // 
            // Dashboard
            // 
            this.Dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.Dashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Dashboard.FlatAppearance.BorderSize = 0;
            this.Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dashboard.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.Dashboard.ForeColor = System.Drawing.Color.Black;
            this.Dashboard.Image = ((System.Drawing.Image)(resources.GetObject("Dashboard.Image")));
            this.Dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Dashboard.Location = new System.Drawing.Point(32, 142);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(177, 47);
            this.Dashboard.TabIndex = 2;
            this.Dashboard.Text = "Dashboard";
            this.Dashboard.UseVisualStyleBackColor = false;
            this.Dashboard.Click += new System.EventHandler(this.Dashboard_Click);
            // 
            // Courses
            // 
            this.Courses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.Courses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Courses.FlatAppearance.BorderSize = 0;
            this.Courses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Courses.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.Courses.ForeColor = System.Drawing.Color.Black;
            this.Courses.Image = ((System.Drawing.Image)(resources.GetObject("Courses.Image")));
            this.Courses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Courses.Location = new System.Drawing.Point(32, 293);
            this.Courses.Name = "Courses";
            this.Courses.Size = new System.Drawing.Size(159, 47);
            this.Courses.TabIndex = 5;
            this.Courses.Text = "Courses";
            this.Courses.UseVisualStyleBackColor = false;
            this.Courses.Click += new System.EventHandler(this.Courses_Click);
            // 
            // Tracks
            // 
            this.Tracks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.Tracks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Tracks.FlatAppearance.BorderSize = 0;
            this.Tracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tracks.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.Tracks.ForeColor = System.Drawing.Color.Black;
            this.Tracks.Image = ((System.Drawing.Image)(resources.GetObject("Tracks.Image")));
            this.Tracks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Tracks.Location = new System.Drawing.Point(32, 241);
            this.Tracks.Name = "Tracks";
            this.Tracks.Size = new System.Drawing.Size(142, 47);
            this.Tracks.TabIndex = 4;
            this.Tracks.Text = "Tracks";
            this.Tracks.UseVisualStyleBackColor = false;
            this.Tracks.Click += new System.EventHandler(this.Tracks_Click_1);
            // 
            // Branches
            // 
            this.Branches.BackColor = System.Drawing.Color.Transparent;
            this.Branches.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Branches.FlatAppearance.BorderSize = 0;
            this.Branches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Branches.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.Branches.ForeColor = System.Drawing.Color.Black;
            this.Branches.Image = ((System.Drawing.Image)(resources.GetObject("Branches.Image")));
            this.Branches.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Branches.Location = new System.Drawing.Point(32, 188);
            this.Branches.Name = "Branches";
            this.Branches.Size = new System.Drawing.Size(165, 47);
            this.Branches.TabIndex = 3;
            this.Branches.Text = "Branches";
            this.Branches.UseVisualStyleBackColor = false;
            this.Branches.Click += new System.EventHandler(this.Branches_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(1238, 31);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(20, 22);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "X";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1175, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "←";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1324, 526);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "a";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label Exit;
        private Label label1;
    }
}
