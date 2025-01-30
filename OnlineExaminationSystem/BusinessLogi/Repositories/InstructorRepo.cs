using DataAccess;
using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessLogi.DTO;

namespace BusinessLogic.Repositories
{
    public class InstructorRepo
    {
        private readonly DBManager _dbManager;

        public InstructorRepo(DBManager dbManager)
        {
            _dbManager = dbManager; 
        }

        public List<InstructorDTO> GetInstructors()
        {
            string procedureName = "INSTRUCTOR_VIEW";
            DataTable dataTable;

            try
            {
                dataTable = _dbManager.ExecuteStoredProcedure(procedureName, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving instructors from the database.", ex);
            }

            List<InstructorDTO> instructors = new List<InstructorDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                InstructorDTO instructor = new InstructorDTO
                {
                    InstructorId = row.Field<int>("INS_ID"),
                    FirstName = row.Field<string>("FName"),
                    LastName = row.Field<string>("LName"),
                    Email = row.Field<string>("Email"),
                    MName = row.Field<string>("MName"),
                    age = row.Field<int>("Age"),
                    Gender = row.Field<string>("gender")
                };
                    instructors.Add(instructor);
            }
            return instructors;
        }
        public void InsertInstructor(InstructorDTO instructor)
        {
            string procedureName = "INSTRUCTOR_INSERT";
            DataTable result;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@FName", SqlDbType.VarChar) { Value = instructor.FirstName },
                    new SqlParameter("@MName", SqlDbType.VarChar) { Value = instructor.MName },
                    new SqlParameter("@LName", SqlDbType.VarChar) { Value = instructor.LastName },
                    new SqlParameter("@Email", SqlDbType.VarChar) { Value = instructor.Email },
                    new SqlParameter("@Gender", SqlDbType.VarChar) { Value = instructor.Gender },
                    new SqlParameter("@Salary", SqlDbType.Int) { Value = instructor.Salary },
                    new SqlParameter("@Age", SqlDbType.Int) { Value = instructor.age }

                };
                result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting instructor into the database.", ex);
            }
        }
    }
}
