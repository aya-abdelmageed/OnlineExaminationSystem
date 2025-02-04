using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Front.ReportsControllers
{
    public partial class ReportsControl : UserControl
    {

        //private static ReportsControl _instance;

        //public static ReportsControl Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new ReportsControl();
        //        }
        //        return _instance;
        //    }
        //}

        public ReportsControl()
        {
            InitializeComponent(); // ✅ Always call this first!

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.Size = new Size(1324, 657); // ✅ Corrected (UserControl does not have ClientSize)

            SelectionReports.SelectedIndexChanged += SelectionReports_SelectionChangeCommitted;

            param1.Enabled = false;
            param2.Enabled = false;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectionReports.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = SelectionReports.GetItemText(SelectionReports.SelectedItem);
            string _param1 = param1.Text.Trim();
            string _param2 = param2.Enabled ? param2.Text.Trim() : null;// Only use if enabled


            // Debugging: Check values before validation
            Console.WriteLine($"param1: '{_param1}', param2: '{_param2}', Enabled: {param2.Enabled}");

            // Ensure at least param1 is provided
            if (string.IsNullOrWhiteSpace(_param1)) // Use IsNullOrWhiteSpace to catch spaces-only input
            {
                MessageBox.Show("Please enter valid input for the required parameter.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //// Validation for input
            //if (IsInputValid(_param1) && (!param2.Enabled || IsInputValid(_param2)))
            //{
            //    MessageBox.Show("Valid input.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // Open the Report Viewer Form and pass parameters

            ReportForm reportViewer = new ReportForm(reportType, _param1, _param2);
            DataTable reportData = reportViewer.GetReportData();

            if(reportData == null || reportData.Rows.Count == 0)
            {
                MessageBox.Show("No data found for the selected report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                reportViewer.Show();
            }





        }

        private void SelectionReports_SelectionChangeCommitted(object sender, EventArgs e)
        {

            {
                string selectedItem = SelectionReports.GetItemText(SelectionReports.SelectedItem);
                param1.KeyPress -= TextBox_CharOnly;
                param1.KeyPress -= TextBox_NumberOnly;
                param2.KeyPress -= TextBox_CharOnly;
                param2.KeyPress -= TextBox_NumberOnly;

                param1.Clear();
                param2.Clear();

                switch (selectedItem)
                {
                    case "Students info":
                        paramLabel1.Text = "Department name";
                        paramLabel2.Text = "parameter2";
                        param1.Enabled = true;
                        param1.KeyPress += TextBox_CharOnly;  // Accept only characters
                        param2.Enabled = false;  // Disable second parameter
                        param2.Clear();
                        break;

                    case "Student's grades":
                        paramLabel1.Text = "Student ID";
                        paramLabel2.Text = "parameter2";
                        param1.Enabled = true;
                        param1.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        param2.Enabled = false;
                        param2.Clear();
                        break;

                    case "Instructor's Courses":
                        paramLabel1.Text = "Instructor ID";
                        paramLabel2.Text = "parameter2";
                        param1.Enabled = true;
                        param1.KeyPress += TextBox_NumberOnly; // Accept only characters
                        param2.Enabled = false;
                        param2.Clear();
                        break;

                    case "Course's Topics":
                        paramLabel1.Text = "Course ID";
                        paramLabel2.Text = "parameter2";
                        param1.Enabled = true;
                        param1.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        param2.Enabled = false;
                        param2.Clear();
                        break;

                    case "Exam's Questions":
                        paramLabel1.Text = "Exam ID";
                        paramLabel2.Text = "parameter2";
                        param1.Enabled = true;
                        param1.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        param2.Enabled = false;
                        param2.Clear();
                        break;

                    case "Student's Exam Answers":
                        paramLabel1.Text = "Exam ID";
                        param1.Enabled = true;
                        param1.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        paramLabel2.Text = "Student ID";
                        param2.Enabled = true;
                        param2.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        break;

                    default:
                        paramLabel1.Text = "parameter1";
                        paramLabel2.Text = "parameter2";
                        param1.Enabled = false;
                        param2.Enabled = false;
                        param1.Clear();
                        param2.Clear();
                        break;
                }
            }
        }


        // Method to allow only characters (letters and space)
        private void TextBox_CharOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;  // Block the input
            }
        }

        // Method to allow only numbers
        private void TextBox_NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Block the input
            }
        }

        /*
         * private bool IsInputValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input); // Handles empty, null, and spaces-only cases
        }
        */
        private void paramLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
