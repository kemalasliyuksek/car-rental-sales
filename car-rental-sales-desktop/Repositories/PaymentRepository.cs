using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>
    {
        public PaymentRepository() : base("Payments", "PaymentID")
        {
        }

        protected override Payment MapToModel(DataRow row)
        {
            return new Payment
            {
                PaymentID = row.GetValue<int>("PaymentID"),
                PaymentTransactionType = row.GetValue<string>("PaymentTransactionType"),
                PaymentTransactionID = row.GetValue<int>("PaymentTransactionID"),
                PaymentCustomerID = row.GetValue<int>("PaymentCustomerID"),
                PaymentAmount = row.GetValue<decimal>("PaymentAmount"),
                PaymentDate = row.GetValue<DateTime>("PaymentDate"),
                PaymentType = row.GetValue<string>("PaymentType"),
                PaymentBankID = row.GetValue<int?>("PaymentBankID"),
                PaymentNote = row.GetValue<string>("PaymentNote"),
                PaymentUserID = row.GetValue<int>("PaymentUserID"),
                PaymentCreatedAt = row.GetValue<DateTime>("PaymentCreatedAt"),

                // Navigation properties
                Customer = GetCustomer(row.GetValue<int>("PaymentCustomerID")),
                Bank = row.GetValue<int?>("PaymentBankID").HasValue ?
                    GetBank(row.GetValue<int>("PaymentBankID")) : null,
                User = GetUser(row.GetValue<int>("PaymentUserID"))
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Payment entity)
        {
            return new Dictionary<string, object>
            {
                { "PaymentTransactionType", entity.PaymentTransactionType },
                { "PaymentTransactionID", entity.PaymentTransactionID },
                { "PaymentCustomerID", entity.PaymentCustomerID },
                { "PaymentAmount", entity.PaymentAmount },
                { "PaymentDate", entity.PaymentDate },
                { "PaymentType", entity.PaymentType },
                { "PaymentBankID", entity.PaymentBankID },
                { "PaymentNote", entity.PaymentNote },
                { "PaymentUserID", entity.PaymentUserID },
                { "PaymentCreatedAt", entity.PaymentCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Payment entity)
        {
            return new Dictionary<string, object>
            {
                { "PaymentTransactionType", entity.PaymentTransactionType },
                { "PaymentTransactionID", entity.PaymentTransactionID },
                { "PaymentCustomerID", entity.PaymentCustomerID },
                { "PaymentAmount", entity.PaymentAmount },
                { "PaymentDate", entity.PaymentDate },
                { "PaymentType", entity.PaymentType },
                { "PaymentBankID", entity.PaymentBankID },
                { "PaymentNote", entity.PaymentNote },
                { "PaymentUserID", entity.PaymentUserID }
            };
        }

        protected override int GetEntityId(Payment entity)
        {
            return entity.PaymentID;
        }

        // Get payments by transaction
        public List<Payment> GetByTransaction(string transactionType, int transactionId)
        {
            string query = "SELECT * FROM Payments WHERE PaymentTransactionType = @transactionType AND PaymentTransactionID = @transactionId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@transactionType", transactionType),
                DatabaseHelper.CreateParameter("@transactionId", transactionId)
            };

            var dataTable = DatabaseHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dataTable);
        }

        // Get payments by customer
        public List<Payment> GetByCustomer(int customerId)
        {
            string query = "SELECT * FROM Payments WHERE PaymentCustomerID = @customerId";
            var parameter = DatabaseHelper.CreateParameter("@customerId", customerId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get payments by date range
        public List<Payment> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM Payments WHERE PaymentDate BETWEEN @startDate AND @endDate";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            var dataTable = DatabaseHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dataTable);
        }

        // Get payments by type
        public List<Payment> GetByPaymentType(string paymentType)
        {
            string query = "SELECT * FROM Payments WHERE PaymentType = @paymentType";
            var parameter = DatabaseHelper.CreateParameter("@paymentType", paymentType);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get payments by bank
        public List<Payment> GetByBank(int bankId)
        {
            string query = "SELECT * FROM Payments WHERE PaymentBankID = @bankId";
            var parameter = DatabaseHelper.CreateParameter("@bankId", bankId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get payments by user
        public List<Payment> GetByUser(int userId)
        {
            string query = "SELECT * FROM Payments WHERE PaymentUserID = @userId";
            var parameter = DatabaseHelper.CreateParameter("@userId", userId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get payment totals by type
        public DataTable GetPaymentTotalsByType()
        {
            string query = @"
                SELECT 
                    PaymentType,
                    COUNT(*) AS PaymentCount,
                    SUM(PaymentAmount) AS TotalAmount
                FROM Payments
                GROUP BY PaymentType
                ORDER BY TotalAmount DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Get payment totals by transaction type
        public DataTable GetPaymentTotalsByTransactionType()
        {
            string query = @"
                SELECT 
                    PaymentTransactionType,
                    COUNT(*) AS PaymentCount,
                    SUM(PaymentAmount) AS TotalAmount
                FROM Payments
                GROUP BY PaymentTransactionType
                ORDER BY TotalAmount DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Get payment statistics by date range
        public DataTable GetPaymentStatistics(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    COUNT(*) AS TotalPayments,
                    SUM(PaymentAmount) AS TotalAmount,
                    AVG(PaymentAmount) AS AverageAmount,
                    MIN(PaymentAmount) AS MinAmount,
                    MAX(PaymentAmount) AS MaxAmount
                FROM Payments
                WHERE PaymentDate BETWEEN @startDate AND @endDate";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // Get payments by month
        public DataTable GetPaymentsByMonth(int year)
        {
            string query = @"
                SELECT 
                    MONTH(PaymentDate) AS Month,
                    COUNT(*) AS PaymentCount,
                    SUM(PaymentAmount) AS TotalAmount
                FROM Payments
                WHERE YEAR(PaymentDate) = @year
                GROUP BY MONTH(PaymentDate)
                ORDER BY Month";

            var parameter = DatabaseHelper.CreateParameter("@year", year);
            return DatabaseHelper.ExecuteQuery(query, parameter);
        }

        // Create transaction payment with multiple payment methods
        public bool CreateTransactionPayments(string transactionType, int transactionId, int customerId, List<Payment> payments)
        {
            using (var connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var payment in payments)
                        {
                            string insertQuery = @"
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
                                    @transactionType,
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

                            using (var command = new MySqlCommand(insertQuery, connection, transaction))
                            {
                                command.Parameters.Add(new MySqlParameter("@transactionType", transactionType));
                                command.Parameters.Add(new MySqlParameter("@transactionId", transactionId));
                                command.Parameters.Add(new MySqlParameter("@customerId", customerId));
                                command.Parameters.Add(new MySqlParameter("@amount", payment.PaymentAmount));
                                command.Parameters.Add(new MySqlParameter("@paymentDate", payment.PaymentDate));
                                command.Parameters.Add(new MySqlParameter("@paymentType", payment.PaymentType));
                                command.Parameters.Add(new MySqlParameter("@bankId", payment.PaymentBankID ?? (object)DBNull.Value));
                                command.Parameters.Add(new MySqlParameter("@note", payment.PaymentNote ?? (object)DBNull.Value));
                                command.Parameters.Add(new MySqlParameter("@userId", payment.PaymentUserID));
                                command.Parameters.Add(new MySqlParameter("@createdAt", DateTime.Now));
                                command.ExecuteNonQuery();
                            }
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
                CustomerLastName = row.GetValue<string>("CustomerLastName")
                // Add other fields as needed
            };
        }

        // Helper method to get bank
        private Bank GetBank(int? bankId)
        {
            if (!bankId.HasValue)
                return null;

            string query = "SELECT * FROM Banks WHERE BankID = @bankId";
            var parameter = DatabaseHelper.CreateParameter("@bankId", bankId.Value);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Bank
            {
                BankID = row.GetValue<int>("BankID"),
                BankName = row.GetValue<string>("BankName"),
                BankDescription = row.GetValue<string>("BankDescription")
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