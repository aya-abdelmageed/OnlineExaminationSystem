﻿using Front.InstructorDashboard;
using Front.StudentDashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccess;
using Front;
using Nest;
using BusinessLogi.Repositories;

namespace UI.AdminDashboard
{
    public partial class Dashboard:Form1
    {
        private DBManager dbManager;
        private int userId;
        private string userType;
        private BranchRepo count; 

        public Dashboard(int userId, string userType)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 600); // Set exact size (same as in the Designer)
            InitializeComponent();
            dbManager = new DBManager();
            panel3.Click += panel3_click;
            panel4.Click += panel4_Paint_Click;
            count = new BranchRepo();

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rounded rectangle for panel2
            DrawRoundedPanelBorder(e, panel2, 20, Color.Black, 2);
        }

       
       
     




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    
        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel3, 20, Color.Black, 1);



        }

      
        private void panel3_click(object sender, EventArgs e)
        {
           var form = new InstructorDashboard(1 ,"Instructor" );
           ShowForm(form);

        }
   
   

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel2, 20, Color.Black, 1);


        }

       
        private void panel4_Paint_Click(object sender, EventArgs e)
        {
            ShowForm(new StudentDashboard(1 ,"Student"));


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel4, 20, Color.Black, 1);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
           // ShowForm(new Login());
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
             int branchCount = count.GetBranchCount();
            label2.Text = branchCount.ToString();

        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {
            
            int InstructorCount = count.GetInstructorCount();
            label3.Text = InstructorCount.ToString();
        }

        private void label5_Paint(object sender, PaintEventArgs e)
        {
            int StudentCount = count.GetStudentCount();
            label5.Text = StudentCount.ToString();

        }


        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Resize(object sender, EventArgs e)
        {

        }
    }
}
