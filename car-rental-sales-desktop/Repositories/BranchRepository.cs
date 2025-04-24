using System;
using System.Collections.Generic;
using System.Data;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class BranchRepository : BaseRepository<Branch>
    {
        public BranchRepository() : base("Branches", "BranchID")
        {
        }

        protected override Branch MapToModel(DataRow row)
        {
            return new Branch
            {
                BranchID = row.GetValue<int>("BranchID"),
                BranchName = row.GetValue<string>("BranchName"),
                BranchAddress = row.GetValue<string>("BranchAddress"),
                BranchPhone = row.GetValue<string>("BranchPhone"),
                BranchEmail = row.GetValue<string>("BranchEmail"),
                BranchActive = row.GetValue<bool>("BranchActive"),
                BranchCreatedAt = row.GetValue<DateTime>("BranchCreatedAt")
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Branch entity)
        {
            return new Dictionary<string, object>
            {
                { "BranchName", entity.BranchName },
                { "BranchAddress", entity.BranchAddress },
                { "BranchPhone", entity.BranchPhone },
                { "BranchEmail", entity.BranchEmail },
                { "BranchActive", entity.BranchActive },
                { "BranchCreatedAt", entity.BranchCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Branch entity)
        {
            return new Dictionary<string, object>
            {
                { "BranchName", entity.BranchName },
                { "BranchAddress", entity.BranchAddress },
                { "BranchPhone", entity.BranchPhone },
                { "BranchEmail", entity.BranchEmail },
                { "BranchActive", entity.BranchActive }
            };
        }

        protected override int GetEntityId(Branch entity)
        {
            return entity.BranchID;
        }

        // Get active branches
        public List<Branch> GetActiveBranches()
        {
            string query = "SELECT * FROM Branches WHERE BranchActive = 1";
            var dataTable = DatabaseHelper.ExecuteQuery(query);

            return ConvertDataTableToList(dataTable);
        }

        // Get branch with vehicles count
        public DataTable GetBranchesWithVehicleCount()
        {
            string query = @"
                SELECT 
                    b.BranchID,
                    b.BranchName,
                    b.BranchAddress,
                    b.BranchPhone,
                    b.BranchEmail,
                    b.BranchActive,
                    COUNT(v.VehicleID) AS VehicleCount
                FROM Branches b
                LEFT JOIN Vehicles v ON b.BranchID = v.VehicleBranchID
                GROUP BY b.BranchID, b.BranchName, b.BranchAddress, b.BranchPhone, b.BranchEmail, b.BranchActive
                ORDER BY b.BranchName";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Get branch with staff count
        public DataTable GetBranchesWithStaffCount()
        {
            string query = @"
                SELECT 
                    b.BranchID,
                    b.BranchName,
                    b.BranchAddress,
                    b.BranchPhone,
                    b.BranchEmail,
                    b.BranchActive,
                    COUNT(u.UserID) AS StaffCount
                FROM Branches b
                LEFT JOIN Users u ON b.BranchID = u.UserBranchID
                GROUP BY b.BranchID, b.BranchName, b.BranchAddress, b.BranchPhone, b.BranchEmail, b.BranchActive
                ORDER BY b.BranchName";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Get branch status (active/inactive)
        public bool SetBranchStatus(int branchId, bool isActive)
        {
            string query = "UPDATE Branches SET BranchActive = @isActive WHERE BranchID = @branchId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@isActive", isActive),
                DatabaseHelper.CreateParameter("@branchId", branchId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Get branch with vehicle availability
        public DataTable GetBranchVehicleAvailability()
        {
            string query = @"
                SELECT 
                    b.BranchID,
                    b.BranchName,
                    COUNT(v.VehicleID) AS TotalVehicles,
                    SUM(CASE WHEN v.VehicleStatusID = 1 THEN 1 ELSE 0 END) AS AvailableVehicles,
                    SUM(CASE WHEN v.VehicleStatusID = 3 THEN 1 ELSE 0 END) AS RentedVehicles,
                    SUM(CASE WHEN v.VehicleStatusID = 2 THEN 1 ELSE 0 END) AS ForSaleVehicles,
                    SUM(CASE WHEN v.VehicleStatusID = 4 THEN 1 ELSE 0 END) AS MaintenanceVehicles
                FROM Branches b
                LEFT JOIN Vehicles v ON b.BranchID = v.VehicleBranchID
                WHERE b.BranchActive = 1
                GROUP BY b.BranchID, b.BranchName
                ORDER BY b.BranchName";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Get branch with rental statistics
        public DataTable GetBranchRentalStatistics(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    b.BranchID,
                    b.BranchName,
                    COUNT(r.RentalID) AS RentalCount,
                    SUM(r.RentalAmount) AS TotalRevenue,
                    AVG(r.RentalAmount) AS AverageRentalAmount
                FROM Branches b
                LEFT JOIN Vehicles v ON b.BranchID = v.VehicleBranchID
                LEFT JOIN Rentals r ON v.VehicleID = r.RentalVehicleID AND r.RentalStartDate BETWEEN @startDate AND @endDate
                WHERE b.BranchActive = 1
                GROUP BY b.BranchID, b.BranchName
                ORDER BY TotalRevenue DESC";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}