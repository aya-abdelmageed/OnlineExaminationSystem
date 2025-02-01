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
    public class TrackRepo
    {
        private readonly DBManager _dbManager;
        public TrackRepo()
        {
            _dbManager = new DBManager();
        }
        public List<TrackDTO> GetTracks()
        {
            DataTable resultTable;
            try
            {
                resultTable = _dbManager.ExecuteStoredProcedure("GetTracks", null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting tracks", ex); 
            }
            List<TrackDTO> tracks = new List<TrackDTO>();
            foreach (DataRow row in resultTable.Rows)
            {
                TrackDTO track = new TrackDTO
                {
                    TrackID = Convert.ToInt32(row["TrackID"]),
                    Name = row["Name"].ToString(),
                    Department = row["Department"].ToString()
                };
                tracks.Add(track);
            }
            return tracks;
        }
        public void InsertTrack(TrackDTO track)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", SqlDbType.VarChar) { Value = track.Name },
                    new SqlParameter("@Department", SqlDbType.VarChar) { Value = track.Department }
                };
                _dbManager.ExecuteNonQuery("InsertTrack", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting track", ex);
            }
        }
        public void UpdateTrack(TrackDTO track)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrackID", SqlDbType.Int) { Value = track.TrackID },
                    new SqlParameter("@Name", SqlDbType.VarChar) { Value = track.Name },
                    new SqlParameter("@Department", SqlDbType.VarChar) { Value = track.Department }
                };
                _dbManager.ExecuteNonQuery("UpdateTrack", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating track", ex);
            }
        }
        public void DeleteTrack(int trackID)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrackID", SqlDbType.Int) { Value = trackID }
                };
                _dbManager.ExecuteNonQuery("DeleteTrack", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting track", ex);
            }
        }
    }
}
