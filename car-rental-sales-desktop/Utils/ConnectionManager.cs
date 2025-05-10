using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace car_rental_sales_desktop.Utils
{
    public static class ConnectionManager
    {
        public static bool UseRemoteDatabase { get; set; } = true;

        public static string GetConnectionString()
        {
            string connectionName = UseRemoteDatabase ? "AracDB_Remote" : "AracDB_Local";

            ConnectionStringSettings connectionSettings = ConfigurationManager.ConnectionStrings[connectionName];

            if (connectionSettings == null || string.IsNullOrEmpty(connectionSettings.ConnectionString))
                throw new InvalidOperationException($"Bağlantı cümlesi bulunamadı: {connectionName}");

            return connectionSettings.ConnectionString;
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(GetConnectionString());
        }
    }
}