using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;


namespace Front.ReportsControllers
{
    public partial class ReportForm : Form
    {
        private string _reportType;
        private string _param1;
        private string _param2;

        public ReportForm(string reportType, string param1, string param2)
        {
            InitializeComponent();
            _reportType = reportType;
            _param1 = param1;
            _param2 = param2;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportPath = GetReportPath(_reportType);
                reportViewer1.LocalReport.DataSources.Clear();

                // Fetch data from the database
                DataTable reportData = GetReportData();

                if (reportData != null && reportData.Rows.Count > 0)
                {
                    ReportDataSource dataSource = new ReportDataSource("DataSet", reportData);
                    reportViewer1.LocalReport.DataSources.Add(dataSource);

                    // Prepare report parameters
                    List<ReportParameter> reportParams = new List<ReportParameter>
                    {
                        new ReportParameter("parameter1", _param1) // Always send parameter1
                    };

                    if (!string.IsNullOrEmpty(_param2)) // Only add parameter2 if it's not null/empty
                    {
                        reportParams.Add(new ReportParameter("parameter2", _param2));
                    }

                    reportViewer1.LocalReport.SetParameters(reportParams);
                    reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No data found for the selected report.", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

        }

        private string GetReportPath(string reportType)
        {
            switch (reportType)
            {
                case "Students info": return @"Reports\DepartmentStudentsReport.rdlc";
                case "Student's grades": return @"Reports\StudentGradesReport.rdlc";
                case "Instructor's Courses": return @"Reports\InstructorCoursesReport.rdlc";
                case "Course's Topics": return @"Reports\CourseTopicsReport.rdlc";
                case "Exam's Questions": return @"Reports\ExamQuestionsReport.rdlc";
                case "Student's Exam Answers": return @"Reports\ExamStudentAnswersReport.rdlc";
                default: return string.Empty;
            }
        }

        public DataTable GetReportData()
        {
            string connectionString = "Data Source=DESKTOP-PAJ6AIB\\SQLEXPRESS;Initial Catalog=Online_Examination_System;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string storedProc = GetStoredProcedureName(_reportType);
                using (SqlCommand cmd = new SqlCommand(storedProc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add required parameter1
                    cmd.Parameters.AddWithValue("@parameter1", _param1);

                    // Only add parameter2 if it's not empty/null and if the stored procedure expects it
                    if (!string.IsNullOrEmpty(_param2))
                    {
                        cmd.Parameters.AddWithValue("@parameter2", _param2);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }


        private string GetStoredProcedureName(string reportType)
        {
            switch (reportType)
            {
                case "Students info": return "DEPARTMENT_STUDENTS_REPORT";
                case "Student's grades": return "STUDENT_GRADES";
                case "Instructor's Courses": return "INSTRUCTOR_COURSE_STUDENTS_NO";
                case "Course's Topics": return "COURSE_TOPICS";
                case "Exam's Questions": return "EXAM_QUESTIONS_REPORT";
                case "Student's Exam Answers": return "EXAM_STUDENT_ANSWERS_REPORT";
                default: return string.Empty;
            }
        }
    
    }
}
