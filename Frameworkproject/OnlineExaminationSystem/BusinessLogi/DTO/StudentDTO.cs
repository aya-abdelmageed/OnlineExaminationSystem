using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string Gender { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public int trackID { get; set; }
    }
}
