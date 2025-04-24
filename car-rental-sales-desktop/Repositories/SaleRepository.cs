using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class SaleRepository : BaseRepository<Sale>
    {
        public SaleRepository() : base("Sales", "SaleID")
        {
        }

        protected override Sale MapToModel(DataRow row)
        {
            return new Sale
            {
                SaleID = row.GetValue<int>("SaleID"),
                SaleCustomerID = row.GetValue<int>("SaleCustomerID"),
                SaleVehicleID = row.GetValue<int>("SaleVehicleID"),
                SaleDate = row.GetValue<DateTime>("SaleDate"),
                SaleAmount = row.GetValue<decimal>("SaleAmount"),
                SalePaymentType = row.GetValue<string>("SalePaymentType"),
                SaleInstallmentCount = row.GetValue<int>("SaleInstallmentCount"),
                SaleNotaryDate = row.GetValue<DateTime?>("SaleNotaryDate"),
                SaleContractID = row.GetValue<int?>("SaleContractID"),
                SaleUserID = row.GetValue<int>("SaleUserID"),
                SaleCreatedAt = row.GetValue<DateTime>("SaleCreatedAt"),
                SaleUpdatedAt = row.GetValue<DateTime?>("SaleUpdatedAt"),

                // Navigation properties
                Customer = GetCustomer(row.GetValue<int>("SaleCustomerID")),
                Vehicle = GetVehicle(row.GetValue<int>("SaleVehicleID")),
                User = GetUser(row.GetValue<int>("SaleUserID"))
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Sale entity)
        {
            return new Dictionary<string, object>
            {
                { "SaleCustomerID", entity.SaleCustomerID },
                { "SaleVehicleID", entity.SaleVehicleID },
                { "SaleDate", entity.SaleDate },
                { "SaleAmount", entity.SaleAmount },
                { "SalePaymentType", entity.SalePaymentType },
                { "SaleInstallmentCount", entity.SaleInstallmentCount },
                { "SaleNotaryDate", entity.SaleNotaryDate },
                { "SaleContractID", entity.SaleContractID },
                { "SaleUserID", entity.SaleUserID },
                { "SaleCreatedAt", entity.SaleCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Sale entity)
        {
            return new Dictionary<string, object>
            {
                { "SaleCustomerID", entity.SaleCustomerID },
                { "SaleVehicleID", entity.SaleVehicleID },
                { "SaleDate", entity.SaleDate },
                { "SaleAmount", entity.SaleAmount },
                { "SalePaymentType", entity.SalePaymentType },
                { "SaleInstallmentCount", entity.SaleInstallmentCount },
                { "SaleNotaryDate", entity.SaleNotaryDate },
                { "SaleContractID", entity.SaleContractID },
                { "SaleUserID", entity.SaleUserID },
                { "SaleUpdatedAt", DateTime.Now }
            };
        }

        protected override int GetEntityId(Sale entity)
        {
            return entity.SaleID;
        }

        // Get sales by customer
        public List<Sale> GetByCustomer(int customerId)
        {
            string query = "SELECT * FROM Sales WHERE SaleCustomerID = @customerId";
            var parameter = DatabaseHelper.CreateParameter("@customerId", customerId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get sale by vehicle
        public Sale GetByVehicle(int vehicleId)
        {
            string query = "SELECT * FROM Sales WHERE SaleVehicleID = @vehicleId";
            var parameter = DatabaseHelper.CreateParameter("@vehicleId", vehicleId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Get sales by date range
        public List<Sale> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM Sales WHERE SaleDate BETWEEN @startDate AND @endDate";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            var dataTable = DatabaseHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dataTable);
        }

        // Get sales by branch
        public List<Sale> GetByBranch(int branchId)
        {
            string query = @"
                SELECT s.* FROM Sales s
                INNER JOIN Vehicles v ON s.SaleVehicleID = v.VehicleID
                WHERE v.VehicleBranchID = @branchId";

            var parameter = DatabaseHelper.CreateParameter("@branchId", branchId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get sales by user
        public List<Sale> GetByUser(int userId)
        {
            string query = "SELECT * FROM Sales WHERE SaleUserID = @userId";
            var parameter = DatabaseHelper.CreateParameter("@userId", userId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Create a new sale with payment
        public int CreateSaleWithPayment(Sale sale, Payment payment)
        {
            using (var connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert sale
                        string insertSaleQuery = @"
                            INSERT INTO Sales (
                                SaleCustomerID,
                                SaleVehicleID,
                                SaleDate,
                                SaleAmount,
                                SalePaymentType,
                                SaleInstallmentCount,
                                SaleNotaryDate,
                                SaleContractID,
                                SaleUserID,
                                SaleCreatedAt
                            ) VALUES (
                                @customerId,
                                @vehicleId,
                                @saleDate,
                                @amount,
                                @paymentType,
                                @installmentCount,
                                @notaryDate,
                                @contractId,
                                @userId,
                                @createdAt
                            );
                            SELECT LAST_INSERT_ID();";

                        int saleId;

                        using (var saleCommand = new MySqlCommand(insertSaleQuery, connection, transaction))
                        {
                            saleCommand.Parameters.Add(new MySqlParameter("@customerId", sale.SaleCustomerID));
                            saleCommand.Parameters.Add(new MySqlParameter("@vehicleId", sale.SaleVehicleID));
                            saleCommand.Parameters.Add(new MySqlParameter("@saleDate", sale.SaleDate));
                            saleCommand.Parameters.Add(new MySqlParameter("@amount", sale.SaleAmount));
                            saleCommand.Parameters.Add(new MySqlParameter("@paymentType", sale.SalePaymentType));
                            saleCommand.Parameters.Add(new MySqlParameter("@installmentCount", sale.SaleInstallmentCount));
                            saleCommand.Parameters.Add(new MySqlParameter("@notaryDate", sale.SaleNotaryDate ?? (object)DBNull.Value));
                            saleCommand.Parameters.Add(new MySqlParameter("@contractId", sale.SaleContractID ?? (object)DBNull.Value));
                            saleCommand.Parameters.Add(new MySqlParameter("@userId", sale.SaleUserID));
                            saleCommand.Parameters.Add(new MySqlParameter("@createdAt", DateTime.Now));
                            saleId = Convert.ToInt32(saleCommand.ExecuteScalar());
                        }

                        // 2. Insert payment
                        string insertPaymentQuery = @"
                            INSERT INTO Payments (
                                PaymentTransactionType,
                                PaymentTransactionID,
                                PaymentCustomerID,
                                PaymentAmount,
                                PaymentDate,
                                PaymentType,
                                PaymentBankID,
                                PaymentNote,
                                PaymentUserID,
                                PaymentCreatedAt
                            ) VALUES (
                                'Sale',
                                @transactionId,
                                @customerId,
                                @amount,
                                @paymentDate,
                                @paymentType,
                                @bankId,
                                @note,
                                @userId,
                                @createdAt
                            )";

                        using (var paymentCommand = new MySqlCommand(insertPaymentQuery, connection, transaction))
                        {
                            paymentCommand.Parameters.Add(new MySqlParameter("@transactionId", saleId));
                            paymentCommand.Parameters.Add(new MySqlParameter("@customerId", payment.PaymentCustomerID));
                            paymentCommand.Parameters.Add(new MySqlParameter("@amount", payment.PaymentAmount));
                            paymentCommand.Parameters.Add(new MySqlParameter("@paymentDate", payment.PaymentDate));
                            paymentCommand.Parameters.Add(new MySqlParameter("@paymentType", payment.PaymentType));
                            paymentCommand.Parameters.Add(new MySqlParameter("@bankId", payment.PaymentBankID ?? (object)DBNull.Value));
                            paymentCommand.Parameters.Add(new MySqlParameter("@note", payment.PaymentNote ?? (object)DBNull.Value));
                            paymentCommand.Parameters.Add(new MySqlParameter("@userId", payment.PaymentUserID));
                            paymentCommand.Parameters.Add(new MySqlParameter("@createdAt", DateTime.Now));
                            paymentCommand.ExecuteNonQuery();
                        }

                        // 3. Update vehicle status (mark as sold)
                        string updateVehicleQuery = @"
                            UPDATE Vehicles 
                            SET VehicleStatusID = 5, -- Assuming 5 is 'Sold'
                                VehicleUpdatedAt = @updatedAt
                            WHERE VehicleID = @vehicleId";

                        using (var vehicleCommand = new MySqlCommand(updateVehicleQuery, connection, transaction))
                        {
                            vehicleCommand.Parameters.Add(new MySqlParameter("@updatedAt", DateTime.Now));
                            vehicleCommand.Parameters.Add(new MySqlParameter("@vehicleId", sale.SaleVehicleID));
                            vehicleCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return saleId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
            }
        }

        // Update sale notary date
        public bool UpdateNotaryDate(int saleId, DateTime notaryDate)
        {
            string query = "UPDATE Sales SET SaleNotaryDate = @notaryDate, SaleUpdatedAt = @updatedAt WHERE SaleID = @saleId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@notaryDate", notaryDate),
                DatabaseHelper.CreateParameter("@updatedAt", DateTime.Now),
                DatabaseHelper.CreateParameter("@saleId", saleId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Get sales statistics by date range
        public DataTable GetSalesStatistics(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    COUNT(*) AS TotalSales,
                    SUM(SaleAmount) AS TotalAmount,
                    AVG(SaleAmount) AS AverageAmount,
                    MIN(SaleAmount) AS MinAmount,
                    MAX(SaleAmount) AS MaxAmount
                FROM Sales
                WHERE SaleDate BETWEEN @startDate AND @endDate";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // Get sales grouped by month
        public DataTable GetSalesByMonth(int year)
        {
            string query = @"
                SELECT 
                    MONTH(SaleDate) AS Month,
                    COUNT(*) AS Count,
                    SUM(SaleAmount) AS TotalAmount
                FROM Sales
                WHERE YEAR(SaleDate) = @year
                GROUP BY MONTH(SaleDate)
                ORDER BY Month";

            var parameter = DatabaseHelper.CreateParameter("@year", year);
            return DatabaseHelper.ExecuteQuery(query, parameter);
        }

        // Get sales grouped by vehicle brand
        public DataTable GetSalesByBrand()
        {
            string query = @"
                SELECT 
                    v.VehicleBrand AS Brand,
                    COUNT(*) AS Count,
                    SUM(s.SaleAmount) AS TotalAmount,
                    AVG(s.SaleAmount) AS AverageAmount
                FROM Sales s
                INNER JOIN Vehicles v ON s.SaleVehicleID = v.VehicleID
                GROUP BY v.VehicleBrand
                ORDER BY Count DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Helper method to get customer
        private Customer GetCustomer(int customerId)
        {
            string query = "SELECT * FROM Customers WHERE CustomerID = @customerId";
            var parameter = DatabaseHelper.CreateParameter("@customerId", customerId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Customer
            {
                CustomerID = row.GetValue<int>("CustomerID"),
                CustomerFirstName = row.GetValue<string>("CustomerFirstName"),
                CustomerLastName = row.GetValue<string>("CustomerLastName"),
                CustomerNationalID = row.GetValue<string>("CustomerNationalID"),
                CustomerPhone = row.GetValue<string>("CustomerPhone"),
                CustomerEmail = row.GetValue<string>("CustomerEmail")
                // Add other fields as needed
            };
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
                VehicleModel = row.GetValue<string>("VehicleModel"),
                VehicleYear = row.GetValue<int>("VehicleYear"),
                VehicleSalePrice = row.GetValue<decimal?>("VehicleSalePrice")
                // Add other fields as needed
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
                UserLastName = row.GetValue<string>("UserLastName"),
                Username = row.GetValue<string>("Username")
                // Add other fields as needed
            };
        }
    }
}