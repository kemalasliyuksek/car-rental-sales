using System;
using System.Collections.Generic;
using System.Data;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository() : base("Roles", "RoleID")
        {
        }

        protected override Role MapToModel(DataRow row)
        {
            return new Role
            {
                RoleID = row.GetValue<int>("RoleID"),
                RoleName = row.GetValue<string>("RoleName"),
                RoleDescription = row.GetValue<string>("RoleDescription"),
                RoleCreatedAt = row.GetValue<DateTime>("RoleCreatedAt")
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Role entity)
        {
            return new Dictionary<string, object>
            {
                { "RoleName", entity.RoleName },
                { "RoleDescription", entity.RoleDescription },
                { "RoleCreatedAt", entity.RoleCreatedAt }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Role entity)
        {
            return new Dictionary<string, object>
            {
                { "RoleName", entity.RoleName },
                { "RoleDescription", entity.RoleDescription }
            };
        }

        protected override int GetEntityId(Role entity)
        {
            return entity.RoleID;
        }

        // Get role by name
        public Role GetByName(string roleName)
        {
            string query = "SELECT * FROM Roles WHERE RoleName = @roleName";
            var parameter = DatabaseHelper.CreateParameter("@roleName", roleName);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Get roles with user count
        public DataTable GetRolesWithUserCount()
        {
            string query = @"
                SELECT 
                    r.RoleID,
                    r.RoleName,
                    r.RoleDescription,
                    COUNT(u.UserID) AS UserCount
                FROM Roles r
                LEFT JOIN Users u ON r.RoleID = u.UserRoleID
                GROUP BY r.RoleID, r.RoleName, r.RoleDescription
                ORDER BY r.RoleName";

            return DatabaseHelper.ExecuteQuery(query);
        }
    }
}