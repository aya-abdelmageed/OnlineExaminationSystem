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
            _dbManager = dbManager; // Injected DBManager instance
        }

        public List<InstructorDTO> GetInstructors()
        {
            string procedureName = "INSTRUCTOR_VIEW"; // Stored procedure name
            DataTable dataTable;

            try
            {
                // Call the stored procedure using DBManager
                dataTable = _dbManager.ExecuteStoredProcedure(procedureName, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving instructors from the database.", ex);
            }

            // Map the resulting DataTable to a list of InstructorDTO
            var instructors = new List<InstructorDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                var instructor = new InstructorDTO
                {
                    InstructorId = row.Field<int>("INS_ID"), // Assuming InstructorId is of type int
                    FirstName = row.Field<string>("FName"),   // Assuming FirstName is a string
                    LastName = row.Field<string>("LName"),     // Assuming LastName is a string
                    Email = row.Field<string>("Email"),           // Assuming Email is a string
                    // Add other fields from the DataTable here as needed
                };

                instructors.Add(instructor); // Add mapped InstructorDTO to the list
            }

            return instructors;
        }
    }
}
