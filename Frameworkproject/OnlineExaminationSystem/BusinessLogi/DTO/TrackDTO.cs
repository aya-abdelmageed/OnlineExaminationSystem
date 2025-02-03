using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.DTO
{
    public class TrackDTO
    {
        public int TrackID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Track_ID { get; internal set; }
    }
}
