using AutoMapper;
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

        // Constructor using Dependency Injection for DBManager and AutoMapper
        public InstructorRepo(DBManager dbManager)
        {
            _dbManager = dbManager; // Injected DBManager instance
        }

        // Method to retrieve instructors using a stored procedure
        //public List<InstructorDTO> GetInstructors()
        //{
        //    string procedureName = "INSTRUCTOR_VIEW"; // Stored procedure name
        //    DataTable dataTable;

        //    try
        //    {
        //        // Call the stored procedure using DBManager
        //        dataTable = _dbManager.ExecuteStoredProcedure(procedureName, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error retrieving instructors from the database.", ex);
        //    }

        //    // Map the resulting DataTable to a list of InstructorDTO
        //    var instructors = new List<InstructorDTO>();
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        try
        //        {
        //            // Use AutoMapper to map each DataRow to InstructorDTO
        //            var instructor = _mapper.Map<InstructorDTO>(row);
        //            instructors.Add(instructor);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error mapping DataRow to InstructorDTO.", ex);
        //        }
        //    }

        //    return instructors;
        //}
    }
}
