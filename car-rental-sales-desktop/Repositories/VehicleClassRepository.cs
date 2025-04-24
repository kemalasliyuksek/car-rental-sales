using System;
using System.Collections.Generic;
using System.Data;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class VehicleClassRepository : BaseRepository<VehicleClass>
    {
        public VehicleClassRepository() : base("VehicleClasses", "VehicleClassID")
        {
        }

        protected override VehicleClass MapToModel(DataRow row)
        {
            return new VehicleClass
            {
                VehicleClassID = row.GetValue<int>("VehicleClassID"),
                VehicleClassName = row.GetValue<string>("VehicleClassName"),
                VehicleClassDescription = row.GetValue<string>("VehicleClassDescription"),
                VehicleClassCreatedAt = row.GetValue<DateTime>("VehicleClassCreatedAt")
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(VehicleClass entity)
        {
            return new Dictionary<string, object>
            {
                { "VehicleClassName", entity.VehicleClassName },
                { "VehicleClassDescription", entity.VehicleClassDescription },
                { "VehicleClassCreatedAt", entity.VehicleClassCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(VehicleClass entity)
        {
            return new Dictionary<string, object>
            {
                { "VehicleClassName", entity.VehicleClassName },
                { "VehicleClassDescription", entity.VehicleClassDescription }
            };
        }

        protected override int GetEntityId(VehicleClass entity)
        {
            return entity.VehicleClassID;
        }

        // Get class with vehicle count
        public DataTable GetClassesWithVehicleCount()
        {
            string query = @"
                SELECT 
                    vc.VehicleClassID,
                    vc.VehicleClassName,
                    vc.VehicleClassDescription,
                    COUNT(v.VehicleID) AS VehicleCount
                FROM VehicleClasses vc
                LEFT JOIN Vehicles v ON vc.VehicleClassID = v.VehicleClassID
                GROUP BY vc.VehicleClassID, vc.VehicleClassName, vc.VehicleClassDescription
                ORDER BY vc.VehicleClassName";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Get class by name
        public VehicleClass GetByName(string className)
        {
            string query = "SELECT * FROM VehicleClasses WHERE VehicleClassName = @className";
            var parameter = DatabaseHelper.CreateParameter("@className", className);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Get rental prices for a class
        public List<RentalPrice> GetRentalPrices(int classId)
        {
            string query = "SELECT * FROM RentalPrices WHERE VehicleClassID = @classId";
            var parameter = DatabaseHelper.CreateParameter("@classId", classId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            var prices = new List<RentalPrice>();
            foreach (DataRow row in dataTable.Rows)
            {
                prices.Add(new RentalPrice
                {
                    RentalPriceID = row.GetValue<int>("RentalPriceID"),
                    VehicleClassID = row.GetValue<int>("VehicleClassID"),
                    RentalType = (RentalType)Enum.Parse(typeof(RentalType), row.GetValue<string>("RentalType")),
                    RentPrice = row.GetValue<decimal>("RentalPrice"),
                    RentalPriceCreatedAt = row.GetValue<DateTime>("RentalPriceCreatedAt")
                });
            }

            return prices;
        }

        // Add or update rental price
        public bool AddOrUpdateRentalPrice(RentalPrice price)
        {
            // Check if the price already exists
            string checkQuery = "SELECT COUNT(*) FROM RentalPrices WHERE VehicleClassID = @classId AND RentalType = @rentalType";
            var checkParameters = new[]
            {
                DatabaseHelper.CreateParameter("@classId", price.VehicleClassID),
                DatabaseHelper.CreateParameter("@rentalType", price.RentalType.ToString())
            };

            object result = DatabaseHelper.ExecuteScalar(checkQuery, checkParameters);
            int count = Convert.ToInt32(result);

            if (count > 0)
            {
                // Update existing price
                string updateQuery = "UPDATE RentalPrices SET RentalPrice = @price WHERE VehicleClassID = @classId AND RentalType = @rentalType";
                var updateParameters = new[]
                {
                    DatabaseHelper.CreateParameter("@price", price.RentPrice),
                    DatabaseHelper.CreateParameter("@classId", price.VehicleClassID),
                    DatabaseHelper.CreateParameter("@rentalType", price.RentalType.ToString())
                };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(updateQuery, updateParameters);
                return affectedRows > 0;
            }
            else
            {
                // Insert new price
                string insertQuery = @"
                    INSERT INTO RentalPrices (
                        VehicleClassID,
                        RentalType,
                        RentalPrice,
                        RentalPriceCreatedAt
                    ) VALUES (
                        @classId,
                        @rentalType,
                        @price,
                        @createdAt
                    )";

                var insertParameters = new[]
                {
                    DatabaseHelper.CreateParameter("@classId", price.VehicleClassID),
                    DatabaseHelper.CreateParameter("@rentalType", price.RentalType.ToString()),
                    DatabaseHelper.CreateParameter("@price", price.RentPrice),
                    DatabaseHelper.CreateParameter("@createdAt", DateTime.Now)
                };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(insertQuery, insertParameters);
                return affectedRows > 0;
            }
        }

        // Get rental price by class and type
        public decimal GetRentalPrice(int classId, RentalType rentalType)
        {
            string query = "SELECT RentalPrice FROM RentalPrices WHERE VehicleClassID = @classId AND RentalType = @rentalType";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@classId", classId),
                DatabaseHelper.CreateParameter("@rentalType", rentalType.ToString())
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);

            if (result == null || result == DBNull.Value)
                return 0m;

            return Convert.ToDecimal(result);
        }

        // Get classes with rental statistics
        public DataTable GetClassesWithRentalStatistics()
        {
            string query = @"
                SELECT 
                    vc.VehicleClassID,
                    vc.VehicleClassName,
                    COUNT(r.RentalID) AS RentalCount,
                    SUM(r.RentalAmount) AS TotalRevenue,
                    AVG(r.RentalAmount) AS AverageRentalAmount
                FROM VehicleClasses vc
                LEFT JOIN Vehicles v ON vc.VehicleClassID = v.VehicleClassID
                LEFT JOIN Rentals r ON v.VehicleID = r.RentalVehicleID
                GROUP BY vc.VehicleClassID, vc.VehicleClassName
                ORDER BY TotalRevenue DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }
    }
}