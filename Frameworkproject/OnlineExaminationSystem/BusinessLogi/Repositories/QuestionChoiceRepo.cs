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
    public class QuestionChoiceRepo
    {
        private readonly DBManager _dbManager;
        public QuestionChoiceRepo()
        {
            _dbManager = new  DBManager();
        }
        public List<QuestionsChoicesDTO> GetQuestionChoices(int questionID)
        {
            DataTable result;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@question_ID",questionID)
                };
                result = _dbManager.ExecuteStoredProcedure("CHOICE_SELECTION", parameters);
            }
            catch
            {
                throw new Exception("Error getting question choice");
            }
            List<QuestionsChoicesDTO> questionChoices = new List<QuestionsChoicesDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                QuestionsChoicesDTO questionChoice = new QuestionsChoicesDTO
                {
                    QuestionID = Convert.ToInt32(dataRow["Question_ID"]),
                    Choice = dataRow["QUESTION_CHOICE"].ToString(),
                };
                questionChoices.Add(questionChoice);
            }
            return questionChoices;
        }
        public void InsertQuestionChoice(int questionID, string choice)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@QuestionID",questionID),
                    new SqlParameter("@Choice",choice)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("CHOICE_INSERTION", parameters);
            }
            catch
            {
                throw new Exception("Error inserting question choice");
            }
        }
        public void DeleteQuestionChoice(int questionID, string choice)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@QuestionID",questionID),
                    new SqlParameter("@Choice",choice)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("CHOICE_DELETION", parameters);
            }
            catch
            {
                throw new Exception("Error deleting question choice");
            }
        }
        public void UpdateQuestionChoice(int old_choice, int new_choice, int Question_ID)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Old_Choice",old_choice),
                    new SqlParameter("@New_Choice",new_choice),
                    new SqlParameter("@Question_ID",Question_ID)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("CHOICE_UPDATE", parameters);
            }
            catch
            {
                throw new Exception("Error updating question choice");
            }
        }
    }
}
