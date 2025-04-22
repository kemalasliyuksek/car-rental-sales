using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace car_rental_sales_desktop.Repositories
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        public List<Vehicle> GetAll()
        {
            string query = @"SELECT v.*, vs.StatusName, vc.ClassName, b.BranchName 
                           FROM Vehicles v
                           LEFT JOIN VehicleStatuses vs ON v.StatusID = vs.StatusID
                           LEFT JOIN VehicleClasses vc ON v.VehicleClassID = vc.VehicleClassID
                           LEFT JOIN Branches b ON v.BranchID = b.BranchID
                           ORDER BY v.Brand, v.Model";

            try
            {
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                return ConvertDataTableToVehicles(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "VehicleRepository.GetAll");
                return new List<Vehicle>();
            }
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            // StatusID 1 is assumed to be "Available"
            string query = @"SELECT v.*, vs.StatusName, vc.ClassName, b.BranchName 
                           FROM Vehicles v
                           LEFT JOIN VehicleStatuses vs ON v.StatusID = vs.StatusID
                           LEFT JOIN VehicleClasses vc ON v.VehicleClassID = vc.VehicleClassID
                           LEFT JOIN Branches b ON v.BranchID = b.BranchID
                           WHERE v.StatusID = 1
                           ORDER BY v.Brand, v.Model";

            try
            {
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                return ConvertDataTableToVehicles(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "VehicleRepository.GetAvailableVehicles");
                return new List<Vehicle>();
            }
        }

        public Vehicle GetById(int id)
        {
            string query = @"SELECT v.*, vs.StatusName, vc.ClassName, b.BranchName 
                           FROM Vehicles v
                           LEFT JOIN VehicleStatuses vs ON v.StatusID = vs.StatusID
                           LEFT JOIN VehicleClasses vc ON v.VehicleClassID = vc.VehicleClassID
                           LEFT JOIN Branches b ON v.BranchID = b.BranchID
                           WHERE v.VehicleID = @VehicleID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@VehicleID", id);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    return ConvertDataRowToVehicle(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "VehicleRepository.GetById");
                return null;
            }
        }

        public Vehicle GetByPlateNumber(string plateNumber)
        {
            string query = @"SELECT v.*, vs.StatusName, vc.ClassName, b.BranchName 
                           FROM Vehicles v
                           LEFT JOIN VehicleStatuses vs ON v.StatusID = vs.StatusID
                           LEFT JOIN VehicleClasses vc ON v.VehicleClassID = vc.VehicleClassID
                           LEFT JOIN Branches b ON v.BranchID = b.BranchID
                           WHERE v.PlateNumber = @PlateNumber";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@PlateNumber", plateNumber);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    return ConvertDataRowToVehicle(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "VehicleRepository.GetByPlateNumber");
                return null;
            }
        }

        public bool Insert(Vehicle vehicle)
        {
            string query = @"INSERT INTO Vehicles (
                                PlateNumber, Brand, Model, Year, EngineNumber, 
                                ChassisNumber, Color, Mileage, FuelType, TransmissionType, 
                                StatusID, AcquisitionDate, PurchasePrice, SalePrice, 
                                BranchID, VehicleClassID
                            ) VALUES (
                                @PlateNumber, @Brand, @Model, @Year, @EngineNumber, 
                                @ChassisNumber, @Color, @Mileage, @FuelType, @TransmissionType, 
                                @StatusID, @AcquisitionDate, @PurchasePrice, @SalePrice, 
                                @BranchID, @VehicleClassID
                            )";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@PlateNumber", vehicle.PlateNumber),
                DatabaseHelper.CreateParameter("@Brand", vehicle.Brand),
                DatabaseHelper.CreateParameter("@Model", vehicle.Model),
                DatabaseHelper.CreateParameter("@Year", vehicle.Year),
                DatabaseHelper.CreateParameter("@EngineNumber", vehicle.EngineNumber),
                DatabaseHelper.CreateParameter("@ChassisNumber", vehicle.ChassisNumber),
                DatabaseHelper.CreateParameter("@Color", vehicle.Color),
                DatabaseHelper.CreateParameter("@Mileage", vehicle.Mileage),
                DatabaseHelper.CreateParameter("@FuelType", vehicle.FuelType),
                DatabaseHelper.CreateParameter("@TransmissionType", vehicle.TransmissionType),
                DatabaseHelper.CreateParameter("@StatusID", vehicle.StatusID),
                DatabaseHelper.CreateParameter("@AcquisitionDate", vehicle.AcquisitionDate),
                DatabaseHelper.CreateParameter("@PurchasePrice", vehicle.PurchasePrice),
                DatabaseHelper.CreateParameter("@SalePrice", vehicle.SalePrice),
                DatabaseHelper.CreateParameter("@BranchID", vehicle.BranchID),
                DatabaseHelper.CreateParameter("@VehicleClassID", vehicle.VehicleClassID)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "VehicleRepository.Insert");
                return false;
            }
        }

        public bool Update(Vehicle vehicle)
        {
            string query = @"UPDATE Vehicles SET 
                                PlateNumber = @PlateNumber, 
                                Brand = @Brand, 
                                Model = @Model, 
                                Year = @Year, 
                                EngineNumber = @EngineNumber, 
                                ChassisNumber = @ChassisNumber, 
                                Color = @Color, 
                                Mileage = @Mileage, 
                                FuelType = @FuelType, 
                                TransmissionType = @TransmissionType, 
                                StatusID = @StatusID, 
                                AcquisitionDate = @AcquisitionDate, 
                                PurchasePrice = @PurchasePrice, 
                                SalePrice = @SalePrice, 
                                BranchID = @BranchID, 
                                VehicleClassID = @VehicleClassID,
                                UpdatedAt = NOW()
                            WHERE VehicleID = @VehicleID";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@VehicleID", vehicle.VehicleID),
                DatabaseHelper.CreateParameter("@PlateNumber", vehicle.PlateNumber),
                DatabaseHelper.CreateParameter("@Brand", vehicle.Brand),
                DatabaseHelper.CreateParameter("@Model", vehicle.Model),
                DatabaseHelper.CreateParameter("@Year", vehicle.Year),
                DatabaseHelper.CreateParameter("@EngineNumber", vehicle.EngineNumber),
                DatabaseHelper.CreateParameter("@ChassisNumber", vehicle.ChassisNumber),
                DatabaseHelper.CreateParameter("@Color", vehicle.Color),
                DatabaseHelper.CreateParameter("@Mileage", vehicle.Mileage),
                DatabaseHelper.CreateParameter("@FuelType", vehicle.FuelType),
                DatabaseHelper.CreateParameter("@TransmissionType", vehicle.TransmissionType),
                DatabaseHelper.CreateParameter("@StatusID", vehicle.StatusID),
                DatabaseHelper.CreateParameter("@AcquisitionDate", vehicle.AcquisitionDate),
                DatabaseHelper.CreateParameter("@PurchasePrice", vehicle.PurchasePrice),
                DatabaseHelper.CreateParameter("@SalePrice", vehicle.SalePrice),
                DatabaseHelper.CreateParameter("@BranchID", vehicle.BranchID),
                DatabaseHelper.CreateParameter("@VehicleClassID", vehicle.VehicleClassID)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "VehicleRepository.Update");
                return false;
            }
        }

        public bool UpdateStatus(int vehicleId, int statusId)
        {
            string query = "UPDATE Vehicles SET StatusID = @StatusID, UpdatedAt = NOW() WHERE VehicleID = @VehicleID";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@VehicleID", vehicleId),
                DatabaseHelper.CreateParameter("@StatusID", statusId)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "VehicleRepository.UpdateStatus");
                return false;
            }
        }

        public bool Delete(int id)
        {
            // For vehicles, typically you'd want to change status rather than delete
            // But this is the hard delete option
            string query = "DELETE FROM Vehicles WHERE VehicleID = @VehicleID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@VehicleID", id);
                int result = DatabaseHelper.ExecuteNonQuery(query, parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "VehicleRepository.Delete");
                return false;
            }
        }

        // Helper methods to convert DataTable to Vehicle objects
        private List<Vehicle> ConvertDataTableToVehicles(DataTable dataTable)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (DataRow row in dataTable.Rows)
            {
                vehicles.Add(ConvertDataRowToVehicle(row));
            }

            return vehicles;
        }

        private Vehicle ConvertDataRowToVehicle(DataRow row)
        {
            Vehicle vehicle = new Vehicle
            {
                VehicleID = row.GetValue<int>("VehicleID"),
                PlateNumber = row.GetValue<string>("PlateNumber"),
                Brand = row.GetValue<string>("Brand"),
                Model = row.GetValue<string>("Model"),
                Year = row.GetValue<int>("Year"),
                EngineNumber = row.GetValue<string>("EngineNumber"),
                ChassisNumber = row.GetValue<string>("ChassisNumber"),
                Color = row.GetValue<string>("Color"),
                Mileage = row.GetValue<int>("Mileage"),
                FuelType = row.GetValue<string>("FuelType"),
                TransmissionType = row.GetValue<string>("TransmissionType"),
                StatusID = row.GetValue<int>("StatusID"),
                AcquisitionDate = row.GetValue<DateTime?>("AcquisitionDate"),
                PurchasePrice = row.GetValue<decimal?>("PurchasePrice"),
                SalePrice = row.GetValue<decimal?>("SalePrice"),
                BranchID = row.GetValue<int?>("BranchID"),
                VehicleClassID = row.GetValue<int?>("VehicleClassID"),
                CreatedAt = row.GetValue<DateTime>("CreatedAt"),
                UpdatedAt = row.GetValue<DateTime?>("UpdatedAt")
            };

            // Optional navigation properties if joined with other tables
            if (row.Table.Columns.Contains("StatusName"))
            {
                vehicle.Status = new VehicleStatus
                {
                    StatusID = vehicle.StatusID,
                    StatusName = row.GetValue<string>("StatusName")
                };
            }

            if (row.Table.Columns.Contains("ClassName") && vehicle.VehicleClassID.HasValue)
            {
                vehicle.VehicleClass = new VehicleClass
                {
                    VehicleClassID = vehicle.VehicleClassID.Value,
                    ClassName = row.GetValue<string>("ClassName")
                };
            }

            if (row.Table.Columns.Contains("BranchName") && vehicle.BranchID.HasValue)
            {
                vehicle.Branch = new Branch
                {
                    BranchID = vehicle.BranchID.Value,
                    BranchName = row.GetValue<string>("BranchName")
                };
            }

            return vehicle;
        }
    }
}