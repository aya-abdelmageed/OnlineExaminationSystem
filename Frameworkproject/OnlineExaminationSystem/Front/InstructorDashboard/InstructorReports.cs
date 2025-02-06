using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Front.ReportsControllers;

namespace Front.InstructorDashboard
{
    public partial class InstructorReports : InstructorDashboard
    {
        public InstructorReports(int userId , string userType): base(userId, userType)  
        {
            string[] controlsToRemove = { "label8", "pictureBox6" };

            foreach (string controlName in controlsToRemove)
            {
                Control controlToRemove = this.Controls[controlName]; // Assuming they are on the main form
                if (controlToRemove != null)
                {
                    this.Controls.Remove(controlToRemove);
                    controlToRemove.Dispose(); // Free memory
                }
            }
            InitializeComponent();
            // List of control names to remove
           


            // ✅ Add ReportsControl dynamically
            //ReportsControl reportsControl = new ReportsControl();
            // Makes it fit the form
            Console.WriteLine("Adding ReportsControl...");
            if (panel2 == null)
            {
                MessageBox.Show("panel2 is not initialized.");
                return;
            }
            //if (!mypanel.Controls.Contains(ReportsControl.Instance))
            //{
            ReportsControl reportController = new ReportsControl();
            panel2.Controls.Add(reportController);
            reportController.Dock = DockStyle.Fill;
            reportController.BringToFront();

            //}
            //ReportsControl.Instance.BringToFront();



            //Console.WriteLine("Adding ReportsControl...");

            //this.Controls.Add(reportsControl); // Add to form
            //Console.WriteLine($"Controls count after adding: {this.Controls.Count}");

            //this.Controls.SetChildIndex(reportsControl, 0); // Bring it to the front if needed
            //this.Refresh();
            //Console.WriteLine($"Controls count after adding: {this.Controls.Count}");

            
            //Console.WriteLine("Adding ReportsControl...");

            //this.Controls.Add(reportsControl); // Add to form
            //Console.WriteLine($"Controls count after adding: {this.Controls.Count}");

            //this.Controls.SetChildIndex(reportsControl, 0); // Bring it to the front if needed
            //this.Refresh();
            //Console.WriteLine($"Controls count after adding: {this.Controls.Count}");

            this.PerformLayout();
            this.Update();

        }
    }
}
