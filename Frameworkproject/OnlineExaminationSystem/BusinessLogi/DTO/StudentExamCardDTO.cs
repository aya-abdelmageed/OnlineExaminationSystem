using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class StudentExamCardDTO
    {
        public int Exam_ID { get; set; }
        public DateTime Exam_Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int No_TF { get; set; }
        public int No_MCQ { get; set; }
        public int Max_Marks { get; set; }
        public string Course_Name { get; set; }
        public string Track_Name { get; set; }
        public string Instructor_Name { get; set; }
    }

}
