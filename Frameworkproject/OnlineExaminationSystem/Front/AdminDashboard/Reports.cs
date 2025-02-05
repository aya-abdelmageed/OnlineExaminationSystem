using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using Front.AdminDashboard;
using Front.ReportsControllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.AdminDashboard
{
    public partial class Reports : Form1
    {
        public Reports()
        {

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 657); // Set exact size (same as in the Designer)

            InitializeComponent();
            // ✅ Add ReportsControl dynamically
            //ReportsControl reportsControl = new ReportsControl();
            // Makes it fit the form
            Console.WriteLine("Adding ReportsControl...");
            if (mypanel == null)
            {
                MessageBox.Show("panel2 is not initialized.");
                return;
            }
            //if (!mypanel.Controls.Contains(ReportsControl.Instance))
            //{
            var reportControl = new ReportsControl();
                mypanel.Controls.Add(reportControl);
                reportControl.Dock = DockStyle.Fill;
                reportControl.BringToFront();

            //}
            //ReportsControl.Instance.BringToFront();



            //Console.WriteLine("Adding ReportsControl...");

            //this.Controls.Add(reportsControl); // Add to form
            //Console.WriteLine($"Controls count after adding: {this.Controls.Count}");

            //this.Controls.SetChildIndex(reportsControl, 0); // Bring it to the front if needed
            //this.Refresh();
            //Console.WriteLine($"Controls count after adding: {this.Controls.Count}");

            this.PerformLayout();
            this.Update();

        
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

          
        private void panel2_Paint(object sender, PaintEventArgs e)
        {


        }
    }
    }

