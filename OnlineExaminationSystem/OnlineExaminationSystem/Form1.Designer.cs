namespace UI
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
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            panel5 = new Panel();
            checkBox1 = new CheckBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label10 = new Label();
            textBox1 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel5.SuspendLayout();
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
            panel1.Paint += panel1_Paint;
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
            Instructors.Click += button5_Click;
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
            Reports.Click += button7_Click;
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
            pictureBox1.Click += pictureBox1_Click;
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
            Students.Click += button6_Click;
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
            Courses.Click += button4_Click;
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
            Tracks.Click += button3_Click;
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
            // panel2
            // 
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(246, 102);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(270, 150);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint_1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_user_account_48__1_;
            pictureBox2.Location = new Point(9, 5);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(204, 8, 8);
            label2.Location = new Point(185, 21);
            label2.Name = "label2";
            label2.Size = new Size(68, 37);
            label2.TabIndex = 1;
            label2.Text = "534";
            label2.Click += label2_Click;
            label2.Paint += label2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 98);
            label1.Name = "label1";
            label1.Size = new Size(219, 32);
            label1.TabIndex = 0;
            label1.Text = "Total Branches";
            label1.Click += label1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(593, 102);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(270, 150);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icons8_teacher_50;
            pictureBox3.Location = new Point(9, 5);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(204, 8, 8);
            label3.Location = new Point(185, 21);
            label3.Name = "label3";
            label3.Size = new Size(68, 37);
            label3.TabIndex = 1;
            label3.Text = "534";
            label3.Click += label3_Click;
            label3.Paint += label3_Paint_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(3, 98);
            label4.Name = "label4";
            label4.Size = new Size(233, 32);
            label4.TabIndex = 0;
            label4.Text = "Total Instructors";
            label4.Click += label4_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(934, 102);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(270, 150);
            panel4.TabIndex = 3;
            panel4.Paint += panel4_Paint;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.icons8_students_48;
            pictureBox4.Location = new Point(9, 5);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(48, 48);
            pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(204, 8, 8);
            label5.Location = new Point(185, 21);
            label5.Name = "label5";
            label5.Size = new Size(68, 37);
            label5.TabIndex = 1;
            label5.Text = "534";
            label5.Click += label5_Click;
            label5.Paint += label5_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(3, 98);
            label6.Name = "label6";
            label6.Size = new Size(212, 32);
            label6.TabIndex = 0;
            label6.Text = "Total Students";
            label6.Click += label6_Click;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(checkBox1);
            panel5.Controls.Add(button1);
            panel5.Controls.Add(textBox2);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(textBox1);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label7);
            panel5.Location = new Point(352, 294);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(606, 315);
            panel5.TabIndex = 4;
            panel5.Paint += panel5_Paint;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(459, 188);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(132, 24);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(204, 8, 8);
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(211, 228);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(124, 40);
            button1.TabIndex = 8;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseHover += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(110, 185);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(330, 27);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(204, 8, 8);
            label10.Location = new Point(144, 272);
            label10.Name = "label10";
            label10.Size = new Size(250, 22);
            label10.TabIndex = 6;
            label10.Text = "Wrong username or password";
            label10.Click += label10_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 96);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(330, 27);
            textBox1.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(222, 150);
            label9.Name = "label9";
            label9.Size = new Size(98, 25);
            label9.TabIndex = 3;
            label9.Text = "Password";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(222, 61);
            label8.Name = "label8";
            label8.Size = new Size(102, 25);
            label8.TabIndex = 2;
            label8.Text = "Username";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(18, 26);
            label7.Name = "label7";
            label7.Size = new Size(98, 32);
            label7.TabIndex = 1;
            label7.Text = "Login ";
            label7.Click += label7_Click;
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
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "a";
            Load += Form1_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
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
        private Panel panel2;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private Panel panel3;
        private PictureBox pictureBox3;
        private Label label3;
        private Label label4;
        private Panel panel4;
        private PictureBox pictureBox4;
        private Label label5;
        private Label label6;
        private Panel panel5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private CheckBox checkBox1;
        private NotifyIcon notifyIcon1;
        private PictureBox pictureBox1;
    }
}
