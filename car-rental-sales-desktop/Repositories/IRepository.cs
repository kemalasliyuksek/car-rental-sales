using System;
using System.Collections.Generic;
using System.Data;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    /// <summary>
    /// Temel repository işlemleri için arayüz
    /// </summary>
    /// <typeparam name="T">Model tipi</typeparam>
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }

    /// <summary>
    /// Hata yönetimi için yardımcı sınıf
    /// </summary>
    public static class ErrorLogger
    {
        public static void LogError(Exception ex, string source)
        {
            string query = @"INSERT INTO ErrorLogs (ErrorID, Date, Severity, Source, Content, ExceptionType, Message, InnerException, StackTrace) 
                           VALUES (@ErrorID, @Date, @Severity, @Source, @Content, @ExceptionType, @Message, @InnerException, @StackTrace)";

            var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
            {
                DatabaseHelper.CreateParameter("@ErrorID", Guid.NewGuid().ToString()),
                DatabaseHelper.CreateParameter("@Date", DateTime.Now),
                DatabaseHelper.CreateParameter("@Severity", "Error"),
                DatabaseHelper.CreateParameter("@Source", source),
                DatabaseHelper.CreateParameter("@Content", ex.Source),
                DatabaseHelper.CreateParameter("@ExceptionType", ex.GetType().Name),
                DatabaseHelper.CreateParameter("@Message", ex.Message),
                DatabaseHelper.CreateParameter("@InnerException", ex.InnerException?.Message),
                DatabaseHelper.CreateParameter("@StackTrace", ex.StackTrace)
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                // Logging hatası durumunda yapılacak bir işlem yok
            }
        }
    }
}