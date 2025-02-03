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
    public class StudentRepo
    {
        private readonly DBManager _dbManager;
        public StudentRepo()
        {
            _dbManager = new DBManager();   
        }
        public List<StudentDTO> GetStudents(int? id)
        {
            string procedureName = "STUDENT_SELECTION";
            DataTable dt;
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@student_id", SqlDbType.Int) { Value = (object)id ?? DBNull.Value }
                };
                dt = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Students from the database.", ex);
            }
            var students = new List<StudentDTO>();
            foreach (DataRow dataRow in dt.Rows)
            {
                var student = new StudentDTO
                {
                    StudentID = dataRow.Field<int>("Student_ID"),
                    Gender = dataRow.Field<string>("Gender"),
                    FName = dataRow.Field<string>("FName"),
                    MName = dataRow.Field<string>("MName"),
                    LName = dataRow.Field<string>("LName"),
                    Phone = dataRow.Field<string>("Phone"),
                    Birthdate = dataRow.Field<DateTime>("Birthdate"),
                    trackID = dataRow.Field<int>("Track_ID")
                };
                students.Add(student);
            }
            return students;
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
    }
}
