using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class MaintenanceRepository : BaseRepository<Maintenance>
    {
        public MaintenanceRepository() : base("Maintenances", "MaintenanceID")
        {
        }

        protected override Maintenance MapToModel(DataRow row)
        {
            return new Maintenance
            {
                MaintenanceID = row.GetValue<int>("MaintenanceID"),
                MaintenanceVehicleID = row.GetValue<int>("MaintenanceVehicleID"),
                MaintenanceStartDate = row.GetValue<DateTime>("MaintenanceStartDate"),
                MaintenanceEndDate = row.GetValue<DateTime?>("MaintenanceEndDate"),
                MaintenanceType = row.GetValue<string>("MaintenanceType"),
                MaintenanceNote = row.GetValue<string>("MaintenanceNote"),
                MaintenanceCost = row.GetValue<decimal>("MaintenanceCost"),
                MaintenanceServiceID = row.GetValue<int?>("MaintenanceServiceID"),
                MaintenanceUserID = row.GetValue<int>("MaintenanceUserID"),
                MaintenanceCreatedAt = row.GetValue<DateTime>("MaintenanceCreatedAt"),
                MaintenanceUpdatedAt = row.GetValue<DateTime?>("MaintenanceUpdatedAt"),

                // Navigation properties
                Vehicle = GetVehicle(row.GetValue<int>("MaintenanceVehicleID")),
                Service = row.GetValue<int?>("MaintenanceServiceID").HasValue ?
                    GetService(row.GetValue<int>("MaintenanceServiceID")) : null,
                User = GetUser(row.GetValue<int>("MaintenanceUserID"))
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Maintenance entity)
        {
            return new Dictionary<string, object>
            {
                { "MaintenanceVehicleID", entity.MaintenanceVehicleID },
                { "MaintenanceStartDate", entity.MaintenanceStartDate },
                { "MaintenanceEndDate", entity.MaintenanceEndDate },
                { "MaintenanceType", entity.MaintenanceType },
                { "MaintenanceNote", entity.MaintenanceNote },
                { "MaintenanceCost", entity.MaintenanceCost },
                { "MaintenanceServiceID", entity.MaintenanceServiceID },
                { "MaintenanceUserID", entity.MaintenanceUserID },
                { "MaintenanceCreatedAt", entity.MaintenanceCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Maintenance entity)
        {
            return new Dictionary<string, object>
            {
                { "MaintenanceVehicleID", entity.MaintenanceVehicleID },
                { "MaintenanceStartDate", entity.MaintenanceStartDate },
                { "MaintenanceEndDate", entity.MaintenanceEndDate },
                { "MaintenanceType", entity.MaintenanceType },
                { "MaintenanceNote", entity.MaintenanceNote },
                { "MaintenanceCost", entity.MaintenanceCost },
                { "MaintenanceServiceID", entity.MaintenanceServiceID },
                { "MaintenanceUserID", entity.MaintenanceUserID },
                { "MaintenanceUpdatedAt", DateTime.Now }
            };
        }

        protected override int GetEntityId(Maintenance entity)
        {
            return entity.MaintenanceID;
        }

        // Get maintenances by vehicle
        public List<Maintenance> GetByVehicle(int vehicleId)
        {
            string query = "SELECT * FROM Maintenances WHERE MaintenanceVehicleID = @vehicleId ORDER BY MaintenanceStartDate DESC";
            var parameter = DatabaseHelper.CreateParameter("@vehicleId", vehicleId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get maintenances by service
        public List<Maintenance> GetByService(int serviceId)
        {
            string query = "SELECT * FROM Maintenances WHERE MaintenanceServiceID = @serviceId ORDER BY MaintenanceStartDate DESC";
            var parameter = DatabaseHelper.CreateParameter("@serviceId", serviceId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get active maintenances (not ended yet)
        public List<Maintenance> GetActiveMaintenances()
        {
            string query = "SELECT * FROM Maintenances WHERE MaintenanceEndDate IS NULL";
            var dataTable = DatabaseHelper.ExecuteQuery(query);

            return ConvertDataTableToList(dataTable);
        }

        // Get maintenances by date range
        public List<Maintenance> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT * FROM Maintenances 
                WHERE (MaintenanceStartDate BETWEEN @startDate AND @endDate) 
                   OR (MaintenanceEndDate BETWEEN @startDate AND @endDate)
                   OR (MaintenanceStartDate <= @startDate AND (MaintenanceEndDate >= @endDate OR MaintenanceEndDate IS NULL))";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            var dataTable = DatabaseHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dataTable);
        }

        // Complete maintenance
        public bool CompleteMaintenance(int maintenanceId, DateTime endDate, string note = null)
        {
            using (var connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Update maintenance
                        string updateMaintenanceQuery = @"
                            UPDATE Maintenances 
                            SET MaintenanceEndDate = @endDate, 
                                MaintenanceNote = CASE WHEN @note IS NULL OR @note = '' THEN MaintenanceNote ELSE @note END,
                                MaintenanceUpdatedAt = @updatedAt
                            WHERE MaintenanceID = @maintenanceId";

                        using (var command = new MySqlCommand(updateMaintenanceQuery, connection, transaction))
                        {
                            command.Parameters.Add(new MySqlParameter("@endDate", endDate));
                            command.Parameters.Add(new MySqlParameter("@note", string.IsNullOrEmpty(note) ? DBNull.Value : (object)note));
                            command.Parameters.Add(new MySqlParameter("@updatedAt", DateTime.Now));
                            command.Parameters.Add(new MySqlParameter("@maintenanceId", maintenanceId));
                            command.ExecuteNonQuery();
                        }

                        // 2. Get vehicle ID
                        string getVehicleQuery = "SELECT MaintenanceVehicleID FROM Maintenances WHERE MaintenanceID = @maintenanceId";
                        int vehicleId;

                        using (var command = new MySqlCommand(getVehicleQuery, connection, transaction))
                        {
                            command.Parameters.Add(new MySqlParameter("@maintenanceId", maintenanceId));
                            vehicleId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // 3. Update vehicle status back to Available
                        string updateVehicleQuery = @"
                            UPDATE Vehicles 
                            SET VehicleStatusID = 1, -- Assuming 1 is 'Available'
                                VehicleUpdatedAt = @updatedAt
                            WHERE VehicleID = @vehicleId";

                        using (var command = new MySqlCommand(updateVehicleQuery, connection, transaction))
                        {
                            command.Parameters.Add(new MySqlParameter("@updatedAt", DateTime.Now));
                            command.Parameters.Add(new MySqlParameter("@vehicleId", vehicleId));
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        // Create maintenance and update vehicle status
        public int CreateMaintenanceAndUpdateVehicle(Maintenance maintenance)
        {
            using (var connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert maintenance
                        string insertMaintenanceQuery = @"
                            INSERT INTO Maintenances (
                                MaintenanceVehicleID,
                                MaintenanceStartDate,
                                MaintenanceEndDate,
                                MaintenanceType,
                                MaintenanceNote,
                                MaintenanceCost,
                                MaintenanceServiceID,
                                MaintenanceUserID,
                                MaintenanceCreatedAt
                            ) VALUES (
                                @vehicleId,
                                @startDate,
                                @endDate,
                                @type,
                                @note,
                                @cost,
                                @serviceId,
                                @userId,
                                @createdAt
                            );
                            SELECT LAST_INSERT_ID();";

                        int maintenanceId;

                        using (var command = new MySqlCommand(insertMaintenanceQuery, connection, transaction))
                        {
                            command.Parameters.Add(new MySqlParameter("@vehicleId", maintenance.MaintenanceVehicleID));
                            command.Parameters.Add(new MySqlParameter("@startDate", maintenance.MaintenanceStartDate));
                            command.Parameters.Add(new MySqlParameter("@endDate", maintenance.MaintenanceEndDate ?? (object)DBNull.Value));
                            command.Parameters.Add(new MySqlParameter("@type", maintenance.MaintenanceType));
                            command.Parameters.Add(new MySqlParameter("@note", maintenance.MaintenanceNote ?? (object)DBNull.Value));
                            command.Parameters.Add(new MySqlParameter("@cost", maintenance.MaintenanceCost));
                            command.Parameters.Add(new MySqlParameter("@serviceId", maintenance.MaintenanceServiceID ?? (object)DBNull.Value));
                            command.Parameters.Add(new MySqlParameter("@userId", maintenance.MaintenanceUserID));
                            command.Parameters.Add(new MySqlParameter("@createdAt", DateTime.Now));
                            maintenanceId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // 2. Update vehicle status to Maintenance
                        string updateVehicleQuery = @"
                            UPDATE Vehicles 
                            SET VehicleStatusID = 4, -- Assuming 4 is 'Maintenance'
                                VehicleUpdatedAt = @updatedAt
                            WHERE VehicleID = @vehicleId";

                        using (var command = new MySqlCommand(updateVehicleQuery, connection, transaction))
                        {
                            command.Parameters.Add(new MySqlParameter("@updatedAt", DateTime.Now));
                            command.Parameters.Add(new MySqlParameter("@vehicleId", maintenance.MaintenanceVehicleID));
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return maintenanceId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
            }
        }

        // Get maintenance statistics
        public DataTable GetMaintenanceStatistics()
        {
            string query = @"
                SELECT 
                    MaintenanceType,
                    COUNT(*) AS MaintenanceCount,
                    SUM(MaintenanceCost) AS TotalCost,
                    AVG(MaintenanceCost) AS AverageCost,
                    MIN(MaintenanceCost) AS MinCost,
                    MAX(MaintenanceCost) AS MaxCost
                FROM Maintenances
                GROUP BY MaintenanceType
                ORDER BY MaintenanceCount DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Get most common maintenance types for each vehicle brand
        public DataTable GetMaintenanceByVehicleBrand()
        {
            string query = @"
                SELECT 
                    v.VehicleBrand,
                    COUNT(*) AS MaintenanceCount,
                    SUM(m.MaintenanceCost) AS TotalCost,
                    SUBSTRING_INDEX(
                        GROUP_CONCAT(m.MaintenanceType ORDER BY COUNT(*) DESC SEPARATOR ';'),
                        ';',
                        1
                    ) AS MostCommonMaintenanceType
                FROM Maintenances m
                INNER JOIN Vehicles v ON m.MaintenanceVehicleID = v.VehicleID
                GROUP BY v.VehicleBrand
                ORDER BY MaintenanceCount DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Helper method to get vehicle
        private Vehicle GetVehicle(int vehicleId)
        {
            string query = "SELECT * FROM Vehicles WHERE VehicleID = @vehicleId";
            var parameter = DatabaseHelper.CreateParameter("@vehicleId", vehicleId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Vehicle
            {
                VehicleID = row.GetValue<int>("VehicleID"),
                VehiclePlateNumber = row.GetValue<string>("VehiclePlateNumber"),
                VehicleBrand = row.GetValue<string>("VehicleBrand"),
                VehicleModel = row.GetValue<string>("VehicleModel")
                // Add other fields as needed
            };
        }

        // Helper method to get service
        private Service GetService(int? serviceId)
        {
            if (!serviceId.HasValue)
                return null;

            string query = "SELECT * FROM Services WHERE ServiceID = @serviceId";
            var parameter = DatabaseHelper.CreateParameter("@serviceId", serviceId.Value);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Service
            {
                ServiceID = row.GetValue<int>("ServiceID"),
                ServiceName = row.GetValue<string>("ServiceName"),
                ServiceAddress = row.GetValue<string>("ServiceAddress"),
                ServicePhone = row.GetValue<string>("ServicePhone"),
                ServiceEmail = row.GetValue<string>("ServiceEmail"),
                ServiceAuthorizedPersonID = row.GetValue<int>("ServiceAuthorizedPersonID")
            };
        }

        // Helper method to get user
        private User GetUser(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @userId";
            var parameter = DatabaseHelper.CreateParameter("@userId", userId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new User
            {
                UserID = row.GetValue<int>("UserID"),
                UserFirstName = row.GetValue<string>("UserFirstName"),
                UserLastName = row.GetValue<string>("UserLastName")
                // Add other fields as needed
            };
        }
    }
}