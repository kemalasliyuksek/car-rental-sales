using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace car_rental_sales_desktop.Repositories
{
    public class BranchRepository : IRepository<Branch>
    {
        public List<Branch> GetAll()
        {
            string query = "SELECT * FROM Branches WHERE IsActive = 1 ORDER BY BranchName";

            try
            {
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                return ConvertDataTableToBranches(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "BranchRepository.GetAll");
                return new List<Branch>();
            }
        }

        public Branch GetById(int id)
        {
            string query = "SELECT * FROM Branches WHERE BranchID = @BranchID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@BranchID", id);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    return ConvertDataRowToBranch(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "BranchRepository.GetById");
                return null;
            }
        }

        public bool Insert(Branch branch)
        {
            string query = @"INSERT INTO Branches (BranchName, Address, CountryCode, PhoneNumber, Email, CityCode, IsActive) 
                            VALUES (@BranchName, @Address, @CountryCode, @PhoneNumber, @Email, @CityCode, @IsActive)";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@BranchName", branch.BranchName),
                DatabaseHelper.CreateParameter("@Address", branch.Address),
                DatabaseHelper.CreateParameter("@CountryCode", branch.CountryCode),
                DatabaseHelper.CreateParameter("@PhoneNumber", branch.PhoneNumber),
                DatabaseHelper.CreateParameter("@Email", branch.Email),
                DatabaseHelper.CreateParameter("@CityCode", branch.CityCode),
                DatabaseHelper.CreateParameter("@IsActive", branch.IsActive)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "BranchRepository.Insert");
                return false;
            }
        }

        public bool Update(Branch branch)
        {
            string query = @"UPDATE Branches 
                            SET BranchName = @BranchName, 
                                Address = @Address, 
                                CountryCode = @CountryCode, 
                                PhoneNumber = @PhoneNumber, 
                                Email = @Email, 
                                CityCode = @CityCode, 
                                IsActive = @IsActive 
                            WHERE BranchID = @BranchID";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@BranchID", branch.BranchID),
                DatabaseHelper.CreateParameter("@BranchName", branch.BranchName),
                DatabaseHelper.CreateParameter("@Address", branch.Address),
                DatabaseHelper.CreateParameter("@CountryCode", branch.CountryCode),
                DatabaseHelper.CreateParameter("@PhoneNumber", branch.PhoneNumber),
                DatabaseHelper.CreateParameter("@Email", branch.Email),
                DatabaseHelper.CreateParameter("@CityCode", branch.CityCode),
                DatabaseHelper.CreateParameter("@IsActive", branch.IsActive)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "BranchRepository.Update");
                return false;
            }
        }

        public bool Delete(int id)
        {
            // Soft delete - just update IsActive to false
            string query = "UPDATE Branches SET IsActive = 0 WHERE BranchID = @BranchID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@BranchID", id);
                int result = DatabaseHelper.ExecuteNonQuery(query, parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "BranchRepository.Delete");
                return false;
            }
        }

        // Helper methods to convert DataTable to Branch objects
        private List<Branch> ConvertDataTableToBranches(DataTable dataTable)
        {
            List<Branch> branches = new List<Branch>();

            foreach (DataRow row in dataTable.Rows)
            {
                branches.Add(ConvertDataRowToBranch(row));
            }

            return branches;
        }

        private Branch ConvertDataRowToBranch(DataRow row)
        {
            return new Branch
            {
                BranchID = row.GetValue<int>("BranchID"),
                BranchName = row.GetValue<string>("BranchName"),
                Address = row.GetValue<string>("Address"),
                CountryCode = row.GetValue<string>("CountryCode"),
                PhoneNumber = row.GetValue<string>("PhoneNumber"),
                Email = row.GetValue<string>("Email"),
                CityCode = row.GetValue<string>("CityCode"),
                IsActive = row.GetValue<bool>("IsActive"),
                CreatedAt = row.GetValue<DateTime>("CreatedAt")
            };
        }
    }
}