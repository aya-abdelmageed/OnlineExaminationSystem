using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class ExamQuestionsStudentDTO
    {
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int QuestionID { get; set; }
        public string Answer { get; set; }
        public int Score { get; set; }
    }
}
