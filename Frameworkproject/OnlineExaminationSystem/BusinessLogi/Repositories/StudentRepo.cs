using BusinessLogi.DTO;
using BusinessLogic.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace BusinessLogi.Repositories
{
    public class StudentRepo
    {
        private readonly DBManager _dbManager;
        public StudentRepo()
        {
            _dbManager = new DBManager();   
        }
        public List<StudentDTO> GetStudents(int? Student_ID)
        {
            string procedureName = "STUDENT_SELECTION";
            var parameters = new[] { new SqlParameter("Student_ID", SqlDbType.Int) { Value = (object)Student_ID ?? DBNull.Value } };

            try
            {
                DataTable dataTable = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                if (dataTable.Rows.Count == 0)
                {
                    return new List<StudentDTO>(null); // Return empty list instead of null
                }

                return ConvertToStudentList(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving students from the database.", ex);
            }

        }
        // Search Branch by Name
        public List<StudentDTO> SearchStudentByName(string studentName)
        {
            string procedureName = "SearchSTD_FName";
            var parameters = new[]
            {
                new SqlParameter("@FName", SqlDbType.VarChar)
                {
                    Value = string.IsNullOrEmpty(studentName) ? (object)DBNull.Value : studentName
                }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToStudentList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching student by name.", ex);
            }
        }
        public void InsertStudent(StudentDTO student)
        {
            string procdureName = "STUDENT_INSERTION";
            DataTable reslut;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Gender", SqlDbType.VarChar) { Value = student.Gender },
                    new SqlParameter("@first_name", SqlDbType.VarChar) { Value = student.FName },
                    new SqlParameter("@middle_name", SqlDbType.VarChar) { Value = student.MName },
                    new SqlParameter("@last_name", SqlDbType.VarChar) { Value = student.LName },
                    new SqlParameter("@phone_num", SqlDbType.VarChar) { Value = student.Phone },
                    new SqlParameter("@birthday", SqlDbType.DateTime) { Value = student.Birthdate },
                    new SqlParameter("@track_id", SqlDbType.Int) { Value = student.trackID }
                    };
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Students from the database.", ex);
            }
        }
        public void UpdateStudent(StudentDTO student)
        {
            string procdureName = "STUDENT_UPDATE";
            DataTable reslut;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Student_ID", SqlDbType.Int) { Value = student.StudentID },
                    new SqlParameter("@gender", SqlDbType.VarChar) { Value = student.Gender },
                    new SqlParameter("@first_name", SqlDbType.VarChar) { Value = student.FName },
                    new SqlParameter("@middle_name", SqlDbType.VarChar) { Value = student.MName },
                    new SqlParameter("@last_name", SqlDbType.VarChar) { Value = student.LName },
                    new SqlParameter("@phone_num", SqlDbType.VarChar) { Value = student.Phone },
                    new SqlParameter("@birthday", SqlDbType.DateTime) { Value = student.Birthdate },
                    new SqlParameter("@track_id", SqlDbType.Int) { Value = student.trackID }
                    };
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Students from the database.", ex);
            }
        }
        public void DeleteStudent(int studentID)
        {
            string procdureName = "STUDENT_DELETION";
            DataTable reslut;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Student_ID", SqlDbType.Int) { Value = studentID }
                };
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Students from the database.", ex);
            }
        }

        // Convert DataTable to List of BranchDTO
        private List<StudentDTO> ConvertToStudentList(DataTable table)
        {
            var students = new List<StudentDTO>();

            foreach (DataRow row in table.Rows)
            {
                var student = new StudentDTO
                {
                    StudentID = row.Field<int>("Student_ID"),
                    Gender = row.Field<string>("Gender"),
                    FName = row.Field<string>("FName"),
                    MName = row.Field<string>("MName"),
                    LName = row.Field<string>("LName"),
                    Phone = row.Field<string>("Phone"),
                    Birthdate = row.Field<DateTime>("Birthdate"),
                    trackID = row.Field<int>("Track_ID"),
                };
                students.Add(student);
            }
            return students;
        }
    }
}
