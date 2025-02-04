using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
  public class StudentExamResultDTO
    {
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int Grade { get; set; }
        public string CourseName { get; set; }
        public int CorrectQuestions { get; set; }
        public int WrongQuestions { get; set; }
        public int TotalMarks { get; set; }
    }
}
