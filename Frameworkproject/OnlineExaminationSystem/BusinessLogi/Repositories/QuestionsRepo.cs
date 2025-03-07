﻿using BusinessLogi.DTO;
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
    public class QuestionsRepo
    {
        private readonly DBManager _dbManager;

        public QuestionsRepo()
        {
            _dbManager = new DBManager();
        }
        public List<QuestionsDTO> GetQuestionsByID(int Q_id,int Crs_id)
        {
            string procedureName = "QUESTION_SELECTION";
            DataTable result;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Question_ID", SqlDbType.Int) { Value = Q_id },
                    new SqlParameter("@Course_ID", SqlDbType.Int) { Value = Crs_id }
                };  
                result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Questions from the database.", ex);
            }
            var questions = new List<QuestionsDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                var question = new QuestionsDTO
                {
                    QuestionID = dataRow.Field<int>("QUESTION_ID"),
                    Question = dataRow.Field<string>("QUESTION"),
                    Answer = dataRow.Field<string>("Correct_Ans"),
                    Type = dataRow.Field<string>("Type"),
                    Points = dataRow.Field<int>("Points"),
                    CourseID = dataRow.Field<int>("COURSE_ID")
                };
                questions.Add(question);
            }
            return questions;
        }
        public List<QuestionsDTO> ALL_COURSE_QUESTION(int? Crs_id)
        {
            string procedureName = "ALL_COURSE_QUESTION_SELECTION";
            DataTable result;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@course_id", SqlDbType.Int) { Value = Crs_id }
                };
                result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Questions from the database.", ex);
            }
            var questions = new List<QuestionsDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                var question = new QuestionsDTO
                {
                    QuestionID = dataRow.Field<int>("Question_ID"),
                    Question = dataRow.Field<string>("Question"),
                    Answer = dataRow.Field<string>("Correct_Ans"),
                    Type = dataRow.Field<string>("Type"),
                    Points = dataRow.Field<int>("Points"),
                    CourseID = dataRow.Field<int>("Course_ID")
                };
                questions.Add(question);
            }
            return questions;
        }
        public int InsertQuestions(QuestionsDTO question)
        {
            string procedureName = "QUESTION_INSERTION";

            try
            {
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@Question", SqlDbType.NVarChar) { Value = question.Question },
            new SqlParameter("@correct_ans", SqlDbType.NVarChar) { Value = question.Answer },
            new SqlParameter("@Type", SqlDbType.NVarChar) { Value = question.Type },
            new SqlParameter("@Points", SqlDbType.Int) { Value = question.Points },
            new SqlParameter("@Course_ID", SqlDbType.Int) { Value = question.CourseID },

            // Output parameter for Question_ID
            new SqlParameter("@new_question_id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            }
                };

                _dbManager.ExecuteStoredProcedure(procedureName, parameters);

                // Retrieve the output value
                return Convert.ToInt32(parameters[5].Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting question into the database.", ex);
            }
        }

        public void DeleteQuestions(int id)
        {
            string procdureName = "QUESTION_DELETION";
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Question_ID", SqlDbType.Int) { Value = id }
                };
                _dbManager.ExecuteStoredProcedure(procdureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Questions from the database.", ex);
            }
        }
        public void UpdateQuestions(QuestionsDTO question)
        {
            string procdureName = "QUESTION_UPDATE";
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Question_ID", SqlDbType.Int) { Value = question.QuestionID },
                    new SqlParameter("@Question", SqlDbType.VarChar) { Value = question.Question },
                    new SqlParameter("@correct_ans", SqlDbType.VarChar) { Value = question.Answer },
                    new SqlParameter("@Type", SqlDbType.VarChar) { Value = question.Type },
                    new SqlParameter("@Points", SqlDbType.Int) { Value = question.Points },
                    new SqlParameter("@Course_ID", SqlDbType.Int) { Value = question.CourseID }
                };
                _dbManager.ExecuteStoredProcedure(procdureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Questions from the database.", ex);
            }
        }
    }
}