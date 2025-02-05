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

        public InstructorRepo()
        {
            _dbManager =  new DBManager();
        }

        public List<InstructorDTO> GetInstructors(int? INS_ID)
        {
            string procedureName = "INSTRUCTOR_VIEW";
            var parameters = new[] { new SqlParameter("INS_ID", SqlDbType.Int) { Value = (object)INS_ID ?? DBNull.Value } };

            try
            {
               DataTable dataTable = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                if (dataTable.Rows.Count == 0)
                {
                    return new List<InstructorDTO>(null); // Return empty list instead of null
                }

                return ConvertToInstructorList(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving instructors from the database.", ex);
            }

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
                    new SqlParameter("@Salary", SqlDbType.Decimal) { Value = instructor.Salary },
                    new SqlParameter("@Age", SqlDbType.Int) { Value = instructor.age }

                };
                result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting instructor into the database.", ex);
            }
        }

        // Search Instructor by Name
        public List<InstructorDTO> SearchInstructorByName(string InstructorName)
        {
            string procedureName = "SearchINS_FName";
            var parameters = new[]
            {
                new SqlParameter("@FName", SqlDbType.VarChar)
                {
                    Value = string.IsNullOrEmpty(InstructorName) ? (object)DBNull.Value : InstructorName
                }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToInstructorList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching instructor by name.", ex);
            }
        }
        public void DeleteInstructor(int id)
        {
            string procedureName = "INSTRUCTOR_DELETE";
            DataTable result;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@INS_ID", SqlDbType.Int) { Value = id }
                };
                result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting instructor from the database.", ex);
            }
        }
        public void UpdateInstructor(InstructorDTO instructor)
        {
            string procedureName = "INSTRUCTOR_UPDATE";
            DataTable result;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@INS_ID", SqlDbType.Int) { Value = instructor.InstructorId },
                    new SqlParameter("@FName", SqlDbType.VarChar) { Value = instructor.FirstName },
                    new SqlParameter("@MName", SqlDbType.VarChar) { Value = instructor.MName },
                    new SqlParameter("@LName", SqlDbType.VarChar) { Value = instructor.LastName },
                    new SqlParameter("@Email", SqlDbType.VarChar) { Value = instructor.Email },
                    new SqlParameter("@Gender", SqlDbType.VarChar) { Value = instructor.Gender },
                    new SqlParameter("@Salary", SqlDbType.Decimal) { Value = instructor.Salary },
                    new SqlParameter("@Age", SqlDbType.Int) { Value = instructor.age }
                };
                result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating instructor in the database.", ex);
            }

        }

        private List<InstructorDTO> ConvertToInstructorList(DataTable table)
        {
            var instructors = new List<InstructorDTO>();

            foreach (DataRow row in table.Rows)
            {
                var instructor = new InstructorDTO
                {
                    InstructorId = row.Field<int>("INS_ID"),
                    FirstName = row.Field<string>("FName"),
                    LastName = row.Field<string>("LName"),
                    Email = row.Field<string>("Email"),
                    MName = row.Field<string>("MName"),
                    age = row.Field<int>("Age"),
                    Gender = row.Field<string>("gender"),
                    Salary = (double)row.Field<decimal>("Salary")
                };
                instructors.Add(instructor);
            }
            return instructors;
        }
    }
}
