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
    public class ExamTrackRepo
    {
        private readonly DBManager _dbManager;
        public ExamTrackRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
        public List<ExamTrackDTO> GetExamTracks(int? E_ID, int? T_ID)
        {
            string procedureName = "EXAM_TRACK_SELECTION";
            DataTable result;
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@E_ID", E_ID),
                    new SqlParameter("@T_ID", T_ID)
                };
                result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch
            {
                throw new Exception("Error connecting to database");
            }
            List<ExamTrackDTO> examTracks = new List<ExamTrackDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                ExamTrackDTO examTrack = new ExamTrackDTO
                {
                    ExamID = Convert.ToInt32(dataRow["ExamID"]),
                    TrackID = Convert.ToInt32(dataRow["TrackID"])
                };
                examTracks.Add(examTrack);
            }
            return examTracks;
        }
        public void InsertExamTrack(int ExamID, int TrackID)
        {
            try
            {
                string procedureName = "EXAM_TRACK_INSERTION";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ExamID", ExamID),
                    new SqlParameter("@TrackID", TrackID)
                };
                _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch
            {
                throw new Exception("Error inserting exam track");
            }
        }
        public void DeleteExamTrack(int ExamID, int TrackID)
        {
            try
            {
                string procedureName = "EXAM_TRACK_DELETION";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ExamID", ExamID),
                    new SqlParameter("@TrackID", TrackID)
                };
                _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch
            {
                throw new Exception("Error deleting exam track");
            }
        }
        public void UpdateExamTrack(int ExamID,int NewExamID, int TrackID)
        {
            try
            {
                string procedureName = "EXAM_TRACK_UPDATE";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@E_ID", ExamID),
                    new SqlParameter("@T_ID", TrackID),
                    new SqlParameter("@NEW_E_ID", NewExamID)
                };
                _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch
            {
                throw new Exception("Error updating exam track");
            }
        }
    }

}
