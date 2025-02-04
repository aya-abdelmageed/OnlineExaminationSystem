using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class StudentExamQuestionDetialsDTO
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string Type { get; set; }
        public int Points { get; set; }
        public int AdjustedPoints { get; set; }
        public List<string> Choices { get; set; } = new List<string>();
        public string StudentAnswer { get; set; }
        public bool? IsCorrect { get; set; } // Nullable to handle unanswered questions
    }

}
