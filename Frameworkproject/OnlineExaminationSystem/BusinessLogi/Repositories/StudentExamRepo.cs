using BusinessLogi.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.Repositories
{
    public class StudentExamRepo
    {
        private readonly DBManager _dbManager;
        public StudentExamRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
        public List<StudentExamDTO> GetStudentExams(int? student_id,int? exam_id)
        {
            DataTable result;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID",student_id),
                    new SqlParameter("@ExamID",exam_id)
                };
                result = _dbManager.ExecuteStoredProcedure("STUDENT_EXAM_SELECTION", parameters);
            }
            catch
            {
                throw new Exception("Error getting student exams");
            }
            List<StudentExamDTO> studentExams = new List<StudentExamDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                StudentExamDTO studentExam = new StudentExamDTO
                {
                    StudentId = Convert.ToInt32(dataRow["StudentId"]),
                    ExamID = Convert.ToInt32(dataRow["ExamID"]),
                    Grade = Convert.ToInt32(dataRow["Grade"])
                };
                studentExams.Add(studentExam);
            }
            return studentExams;
        }
        public void InsertStudentExam(StudentExamDTO studentExam)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID",studentExam.StudentId),
                    new SqlParameter("@ExamID",studentExam.ExamID),
                    new SqlParameter("@Grade",studentExam.Grade)
                };
                _dbManager.ExecuteStoredProcedure("STUDENT_EXAM_INSERTION", parameters);
            }
            catch
            {
                throw new Exception("Error inserting student exam");
            }
        }
        public void DeleteStudentExam(int student_id, int exam_id)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID",student_id),
                    new SqlParameter("@ExamID",exam_id)
                };
                _dbManager.ExecuteStoredProcedure("STUDENT_EXAM_DELETION", parameters);
            }
            catch
            {
                throw new Exception("Error deleting student exam");
            }
        }
        public void UpdateStudentExam(int student_id, int exam_id, int grade)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID",student_id),
                    new SqlParameter("@ExamID",exam_id),
                    new SqlParameter("@Grade",grade)
                };
                _dbManager.ExecuteStoredProcedure("STUDENT_EXAM_UPDATE", parameters);
            }
            catch
            {
                throw new Exception("Error updating student exam");
            }
        }
    }
}
