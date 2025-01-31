using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class ExamDTO
    {
        public int id { get; set; } 
        public int crs_id { get; set; }
        public int ins_id { get; set; }
        public DateTime Exam_Date { get; set; }
        public TimeSpan Start_Time { get; set; }
        public TimeSpan End_Time { get; set; }
        public int Number_of_TF {  get; set; }
        public int Number_of_MCQ { get; set; }
        public int Max_Marks {  get; set; }
    }
}
