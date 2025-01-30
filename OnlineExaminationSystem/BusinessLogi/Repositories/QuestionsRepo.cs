using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.Repositories
{
    public class QuestionsRepo
    {
        private readonly DBManager _dbManager;

        public QuestionsRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
    }
}
