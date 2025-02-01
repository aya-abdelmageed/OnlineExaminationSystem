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
    public class TrackBranchRepo
    {
        private readonly DBManager _dbManager;
        public TrackBranchRepo()
        {
            _dbManager = new DBManager();
        }
        public List<TrackBranchDTO> GetTrackBranches()
        {
            DataTable result;
            try
            {
                result = _dbManager.ExecuteStoredProcedure("SelectAllFromTrack_Branch", null);
            }
            catch
            {
                throw new Exception("Error getting track branch");
            }
            List<TrackBranchDTO> trackBranches = new List<TrackBranchDTO>();
            foreach(DataRow dataRow in result.Rows)
            {
                TrackBranchDTO track = new TrackBranchDTO
                {
                    TrackID = Convert.ToInt32(dataRow["TrackID"]),
                    BranchID = Convert.ToInt32(dataRow["BranchID"])
                };
                trackBranches.Add(track);
            }
            return trackBranches;
        }
        public void InsertTrackBranch(int TrackID,int BranchID)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrackID",TrackID),
                    new SqlParameter("@BranchID",BranchID)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("InsertTrack_Branch", parameters);
            }
            catch
            {
                throw new Exception("Error inserting track branch");
            }
        }
        public void DeleteTrackBranch(int TrackID, int BranchID)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrackID",TrackID),
                    new SqlParameter("@BranchID",BranchID)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("DeleteTrack_Branch", parameters);
            }
            catch
            {
                throw new Exception("Error deleting track branch");
            }
        }
        public void UpdateTrackBranch(int TrackID, int BranchID)
        {
            try
            {
                DataTable dataTable;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrackID",TrackID),
                    new SqlParameter("@BranchID",BranchID)
                };
                dataTable = _dbManager.ExecuteStoredProcedure("UpdateTrack_Branch", parameters);
            }
            catch
            {
                throw new Exception("Error updating track branch");
            }
        }
    }
}
