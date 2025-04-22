using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace car_rental_sales_desktop.Utils
{
    public static class DatabaseHelper
    {
        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (var connection = ConnectionManager.GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                var dataTable = new DataTable();
                command.CommandTimeout = 60;
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                using (var adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
                return dataTable;
            }
        }

        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var connection = ConnectionManager.GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                command.CommandTimeout = 60;
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var connection = ConnectionManager.GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                command.CommandTimeout = 60;
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public static MySqlParameter CreateParameter(string name, object value)
        {
            return new MySqlParameter(name, value ?? DBNull.Value);
        }

        public static T GetValue<T>(this DataRow row, string columnName)
        {
            if (row == null || !row.Table.Columns.Contains(columnName) || row[columnName] == DBNull.Value)
                return default;

            object value = row[columnName];
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }
}
