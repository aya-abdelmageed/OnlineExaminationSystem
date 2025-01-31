namespace UI.AdminDashboard
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            notifyIcon1 = new NotifyIcon(components);
            pictureBox4 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            panel3 = new Panel();
            label3 = new Label();
            label4 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBox1 = new TextBox();
            label10 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.icons8_students_48;
            pictureBox4.Location = new Point(19, 16);
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
            label5.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(204, 8, 8);
            label5.Location = new Point(185, 21);
            label5.Name = "label5";
            label5.Size = new Size(69, 34);
            label5.TabIndex = 1;
            label5.Text = "534";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(30, 68);
            label6.Name = "label6";
            label6.Size = new Size(212, 32);
            label6.TabIndex = 0;
            label6.Text = "Total Students";
            label6.Click += label6_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(978, 102);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(279, 117);
            panel4.TabIndex = 8;
            panel4.Paint += panel4_Paint;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icons8_teacher_50;
            pictureBox3.Location = new Point(21, 14);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(644, 102);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(279, 117);
            panel3.TabIndex = 7;
            panel3.Paint += panel3_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(204, 8, 8);
            label3.Location = new Point(185, 21);
            label3.Name = "label3";
            label3.Size = new Size(69, 34);
            label3.TabIndex = 1;
            label3.Text = "534";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(33, 68);
            label4.Name = "label4";
            label4.Size = new Size(233, 32);
            label4.TabIndex = 0;
            label4.Text = "Total Instructors";
            label4.Click += label4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(21, 68);
            label1.Name = "label1";
            label1.Size = new Size(219, 32);
            label1.TabIndex = 0;
            label1.Text = "Total Branches";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(204, 8, 8);
            label2.Location = new Point(185, 21);
            label2.Name = "label2";
            label2.Size = new Size(69, 34);
            label2.TabIndex = 1;
            label2.Text = "534";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(297, 102);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(279, 117);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_user_account_48__1_;
            pictureBox2.Location = new Point(9, 16);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
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
            // textBox1
            // 
            textBox1.Location = new Point(110, 96);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(330, 27);
            textBox1.TabIndex = 5;
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
            // 
            // textBox2
            // 
            textBox2.Location = new Point(110, 185);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(330, 27);
            textBox2.TabIndex = 7;
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
            // 
            // panel5
            // 
            panel5.Controls.Add(checkBox1);
            panel5.Controls.Add(button1);
            panel5.Controls.Add(textBox2);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(textBox1);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label7);
            panel5.Location = new Point(350, 272);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(606, 315);
            panel5.TabIndex = 9;
            panel5.Paint += panel5_Paint;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1324, 657);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            Controls.SetChildIndex(panel2, 0);
            Controls.SetChildIndex(panel3, 0);
            Controls.SetChildIndex(panel4, 0);
            Controls.SetChildIndex(panel5, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private PictureBox pictureBox4;
        private Label label5;
        private Label label6;
        private Panel panel4;
        private PictureBox pictureBox3;
        private Panel panel3;
        private Label label3;
        private Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox1;
        private Label label10;
        private TextBox textBox2;
        private Button button1;
        private CheckBox checkBox1;
        private Panel panel5;
        private PictureBox pictureBox2;
    }
}