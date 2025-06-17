using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class RentalRepository : BaseRepository<Rental>
    {
        public RentalRepository() : base("Rentals", "RentalID")
        {
        }

        protected override Rental MapToModel(DataRow row)
        {
            return new Rental
            {
                RentalID = row.GetValue<int>("RentalID"),
                RentalCustomerID = row.GetValue<int>("RentalCustomerID"),
                RentalVehicleID = row.GetValue<int>("RentalVehicleID"),
                RentalStartDate = row.GetValue<DateTime>("RentalStartDate"),
                RentalEndDate = row.GetValue<DateTime>("RentalEndDate"),
                RentalReturnDate = row.GetValue<DateTime?>("RentalReturnDate"),
                RentalStartKm = row.GetValue<int>("RentalStartKm"),
                RentalEndKm = row.GetValue<int?>("RentalEndKm"),
                RentalAmount = row.GetValue<decimal>("RentalAmount"),
                RentalDepositAmount = row.GetValue<decimal?>("RentalDepositAmount"),
                RentalPaymentType = row.GetValue<string>("RentalPaymentType"),
                RentalStatus = row.GetValue<string>("RentalStatus") ?? "Pending",
                RentalNoteID = row.GetValue<int?>("RentalNoteID"),
                RentalContractID = row.GetValue<int?>("RentalContractID"),
                RentalUserID = row.GetValue<int>("RentalUserID"),
                RentalCreatedAt = row.GetValue<DateTime>("RentalCreatedAt"),
                RentalUpdatedAt = row.GetValue<DateTime?>("RentalUpdatedAt"),

                // Navigasyon özellikleri - gerekirse ayrı olarak yüklenebilir
                Customer = GetCustomer(row.GetValue<int>("RentalCustomerID")),
                Vehicle = GetVehicle(row.GetValue<int>("RentalVehicleID")),
                User = GetUser(row.GetValue<int>("RentalUserID"))
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Rental entity)
        {
            return new Dictionary<string, object>
            {
                { "RentalCustomerID", entity.RentalCustomerID },
                { "RentalVehicleID", entity.RentalVehicleID },
                { "RentalStartDate", entity.RentalStartDate },
                { "RentalEndDate", entity.RentalEndDate },
                { "RentalReturnDate", entity.RentalReturnDate },
                { "RentalStartKm", entity.RentalStartKm },
                { "RentalEndKm", entity.RentalEndKm },
                { "RentalAmount", entity.RentalAmount },
                { "RentalDepositAmount", entity.RentalDepositAmount },
                { "RentalPaymentType", entity.RentalPaymentType },
                { "RentalStatus", entity.RentalStatus ?? "Pending" },
                { "RentalNoteID", entity.RentalNoteID },
                { "RentalContractID", entity.RentalContractID },
                { "RentalUserID", entity.RentalUserID },
                { "RentalCreatedAt", entity.RentalCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Rental entity)
        {
            return new Dictionary<string, object>
            {
                { "RentalCustomerID", entity.RentalCustomerID },
                { "RentalVehicleID", entity.RentalVehicleID },
                { "RentalStartDate", entity.RentalStartDate },
                { "RentalEndDate", entity.RentalEndDate },
                { "RentalReturnDate", entity.RentalReturnDate },
                { "RentalStartKm", entity.RentalStartKm },
                { "RentalEndKm", entity.RentalEndKm },
                { "RentalAmount", entity.RentalAmount },
                { "RentalDepositAmount", entity.RentalDepositAmount },
                { "RentalPaymentType", entity.RentalPaymentType },
                { "RentalNoteID", entity.RentalNoteID },
                { "RentalContractID", entity.RentalContractID },
                { "RentalUserID", entity.RentalUserID },
                { "RentalUpdatedAt", DateTime.Now }
            };
        }

        protected override int GetEntityId(Rental entity)
        {
            return entity.RentalID;
        }

        // Aktif kiralamaları getir (henüz iade edilmemiş)
        public List<Rental> GetActiveRentals()
        {
            string query = "SELECT * FROM Rentals WHERE RentalReturnDate IS NULL AND RentalStatus <> 'Rejected'";
            var dataTable = DatabaseHelper.ExecuteQuery(query);

            return ConvertDataTableToList(dataTable);
        }

        // Vadesi geçmiş kiralamaları getir
        public List<Rental> GetOverdueRentals()
        {
            string query = "SELECT * FROM Rentals WHERE RentalEndDate < @today AND RentalReturnDate IS NULL";
            var parameter = DatabaseHelper.CreateParameter("@today", DateTime.Today);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Müşteriye göre kiralamaları getir
        public List<Rental> GetByCustomer(int customerId)
        {
            string query = "SELECT * FROM Rentals WHERE RentalCustomerID = @customerId";
            var parameter = DatabaseHelper.CreateParameter("@customerId", customerId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Araca göre kiralamaları getir
        public List<Rental> GetByVehicle(int vehicleId)
        {
            string query = "SELECT * FROM Rentals WHERE RentalVehicleID = @vehicleId";
            var parameter = DatabaseHelper.CreateParameter("@vehicleId", vehicleId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Tarih aralığına göre kiralamaları getir
        public List<Rental> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT * FROM Rentals 
                WHERE (RentalStartDate BETWEEN @startDate AND @endDate) 
                   OR (RentalEndDate BETWEEN @startDate AND @endDate)
                   OR (RentalStartDate <= @startDate AND RentalEndDate >= @endDate)";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            var dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

            return ConvertDataTableToList(dataTable);
        }

        // Şubeye göre kiralamaları getir
        public List<Rental> GetByBranch(int branchId)
        {
            string query = @"
                SELECT r.* FROM Rentals r
                INNER JOIN Vehicles v ON r.RentalVehicleID = v.VehicleID
                WHERE v.VehicleBranchID = @branchId";

            var parameter = DatabaseHelper.CreateParameter("@branchId", branchId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Kullanıcı tarafından oluşturulan kiralamaları getir
        public List<Rental> GetByUser(int userId)
        {
            string query = "SELECT * FROM Rentals WHERE RentalUserID = @userId";
            var parameter = DatabaseHelper.CreateParameter("@userId", userId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Araç iade işlemini yap
        public bool ProcessReturn(int rentalId, DateTime returnDate, int endKm)
        {
            using (var connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiralama iade bilgilerini güncelle
                        string updateRentalQuery = @"
                            UPDATE Rentals 
                            SET RentalReturnDate = @returnDate, 
                                RentalEndKm = @endKm,
                                RentalUpdatedAt = @updatedAt
                            WHERE RentalID = @rentalId";

                        var rentalParameters = new[]
                        {
                            new MySqlParameter("@returnDate", returnDate),
                            new MySqlParameter("@endKm", endKm),
                            new MySqlParameter("@updatedAt", DateTime.Now),
                            new MySqlParameter("@rentalId", rentalId)
                        };

                        using (var rentalCommand = new MySqlCommand(updateRentalQuery, connection, transaction))
                        {
                            rentalCommand.Parameters.AddRange(rentalParameters);
                            rentalCommand.ExecuteNonQuery();
                        }

                        // 2. Araç kimliğini al ve araç bilgilerini güncelle
                        string getVehicleQuery = "SELECT RentalVehicleID FROM Rentals WHERE RentalID = @rentalId";
                        int vehicleId;

                        using (var getVehicleCommand = new MySqlCommand(getVehicleQuery, connection, transaction))
                        {
                            getVehicleCommand.Parameters.Add(new MySqlParameter("@rentalId", rentalId));
                            vehicleId = Convert.ToInt32(getVehicleCommand.ExecuteScalar());
                        }

                        // 3. Araç kilometresini ve durumunu güncelle
                        string updateVehicleQuery = @"
                            UPDATE Vehicles 
                            SET VehicleMileage = @mileage, 
                                VehicleStatusID = 1, -- 1'in 'Müsait' olduğunu varsayalım
                                VehicleUpdatedAt = @updatedAt
                            WHERE VehicleID = @vehicleId";

                        var vehicleParameters = new[]
                        {
                            new MySqlParameter("@mileage", endKm),
                            new MySqlParameter("@updatedAt", DateTime.Now),
                            new MySqlParameter("@vehicleId", vehicleId)
                        };

                        using (var vehicleCommand = new MySqlCommand(updateVehicleQuery, connection, transaction))
                        {
                            vehicleCommand.Parameters.AddRange(vehicleParameters);
                            vehicleCommand.ExecuteNonQuery();
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

        // Not ile kiralama oluştur
        public int CreateRentalWithNote(Rental rental, string noteText)
        {
            using (var connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiralama notunu ekle
                        string insertNoteQuery = @"
                            INSERT INTO RentalNotes (
                                RentalID,
                                RentalNoteText,
                                RentalNoteCreatedAt,
                                RentalNoteUserID
                            ) VALUES (
                                @rentalId,
                                @noteText,
                                @createdAt,
                                @userId
                            );
                            SELECT LAST_INSERT_ID();";

                        int noteId;
                        int tempRentalId = -1; // Geçici yer tutucu

                        using (var noteCommand = new MySqlCommand(insertNoteQuery, connection, transaction))
                        {
                            noteCommand.Parameters.Add(new MySqlParameter("@rentalId", tempRentalId));
                            noteCommand.Parameters.Add(new MySqlParameter("@noteText", noteText));
                            noteCommand.Parameters.Add(new MySqlParameter("@createdAt", DateTime.Now));
                            noteCommand.Parameters.Add(new MySqlParameter("@userId", rental.RentalUserID));
                            noteId = Convert.ToInt32(noteCommand.ExecuteScalar());
                        }

                        // 2. Not kimliği ile kiralamayı ekle
                        string insertRentalQuery = @"
                            INSERT INTO Rentals (
                                RentalCustomerID,
                                RentalVehicleID,
                                RentalStartDate,
                                RentalEndDate,
                                RentalReturnDate,
                                RentalStartKm,
                                RentalEndKm,
                                RentalAmount,
                                RentalDepositAmount,
                                RentalPaymentType,
                                RentalNoteID,
                                RentalContractID,
                                RentalUserID,
                                RentalCreatedAt
                            ) VALUES (
                                @customerId,
                                @vehicleId,
                                @startDate,
                                @endDate,
                                @returnDate,
                                @startKm,
                                @endKm,
                                @amount,
                                @depositAmount,
                                @paymentType,
                                @noteId,
                                @contractId,
                                @userId,
                                @createdAt
                            );
                            SELECT LAST_INSERT_ID();";

                        int rentalId;

                        using (var rentalCommand = new MySqlCommand(insertRentalQuery, connection, transaction))
                        {
                            rentalCommand.Parameters.Add(new MySqlParameter("@customerId", rental.RentalCustomerID));
                            rentalCommand.Parameters.Add(new MySqlParameter("@vehicleId", rental.RentalVehicleID));
                            rentalCommand.Parameters.Add(new MySqlParameter("@startDate", rental.RentalStartDate));
                            rentalCommand.Parameters.Add(new MySqlParameter("@endDate", rental.RentalEndDate));
                            rentalCommand.Parameters.Add(new MySqlParameter("@returnDate", rental.RentalReturnDate ?? (object)DBNull.Value));
                            rentalCommand.Parameters.Add(new MySqlParameter("@startKm", rental.RentalStartKm));
                            rentalCommand.Parameters.Add(new MySqlParameter("@endKm", rental.RentalEndKm ?? (object)DBNull.Value));
                            rentalCommand.Parameters.Add(new MySqlParameter("@amount", rental.RentalAmount));
                            rentalCommand.Parameters.Add(new MySqlParameter("@depositAmount", rental.RentalDepositAmount ?? (object)DBNull.Value));
                            rentalCommand.Parameters.Add(new MySqlParameter("@paymentType", rental.RentalPaymentType));
                            rentalCommand.Parameters.Add(new MySqlParameter("@noteId", noteId));
                            rentalCommand.Parameters.Add(new MySqlParameter("@contractId", rental.RentalContractID ?? (object)DBNull.Value));
                            rentalCommand.Parameters.Add(new MySqlParameter("@userId", rental.RentalUserID));
                            rentalCommand.Parameters.Add(new MySqlParameter("@createdAt", DateTime.Now));
                            rentalId = Convert.ToInt32(rentalCommand.ExecuteScalar());
                        }

                        // 3. Kiralama notunu doğru kiralama kimliği ile güncelle
                        string updateNoteQuery = "UPDATE RentalNotes SET RentalID = @rentalId WHERE RentalNoteID = @noteId";

                        using (var updateNoteCommand = new MySqlCommand(updateNoteQuery, connection, transaction))
                        {
                            updateNoteCommand.Parameters.Add(new MySqlParameter("@rentalId", rentalId));
                            updateNoteCommand.Parameters.Add(new MySqlParameter("@noteId", noteId));
                            updateNoteCommand.ExecuteNonQuery();
                        }

                        // 4. Araç durumunu güncelle
                        string updateVehicleQuery = @"
                            UPDATE Vehicles 
                            SET VehicleStatusID = 3, -- 3'ün 'Kirada' olduğunu varsayalım
                                VehicleUpdatedAt = @updatedAt
                            WHERE VehicleID = @vehicleId";

                        using (var vehicleCommand = new MySqlCommand(updateVehicleQuery, connection, transaction))
                        {
                            vehicleCommand.Parameters.Add(new MySqlParameter("@updatedAt", DateTime.Now));
                            vehicleCommand.Parameters.Add(new MySqlParameter("@vehicleId", rental.RentalVehicleID));
                            vehicleCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return rentalId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }
            }
        }

        // Mevcut kiralamaya not ekle
        public bool AddNote(int rentalId, string noteText, int userId)
        {
            string query = @"
                INSERT INTO RentalNotes (
                    RentalID,
                    RentalNoteText,
                    RentalNoteCreatedAt,
                    RentalNoteUserID
                ) VALUES (
                    @rentalId,
                    @noteText,
                    @createdAt,
                    @userId
                )";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@rentalId", rentalId),
                DatabaseHelper.CreateParameter("@noteText", noteText),
                DatabaseHelper.CreateParameter("@createdAt", DateTime.Now),
                DatabaseHelper.CreateParameter("@userId", userId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Yeni metod: Onay bekleyen kiralamaları getir
        public List<Rental> GetPendingRentals()
        {
            string query = "SELECT * FROM Rentals WHERE RentalStatus = 'Pending' ORDER BY RentalCreatedAt DESC";
            var dataTable = DatabaseHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dataTable);
        }

        // Yeni metod: Kiralama durumunu güncelle
        public bool UpdateRentalStatus(int rentalId, string status)
        {
            string query = "UPDATE Rentals SET RentalStatus = @status, RentalUpdatedAt = @updatedAt WHERE RentalID = @rentalId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@status", status),
                DatabaseHelper.CreateParameter("@updatedAt", DateTime.Now),
                DatabaseHelper.CreateParameter("@rentalId", rentalId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Bir kiralama için notları getir
        public List<RentalNote> GetNotes(int rentalId)
        {
            string query = @"
                SELECT * FROM RentalNotes
                WHERE RentalID = @rentalId
                ORDER BY RentalNoteCreatedAt DESC";

            var parameter = DatabaseHelper.CreateParameter("@rentalId", rentalId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            var notes = new List<RentalNote>();
            foreach (DataRow row in dataTable.Rows)
            {
                notes.Add(new RentalNote
                {
                    RentalNoteID = row.GetValue<int>("RentalNoteID"),
                    RentalID = row.GetValue<int>("RentalID"),
                    RentalNoteText = row.GetValue<string>("RentalNoteText"),
                    RentalNoteCreatedAt = row.GetValue<DateTime>("RentalNoteCreatedAt"),
                    RentalNoteUserID = row.GetValue<int>("RentalNoteUserID"),
                    User = GetUser(row.GetValue<int>("RentalNoteUserID"))
                });
            }

            return notes;
        }

        // Müşteriyi getirmek için yardımcı metot
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
            };
        }

        // Aracı getirmek için yardımcı metot
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
                VehicleMileage = row.GetValue<int>("VehicleMileage")
            };
        }

        // Kullanıcıyı getirmek için yardımcı metot
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
            };
        }
    }
}