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
        public List<StudentDTO> GetStudents(int id)
        {
            string procedureName = "STUDENT_SELECTION";
            DataTable dt;
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Student_ID", SqlDbType.Int) { Value = id }
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
                    StudentID = dataRow.Field<int>("Student ID"),
                    Gender = dataRow.Field<string>("Gender"),
                    FName = dataRow.Field<string>("First Name"),
                    MName = dataRow.Field<string>("Middle Name"),
                    LName = dataRow.Field<string>("Last Name"),
                    Phone = dataRow.Field<string>("Phone Number"),
                    Birthdate = dataRow.Field<DateTime>("Date of Birth"),
                    trackID = dataRow.Field<int>("Track")
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
                    new SqlParameter("@Gender", SqlDbType.VarChar) { Value = student.Gender },
                    new SqlParameter("@F_Name", SqlDbType.VarChar) { Value = student.FName },
                    new SqlParameter("@M_Name", SqlDbType.VarChar) { Value = student.MName },
                    new SqlParameter("@L_Name", SqlDbType.VarChar) { Value = student.LName },
                    new SqlParameter("@Student_Phone", SqlDbType.VarChar) { Value = student.Phone },
                    new SqlParameter("@Student_birthdate", SqlDbType.DateTime) { Value = student.Birthdate },
                    new SqlParameter("@Track_ID", SqlDbType.Int) { Value = student.trackID }
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
            string procdureName = "STUDENT_DELETE";
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
