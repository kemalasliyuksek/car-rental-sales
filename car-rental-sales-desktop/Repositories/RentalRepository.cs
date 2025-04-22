using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace car_rental_sales_desktop.Repositories
{
    public class RentalRepository : IRepository<Rental>
    {
        public List<Rental> GetAll()
        {
            string query = @"SELECT r.*, 
                           CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                           v.PlateNumber, CONCAT(v.Brand, ' ', v.Model) AS VehicleName,
                           CONCAT(u.FirstName, ' ', u.LastName) AS UserFullName
                           FROM Rentals r
                           JOIN Customers c ON r.CustomerID = c.CustomerID
                           JOIN Vehicles v ON r.VehicleID = v.VehicleID
                           JOIN Users u ON r.UserID = u.UserID
                           ORDER BY r.StartDate DESC";

            try
            {
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                return ConvertDataTableToRentals(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "RentalRepository.GetAll");
                return new List<Rental>();
            }
        }

        public List<Rental> GetActiveRentals()
        {
            string query = @"SELECT r.*, 
                           CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                           v.PlateNumber, CONCAT(v.Brand, ' ', v.Model) AS VehicleName,
                           CONCAT(u.FirstName, ' ', u.LastName) AS UserFullName
                           FROM Rentals r
                           JOIN Customers c ON r.CustomerID = c.CustomerID
                           JOIN Vehicles v ON r.VehicleID = v.VehicleID
                           JOIN Users u ON r.UserID = u.UserID
                           WHERE r.ReturnDate IS NULL
                           ORDER BY r.EndDate ASC";

            try
            {
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                return ConvertDataTableToRentals(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "RentalRepository.GetActiveRentals");
                return new List<Rental>();
            }
        }

        public List<Rental> GetRentalsByCustomerId(int customerId)
        {
            string query = @"SELECT r.*, 
                           CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                           v.PlateNumber, CONCAT(v.Brand, ' ', v.Model) AS VehicleName,
                           CONCAT(u.FirstName, ' ', u.LastName) AS UserFullName
                           FROM Rentals r
                           JOIN Customers c ON r.CustomerID = c.CustomerID
                           JOIN Vehicles v ON r.VehicleID = v.VehicleID
                           JOIN Users u ON r.UserID = u.UserID
                           WHERE r.CustomerID = @CustomerID
                           ORDER BY r.StartDate DESC";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@CustomerID", customerId);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);
                return ConvertDataTableToRentals(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "RentalRepository.GetRentalsByCustomerId");
                return new List<Rental>();
            }
        }

        public List<Rental> GetRentalsByVehicleId(int vehicleId)
        {
            string query = @"SELECT r.*, 
                           CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                           v.PlateNumber, CONCAT(v.Brand, ' ', v.Model) AS VehicleName,
                           CONCAT(u.FirstName, ' ', u.LastName) AS UserFullName
                           FROM Rentals r
                           JOIN Customers c ON r.CustomerID = c.CustomerID
                           JOIN Vehicles v ON r.VehicleID = v.VehicleID
                           JOIN Users u ON r.UserID = u.UserID
                           WHERE r.VehicleID = @VehicleID
                           ORDER BY r.StartDate DESC";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@VehicleID", vehicleId);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);
                return ConvertDataTableToRentals(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "RentalRepository.GetRentalsByVehicleId");
                return new List<Rental>();
            }
        }

        public Rental GetById(int id)
        {
            string query = @"SELECT r.*, 
                           CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                           v.PlateNumber, CONCAT(v.Brand, ' ', v.Model) AS VehicleName,
                           CONCAT(u.FirstName, ' ', u.LastName) AS UserFullName
                           FROM Rentals r
                           JOIN Customers c ON r.CustomerID = c.CustomerID
                           JOIN Vehicles v ON r.VehicleID = v.VehicleID
                           JOIN Users u ON r.UserID = u.UserID
                           WHERE r.RentalID = @RentalID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@RentalID", id);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    return ConvertDataRowToRental(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "RentalRepository.GetById");
                return null;
            }
        }

        public bool Insert(Rental rental)
        {
            // Begin a transaction for rental insert
            using (var connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO Rentals (
                                            CustomerID, VehicleID, StartDate, EndDate, 
                                            StartKm, RentalAmount, DepositAmount, 
                                            PaymentType, ContractID, UserID
                                        ) VALUES (
                                            @CustomerID, @VehicleID, @StartDate, @EndDate, 
                                            @StartKm, @RentalAmount, @DepositAmount, 
                                            @PaymentType, @ContractID, @UserID
                                        );
                                        SELECT LAST_INSERT_ID();";

                        MySqlParameter[] parameters = {
                            DatabaseHelper.CreateParameter("@CustomerID", rental.CustomerID),
                            DatabaseHelper.CreateParameter("@VehicleID", rental.VehicleID),
                            DatabaseHelper.CreateParameter("@StartDate", rental.StartDate),
                            DatabaseHelper.CreateParameter("@EndDate", rental.EndDate),
                            DatabaseHelper.CreateParameter("@StartKm", rental.StartKm),
                            DatabaseHelper.CreateParameter("@RentalAmount", rental.RentalAmount),
                            DatabaseHelper.CreateParameter("@DepositAmount", rental.DepositAmount),
                            DatabaseHelper.CreateParameter("@PaymentType", rental.PaymentType),
                            DatabaseHelper.CreateParameter("@ContractID", rental.ContractID),
                            DatabaseHelper.CreateParameter("@UserID", rental.UserID)
                        };

                        using (var command = new MySqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddRange(parameters);
                            int rentalId = Convert.ToInt32(command.ExecuteScalar());

                            // Update vehicle status to rented (assuming StatusID 2 is "Rented")
                            string updateVehicleQuery = "UPDATE Vehicles SET StatusID = 2, UpdatedAt = NOW() WHERE VehicleID = @VehicleID";
                            using (var vehicleCommand = new MySqlCommand(updateVehicleQuery, connection, transaction))
                            {
                                vehicleCommand.Parameters.AddWithValue("@VehicleID", rental.VehicleID);
                                vehicleCommand.ExecuteNonQuery();
                            }

                            // Insert rental note if provided
                            if (!string.IsNullOrEmpty(rental.RentalNote?.NoteText))
                            {
                                string insertNoteQuery = @"INSERT INTO RentalNotes (RentalID, NoteText, UserID) 
                                                         VALUES (@RentalID, @NoteText, @UserID);
                                                         SELECT LAST_INSERT_ID();";

                                using (var noteCommand = new MySqlCommand(insertNoteQuery, connection, transaction))
                                {
                                    noteCommand.Parameters.AddWithValue("@RentalID", rentalId);
                                    noteCommand.Parameters.AddWithValue("@NoteText", rental.RentalNote.NoteText);
                                    noteCommand.Parameters.AddWithValue("@UserID", rental.UserID);

                                    int noteId = Convert.ToInt32(noteCommand.ExecuteScalar());

                                    // Update the rental with the note ID
                                    string updateRentalQuery = "UPDATE Rentals SET RentalNoteID = @NoteID WHERE RentalID = @RentalID";
                                    using (var updateCommand = new MySqlCommand(updateRentalQuery, connection, transaction))
                                    {
                                        updateCommand.Parameters.AddWithValue("@NoteID", noteId);
                                        updateCommand.Parameters.AddWithValue("@RentalID", rentalId);
                                        updateCommand.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ErrorLogger.LogError(ex, "RentalRepository.Insert");
                        return false;
                    }
                }
            }
        }

        public bool Update(Rental rental)
        {
            string query = @"UPDATE Rentals SET 
                                CustomerID = @CustomerID, 
                                VehicleID = @VehicleID, 
                                StartDate = @StartDate, 
                                EndDate = @EndDate, 
                                ReturnDate = @ReturnDate,
                                StartKm = @StartKm, 
                                EndKm = @EndKm,
                                RentalAmount = @RentalAmount, 
                                DepositAmount = @DepositAmount, 
                                PaymentType = @PaymentType, 
                                ContractID = @ContractID,
                                UpdatedAt = NOW()
                            WHERE RentalID = @RentalID";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@RentalID", rental.RentalID),
                DatabaseHelper.CreateParameter("@CustomerID", rental.CustomerID),
                DatabaseHelper.CreateParameter("@VehicleID", rental.VehicleID),
                DatabaseHelper.CreateParameter("@StartDate", rental.StartDate),
                DatabaseHelper.CreateParameter("@EndDate", rental.EndDate),
                DatabaseHelper.CreateParameter("@ReturnDate", rental.ReturnDate),
                DatabaseHelper.CreateParameter("@StartKm", rental.StartKm),
                DatabaseHelper.CreateParameter("@EndKm", rental.EndKm),
                DatabaseHelper.CreateParameter("@RentalAmount", rental.RentalAmount),
                DatabaseHelper.CreateParameter("@DepositAmount", rental.DepositAmount),
                DatabaseHelper.CreateParameter("@PaymentType", rental.PaymentType),
                DatabaseHelper.CreateParameter("@ContractID", rental.ContractID)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "RentalRepository.Update");
                return false;
            }
        }

        public bool ReturnVehicle(int rentalId, DateTime returnDate, int endKm)
        {
            // Begin a transaction for return process
            using (var connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // First get the rental and vehicle information
                        string getRentalQuery = "SELECT VehicleID FROM Rentals WHERE RentalID = @RentalID";
                        int vehicleId;

                        using (var command = new MySqlCommand(getRentalQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@RentalID", rentalId);
                            vehicleId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // Update the rental record
                        string updateRentalQuery = @"UPDATE Rentals 
                                                   SET ReturnDate = @ReturnDate, 
                                                       EndKm = @EndKm,
                                                       UpdatedAt = NOW()
                                                   WHERE RentalID = @RentalID";

                        using (var command = new MySqlCommand(updateRentalQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@RentalID", rentalId);
                            command.Parameters.AddWithValue("@ReturnDate", returnDate);
                            command.Parameters.AddWithValue("@EndKm", endKm);
                            command.ExecuteNonQuery();
                        }

                        // Update vehicle status and mileage
                        // Assuming StatusID 1 is "Available"
                        string updateVehicleQuery = @"UPDATE Vehicles 
                                                    SET StatusID = 1, 
                                                        Mileage = @Mileage,
                                                        UpdatedAt = NOW()
                                                    WHERE VehicleID = @VehicleID";

                        using (var command = new MySqlCommand(updateVehicleQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@VehicleID", vehicleId);
                            command.Parameters.AddWithValue("@Mileage", endKm);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ErrorLogger.LogError(ex, "RentalRepository.ReturnVehicle");
                        return false;
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            // Typically, rentals should not be deleted, but this functionality is included for completeness
            string query = "DELETE FROM Rentals WHERE RentalID = @RentalID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@RentalID", id);
                int result = DatabaseHelper.ExecuteNonQuery(query, parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "RentalRepository.Delete");
                return false;
            }
        }

        // Helper methods to convert DataTable to Rental objects
        private List<Rental> ConvertDataTableToRentals(DataTable dataTable)
        {
            List<Rental> rentals = new List<Rental>();

            foreach (DataRow row in dataTable.Rows)
            {
                rentals.Add(ConvertDataRowToRental(row));
            }

            return rentals;
        }

        private Rental ConvertDataRowToRental(DataRow row)
        {
            Rental rental = new Rental
            {
                RentalID = row.GetValue<int>("RentalID"),
                CustomerID = row.GetValue<int>("CustomerID"),
                VehicleID = row.GetValue<int>("VehicleID"),
                StartDate = row.GetValue<DateTime>("StartDate"),
                EndDate = row.GetValue<DateTime>("EndDate"),
                ReturnDate = row.GetValue<DateTime?>("ReturnDate"),
                StartKm = row.GetValue<int>("StartKm"),
                EndKm = row.GetValue<int?>("EndKm"),
                RentalAmount = row.GetValue<decimal>("RentalAmount"),
                DepositAmount = row.GetValue<decimal?>("DepositAmount"),
                PaymentType = row.GetValue<string>("PaymentType"),
                RentalNoteID = row.GetValue<int?>("RentalNoteID"),
                ContractID = row.GetValue<int?>("ContractID"),
                UserID = row.GetValue<int>("UserID"),
                CreatedAt = row.GetValue<DateTime>("CreatedAt"),
                UpdatedAt = row.GetValue<DateTime?>("UpdatedAt")
            };

            // Optional navigation properties if joined with other tables
            if (row.Table.Columns.Contains("CustomerName"))
            {
                rental.Customer = new Customer
                {
                    CustomerID = rental.CustomerID,
                    FirstName = row.GetValue<string>("CustomerName").Split(' ')[0],
                    LastName = row.GetValue<string>("CustomerName").Split(' ')[1]
                };
            }

            if (row.Table.Columns.Contains("PlateNumber"))
            {
                rental.Vehicle = new Vehicle
                {
                    VehicleID = rental.VehicleID,
                    PlateNumber = row.GetValue<string>("PlateNumber"),
                    Brand = row.GetValue<string>("VehicleName").Split(' ')[0],
                    Model = row.GetValue<string>("VehicleName").Split(' ')[1]
                };
            }

            if (row.Table.Columns.Contains("UserFullName"))
            {
                string[] nameParts = row.GetValue<string>("UserFullName").Split(' ');
                rental.User = new User
                {
                    UserID = rental.UserID,
                    FirstName = nameParts[0],
                    LastName = nameParts[1]
                };
            }

            return rental;
        }
    }
}