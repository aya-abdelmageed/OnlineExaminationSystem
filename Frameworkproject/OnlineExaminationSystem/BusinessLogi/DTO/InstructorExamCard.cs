using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class InstructorExamCard
    {
    
            public int? ExamID { get; set; }
            public string CourseName { get; set; }
            public DateTime ExamDate { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
            public int TFnum { get; set; }  
            public int MCQnum { get; set; }         
            public int MaxMarks { get; set; }
       

    }
}
