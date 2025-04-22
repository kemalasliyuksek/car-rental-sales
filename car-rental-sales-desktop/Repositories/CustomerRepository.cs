using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace car_rental_sales_desktop.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetAll()
        {
            string query = "SELECT * FROM Customers WHERE IsAvailable = 1 ORDER BY FirstName, LastName";

            try
            {
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                return ConvertDataTableToCustomers(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "CustomerRepository.GetAll");
                return new List<Customer>();
            }
        }

        public Customer GetById(int id)
        {
            string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@CustomerID", id);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    return ConvertDataRowToCustomer(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "CustomerRepository.GetById");
                return null;
            }
        }

        public Customer GetByNationalId(string nationalId)
        {
            string query = "SELECT * FROM Customers WHERE NationalID = @NationalID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@NationalID", nationalId);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    return ConvertDataRowToCustomer(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "CustomerRepository.GetByNationalId");
                return null;
            }
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            string query = @"SELECT * FROM Customers 
                           WHERE IsAvailable = 1 AND (
                               FirstName LIKE @SearchTerm OR 
                               LastName LIKE @SearchTerm OR 
                               NationalID LIKE @SearchTerm OR 
                               PhoneNumber LIKE @SearchTerm OR 
                               Email LIKE @SearchTerm
                           ) ORDER BY FirstName, LastName";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@SearchTerm", "%" + searchTerm + "%");
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);
                return ConvertDataTableToCustomers(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "CustomerRepository.SearchCustomers");
                return new List<Customer>();
            }
        }

        public bool Insert(Customer customer)
        {
            string query = @"INSERT INTO Customers (
                                FirstName, LastName, NationalID, DateOfBirth, 
                                LicenseNumber, LicenseClass, LicenseDate, 
                                CountryCode, PhoneNumber, Email, Address, 
                                CustomerType, IsAvailable
                            ) VALUES (
                                @FirstName, @LastName, @NationalID, @DateOfBirth, 
                                @LicenseNumber, @LicenseClass, @LicenseDate, 
                                @CountryCode, @PhoneNumber, @Email, @Address, 
                                @CustomerType, @IsAvailable
                            )";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@FirstName", customer.FirstName),
                DatabaseHelper.CreateParameter("@LastName", customer.LastName),
                DatabaseHelper.CreateParameter("@NationalID", customer.NationalID),
                DatabaseHelper.CreateParameter("@DateOfBirth", customer.DateOfBirth),
                DatabaseHelper.CreateParameter("@LicenseNumber", customer.LicenseNumber),
                DatabaseHelper.CreateParameter("@LicenseClass", customer.LicenseClass),
                DatabaseHelper.CreateParameter("@LicenseDate", customer.LicenseDate),
                DatabaseHelper.CreateParameter("@CountryCode", customer.CountryCode),
                DatabaseHelper.CreateParameter("@PhoneNumber", customer.PhoneNumber),
                DatabaseHelper.CreateParameter("@Email", customer.Email),
                DatabaseHelper.CreateParameter("@Address", customer.Address),
                DatabaseHelper.CreateParameter("@CustomerType", customer.CustomerType),
                DatabaseHelper.CreateParameter("@IsAvailable", customer.IsAvailable)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "CustomerRepository.Insert");
                return false;
            }
        }

        public bool Update(Customer customer)
        {
            string query = @"UPDATE Customers SET 
                                FirstName = @FirstName, 
                                LastName = @LastName, 
                                NationalID = @NationalID, 
                                DateOfBirth = @DateOfBirth, 
                                LicenseNumber = @LicenseNumber, 
                                LicenseClass = @LicenseClass, 
                                LicenseDate = @LicenseDate, 
                                CountryCode = @CountryCode, 
                                PhoneNumber = @PhoneNumber, 
                                Email = @Email, 
                                Address = @Address, 
                                CustomerType = @CustomerType, 
                                IsAvailable = @IsAvailable,
                                UpdatedAt = NOW()
                            WHERE CustomerID = @CustomerID";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@CustomerID", customer.CustomerID),
                DatabaseHelper.CreateParameter("@FirstName", customer.FirstName),
                DatabaseHelper.CreateParameter("@LastName", customer.LastName),
                DatabaseHelper.CreateParameter("@NationalID", customer.NationalID),
                DatabaseHelper.CreateParameter("@DateOfBirth", customer.DateOfBirth),
                DatabaseHelper.CreateParameter("@LicenseNumber", customer.LicenseNumber),
                DatabaseHelper.CreateParameter("@LicenseClass", customer.LicenseClass),
                DatabaseHelper.CreateParameter("@LicenseDate", customer.LicenseDate),
                DatabaseHelper.CreateParameter("@CountryCode", customer.CountryCode),
                DatabaseHelper.CreateParameter("@PhoneNumber", customer.PhoneNumber),
                DatabaseHelper.CreateParameter("@Email", customer.Email),
                DatabaseHelper.CreateParameter("@Address", customer.Address),
                DatabaseHelper.CreateParameter("@CustomerType", customer.CustomerType),
                DatabaseHelper.CreateParameter("@IsAvailable", customer.IsAvailable)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "CustomerRepository.Update");
                return false;
            }
        }

        public bool Delete(int id)
        {
            // Soft delete - just update IsAvailable to false
            string query = "UPDATE Customers SET IsAvailable = 0, UpdatedAt = NOW() WHERE CustomerID = @CustomerID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@CustomerID", id);
                int result = DatabaseHelper.ExecuteNonQuery(query, parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "CustomerRepository.Delete");
                return false;
            }
        }

        // Helper methods to convert DataTable to Customer objects
        private List<Customer> ConvertDataTableToCustomers(DataTable dataTable)
        {
            List<Customer> customers = new List<Customer>();

            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(ConvertDataRowToCustomer(row));
            }

            return customers;
        }

        private Customer ConvertDataRowToCustomer(DataRow row)
        {
            return new Customer
            {
                CustomerID = row.GetValue<int>("CustomerID"),
                FirstName = row.GetValue<string>("FirstName"),
                LastName = row.GetValue<string>("LastName"),
                NationalID = row.GetValue<string>("NationalID"),
                DateOfBirth = row.GetValue<DateTime?>("DateOfBirth"),
                LicenseNumber = row.GetValue<string>("LicenseNumber"),
                LicenseClass = row.GetValue<string>("LicenseClass"),
                LicenseDate = row.GetValue<DateTime?>("LicenseDate"),
                CountryCode = row.GetValue<string>("CountryCode"),
                PhoneNumber = row.GetValue<string>("PhoneNumber"),
                Email = row.GetValue<string>("Email"),
                Address = row.GetValue<string>("Address"),
                RegistrationDate = row.GetValue<DateTime>("RegistrationDate"),
                IsAvailable = row.GetValue<bool>("IsAvailable"),
                CustomerType = row.GetValue<string>("CustomerType"),
                UpdatedAt = row.GetValue<DateTime?>("UpdatedAt")
            };
        }
    }
}