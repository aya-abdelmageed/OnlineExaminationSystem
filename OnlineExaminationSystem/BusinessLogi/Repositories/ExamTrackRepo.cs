using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.Repositories
{
    public class ExamTrackRepo
    {
        private readonly DBManager _dbManager;
        public ExamTrackRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
    }
}
