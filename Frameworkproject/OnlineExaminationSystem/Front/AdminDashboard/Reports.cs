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

            InitializeComponent();
            // Remove unnecessary buttons
            Control buttonToRemove = this.Controls["panel2"];
            Control buttonToRemove2 = this.Controls["panel3"];
            Control buttonToRemove3 = this.Controls["panel4"];

            if (buttonToRemove != null)
            {
                this.Controls.Remove(buttonToRemove);
            }

            if (buttonToRemove2 != null)
            {
                this.Controls.Remove(buttonToRemove2);
            }
            if (buttonToRemove3 != null)
                this.Controls.Remove(buttonToRemove3);
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
            this.Size = new Size(1324, 570);
            mypanel.BorderStyle = BorderStyle.None;     





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

