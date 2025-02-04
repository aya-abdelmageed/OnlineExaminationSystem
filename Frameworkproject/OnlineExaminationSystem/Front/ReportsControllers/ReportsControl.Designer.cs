namespace Front.ReportsControllers
{
    partial class ReportsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectionReports = new System.Windows.Forms.ComboBox();
            this.paramLabel1 = new System.Windows.Forms.Label();
            this.paramLabel2 = new System.Windows.Forms.Label();
            this.param1 = new System.Windows.Forms.TextBox();
            this.param2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 4;
            // 
            // SelectionReports
            // 
            this.SelectionReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionReports.FormattingEnabled = true;
            this.SelectionReports.Items.AddRange(new object[] {
            "Students info",
            "Student\'s grades",
            "Instructor\'s Courses",
            "Course\'s Topics",
            "Exam\'s Questions",
            "Student\'s Exam Answers"});
            this.SelectionReports.Location = new System.Drawing.Point(285, 103);
            this.SelectionReports.Name = "SelectionReports";
            this.SelectionReports.Size = new System.Drawing.Size(268, 33);
            this.SelectionReports.TabIndex = 7;
            this.SelectionReports.SelectionChangeCommitted += new System.EventHandler(this.SelectionReports_SelectionChangeCommitted);
            // 
            // paramLabel1
            // 
            this.paramLabel1.AutoSize = true;
            this.paramLabel1.BackColor = System.Drawing.Color.White;
            this.paramLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paramLabel1.Location = new System.Drawing.Point(44, 175);
            this.paramLabel1.Name = "paramLabel1";
            this.paramLabel1.Size = new System.Drawing.Size(123, 25);
            this.paramLabel1.TabIndex = 8;
            this.paramLabel1.Text = "Parameter1";
            this.paramLabel1.Click += new System.EventHandler(this.label5_Click);
            // 
            // paramLabel2
            // 
            this.paramLabel2.AutoSize = true;
            this.paramLabel2.BackColor = System.Drawing.Color.White;
            this.paramLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paramLabel2.Location = new System.Drawing.Point(44, 227);
            this.paramLabel2.Name = "paramLabel2";
            this.paramLabel2.Size = new System.Drawing.Size(123, 25);
            this.paramLabel2.TabIndex = 9;
            this.paramLabel2.Text = "Parameter2";
            this.paramLabel2.Click += new System.EventHandler(this.paramLabel2_Click);
            // 
            // param1
            // 
            this.param1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.param1.Location = new System.Drawing.Point(234, 175);
            this.param1.Name = "param1";
            this.param1.Size = new System.Drawing.Size(221, 30);
            this.param1.TabIndex = 10;
            // 
            // param2
            // 
            this.param2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.param2.Location = new System.Drawing.Point(234, 227);
            this.param2.Name = "param2";
            this.param2.Size = new System.Drawing.Size(221, 30);
            this.param2.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGray;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(205, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 58);
            this.button2.TabIndex = 12;
            this.button2.Text = "Preview";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(67, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(475, 36);
            this.label5.TabIndex = 13;
            this.label5.Text = "Online Examination System Report";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 31);
            this.label6.TabIndex = 14;
            this.label6.Text = "Choose Report";
            // 
            // ReportsControl
            // 
            this.BackColor = System.Drawing.Color.Firebrick;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.param2);
            this.Controls.Add(this.param1);
            this.Controls.Add(this.paramLabel2);
            this.Controls.Add(this.paramLabel1);
            this.Controls.Add(this.SelectionReports);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "ReportsControl";
            this.Size = new System.Drawing.Size(597, 365);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox reportType;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox parameter2;
        private System.Windows.Forms.TextBox parameter1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SelectionReports;
        private System.Windows.Forms.Label paramLabel1;
        private System.Windows.Forms.Label paramLabel2;
        private System.Windows.Forms.TextBox param1;
        private System.Windows.Forms.TextBox param2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
