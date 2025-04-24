using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository() : base("Users", "UserID")
        {
        }

        protected override User MapToModel(DataRow row)
        {
            return new User
            {
                UserID = row.GetValue<int>("UserID"),
                UserFirstName = row.GetValue<string>("UserFirstName"),
                UserLastName = row.GetValue<string>("UserLastName"),
                Username = row.GetValue<string>("Username"),
                UserPassword = row.GetValue<string>("UserPassword"),
                UserEmail = row.GetValue<string>("UserEmail"),
                UserPhone = row.GetValue<string>("UserPhone"),
                UserRoleID = row.GetValue<int>("UserRoleID"),
                UserBranchID = row.GetValue<int?>("UserBranchID"),
                UserLastLogin = row.GetValue<DateTime?>("UserLastLogin"),
                UserActive = row.GetValue<bool>("UserActive"),
                UserCreatedAt = row.GetValue<DateTime>("UserCreatedAt"),
                UserUpdatedAt = row.GetValue<DateTime?>("UserUpdatedAt"),

                // Navigation properties
                Role = GetUserRole(row.GetValue<int>("UserRoleID")),
                Branch = row["UserBranchID"] != DBNull.Value ? GetUserBranch(Convert.ToInt32(row["UserBranchID"])) : null
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(User entity)
        {
            return new Dictionary<string, object>
            {
                { "UserFirstName", entity.UserFirstName },
                { "UserLastName", entity.UserLastName },
                { "Username", entity.Username },
                { "UserPassword", entity.UserPassword },
                { "UserEmail", entity.UserEmail },
                { "UserPhone", entity.UserPhone },
                { "UserRoleID", entity.UserRoleID },
                { "UserBranchID", entity.UserBranchID },
                { "UserActive", entity.UserActive },
                { "UserCreatedAt", entity.UserCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(User entity)
        {
            return new Dictionary<string, object>
            {
                { "UserFirstName", entity.UserFirstName },
                { "UserLastName", entity.UserLastName },
                { "Username", entity.Username },
                { "UserPassword", entity.UserPassword },
                { "UserEmail", entity.UserEmail },
                { "UserPhone", entity.UserPhone },
                { "UserRoleID", entity.UserRoleID },
                { "UserBranchID", entity.UserBranchID },
                { "UserLastLogin", entity.UserLastLogin },
                { "UserActive", entity.UserActive },
                { "UserUpdatedAt", DateTime.Now }
            };
        }

        protected override int GetEntityId(User entity)
        {
            return entity.UserID;
        }

        // Get user by username
        public User GetByUsername(string username)
        {
            string query = "SELECT * FROM Users WHERE Username = @username";
            var parameter = DatabaseHelper.CreateParameter("@username", username);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Validate login credentials
        public bool ValidateLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND UserPassword = @password AND UserActive = 1";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@username", username),
                DatabaseHelper.CreateParameter("@password", password)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            int count = Convert.ToInt32(result);

            if (count > 0)
            {
                // Update last login time
                string updateQuery = "UPDATE Users SET UserLastLogin = @lastLogin WHERE Username = @username";
                var updateParameters = new[]
                {
                    DatabaseHelper.CreateParameter("@lastLogin", DateTime.Now),
                    DatabaseHelper.CreateParameter("@username", username)
                };
                DatabaseHelper.ExecuteNonQuery(updateQuery, updateParameters);

                return true;
            }

            return false;
        }

        // Get users by role
        public List<User> GetByRole(int roleId)
        {
            string query = "SELECT * FROM Users WHERE UserRoleID = @roleId";
            var parameter = DatabaseHelper.CreateParameter("@roleId", roleId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get users by branch
        public List<User> GetByBranch(int branchId)
        {
            string query = "SELECT * FROM Users WHERE UserBranchID = @branchId";
            var parameter = DatabaseHelper.CreateParameter("@branchId", branchId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get active users
        public List<User> GetActiveUsers()
        {
            string query = "SELECT * FROM Users WHERE UserActive = 1";
            var dataTable = DatabaseHelper.ExecuteQuery(query);

            return ConvertDataTableToList(dataTable);
        }

        // Change user password
        public bool ChangePassword(int userId, string newPassword)
        {
            string query = "UPDATE Users SET UserPassword = @password, UserUpdatedAt = @updatedAt WHERE UserID = @userId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@password", newPassword),
                DatabaseHelper.CreateParameter("@updatedAt", DateTime.Now),
                DatabaseHelper.CreateParameter("@userId", userId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Activate or deactivate user
        public bool SetUserStatus(int userId, bool isActive)
        {
            string query = "UPDATE Users SET UserActive = @isActive, UserUpdatedAt = @updatedAt WHERE UserID = @userId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@isActive", isActive),
                DatabaseHelper.CreateParameter("@updatedAt", DateTime.Now),
                DatabaseHelper.CreateParameter("@userId", userId)
            };

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return affectedRows > 0;
        }

        // Helper method to get role
        private Role GetUserRole(int roleId)
        {
            string query = "SELECT * FROM Roles WHERE RoleID = @roleId";
            var parameter = DatabaseHelper.CreateParameter("@roleId", roleId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Role
            {
                RoleID = row.GetValue<int>("RoleID"),
                RoleName = row.GetValue<string>("RoleName"),
                RoleDescription = row.GetValue<string>("RoleDescription"),
                RoleCreatedAt = row.GetValue<DateTime>("RoleCreatedAt")
            };
        }

        // Helper method to get branch
        private Branch GetUserBranch(int? branchId)
        {
            if (!branchId.HasValue)
                return null;

            string query = "SELECT * FROM Branches WHERE BranchID = @branchId";
            var parameter = DatabaseHelper.CreateParameter("@branchId", branchId.Value);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new Branch
            {
                BranchID = row.GetValue<int>("BranchID"),
                BranchName = row.GetValue<string>("BranchName"),
                BranchAddress = row.GetValue<string>("BranchAddress"),
                BranchPhone = row.GetValue<string>("BranchPhone"),
                BranchEmail = row.GetValue<string>("BranchEmail"),
                BranchActive = row.GetValue<bool>("BranchActive"),
                BranchCreatedAt = row.GetValue<DateTime>("BranchCreatedAt")
            };
        }
    }
}