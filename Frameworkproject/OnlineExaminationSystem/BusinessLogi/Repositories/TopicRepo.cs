using BusinessLogi.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogi.Repositories
{
    public class TopicRepo
    {
        private readonly DBManager _dbManager;

        public TopicRepo()
        {
            _dbManager = new DBManager();
        }
        public List<TopicDTO> GetTopics()
        {
            string procedureName = "TOPIC_VIEW";
            DataTable result;
            try
            {
                result = _dbManager.ExecuteStoredProcedure(procedureName, null);
            }
            catch
            {
                throw new Exception("Error getting topics");
            }
            List<TopicDTO> topics = new List<TopicDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                TopicDTO topic = new TopicDTO
                {
                    TopicID = Convert.ToInt32(dataRow["TopicID"]),
                    Name = dataRow["Name"].ToString(),
                    CourseID = Convert.ToInt32(dataRow["CourseID"])
                };
                topics.Add(topic);
            }
            return topics;
        }
        public void InsertTopic(string Name, int CourseID)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name",Name),
                    new SqlParameter("@CourseID",CourseID)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("TOPIC_INSERT", parameters);
            }
            catch
            {
                throw new Exception("Error inserting topic");
            }
        }
        public void DeleteTopic(int TopicID)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TopicID",TopicID)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("TOPIC_DELETE", parameters);
            }
            catch
            {
                throw new Exception("Error deleting topic");
            }
        }
        public void UpdateTopic(int TopicID, string Name, int CourseID)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TopicID",TopicID),
                    new SqlParameter("@Name",Name),
                    new SqlParameter("@CourseID",CourseID)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("TOPIC_UPDATE", parameters);
            }
            catch
            {
                throw new Exception("Error updating topic");
            }
        }
    }
}
