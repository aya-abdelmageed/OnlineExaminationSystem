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
    public class ExamQuestionRepo
    {
        private readonly DBManager _dbManager;
        public ExamQuestionRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
        public void AddExamQuestion(int examId, int questionId,int? points)
        {
            string procedureName = "EXAM_QUESTIONS_INSERTION";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ExamId", examId),
                new SqlParameter("@QuestionId", questionId),
                new SqlParameter("@Points", points)
            };
            _dbManager.ExecuteNonQuery(procedureName, parameters);
        }
        public void DeleteExamQuestion(int examId, int questionId)
        {
            string procedureName = "EXAM_QUESTIONS_DELETION";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ExamId", examId),
                new SqlParameter("@QuestionId", questionId)
            };
            _dbManager.ExecuteNonQuery(procedureName, parameters);
        }
        public void UpdateExamQuestion(int examId, int questionId, int points)
        {
            string procedureName = "EXAM_QUESTIONS_UPDATE";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ExamId", examId),
                new SqlParameter("@QuestionId", questionId),
                new SqlParameter("@Points", points) 
            };
            _dbManager.ExecuteNonQuery(procedureName, parameters);
        }
        public List<ExamQuestionsDTO> GetExamQuestions(int examId)
        {
            string procedureName = "Exam_QUESTIONS_SELECTION";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ExamId", examId)
            };
            DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            List<ExamQuestionsDTO> examQuestions = new List<ExamQuestionsDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                examQuestions.Add(new ExamQuestionsDTO
                {
                    ExamID = dataRow.Field<int>("ExamId"),
                    QuestionID = dataRow.Field<int>("QuestionId"),
                    Points_Edit = dataRow.Field<int>("Points")
                });
            }
            return examQuestions;
        }
    }
}
