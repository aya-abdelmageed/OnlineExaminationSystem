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
        public CourseRepo()
        {
            _dbManager = new DBManager();
        }
        public List<CourseDTO> GetCourses(int? Course_ID)
        {
            string procedureName = "COURSE_VIEW";
            var parameters = new[] { new SqlParameter("Course_ID", SqlDbType.Int) { Value = (object)Course_ID ?? DBNull.Value } };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                if (result.Rows.Count == 0)
                {
                    return new List<CourseDTO>(null); // Return empty list instead of null
                }

                return ConvertToCourseList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Courses from the database.", ex);
            }
        }


        // Search Course by Name
        public List<CourseDTO> SearchCourseByName(string courseName)
        {
            string procedureName = "SearchCourse_Name";
            var parameters = new[]
            {
                new SqlParameter("@Course_Name", SqlDbType.VarChar)
                {
                    Value = string.IsNullOrEmpty(courseName) ? (object)DBNull.Value : courseName
                }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToCourseList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching course by name.", ex);
            }
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
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Courses from the database.", ex);
            }
        }
        public void DeleteCourses(int id) { 
            string procdureName = "COURSE_DELETE";
            DataTable reslut;
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Course_ID",SqlDbType.Int) { Value = id }
                };
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, parameters);
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
                reslut = _dbManager.ExecuteStoredProcedure(procdureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Courses from the database.", ex);
            }
            return 1;
        }



        // Convert DataTable to List of CourseDTO
        private List<CourseDTO> ConvertToCourseList(DataTable table)
        {
            var courses = new List<CourseDTO>();

            foreach (DataRow row in table.Rows)
            {
                var course = new CourseDTO
                {
                    ID = row.Field<int>("Course_ID"),
                    Name = row.Field<string>("Course_Name"),
                };
                courses.Add(course);
            }
            return courses;
        }
    }
}
