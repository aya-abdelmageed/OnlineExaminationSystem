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

        public BranchRepo()
        {
            _dbManager = new DBManager();
        }
        // take string with accept null
        public List<BranchDTO> GetBranches(int? Branch_ID)
        {
            string procedureName = "SelectAllFromBranch";
            DataTable result;
            var parameters = new[]{ new SqlParameter("@Branch_ID", SqlDbType.Int) {Value = Branch_ID} };
            try
            {
                result = _dbManager.ExecuteStoredProcedure(procedureName, parameters); 
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
                throw new Exception("Error updating Branch in the database.", ex);
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
                throw new Exception("Error deleting Branch from the database.", ex);
            }
        }
    }
}
