using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace car_rental_sales_desktop.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public List<User> GetAll()
        {
            string query = @"SELECT u.*, r.RoleName, b.BranchName 
                           FROM Users u
                           LEFT JOIN Roles r ON u.RoleID = r.RoleID
                           LEFT JOIN Branches b ON u.BranchID = b.BranchID
                           WHERE u.IsActive = 1 
                           ORDER BY u.FirstName, u.LastName";

            try
            {
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
                return ConvertDataTableToUsers(dataTable);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.GetAll");
                return new List<User>();
            }
        }

        public User GetById(int id)
        {
            string query = @"SELECT u.*, r.RoleName, b.BranchName 
                           FROM Users u
                           LEFT JOIN Roles r ON u.RoleID = r.RoleID
                           LEFT JOIN Branches b ON u.BranchID = b.BranchID
                           WHERE u.UserID = @UserID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@UserID", id);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    return ConvertDataRowToUser(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.GetById");
                return null;
            }
        }

        public User GetByUsername(string username)
        {
            string query = @"SELECT u.*, r.RoleName, b.BranchName 
                           FROM Users u
                           LEFT JOIN Roles r ON u.RoleID = r.RoleID
                           LEFT JOIN Branches b ON u.BranchID = b.BranchID
                           WHERE u.Username = @Username";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@Username", username);
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

                if (dataTable.Rows.Count > 0)
                {
                    return ConvertDataRowToUser(dataTable.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.GetByUsername");
                return null;
            }
        }

        public bool ValidateLogin(string username, string password)
        {
            string query = "SELECT UserID FROM Users WHERE Username = @Username AND Password = @Password AND IsActive = 1";

            try
            {
                MySqlParameter[] parameters = {
                    DatabaseHelper.CreateParameter("@Username", username),
                    DatabaseHelper.CreateParameter("@Password", password)
                };

                DataTable dataTable = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    UpdateLastLogin(dataTable.Rows[0].GetValue<int>("UserID"));
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.ValidateLogin");
                return false;
            }
        }

        public bool UpdateLastLogin(int userId)
        {
            string query = "UPDATE Users SET LastLogin = NOW() WHERE UserID = @UserID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@UserID", userId);
                int result = DatabaseHelper.ExecuteNonQuery(query, parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.UpdateLastLogin");
                return false;
            }
        }

        public bool Insert(User user)
        {
            string query = @"INSERT INTO Users (
                                FirstName, LastName, Username, Password, 
                                Email, CountryCode, PhoneNumber, 
                                RoleID, BranchID, IsActive
                            ) VALUES (
                                @FirstName, @LastName, @Username, @Password, 
                                @Email, @CountryCode, @PhoneNumber, 
                                @RoleID, @BranchID, @IsActive
                            )";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@FirstName", user.FirstName),
                DatabaseHelper.CreateParameter("@LastName", user.LastName),
                DatabaseHelper.CreateParameter("@Username", user.Username),
                DatabaseHelper.CreateParameter("@Password", user.Password),
                DatabaseHelper.CreateParameter("@Email", user.Email),
                DatabaseHelper.CreateParameter("@CountryCode", user.CountryCode),
                DatabaseHelper.CreateParameter("@PhoneNumber", user.PhoneNumber),
                DatabaseHelper.CreateParameter("@RoleID", user.RoleID),
                DatabaseHelper.CreateParameter("@BranchID", user.BranchID),
                DatabaseHelper.CreateParameter("@IsActive", user.IsActive)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.Insert");
                return false;
            }
        }

        public bool Update(User user)
        {
            string query = @"UPDATE Users SET 
                                FirstName = @FirstName, 
                                LastName = @LastName, 
                                Username = @Username, 
                                Email = @Email, 
                                CountryCode = @CountryCode, 
                                PhoneNumber = @PhoneNumber, 
                                RoleID = @RoleID, 
                                BranchID = @BranchID, 
                                IsActive = @IsActive,
                                UpdatedAt = NOW()
                            WHERE UserID = @UserID";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@UserID", user.UserID),
                DatabaseHelper.CreateParameter("@FirstName", user.FirstName),
                DatabaseHelper.CreateParameter("@LastName", user.LastName),
                DatabaseHelper.CreateParameter("@Username", user.Username),
                DatabaseHelper.CreateParameter("@Email", user.Email),
                DatabaseHelper.CreateParameter("@CountryCode", user.CountryCode),
                DatabaseHelper.CreateParameter("@PhoneNumber", user.PhoneNumber),
                DatabaseHelper.CreateParameter("@RoleID", user.RoleID),
                DatabaseHelper.CreateParameter("@BranchID", user.BranchID),
                DatabaseHelper.CreateParameter("@IsActive", user.IsActive)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.Update");
                return false;
            }
        }

        public bool UpdatePassword(int userId, string newPassword)
        {
            string query = "UPDATE Users SET Password = @Password, UpdatedAt = NOW() WHERE UserID = @UserID";

            MySqlParameter[] parameters = {
                DatabaseHelper.CreateParameter("@UserID", userId),
                DatabaseHelper.CreateParameter("@Password", newPassword)
            };

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.UpdatePassword");
                return false;
            }
        }

        public bool Delete(int id)
        {
            // Soft delete - just update IsActive to false
            string query = "UPDATE Users SET IsActive = 0, UpdatedAt = NOW() WHERE UserID = @UserID";

            try
            {
                MySqlParameter parameter = DatabaseHelper.CreateParameter("@UserID", id);
                int result = DatabaseHelper.ExecuteNonQuery(query, parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex, "UserRepository.Delete");
                return false;
            }
        }

        // Helper methods to convert DataTable to User objects
        private List<User> ConvertDataTableToUsers(DataTable dataTable)
        {
            List<User> users = new List<User>();

            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(ConvertDataRowToUser(row));
            }

            return users;
        }

        private User ConvertDataRowToUser(DataRow row)
        {
            User user = new User
            {
                UserID = row.GetValue<int>("UserID"),
                FirstName = row.GetValue<string>("FirstName"),
                LastName = row.GetValue<string>("LastName"),
                Username = row.GetValue<string>("Username"),
                Password = row.GetValue<string>("Password"),
                Email = row.GetValue<string>("Email"),
                CountryCode = row.GetValue<string>("CountryCode"),
                PhoneNumber = row.GetValue<string>("PhoneNumber"),
                RoleID = row.GetValue<int>("RoleID"),
                BranchID = row.GetValue<int?>("BranchID"),
                LastLogin = row.GetValue<DateTime?>("LastLogin"),
                IsActive = row.GetValue<bool>("IsActive"),
                CreatedAt = row.GetValue<DateTime>("CreatedAt"),
                UpdatedAt = row.GetValue<DateTime?>("UpdatedAt")
            };

            // Optional navigation properties if joined with other tables
            if (row.Table.Columns.Contains("RoleName"))
            {
                user.Role = new Role
                {
                    RoleID = user.RoleID,
                    RoleName = row.GetValue<string>("RoleName")
                };
            }

            if (row.Table.Columns.Contains("BranchName") && user.BranchID.HasValue)
            {
                user.Branch = new Branch
                {
                    BranchID = user.BranchID.Value,
                    BranchName = row.GetValue<string>("BranchName")
                };
            }

            return user;
        }
    }
}