using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class QuestionsDTO
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public int Points { get; set; }
        public int CourseID { get; set; }
    }
}
