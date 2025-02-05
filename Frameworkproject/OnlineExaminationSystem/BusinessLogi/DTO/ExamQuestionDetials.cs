using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class ExamQuestionDetials
    {
            public int? ExamId { get; set; }
            public int? QuestionId { get; set; }
            public string Question { get; set; }
            public string CorrectAns { get; set; }
            public int? PointsEdit { get; set; }
            public string Type { get; set; }
            public int? Points { get; set; }
            public int? CourseId { get; set; }
            public List<string> Choices { get; set; } = new List<string>();
       

    }
}
