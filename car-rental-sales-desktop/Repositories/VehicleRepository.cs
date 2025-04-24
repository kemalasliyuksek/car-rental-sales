using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>
    {
        public VehicleRepository() : base("Vehicles", "VehicleID")
        {
        }

        protected override Vehicle MapToModel(DataRow row)
        {
            return new Vehicle
            {
                VehicleID = row.GetValue<int>("VehicleID"),
                VehiclePlateNumber = row.GetValue<string>("VehiclePlateNumber"),
                VehicleBrand = row.GetValue<string>("VehicleBrand"),
                VehicleModel = row.GetValue<string>("VehicleModel"),
                VehicleYear = row.GetValue<int>("VehicleYear"),
                VehicleEngineNumber = row.GetValue<string>("VehicleEngineNumber"),
                VehicleChassisNumber = row.GetValue<string>("VehicleChassisNumber"),
                VehicleColor = row.GetValue<string>("VehicleColor"),
                VehicleMileage = row.GetValue<int>("VehicleMileage"),
                VehicleFuelType = row.GetValue<string>("VehicleFuelType"),
                VehicleTransmissionType = row.GetValue<string>("VehicleTransmissionType"),
                VehicleStatusID = row.GetValue<int>("VehicleStatusID"),
                VehicleAcquisitionDate = row.GetValue<DateTime?>("VehicleAcquisitionDate"),
                VehiclePurchasePrice = row.GetValue<decimal?>("VehiclePurchasePrice"),
                VehicleSalePrice = row.GetValue<decimal?>("VehicleSalePrice"),
                VehicleBranchID = row.GetValue<int?>("VehicleBranchID"),
                VehicleClassID = row.GetValue<int?>("VehicleClassID"),
                VehicleCreatedAt = row.GetValue<DateTime>("VehicleCreatedAt"),
                VehicleUpdatedAt = row.GetValue<DateTime?>("VehicleUpdatedAt"),

                // Navigation properties
                VehicleStatus = GetVehicleStatus(row.GetValue<int>("VehicleStatusID")),
                Branch = row.GetValue<int?>("VehicleBranchID").HasValue
                    ? GetVehicleBranch(row.GetValue<int>("VehicleBranchID"))
                    : null,
                VehicleClass = row.GetValue<int?>("VehicleClassID").HasValue
                    ? GetVehicleClass(row.GetValue<int>("VehicleClassID"))
                    : null
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Vehicle entity)
        {
            return new Dictionary<string, object>
            {
                { "VehiclePlateNumber", entity.VehiclePlateNumber },
                { "VehicleBrand", entity.VehicleBrand },
                { "VehicleModel", entity.VehicleModel },
                { "VehicleYear", entity.VehicleYear },
                { "VehicleEngineNumber", entity.VehicleEngineNumber },
                { "VehicleChassisNumber", entity.VehicleChassisNumber },
                { "VehicleColor", entity.VehicleColor },
                { "VehicleMileage", entity.VehicleMileage },
                { "VehicleFuelType", entity.VehicleFuelType },
                { "VehicleTransmissionType", entity.VehicleTransmissionType },
                { "VehicleStatusID", entity.VehicleStatusID },
                { "VehicleAcquisitionDate", entity.VehicleAcquisitionDate },
                { "VehiclePurchasePrice", entity.VehiclePurchasePrice },
                { "VehicleSalePrice", entity.VehicleSalePrice },
                { "VehicleBranchID", entity.VehicleBranchID },
                { "VehicleClassID", entity.VehicleClassID },
                { "VehicleCreatedAt", entity.VehicleCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Vehicle entity)
        {
            return new Dictionary<string, object>
            {
                { "VehiclePlateNumber", entity.VehiclePlateNumber },
                { "VehicleBrand", entity.VehicleBrand },
                { "VehicleModel", entity.VehicleModel },
                { "VehicleYear", entity.VehicleYear },
                { "VehicleEngineNumber", entity.VehicleEngineNumber },
                { "VehicleChassisNumber", entity.VehicleChassisNumber },
                { "VehicleColor", entity.VehicleColor },
                { "VehicleMileage", entity.VehicleMileage },
                { "VehicleFuelType", entity.VehicleFuelType },
                { "VehicleTransmissionType", entity.VehicleTransmissionType },
                { "VehicleStatusID", entity.VehicleStatusID },
                { "VehicleAcquisitionDate", entity.VehicleAcquisitionDate },
                { "VehiclePurchasePrice", entity.VehiclePurchasePrice },
                { "VehicleSalePrice", entity.VehicleSalePrice },
                { "VehicleBranchID", entity.VehicleBranchID },
                { "VehicleClassID", entity.VehicleClassID },
                { "VehicleUpdatedAt", DateTime.Now }
            };
        }

        protected override int GetEntityId(Vehicle entity)
        {
            return entity.VehicleID;
        }

        // Get vehicle by plate number
        public Vehicle GetByPlateNumber(string plateNumber)
        {
            string query = "SELECT * FROM Vehicles WHERE VehiclePlateNumber = @plateNumber";
            var parameter = DatabaseHelper.CreateParameter("@plateNumber", plateNumber);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Get vehicle by chassis number
        public Vehicle GetByChassisNumber(string chassisNumber)
        {
            string query = "SELECT * FROM Vehicles WHERE VehicleChassisNumber = @chassisNumber";
            var parameter = DatabaseHelper.CreateParameter("@chassisNumber", chassisNumber);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Get vehicles by status
        public List<Vehicle> GetByStatus(int statusId)
        {
            string query = "SELECT * FROM Vehicles WHERE VehicleStatusID = @statusId";
            var parameter = DatabaseHelper.CreateParameter("@statusId", statusId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get vehicles by branch
        public List<Vehicle> GetByBranch(int branchId)
        {
            string query = "SELECT * FROM Vehicles WHERE VehicleBranchID = @branchId";
            var parameter = DatabaseHelper.CreateParameter("@branchId", branchId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get vehicles by class
        public List<Vehicle> GetByClass(int classId)
        {
            string query = "SELECT * FROM Vehicles WHERE VehicleClassID = @classId";
            var parameter = DatabaseHelper.CreateParameter("@classId", classId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Search vehicles
        public List<Vehicle> Search(string searchTerm)
        {
            string query = @"
                SELECT * FROM Vehicles 
                WHERE VehiclePlateNumber LIKE @searchTerm 
                   OR VehicleBrand LIKE @searchTerm 
                   OR VehicleModel LIKE @searchTerm 
                   OR VehicleChassisNumber LIKE @searchTerm
                   OR VehicleEngineNumber LIKE @searchTerm";

            var parameter = DatabaseHelper.CreateParameter("@searchTerm", $"%{searchTerm}%");
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get available vehicles (for rental)
        public List<Vehicle> GetAvailableVehicles()
        {
            // Assuming status ID 1 is "Available"
            string query = @"
                SELECT v.* FROM Vehicles v
                WHERE v.VehicleStatusID = 1
                AND v.VehicleID NOT IN (
                    SELECT r.RentalVehicleID FROM Rentals r
                    WHERE r.RentalEndDate >= @today AND r.RentalReturnDate IS NULL
                )";

            var parameter = DatabaseHelper.CreateParameter("@today", DateTime.Today);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get available vehicles in a specific branch
        public List<Vehicle> GetAvailableVehiclesByBranch(int branchId)
        {
            string query = @"
                SELECT v.* FROM Vehicles v
                WHERE v.VehicleStatusID = 1
                AND v.VehicleBranchID = @branchId
                AND v.VehicleID NOT IN (
                    SELECT r.RentalVehicleID FROM Rentals r
                    WHERE r.RentalEndDate >= @today AND r.RentalReturnDate IS NULL
                )";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@today", DateTime.Today),
                DatabaseHelper.CreateParameter("@branchId", branchId)
            };

            var dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            return ConvertDataTableToList(dataTable);
        }

        // Get vehicles available for sale
        public List<Vehicle> GetVehiclesForSale()
        {
            // Assuming status ID 2 is "For Sale"
            string query = "SELECT * FROM Vehicles WHERE VehicleStatusID = 2";
            var dataTable = DatabaseHelper.ExecuteQuery(query);

            return ConvertDataTableToList(dataTable);
        }

        // Update vehicle status
        public bool UpdateVehicleStatus(int vehicleId, int statusId)
        {
            string query = "UPDATE Vehicles SET VehicleStatusID = @statusId, VehicleUpdatedAt = @updatedAt WHERE VehicleID = @vehicleId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@statusId", statusId),
                DatabaseHelper.CreateParameter("@updatedAt", DateTime.Now),
                DatabaseHelper.CreateParameter("@vehicleId", vehicleId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Update vehicle mileage
        public bool UpdateVehicleMileage(int vehicleId, int mileage)
        {
            string query = "UPDATE Vehicles SET VehicleMileage = @mileage, VehicleUpdatedAt = @updatedAt WHERE VehicleID = @vehicleId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@mileage", mileage),
                DatabaseHelper.CreateParameter("@updatedAt", DateTime.Now),
                DatabaseHelper.CreateParameter("@vehicleId", vehicleId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Transfer vehicle to another branch
        public bool TransferVehicle(int vehicleId, int branchId)
        {
            string query = "UPDATE Vehicles SET VehicleBranchID = @branchId, VehicleUpdatedAt = @updatedAt WHERE VehicleID = @vehicleId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@branchId", branchId),
                DatabaseHelper.CreateParameter("@updatedAt", DateTime.Now),
                DatabaseHelper.CreateParameter("@vehicleId", vehicleId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Helper method to get vehicle status
        private VehicleStatus GetVehicleStatus(int statusId)
        {
            string query = "SELECT * FROM VehicleStatuses WHERE VehicleStatusID = @statusId";
            var parameter = DatabaseHelper.CreateParameter("@statusId", statusId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new VehicleStatus
            {
                VehicleStatusID = row.GetValue<int>("VehicleStatusID"),
                VehicleStatusName = row.GetValue<string>("VehicleStatusName"),
                VehicleStatusDescription = row.GetValue<string>("VehicleStatusDescription"),
                VehicleStatusCreatedAt = row.GetValue<DateTime>("VehicleStatusCreatedAt")
            };
        }

        // Helper method to get branch
        private Branch GetVehicleBranch(int? branchId)
        {
            if (!branchId.HasValue)
                return null;

            string query = "SELECT * FROM Branches WHERE BranchID = @branchId";
            var parameter = DatabaseHelper.CreateParameter("@branchId", branchId.Value);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
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

        // Helper method to get vehicle class
        private VehicleClass GetVehicleClass(int? classId)
        {
            if (!classId.HasValue)
                return null;

            string query = "SELECT * FROM VehicleClasses WHERE VehicleClassID = @classId";
            var parameter = DatabaseHelper.CreateParameter("@classId", classId.Value);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new VehicleClass
            {
                VehicleClassID = row.GetValue<int>("VehicleClassID"),
                VehicleClassName = row.GetValue<string>("VehicleClassName"),
                VehicleClassDescription = row.GetValue<string>("VehicleClassDescription"),
                VehicleClassCreatedAt = row.GetValue<DateTime>("VehicleClassCreatedAt")
            };
        }
    }
}