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
        public StudentExamRepo()
        {
            _dbManager = new DBManager();
        }
        public List<StudentExamDetialsDTO> GetStudentExamDetails(int studentID, int examID)
        {
            string procedureName = "GetExamDetailsForStudent";

            var parameters = new[]
            {
                new SqlParameter("@Exam_ID", SqlDbType.Int) { Value = examID },
                new SqlParameter("@Student_ID", SqlDbType.Int) { Value = studentID }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToStudentExamDTO(result , examID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving exam details for the student.", ex);
            }
        }

        private List<StudentExamDetialsDTO> ConvertToStudentExamDTO(DataTable table, int examId)
        {
            var examDictionary = new Dictionary<int, StudentExamDetialsDTO>();
            var questionDictionary = new Dictionary<int, StudentExamQuestionDetialsDTO>();

            foreach (DataRow row in table.Rows)
            {
                int questionID = Convert.ToInt32(row["Question_ID"]);
                string choiceText = row["Choice_Text"] as string;
                string studentAnswer = row["Student_Answer"] != DBNull.Value ? row["Student_Answer"].ToString() : null;
                bool? isCorrect = row["Is_Correct"] != DBNull.Value ? Convert.ToBoolean(row["Is_Correct"]) : (bool?)null;

                // Ensure the Exam exists in dictionary
                if (!examDictionary.ContainsKey(examId))
                {
                    examDictionary[examId] = new StudentExamDetialsDTO
                    {
                        ExamID = examId,
                        Questions = new List<StudentExamQuestionDetialsDTO>()
                    };
                }

                // Ensure the Question exists in dictionary
                if (!questionDictionary.ContainsKey(questionID))
                {
                    var questionDTO = new StudentExamQuestionDetialsDTO
                    {
                        QuestionID = questionID,
                        QuestionText = row["Question"] as string,
                        Type = row["Type"] as string,
                        Points = row["Points"] != DBNull.Value ? Convert.ToInt32(row["Points"]) : 0,
                        AdjustedPoints = row["Adjusted_Points"] != DBNull.Value ? Convert.ToInt32(row["Adjusted_Points"]) : 0,
                        StudentAnswer = studentAnswer,
                        IsCorrect = isCorrect,
                        Choices = new List<string>() // Initialize Choices list
                    };

                    questionDictionary[questionID] = questionDTO;
                    examDictionary[examId].Questions.Add(questionDTO); // Add question to exam
                }

                // Add choice to the question
                if (!string.IsNullOrEmpty(choiceText))
                {
                    questionDictionary[questionID].Choices.Add(choiceText);
                }
            }

            return examDictionary.Values.ToList();
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
        public List<StudentExamCardDTO> GetStudentExamsCard(int studentID)
        {
            string procedureName = "GetStudentExamCards";

            var parameters = new[]
            {
                new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentID }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToExamList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving exams for the student.", ex);
            }
        }

        // Helper method to convert DataTable to List<ExamDTO>
        private List<StudentExamCardDTO> ConvertToExamList(DataTable dt)
        {
            List<StudentExamCardDTO> exams = new List<StudentExamCardDTO>();

            foreach (DataRow row in dt.Rows)
            {
                exams.Add(new StudentExamCardDTO
                {
                    Exam_ID = row["Exam_ID"] != DBNull.Value ? Convert.ToInt32(row["Exam_ID"]) : 0,
                    Exam_Date = row["Exam_Date"] != DBNull.Value ? Convert.ToDateTime(row["Exam_Date"]) : DateTime.MinValue,
                    StartTime = row["StartTime"] != DBNull.Value ? row["StartTime"].ToString() : string.Empty,
                    EndTime = row["EndTime"] != DBNull.Value ? row["EndTime"].ToString() : string.Empty,
                    No_TF = row["No_TF"] != DBNull.Value ? Convert.ToInt32(row["No_TF"]) : 0,
                    No_MCQ = row["No_MCQ"] != DBNull.Value ? Convert.ToInt32(row["No_MCQ"]) : 0,
                    Max_Marks = row["Max_Marks"] != DBNull.Value ? Convert.ToInt32(row["Max_Marks"]) : 0,
                    Course_Name = row["Course_Name"] != DBNull.Value ? row["Course_Name"].ToString() : string.Empty,
                    Track_Name = row["Track_Name"] != DBNull.Value ? row["Track_Name"].ToString() : string.Empty,
                    Instructor_Name = row["Instructor_Name"] != DBNull.Value ? row["Instructor_Name"].ToString() : string.Empty
                });
            }

            return exams;
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
        public List<StudentExamResultDTO> GetStudentExamResults(int studentId, int examId)
        {
            string procedureName = "GetStudentExamResults";

            var parameters = new[]
            {
                new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentId },
                new SqlParameter("@ExamID", SqlDbType.Int) { Value = examId }
           };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToStudentExamResultList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving student exam results from the database.", ex);
            }
        }

        private List<StudentExamResultDTO> ConvertToStudentExamResultList(DataTable dataTable)
        {
            List<StudentExamResultDTO> results = new List<StudentExamResultDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                StudentExamResultDTO result = new StudentExamResultDTO
                {
                    StudentID = row.Field<int>("Student_ID"),
                    ExamID = row.Field<int>("Exam_ID"),
                    Grade = row.Field<int>("Grade"),
                    CourseName= row.Field<string>("Course_Name"),
                    CorrectQuestions = row.Field<int>("Correct_Questions"),
                    WrongQuestions = row.Field<int>("Wrong_Questions"),
                    TotalMarks = row.Field<int>("Total_Marks")
                };

                results.Add(result);
            }

            return results;
        }


    }
}
