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
        public int InsertExam(ExamDTO exam)
        {
            string procedureName = "EXAM_INSERTION";
            var parameters = new[]
            {
                new SqlParameter("@Instructor_id", SqlDbType.Int) { Value = exam.ins_id },
                new SqlParameter("@Crs_id", SqlDbType.Int) { Value = exam.crs_id },
                new SqlParameter("@Exam_Date", SqlDbType.Date) { Value = exam.Exam_Date },
                new SqlParameter("@Start_Time", SqlDbType.Time) { Value = exam.Start_Time },
                new SqlParameter("@End_Time", SqlDbType.Time) { Value = exam.End_Time },
                new SqlParameter("@TF_NUM", SqlDbType.Int) { Value = exam.Number_of_TF },
                new SqlParameter("@MCQ_NUM", SqlDbType.Int) { Value = exam.Number_of_MCQ },
                new SqlParameter("@Max_marks", SqlDbType.Int) { Value = (object)exam.Max_Marks ?? DBNull.Value },
                new SqlParameter("@New_Exam_ID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };
            try
            {
                _dbManager.ExecuteNonQuery(procedureName, parameters);
                exam.id = (int)parameters[parameters.Length - 1].Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Insertion Error, Cann't add Exam to the database.", ex);
            }
            return exam.id;
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