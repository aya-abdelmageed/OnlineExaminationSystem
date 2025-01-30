using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class InstructorTrackCourseDTO
    {
        public int InstructorID { get; set; }
        public int TrackID { get; set; }
        public int CourseID { get; set; }
        public DateTime CourseDate { get; set; }
    }
}
