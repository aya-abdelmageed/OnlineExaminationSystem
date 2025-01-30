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
    public class CourseRepo
    {
        private readonly DBManager _dbManager;
        public CourseRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
        public List<CourseDTO> GetCourses()
        {
            string procedureName = "COURSE_VIEW";
            DataTable result;
            try
            {
                result = _dbManager.ExecuteStoredProcedure(procedureName, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Courses from the database.", ex);
            }
            var courses = new List<CourseDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                var course = new CourseDTO
                {
                    ID = dataRow.Field<int>("Course_ID"),
                    Name = dataRow.Field<string>("Course_Name"),
                };
                courses.Add(course);
            }
            return courses;
        }
        public void InsertCourses(CourseDTO course)
        {
            string procdureName = "COURSE_INSERT";
            DataTable reslut;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Course_Name", SqlDbType.VarChar) { Value = course.Name }
                };
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Courses from the database.", ex);
            }
        }
        public void DeleteCourses() { 
            string procdureName = "COURSE_DELETE";
            DataTable reslut;
            try
            {
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Courses from the database.", ex);
            }
        }
        public int updateCourses(CourseDTO course)
        {
            string procdureName = "COURSE_UPDATE";
            DataTable reslut;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Course_ID", SqlDbType.Int) { Value = course.ID },
                    new SqlParameter("@Course_Name", SqlDbType.VarChar) { Value = course.Name }
                };
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Courses from the database.", ex);
            }
            return 1;
        }
    }
}
