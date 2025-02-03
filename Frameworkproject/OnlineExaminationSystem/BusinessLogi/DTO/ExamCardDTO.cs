
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
   public  class ExamCardDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExamDate { get; set; }
        public string StartTime { get; set; }
        public  string  EndTime {get;set; }
        public int NoTF { get; set; }
        public int  NoMCQ { get; set; } 
        public int MaxMarks { get; set; }        
    }
}
