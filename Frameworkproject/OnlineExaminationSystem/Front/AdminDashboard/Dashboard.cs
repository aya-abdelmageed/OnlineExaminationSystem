using Front.InstructorDashboard;
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

namespace UI.AdminDashboard
{
    public partial class Dashboard:Form1
    {    
        public Dashboard()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 657); // Set exact size (same as in the Designer)
            InitializeComponent();
            panel3.Click += panel3_click;
            panel4.Click += panel4_Paint_Click;


        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

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
            var form = new InstructorDashboard();
            ShowForm(form);

        }
   
   

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel2, 20, Color.Black, 1);


        }

       
        private void panel4_Paint_Click(object sender, EventArgs e)
        {
            ShowForm(new StudentDashboard());


        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel5, 20, Color.Black, 1);


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
    }
}
