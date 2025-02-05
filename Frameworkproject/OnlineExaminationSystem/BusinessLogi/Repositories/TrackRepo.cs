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
        //get tracks by ID
        public List<TrackDTO> GetTracks(int? trackid)
        {
            DataTable resultTable;
            SqlParameter[] parameters = new[] {
                new SqlParameter("@Track_ID", SqlDbType.Int) { Value = trackid }
            };
            try
            {
                resultTable = _dbManager.ExecuteStoredProcedure("SelectAllFromTrack", parameters);
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
                    TrackID = Convert.ToInt32(row["Track_ID"]),
                    Name = row["Track_Name"].ToString(),
                    Department = row["Department"].ToString()
                };
                tracks.Add(track);
            }
            return tracks;
        }
        // Convert DataTable to List of TrackDTO
        private List<TrackDTO> ConvertToTrackList(DataTable table)
        {
            var tracks = new List<TrackDTO>();

            foreach (DataRow row in table.Rows)
            {
                var track = new TrackDTO
                {
                    TrackID = row.Field<int>("Track_ID"),
                    Name = row.Field<string>("Track_Name"),
                    Department = row.Field<string>("Department"),
                };
                tracks.Add(track);
            }
            return tracks;
        }


        // Search Track by Name
        public List<TrackDTO> SearchTrackByName(string trackName)
        {
            string procedureName = "SearchTrack_Name";
            var parameters = new[]
            {
                new SqlParameter("@Track_Name", SqlDbType.VarChar)
                {
                    Value = string.IsNullOrEmpty(trackName) ? (object)DBNull.Value : trackName
                }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToTrackList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching branch by name.", ex);
            }
        }
        public void InsertTrack(TrackDTO track)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Track_Name", SqlDbType.VarChar) { Value = track.Name },
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
                    new SqlParameter("@Track_ID", SqlDbType.Int) { Value = track.TrackID },
                    new SqlParameter("@Track_Name", SqlDbType.VarChar) { Value = track.Name },
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
                    new SqlParameter("@Track_ID", SqlDbType.Int) { Value = trackID }
                };
                _dbManager.ExecuteNonQuery("DeleteFromTrack", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting track", ex);
            }
        }
    }
}