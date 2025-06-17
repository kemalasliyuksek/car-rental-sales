using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public abstract class BaseRepository<T> where T : class, new()
    {
        protected readonly string _tableName;
        protected readonly string _idColumnName;

        // Yapıcı metot
        protected BaseRepository(string tableName, string idColumnName)
        {
            _tableName = tableName;
            _idColumnName = idColumnName;
        }

        // DataRow'u model nesnesine dönüştürür
        protected abstract T MapToModel(DataRow row);

        // Tüm kayıtları getirir
        public virtual List<T> GetAll()
        {
            string query = $"SELECT * FROM {_tableName}";
            var dataTable = DatabaseHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dataTable);
        }

        // ID'ye göre kayıt getirir
        public virtual T GetById(int id)
        {
            string query = $"SELECT * FROM {_tableName} WHERE {_idColumnName} = @id";
            var parameter = DatabaseHelper.CreateParameter("@id", id);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToModel(dataTable.Rows[0]);
        }

        // Yeni kayıt ekler
        public virtual int Insert(T entity)
        {
            var parameters = GetInsertParameters(entity);
            string columnNames = string.Join(", ", parameters.Keys);
            string paramNames = string.Join(", ", parameters.Keys.Select(k => $"@{k}"));

            string query = $"INSERT INTO {_tableName} ({columnNames}) VALUES ({paramNames}); SELECT LAST_INSERT_ID();";

            // Sözlüğü MySqlParameter dizisine dönüştürür
            var sqlParameters = parameters.Select(p => DatabaseHelper.CreateParameter($"@{p.Key}", p.Value)).ToArray();

            // Çalıştırır ve yeni ID'yi alır
            object result = DatabaseHelper.ExecuteScalar(query, sqlParameters);
            return Convert.ToInt32(result);
        }

        // Mevcut kaydı günceller
        public virtual bool Update(T entity)
        {
            var parameters = GetUpdateParameters(entity);
            int id = GetEntityId(entity);

            if (parameters.Count == 0)
                return false;

            string setClause = string.Join(", ", parameters.Keys.Select(k => $"{k} = @{k}"));
            string query = $"UPDATE {_tableName} SET {setClause} WHERE {_idColumnName} = @id";

            // ID dahil tüm parametreleri ekler
            var sqlParameters = parameters.Select(p => DatabaseHelper.CreateParameter($"@{p.Key}", p.Value)).ToList();
            sqlParameters.Add(DatabaseHelper.CreateParameter("@id", id));

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, sqlParameters.ToArray());
            return affectedRows > 0;
        }

        // ID'ye göre kaydı siler
        public virtual bool Delete(int id)
        {
            string query = $"DELETE FROM {_tableName} WHERE {_idColumnName} = @id";
            var parameter = DatabaseHelper.CreateParameter("@id", id);

            int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameter);
            return affectedRows > 0;
        }

        // DataTable'ı varlık listesine dönüştürür
        protected List<T> ConvertDataTableToList(DataTable dataTable)
        {
            List<T> entities = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T entity = MapToModel(row);
                entities.Add(entity);
            }

            return entities;
        }

        // Türetilmiş sınıflar tarafından implemente edilmesi gereken soyut metotlar
        protected abstract Dictionary<string, object> GetInsertParameters(T entity);
        protected abstract Dictionary<string, object> GetUpdateParameters(T entity);
        protected abstract int GetEntityId(T entity);
    }
}