using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.Repositories
{
    public class ExamQuestionStudentRepo
    {
        private readonly DBManager _dbManager;

        public ExamQuestionStudentRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
    }
}
