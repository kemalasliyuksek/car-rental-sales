using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace car_rental_sales_desktop.Utils
{
    // Veritabanı bağlantılarını yönetmek için statik bir sınıf tanımlar.
    // Statik olması, bu sınıfın bir örneğini oluşturmadan üyelerine erişilebileceği anlamına gelir.
    public static class ConnectionManager
    {
        // Uzak veritabanının mı yoksa yerel veritabanının mı kullanılacağını belirten bir özellik (property).
        // 'public static' olması, bu özelliğe programın herhangi bir yerinden erişilebileceği anlamına gelir.
        // '{ get; set; }' bu özelliğin hem okunabileceği hem de yazılabileceği anlamına gelir.
        // '= false' ile başlangıçta yerel veritabanının kullanılacağı varsayılır.
        public static bool UseRemoteDatabase { get; set; } = false;

        // Veritabanı bağlantı cümlesini (connection string) almak için bir metot tanımlar.
        // Bağlantı cümlesi, veritabanına nasıl bağlanılacağını belirten bilgileri içerir.
        public static string GetConnectionString()
        {
            // UseRemoteDatabase özelliğinin değerine göre bağlantı adını belirler.
            // Eğer UseRemoteDatabase true ise "AracDB_Remote", false ise "AracDB_Local" kullanılır.
            string connectionName = UseRemoteDatabase ? "AracDB_Remote" : "AracDB_Local";

            // ConfigurationManager.ConnectionStrings kullanarak App.config veya Web.config dosyasından
            // belirtilen bağlantı adına sahip bağlantı cümlesi ayarlarını alır.
            ConnectionStringSettings connectionSettings = ConfigurationManager.ConnectionStrings[connectionName];

            // Eğer bağlantı ayarları bulunamazsa veya bağlantı cümlesi boşsa,
            // bir InvalidOperationException istisnası fırlatır.
            // Bu, programın çalışmaya devam edemeyeceği kritik bir durum olduğunu gösterir.
            if (connectionSettings == null || string.IsNullOrEmpty(connectionSettings.ConnectionString))
                throw new InvalidOperationException($"Bağlantı cümlesi bulunamadı: {connectionName}");

            // Bulunan bağlantı cümlesini döndürür.
            return connectionSettings.ConnectionString;
        }

        // Yeni bir MySqlConnection nesnesi oluşturup döndüren bir metot tanımlar.
        // Bu metot, veritabanı ile etkileşim kurmak için bir bağlantı nesnesi sağlar.
        public static MySqlConnection GetConnection()
        {
            // GetConnectionString() metodunu çağırarak alınan bağlantı cümlesi ile
            // yeni bir MySqlConnection nesnesi oluşturur ve döndürür.
            return new MySqlConnection(GetConnectionString());
        }
    }
}