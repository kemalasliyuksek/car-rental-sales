using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;

namespace car_rental_sales_desktop.Utils
{
    public static class ConnectionManager
    {
        private static readonly byte[] EncryptionKey = Encoding.UTF8.GetBytes("Arac123456789101");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");

        public static bool UseRemoteDatabase { get; set; } = false;

        public static string GetConnectionString()
        {
            string connectionName = UseRemoteDatabase ? "AracDB_Remote" : "AracDB_Local";
            string encryptedConnectionString = ConfigurationManager.AppSettings[$"Encrypted_{connectionName}"];

            if (string.IsNullOrEmpty(encryptedConnectionString))
                throw new InvalidOperationException($"Şifreli bağlantı cümlesi bulunamadı: {connectionName}");

            return DecryptConnectionString(encryptedConnectionString);
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(GetConnectionString());
        }

        public static string EncryptConnectionString(string connectionString)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = EncryptionKey;
                aes.IV = IV;

                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(connectionString);
                    sw.Close();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private static string DecryptConnectionString(string encrypted)
        {
            byte[] cipherText = Convert.FromBase64String(encrypted);

            using (Aes aes = Aes.Create())
            {
                aes.Key = EncryptionKey;
                aes.IV = IV;

                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream(cipherText))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
