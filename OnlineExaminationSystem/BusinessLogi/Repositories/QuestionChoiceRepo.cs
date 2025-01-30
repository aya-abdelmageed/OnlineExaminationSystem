using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.Repositories
{
    public class QuestionChoiceRepo
    {
        private readonly DBManager _dbManager;
        public QuestionChoiceRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
    }
}
