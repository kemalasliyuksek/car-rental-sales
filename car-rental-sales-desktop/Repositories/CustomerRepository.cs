using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository() : base("Customers", "CustomerID")
        {
        }

        protected override Customer MapToModel(DataRow row)
        {
            return new Customer
            {
                CustomerID = row.GetValue<int>("CustomerID"),
                CustomerFirstName = row.GetValue<string>("CustomerFirstName"),
                CustomerLastName = row.GetValue<string>("CustomerLastName"),
                CustomerNationalID = row.GetValue<string>("CustomerNationalID"),
                CustomerDateOfBirth = row.GetValue<DateTime?>("CustomerDateOfBirth"),//
                CustomerLicenseNumber = row.GetValue<string>("CustomerLicenseNumber"),
                CustomerLicenseClass = row.GetValue<string>("CustomerLicenseClass"),
                CustomerLicenseDate = row.GetValue<DateTime?>("CustomerLicenseDate"),//
                CustomerPhone = row.GetValue<string>("CustomerPhone"),
                CustomerEmail = row.GetValue<string>("CustomerEmail"),
                CustomerAddress = row.GetValue<string>("CustomerAddress"),
                CustomerRegistrationDate = row.GetValue<DateTime>("CustomerRegistrationDate"),
                CustomerAvailable = row.GetValue<bool>("CustomerAvailable"),
                CustomerType = row.GetValue<string>("CustomerType"),//
                CustomerUpdatedAt = row.GetValue<DateTime?>("CustomerUpdatedAt")//
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Customer entity)
        {
            return new Dictionary<string, object>
            {
                { "CustomerFirstName", entity.CustomerFirstName },
                { "CustomerLastName", entity.CustomerLastName },
                { "CustomerNationalID", entity.CustomerNationalID },
                { "CustomerDateOfBirth", entity.CustomerDateOfBirth },
                { "CustomerLicenseNumber", entity.CustomerLicenseNumber },
                { "CustomerLicenseClass", entity.CustomerLicenseClass },
                { "CustomerLicenseDate", entity.CustomerLicenseDate },
                { "CustomerPhone", entity.CustomerPhone },
                { "CustomerEmail", entity.CustomerEmail },
                { "CustomerAddress", entity.CustomerAddress },
                { "CustomerRegistrationDate", entity.CustomerRegistrationDate },
                { "CustomerAvailable", entity.CustomerAvailable },
                { "CustomerType", entity.CustomerType }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Customer entity)
        {
            return new Dictionary<string, object>
            {
                { "CustomerFirstName", entity.CustomerFirstName },
                { "CustomerLastName", entity.CustomerLastName },
                { "CustomerNationalID", entity.CustomerNationalID },
                { "CustomerDateOfBirth", entity.CustomerDateOfBirth },
                { "CustomerLicenseNumber", entity.CustomerLicenseNumber },
                { "CustomerLicenseClass", entity.CustomerLicenseClass },
                { "CustomerLicenseDate", entity.CustomerLicenseDate },
                { "CustomerPhone", entity.CustomerPhone },
                { "CustomerEmail", entity.CustomerEmail },
                { "CustomerAddress", entity.CustomerAddress },
                { "CustomerAvailable", entity.CustomerAvailable },
                { "CustomerType", entity.CustomerType },
                { "CustomerUpdatedAt", DateTime.Now }
            };
        }

        protected override int GetEntityId(Customer entity)
        {
            return entity.CustomerID;
        }

        // Get customer by national ID
        public Customer GetByNationalID(string nationalID)
        {
            string query = "SELECT * FROM Customers WHERE CustomerNationalID = @nationalID";
            var parameter = DatabaseHelper.CreateParameter("@nationalID", nationalID);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Get customer by phone
        public Customer GetByPhone(string phone)
        {
            string query = "SELECT * FROM Customers WHERE CustomerPhone = @phone";
            var parameter = DatabaseHelper.CreateParameter("@phone", phone);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Search customers
        public List<Customer> Search(string searchTerm)
        {
            string query = @"
                SELECT * FROM Customers 
                WHERE CustomerFirstName LIKE @searchTerm 
                   OR CustomerLastName LIKE @searchTerm 
                   OR CustomerNationalID LIKE @searchTerm 
                   OR CustomerPhone LIKE @searchTerm 
                   OR CustomerEmail LIKE @searchTerm";

            var parameter = DatabaseHelper.CreateParameter("@searchTerm", $"%{searchTerm}%");
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get active customers
        public List<Customer> GetActiveCustomers()
        {
            string query = "SELECT * FROM Customers WHERE CustomerAvailable = 1";
            var dataTable = DatabaseHelper.ExecuteQuery(query);

            return ConvertDataTableToList(dataTable);
        }

        // Get customers by type (Individual, Corporate, etc.)
        public List<Customer> GetByType(string customerType)
        {
            string query = "SELECT * FROM Customers WHERE CustomerType = @customerType";
            var parameter = DatabaseHelper.CreateParameter("@customerType", customerType);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get customers with rentals
        public List<Customer> GetCustomersWithRentals()
        {
            string query = @"
                SELECT DISTINCT c.* 
                FROM Customers c
                INNER JOIN Rentals r ON c.CustomerID = r.RentalCustomerID";

            var dataTable = DatabaseHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dataTable);
        }

        // Get customers with sales
        public List<Customer> GetCustomersWithSales()
        {
            string query = @"
                SELECT DISTINCT c.* 
                FROM Customers c
                INNER JOIN Sales s ON c.CustomerID = s.SaleCustomerID";

            var dataTable = DatabaseHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dataTable);
        }

        // Get total number of customers
        public int GetTotalCount()
        {
            string query = "SELECT COUNT(*) FROM Customers";
            object result = DatabaseHelper.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        // Get customers with expired license
        public List<Customer> GetCustomersWithExpiredLicense()
        {
            string query = "SELECT * FROM Customers WHERE CustomerLicenseDate < @today AND CustomerLicenseDate IS NOT NULL";
            var parameter = DatabaseHelper.CreateParameter("@today", DateTime.Today);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get new customers registered in the last N days
        public List<Customer> GetNewCustomers(int days)
        {
            string query = "SELECT * FROM Customers WHERE CustomerRegistrationDate >= @startDate";
            var parameter = DatabaseHelper.CreateParameter("@startDate", DateTime.Now.AddDays(-days));
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }
    }
}