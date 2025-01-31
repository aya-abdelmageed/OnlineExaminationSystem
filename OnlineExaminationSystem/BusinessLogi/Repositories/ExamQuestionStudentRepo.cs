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
    public class ExamQuestionStudentRepo
    {
        private readonly DBManager _dbManager;

        public ExamQuestionStudentRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
        public List<ExamQuestionsStudentDTO> GetQuestionsStudents(int? E_ID,int? S_ID,int? Q_ID)
        {
            string procedureName = "EXAM_QUESTION_STUDENT_SELECTION";
            DataTable result;
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                   new SqlParameter("@E_ID", E_ID),
                   new SqlParameter("@S_ID", S_ID),
                   new SqlParameter("@Q_ID", Q_ID)
                };
                result = _dbManager.ExecuteStoredProcedure(procedureName, null);
            }
            catch
            {
                throw new Exception("Error connecting to database");
            }
            List<ExamQuestionsStudentDTO> examQuestionsStudents = new List<ExamQuestionsStudentDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                ExamQuestionsStudentDTO examQuestionStudent = new ExamQuestionsStudentDTO
                {
                    StudentID = Convert.ToInt32(dataRow["StudentID"]),
                    ExamID = Convert.ToInt32(dataRow["ExamID"]),
                    QuestionID = Convert.ToInt32(dataRow["QuestionID"]),
                    Answer = dataRow["Answer"].ToString(),
                    Score = Convert.ToInt32(dataRow["Score"])
                };
                examQuestionsStudents.Add(examQuestionStudent);
            }
            return examQuestionsStudents;
        }
        public void InsertQuestionStudent(int StudentID, int ExamID, int QuestionID, string Answer, int? Score)
        {
            try
            {
                string procedureName = "EXAM_QUESTION_STUDENT_INSERTION";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID", StudentID),
                    new SqlParameter("@ExamID", ExamID),
                    new SqlParameter("@QuestionID", QuestionID),
                    new SqlParameter("@Answer", Answer),
                    new SqlParameter("@Score", Score)
                };
                _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch
            {
                throw new Exception("Error Inserting to database");
            }
        }
        public void UpdateQuestionStudent(int StudentID, int ExamID, int QuestionID, string Answer, int? Score)
        {
            try
            {
                string procedureName = "EXAM_QUESTION_STUDENT_UPDATE";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID", StudentID),
                    new SqlParameter("@ExamID", ExamID),
                    new SqlParameter("@QuestionID", QuestionID),
                    new SqlParameter("@Answer", Answer),
                    new SqlParameter("@Score", Score)
                };
                _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch
            {
                throw new Exception("Error Updating to database");
            }
        }
        public void DeleteQuestionStudent(int StudentID, int ExamID, int QuestionID)
        {
            try
            {
                string procedureName = "EXAM_QUESTION_STUDENT_DELETION";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID", StudentID),
                    new SqlParameter("@ExamID", ExamID),
                    new SqlParameter("@QuestionID", QuestionID)
                };
                _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch
            {
                throw new Exception("Error Deleting from database");
            }
        }
    }
}
