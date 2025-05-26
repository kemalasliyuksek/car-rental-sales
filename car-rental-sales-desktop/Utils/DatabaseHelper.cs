using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace car_rental_sales_desktop.Utils
{
    public static class DatabaseHelper
    {
        // Veritabanından veri çekmek için kullanılan sorguları çalıştırır.
        // Örneğin, SELECT sorguları için kullanılır.
        // query: Çalıştırılacak SQL sorgusu.
        // parameters: Sorguya eklenecek parametreler.
        // Geriye DataTable tipinde sorgu sonucunu döndürür.
        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (var connection = ConnectionManager.GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                var dataTable = new DataTable();
                command.CommandTimeout = 60; // Komut zaman aşımı 60 saniye olarak ayarlandı.
                if (parameters != null)
                    command.Parameters.AddRange(parameters); // Parametreler komuta eklendi.

                connection.Open(); // Veritabanı bağlantısı açıldı.
                using (var adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable); // Sorgu sonucu DataTable'a dolduruldu.
                }
                return dataTable; // Sonuç döndürüldü.
            }
        }

        // Veritabanında veri döndürmeyen sorguları çalıştırır.
        // Örneğin, INSERT, UPDATE, DELETE sorguları için kullanılır.
        // query: Çalıştırılacak SQL sorgusu.
        // parameters: Sorguya eklenecek parametreler.
        // Geriye etkilenen satır sayısını döndürür.
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var connection = ConnectionManager.GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                command.CommandTimeout = 60; // Komut zaman aşımı 60 saniye olarak ayarlandı.
                if (parameters != null)
                    command.Parameters.AddRange(parameters); // Parametreler komuta eklendi.

                connection.Open(); // Veritabanı bağlantısı açıldı.
                return command.ExecuteNonQuery(); // Sorgu çalıştırıldı ve etkilenen satır sayısı döndürüldü.
            }
        }

        // Veritabanından tek bir değer döndüren sorguları çalıştırır.
        // Örneğin, COUNT(*), MAX(kolon_adı) gibi sorgular için kullanılır.
        // query: Çalıştırılacak SQL sorgusu.
        // parameters: Sorguya eklenecek parametreler.
        // Geriye object tipinde sorgu sonucunu (tek bir değer) döndürür.
        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var connection = ConnectionManager.GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                command.CommandTimeout = 60; // Komut zaman aşımı 60 saniye olarak ayarlandı.
                if (parameters != null)
                    command.Parameters.AddRange(parameters); // Parametreler komuta eklendi.

                connection.Open(); // Veritabanı bağlantısı açıldı.
                return command.ExecuteScalar(); // Sorgu çalıştırıldı ve tek bir değer döndürüldü.
            }
        }

        // SQL sorguları için MySqlParameter nesnesi oluşturur.
        // name: Parametre adı.
        // value: Parametre değeri. Eğer değer null ise DBNull.Value olarak ayarlanır.
        // Geriye oluşturulan MySqlParameter nesnesini döndürür.
        public static MySqlParameter CreateParameter(string name, object value)
        {
            return new MySqlParameter(name, value ?? DBNull.Value); // Parametre oluşturuldu ve null değerler DBNull.Value'ya çevrildi.
        }

        // DataRow nesnesinden belirtilen kolondaki değeri güvenli bir şekilde alır ve belirtilen tipe dönüştürür.
        // Bu bir genişletme metodudur (extension method) ve DataRow üzerinde doğrudan çağrılabilir.
        // row: Değerin alınacağı DataRow nesnesi.
        // columnName: Değerin alınacağı kolonun adı.
        // Geriye T tipinde kolon değerini döndürür. Eğer kolon yoksa, değeri DBNull ise veya dönüştürme başarısız olursa default(T) döner.
        public static T GetValue<T>(this DataRow row, string columnName)
        {
            // Satır null ise veya satırın tablo kolonları belirtilen kolonu içermiyorsa veya kolon değeri DBNull ise varsayılan değeri döndür.
            if (row == null || !row.Table.Columns.Contains(columnName) || row[columnName] == DBNull.Value)
                return default; // Varsayılan değer (örneğin, int için 0, string için null).

            object value = row[columnName]; // Kolon değeri alındı.
            Type targetType = typeof(T); // Hedef tip belirlendi.

            // Hedef tip Nullable ise (örneğin, int?), temel tipi al.
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                targetType = Nullable.GetUnderlyingType(targetType);
            }

            try
            {
                // Hedef tip DateTime ise ve değer string ise, DateTime'a parse etmeyi dene.
                if (targetType == typeof(DateTime) && value is string dateStr)
                {
                    if (DateTime.TryParse(dateStr, out DateTime date))
                        return (T)(object)date; // Başarılı parse işlemi sonucu.
                }

                // Değeri hedef tipe dönüştür.
                return (T)Convert.ChangeType(value, targetType);
            }
            catch
            {
                // Dönüştürme sırasında bir hata oluşursa varsayılan değeri döndür.
                return default;
            }
        }
    }
}