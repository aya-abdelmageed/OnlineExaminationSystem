using BusinessLogi.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogi.Repositories
{
    public class TrackRepo
    {
        private readonly DBManager _dbManager;

        public TrackRepo()
        {
            _dbManager = new DBManager();
        }

        public List<TrackDTO> GetTracks(int? trackID = null, string trackName = null)
        {
            try
            {
                var parameters = new List<SqlParameter>();

                if (trackID.HasValue)
                    parameters.Add(new SqlParameter("@TrackID", SqlDbType.Int) { Value = trackID.Value });

                if (!string.IsNullOrEmpty(trackName))
                    parameters.Add(new SqlParameter("@Track_Name", SqlDbType.VarChar) { Value = trackName });

                DataTable resultTable = _dbManager.ExecuteStoredProcedure("SearchTrack_Name", parameters.ToArray());

                List<TrackDTO> tracks = new List<TrackDTO>();
                foreach (DataRow row in resultTable.Rows)
                {
                    tracks.Add(new TrackDTO
                    {
                        TrackID = Convert.ToInt32(row["TrackID"]),
                        Name = row["Track_Name"].ToString(),
                        Department = row["Department"].ToString()
                    });
                }
                return tracks;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching tracks", ex);
            }
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
