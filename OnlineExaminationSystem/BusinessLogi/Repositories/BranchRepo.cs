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
    public class BranchRepo
    {
        private readonly DBManager _dbManager;

        public BranchRepo(DBManager dbManager)
        {
            _dbManager = dbManager;
        }
        // take string with accept null
        public List<BranchDTO> GetBranches()
        {
            string procedureName = "SelectAllFromBranch";
            DataTable result;
            try
            {
                result = _dbManager.ExecuteStoredProcedure(procedureName, null); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Branches from the database.", ex);
            }
            var branches = new List<BranchDTO>();
            foreach (DataRow dataRow in result.Rows)
            {
                var branch = new BranchDTO
                {
                    BranchID = dataRow.Field<int>("Branch_ID"),
                    Name = dataRow.Field<string>("Branch_Name"),
                    Location = dataRow.Field<string>("Location"),
                    Phone = dataRow.Field<string>("Phone"),
                };
                branches.Add(branch);
            }
            return branches;
        }
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
                throw new Exception("Error inserting Branch into the database.", ex);
            }
        }
        public int UpdateBranch(BranchDTO branch)
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
                return _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Branch in the database.", ex);
            }
        }
        public int DeleteBranch(string branchName)
        {
            string procedureName = "DeleteFromBranch";
            var parameters = new[]
            {
                new SqlParameter("@Branch_Name", SqlDbType.VarChar) { Value = branchName }
            };
            try
            {
                return _dbManager.ExecuteNonQuery(procedureName, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Branch from the database.", ex);
            }
        }
    }
}
