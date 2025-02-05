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
    public class ExamRepo
    {
        private readonly DBManager _dbManager;

        public ExamRepo()
        {
            _dbManager = new DBManager();
        }

        public List<ExamQuestionDetials> GetExamQuestionsWithChoices(int examID)
        {
            string procedureName = "GetExamQuestionsWithChoices";

            var parameters = new[]
            {
        new SqlParameter("@ExamID", SqlDbType.Int) { Value = examID }
    };

            try
            {
                // Execute the stored procedure using your database manager.
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);

                // Convert the DataTable to a list of ExamQuestion objects.
                return ConvertToExamQuestionList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving exam questions from the database.", ex);
            }
        }
        private List<ExamQuestionDetials> ConvertToExamQuestionList(DataTable dataTable)
        {
            var examQuestions = new List<ExamQuestionDetials>();

            // Group rows by Question_ID to aggregate choices for each question.
            var groupedRows = dataTable.AsEnumerable()
                                       .GroupBy(row => row.Field<int>("Question_ID"));

            foreach (var group in groupedRows)
            {
                DataRow firstRow = group.First();

                var examQuestion = new ExamQuestionDetials
                {
                    ExamId= firstRow.Field<int?>("Exam_ID"),
                    QuestionId = firstRow.Field<int?>("Question_ID"),
                    Question = firstRow.Field<string>("Question"),
                    CorrectAns = firstRow.Field<string>("Correct_Ans"),
                    PointsEdit = firstRow.Field<int?>("Points_Edit"),
                    Type = firstRow.Field<string>("Type"),
                    Points = firstRow.Field<int?>("Points"),
                    CourseId = firstRow.Field<int?>("Course_ID"),
                    Choices = group
                        .Where(r => r["Choice"] != DBNull.Value)
                        .Select(r => r.Field<string>("Choice"))
                        .ToList()
                };

                examQuestions.Add(examQuestion);
            }

            return examQuestions;
        }

        public List<InstructorExamCard> GetInstructorExams(int instructorID)
        {
            string procedureName = "GetInstructorExams";

            var parameters = new[]
            {
                new SqlParameter("@InstructorID", SqlDbType.Int) { Value = instructorID }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToExamList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving exams from the database.", ex);
            }
        }

      
        private List<InstructorExamCard> ConvertToExamList(DataTable table)
        {
            List<InstructorExamCard> exams = new List<InstructorExamCard>();

            foreach (DataRow row in table.Rows)
            {
                exams.Add(new InstructorExamCard
                {
                    ExamID = row["Exam_ID"] != DBNull.Value ? Convert.ToInt32(row["Exam_ID"]) : 0,
                    CourseName = row["Course_Name"] != DBNull.Value ? row["Course_Name"].ToString() : "Unknown",
                    ExamDate = row["Exam_Date"] != DBNull.Value ? Convert.ToDateTime(row["Exam_Date"]) : DateTime.MinValue,
                    StartTime = row["StartTime"] != DBNull.Value ? TimeSpan.Parse(row["StartTime"].ToString()) : TimeSpan.Zero,
                    EndTime = row["EndTime"] != DBNull.Value ? TimeSpan.Parse(row["EndTime"].ToString()) : TimeSpan.Zero,
                     TFnum= (row["No_TF"] != DBNull.Value ? Convert.ToInt32(row["No_TF"]) : 0) ,
                    MCQnum =   (row["No_MCQ"] != DBNull.Value ? Convert.ToInt32(row["No_MCQ"]) : 0),
                    MaxMarks = row["Max_Marks"] != DBNull.Value ? Convert.ToInt32(row["Max_Marks"]) : 0
                });
            }

            return exams;
        }


        public List<ExamDTO> GetExams(int? ExamID)
        {
            string procedureName = "EXAM_SELECTION";
            DataTable result;
            var parameters = ExamID.HasValue
            ? new[] { new SqlParameter("@Exam_id", SqlDbType.Int) { Value = ExamID.Value } }
            : new[] { new SqlParameter("@Exam_id", SqlDbType.Int) { Value = DBNull.Value } };
            try
            {
                result = _dbManager.ExecuteStoredProcedure(procedureName, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Exams from the database.", ex);
            }

            result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            var exams = new List<ExamDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                var exam = new ExamDTO
                {
                    id = dataRow.Field<int>("Exam_ID"),
                    crs_id = dataRow.Field<int>("Course_ID"),
                    ins_id = dataRow.Field<int>("Ins_ID"),
                    Exam_Date = dataRow.Field<DateTime>("Exam_Date"),
                    Start_Time = dataRow.Field<TimeSpan>("StartTime"),
                    End_Time = dataRow.Field<TimeSpan>("EndTime"),
                    Number_of_TF = dataRow.Field<int>("No_TF"),
                    Number_of_MCQ = dataRow.Field<int>("No_MCQ"),
                    Max_Marks = dataRow.Field<int>("Max_Marks")
                };
                exams.Add(exam);
            }
            return exams;
        }
  
        public void DeleteExam(int exam_id)
        {
            string procedureName = "EXAM_DELETION";
            var parameters = new[] { new SqlParameter("Exam_ID", SqlDbType.Int) { Value = exam_id } };
            try
            {
                _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Deletion Error, Cann't delete Exam from the database.", ex);
            }
        }

        public void UpdateExam(ExamDTO exam)
        {
            string procedureName = "EXAM_UPDATE";
            var parameters = new[]
            {
                new SqlParameter("@ID", SqlDbType.Int) { Value = exam.ins_id },
                new SqlParameter("@Instructor_id", SqlDbType.Int) { Value = exam.ins_id },
                new SqlParameter("@Crs_id", SqlDbType.Int) { Value = exam.crs_id },
                new SqlParameter("@Exam_Date", SqlDbType.Date) { Value = exam.Exam_Date },
                new SqlParameter("@Start_Time", SqlDbType.Time) { Value = exam.Start_Time },
                new SqlParameter("@End_Time", SqlDbType.Time) { Value = exam.End_Time },
                new SqlParameter("@TF_NUM", SqlDbType.Int) { Value = exam.Number_of_TF },
                new SqlParameter("@MCQ_NUM", SqlDbType.Int) { Value = exam.Number_of_MCQ },
                new SqlParameter("@Max_marks", SqlDbType.Int) { Value = (object)exam.Max_Marks ?? DBNull.Value },
            };
            try
            {
                _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Udate Error, Cann't update Exam info.", ex);
            }

        }
        public void Exam_Generation(String CRS_NAME, int TF_NUM, int MCQ_NUM, DateTime DATE, TimeSpan ST, TimeSpan ET, int? INS_ID)
        {
            string procedureName = "EXAM_GENERATION";
            var parameters = new[]
            {
                new SqlParameter("@CRS_NAME", SqlDbType.VarChar) { Value = CRS_NAME },
                new SqlParameter("@TF_NUM", SqlDbType.Int) { Value = TF_NUM },
                new SqlParameter("@MCQ_NUM", SqlDbType.Int) { Value = MCQ_NUM },
                new SqlParameter("@DTE", SqlDbType.Date) { Value = DATE },
                new SqlParameter("@ST", SqlDbType.Time) { Value = ST },
                new SqlParameter("@ET", SqlDbType.Time) { Value = ET },
                new SqlParameter("@INS_ID", SqlDbType.Int) { Value = INS_ID }
            };
            try
            {
                _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Generation Error, Cann't generate Exam.", ex);
            }
        }
        public void Exam_Correction(int Exam_ID,string studentName)
        {
            string procedureName = "EXAM_CORRECTION";
            var parameters = new[]
            {
                new SqlParameter("@Exam_ID", SqlDbType.Int) { Value = Exam_ID },
                new SqlParameter("@Student_Name", SqlDbType.VarChar) { Value = studentName }
            };
            try
            {
                _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Correction Error, Cann't correct Exam.", ex);
            }
        }
    }
}