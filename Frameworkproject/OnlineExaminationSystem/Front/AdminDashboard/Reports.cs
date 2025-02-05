using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using Front.AdminDashboard;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.AdminDashboard
{
    public partial class Reports : Form1
    {
        public Reports()
        {

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 600); // Set exact size (same as in the Designer)

            InitializeComponent();
            button1.Click += button1_Click;
            

            // Attach event handler to ComboBox selection change
            comboBox1.SelectedIndexChanged += comboBox_selected_change;

            // Attach event handlers for restricting input
            //parameter1.KeyPress += TextBox_CharOnly;
            //parameter2.KeyPress += TextBox_NumberOnly;
            parameter1.Enabled = false;
            parameter2.Enabled = false;


        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = comboBox1.GetItemText(comboBox1.SelectedItem);
            string param1 = parameter1.Text.Trim();
            string param2 = parameter2.Enabled ? parameter2.Text.Trim() : null;// Only use if enabled


            // Debugging: Check values before validation
            Console.WriteLine($"param1: '{param1}', param2: '{param2}', Enabled: {parameter2.Enabled}");

            // Ensure at least param1 is provided
            if (string.IsNullOrWhiteSpace(param1)) // Use IsNullOrWhiteSpace to catch spaces-only input
            {
                MessageBox.Show("Please enter valid input for the required parameter.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // Validation for input
            if (IsInputValid(param1) && (!parameter2.Enabled || IsInputValid(param2)))
            {
                MessageBox.Show("Valid input.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Open the Report Viewer Form and pass parameters
            //ReportViewerForm reportViewer = new ReportViewerForm(reportType, param1, param2);
            //reportViewer.Show();
            ReportForm reportViewer = new ReportForm(reportType, param1, param2);
            reportViewer.Show();

        }

        private bool IsInputValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input); // Handles empty, null, and spaces-only cases
        }

        private void comboBox_selected_change(object sender, EventArgs e)
            {
                string selectedItem = comboBox1.GetItemText(comboBox1.SelectedItem);
                parameter1.KeyPress -= TextBox_CharOnly;
                parameter1.KeyPress -= TextBox_NumberOnly;
                parameter2.KeyPress -= TextBox_CharOnly;
                parameter2.KeyPress -= TextBox_NumberOnly;

                parameter1.Clear();
                parameter2.Clear();

                switch (selectedItem)
                {
                    case "Students info":
                        label2.Text = "Department name";
                        parameter1.Enabled = true;
                        parameter1.KeyPress += TextBox_CharOnly;  // Accept only characters
                        parameter2.Enabled = false;  // Disable second parameter
                        parameter2.Clear();
                        break;

                    case "Student's grades":
                        label2.Text = "Student ID";
                        parameter1.Enabled = true;
                        parameter1.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        parameter2.Enabled = false;
                        parameter2.Clear();
                        break;

                    case "Instructor's Courses":
                        label2.Text = "Instructor ID";
                        parameter1.Enabled = true;
                        parameter1.KeyPress += TextBox_NumberOnly; // Accept only characters
                        parameter2.Enabled = false;
                        parameter2.Clear(); 
                    break;

                    case "Course's Topics":
                        label2.Text = "Course ID";
                        parameter1.Enabled = true;
                        parameter1.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        parameter2.Enabled = false;
                        parameter2.Clear(); 
                        break;

                    case "Exam's Questions":
                        label2.Text = "Exam ID";
                        parameter1.Enabled = true;
                        parameter1.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        parameter2.Enabled = false;
                        parameter2.Clear(); 
                        break;

                    case "Student's Exam Answers":
                        label2.Text = "Exam ID";
                        parameter1.Enabled = true;
                        parameter1.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        label3.Text = "Student ID";
                        parameter2.Enabled = true;
                        parameter2.KeyPress += TextBox_NumberOnly; // Accept only numbers
                        break;

                    default:
                        label2.Text = "parameter1";
                        label3.Text = "parameter2";
                        parameter1.Enabled = false;
                        parameter2.Enabled = false;
                        parameter1.Clear();
                        parameter2.Clear();
                        break;
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
        }
    }

