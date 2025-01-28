using DataAccess;
using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Data;

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

            var instructors = new List<InstructorDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                var instructor = new InstructorDTO
                {
                    InstructorId = row.Field<int>("INS_ID"), 
                    FirstName = row.Field<string>("FName"),   
                    LastName = row.Field<string>("LName"),   
                    Email = row.Field<string>("Email"),          
                };

                instructors.Add(instructor); 
            }

            return instructors;
        }
    }
}
