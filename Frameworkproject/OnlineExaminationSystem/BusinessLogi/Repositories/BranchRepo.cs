using BusinessLogi.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogi.Repositories
{
    public class BranchRepo
    {
        private readonly DBManager _dbManager;

        public BranchRepo()
        {
            _dbManager = new DBManager();
        }

        // Get Branches by ID (nullable)
        public List<BranchDTO> GetBranches(int? Branch_ID)
        {
            string procedureName = "SelectAllFromBranch";

            var parameters = new[]{ new SqlParameter("@Branch_ID", SqlDbType.Int) {Value = Branch_ID} };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToBranchList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving branches from the database.", ex);
            }
        }

        // Insert a new Branch
        public int InsertBranch(BranchDTO branch)
        {
            string procedureName = "InsertBranch";
            var parameters = new[]
            {
                new SqlParameter("@Branch_Name", SqlDbType.VarChar) { Value = branch.Name },
                new SqlParameter("@Location", SqlDbType.VarChar) { Value = branch.Location },
                new SqlParameter("@Phone", SqlDbType.VarChar) { Value = branch.Phone }
            };

            try
            {
                return _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting branch into the database.", ex);
            }
        }

        public void UpdateBranch(BranchDTO branch)
        {
            string procedureName = "UpdateBranch";
            var parameters = new[]
            {
                new SqlParameter("@Branch_ID", SqlDbType.Int) { Value = branch.BranchID },
                new SqlParameter("@Branch_Name", SqlDbType.VarChar) { Value = branch.Name },
                new SqlParameter("@Location", SqlDbType.VarChar) { Value = branch.Location },
                new SqlParameter("@Phone", SqlDbType.VarChar) { Value = branch.Phone }
            };

            try
            {
                 _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating branch in the database.", ex);
            }
        }


        public void DeleteBranch(int branchID)
        {
            string procedureName = "DeleteFromBranch";
            var parameters = new[]
            {
                new SqlParameter("@branch_ID", SqlDbType.Int) { Value = branchID }
            };

            try
            {
                 _dbManager.ExecuteStoredProcedure(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting branch from the database.", ex);
            }
        }

        // Search Branch by Name
        public List<BranchDTO> SearchBranchByName(string branchName)
        {
            string procedureName = "SearchBranch_Name";
            var parameters = new[]
            {
                new SqlParameter("@Branch_Name", SqlDbType.VarChar)
                {
                    Value = string.IsNullOrEmpty(branchName) ? (object)DBNull.Value : branchName
                }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToBranchList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching branch by name.", ex);
            }
        }

        // Search Branch by Location
        public List<BranchDTO> SearchBranchByLocation(string location)
        {
            string procedureName = "SearchBranch_Location";
            var parameters = new[]
            {
                new SqlParameter("@Location", SqlDbType.VarChar)
                {
                    Value = string.IsNullOrEmpty(location) ? (object)DBNull.Value : location
                }
            };

            try
            {
                DataTable result = _dbManager.ExecuteStoredProcedure(procedureName, parameters);
                return ConvertToBranchList(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching branch by location.", ex);
            }
        }

        // Convert DataTable to List of BranchDTO
        private List<BranchDTO> ConvertToBranchList(DataTable table)
        {
            var branches = new List<BranchDTO>();

            foreach (DataRow row in table.Rows)
            {
                var branch = new BranchDTO
                {
                    BranchID = row.Field<int>("Branch_ID"),
                    Name = row.Field<string>("Branch_Name"),
                    Location = row.Field<string>("Location"),
                    Phone = row.Field<string>("Phone"),
                };
                branches.Add(branch);
            }
            return branches;
        }
    }
}
