using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using BusinessLogi.Repositories;
using DataAccess;

namespace Front.ReportsControllers
{
    public partial class ReportForm : Form
    {
        private string _reportType;
        private string _param1;
        private string _param2;
        private ReportRepo reportRepo; 


        public ReportForm(string reportType, string param1, string param2)
        {
            _reportType = reportType;
            _param1 = param1;
            _param2 = param2;
            reportRepo = new ReportRepo();
            InitializeComponent();
            
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
        public DataTable GetReportData()
        {
           return  reportRepo.GetReportData(_reportType , _param1 , _param2 );     
           
        }
        public string GetReportPath(string reportType)
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








    }
}
