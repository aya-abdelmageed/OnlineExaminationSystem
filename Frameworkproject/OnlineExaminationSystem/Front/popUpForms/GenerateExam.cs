using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;
using BusinessLogi.Repositories;
using BusinessLogic.DTO;
using BusinessLogic.Repositories;

namespace Front.popUpForms
{
    public partial class GenerateExam : Form
    {
        private readonly ExamRepo _examRepo;
        private readonly CourseRepo _courseRepo;
        private ComboBox cmbCourses;
        private NumericUpDown numTF;
        private NumericUpDown numMCQ;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;

        public GenerateExam()
        {
            InitializeComponent2();
            _examRepo = new ExamRepo(); 
            _courseRepo = new CourseRepo();
            LoadCourses();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(450, 600);
        }

        private void InitializeComponent2()
        {
            this.Text = "Generate Exam";
            Label courseLabel = new Label { Text = "Course Name:", Location = new System.Drawing.Point(50, 60), Size = new System.Drawing.Size(100, 20) };
            cmbCourses = new ComboBox { Location = new System.Drawing.Point(150, 60), Size = new System.Drawing.Size(200, 20), DropDownStyle = ComboBoxStyle.DropDownList };

            Label tfLabel = new Label { Text = "TF Questions:", Location = new System.Drawing.Point(50, 100), Size = new System.Drawing.Size(100, 20) };
            numTF = new NumericUpDown { Location = new System.Drawing.Point(150, 100), Size = new System.Drawing.Size(200, 20) };

            Label mcqLabel = new Label { Text = "MCQ Questions:", Location = new System.Drawing.Point(50, 140), Size = new System.Drawing.Size(100, 20) };
            numMCQ = new NumericUpDown { Location = new System.Drawing.Point(150, 140), Size = new System.Drawing.Size(200, 20) };

            Label dateLabel = new Label { Text = "Date:", Location = new System.Drawing.Point(50, 180), Size = new System.Drawing.Size(100, 20) };
            dtpDate = new DateTimePicker { Location = new System.Drawing.Point(150, 180), Size = new System.Drawing.Size(200, 20) };

            Label startLabel = new Label { Text = "Start Time:", Location = new System.Drawing.Point(50, 220), Size = new System.Drawing.Size(100, 20) };
            dtpStartTime = new DateTimePicker { Location = new System.Drawing.Point(150, 220), Size = new System.Drawing.Size(200, 20), Format = DateTimePickerFormat.Time, ShowUpDown = true };

            Label endLabel = new Label { Text = "End Time:", Location = new System.Drawing.Point(50, 260), Size = new System.Drawing.Size(100, 20) };
            dtpEndTime = new DateTimePicker { Location = new System.Drawing.Point(150, 260), Size = new System.Drawing.Size(200, 20), Format = DateTimePickerFormat.Time, ShowUpDown = true };

            Button btnGenerate = new Button { Text = "Generate Exam", Location = new System.Drawing.Point(150, 300), Size = new System.Drawing.Size(100, 30) };
            btnGenerate.Click += BtnGenerate_Click;

            this.Controls.Add(courseLabel);
            this.Controls.Add(cmbCourses);
            this.Controls.Add(tfLabel);
            this.Controls.Add(numTF);
            this.Controls.Add(mcqLabel);
            this.Controls.Add(numMCQ);
            this.Controls.Add(dateLabel);
            this.Controls.Add(dtpDate);
            this.Controls.Add(startLabel);
            this.Controls.Add(dtpStartTime);
            this.Controls.Add(endLabel);
            this.Controls.Add(dtpEndTime);
            this.Controls.Add(btnGenerate);
        }

        private void LoadCourses()
        {
            var courses = _courseRepo.GetCourses(null);
            var coursesNames = courses.Select(x => x.Name);
            cmbCourses.Items.Add(courses);
            cmbCourses.DisplayMember = "Course_Name";
            cmbCourses.Items.Clear(); // Clear previous items
            cmbCourses.Items.AddRange(coursesNames.ToArray()); // Add course names to ComboBox
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int tfNum = (int)numTF.Value;
                int mcqNum = (int)numMCQ.Value;
                string course = cmbCourses.Text;   
                DateTime date = dtpDate.Value.Date;
                TimeSpan startTime = dtpStartTime.Value.TimeOfDay;
                TimeSpan endTime = dtpEndTime.Value.TimeOfDay;
                int? instructorId = null;

                _examRepo.Exam_Generation(course, tfNum, mcqNum, date, startTime, endTime, 1);
                MessageBox.Show("Exam generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
