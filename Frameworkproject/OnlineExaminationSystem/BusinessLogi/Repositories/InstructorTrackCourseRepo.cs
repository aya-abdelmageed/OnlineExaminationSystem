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
    public class InstructorTrackCourseRepo
    {
        private readonly DBManager _dbManager;
        public InstructorTrackCourseRepo()
        {
            _dbManager = new DBManager();
        }
        public List<InstructorTrackCourseDTO> GetInstructorTrackCourses()
        {
            DataTable result;
            try
            {
                result = _dbManager.ExecuteStoredProcedure("INS_TRACK_COURSE_VIEW", null);
            }
            catch
            {
                throw new Exception("Error getting instructor track course");
            }
            List<InstructorTrackCourseDTO> instructorTrackCourses = new List<InstructorTrackCourseDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                InstructorTrackCourseDTO instructorTrackCourse = new InstructorTrackCourseDTO
                {
                    InstructorID = Convert.ToInt32(dataRow["InstructorID"]),
                    TrackID = Convert.ToInt32(dataRow["TrackID"]),
                    CourseID = Convert.ToInt32(dataRow["CourseID"]),
                    CourseDate = Convert.ToDateTime(dataRow["CourseDate"])
                };
                instructorTrackCourses.Add(instructorTrackCourse);
            }
            return instructorTrackCourses;
        }
        public void InsertInstructorTrackCourse(int InstructorID, int TrackID, int CourseID, DateTime CourseDate)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@InstructorID",InstructorID),
                    new SqlParameter("@TrackID",TrackID),
                    new SqlParameter("@CourseID",CourseID),
                    new SqlParameter("@CourseDate",CourseDate)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("INS_TRACK_COURSE_INSERT", parameters);
            }
            catch
            {
                throw new Exception("Error inserting instructor track course");
            }
        }
        public void DeleteInstructorTrackCourse(int InstructorID, int TrackID, int CourseID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@InstructorID",InstructorID),
                    new SqlParameter("@TrackID",TrackID),
                    new SqlParameter("@CourseID",CourseID)
                };
                _dbManager.ExecuteStoredProcedure("INS_TRACK_COURSE_DELETE", parameters);
            }
            catch
            {
                throw new Exception("Error deleting instructor track course");
            }
        }
        public void UpdateInstructorTrackCourse(int InstructorID, int TrackID, int CourseID, DateTime CourseDate)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@InstructorID",InstructorID),
                    new SqlParameter("@TrackID",TrackID),
                    new SqlParameter("@CourseID",CourseID),
                    new SqlParameter("@CourseDate",CourseDate)
                };
                _dbManager.ExecuteStoredProcedure("INS_TRACK_COURSE_UPDATE", parameters);
            }
            catch
            {
                throw new Exception("Error updating instructor track course");
            }
        }
    }
}
