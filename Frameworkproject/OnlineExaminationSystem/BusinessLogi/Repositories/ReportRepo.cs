using DataAccess;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.Repositories
{
    public class ReportRepo
    {
        private readonly DBManager _dbManager;

        public ReportRepo()
        {
            _dbManager = new DBManager();
        }


     
        public DataTable GetReportData(string reportType, string _param1, string _param2)
        {
            var storedProc = GetStoredProcedureName(reportType);
           return  _dbManager.GetReportData(storedProc, _param1, _param2); 
        }



        public string GetStoredProcedureName(string reportType)
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
