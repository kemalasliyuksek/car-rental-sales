using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class DocumentRepository : BaseRepository<Document>
    {
        private readonly string _documentsBasePath;

        public DocumentRepository(string documentsBasePath = "Documents") : base("Documents", "DocumentID")
        {
            _documentsBasePath = documentsBasePath;

            // Ensure the documents directory exists
            if (!Directory.Exists(_documentsBasePath))
            {
                Directory.CreateDirectory(_documentsBasePath);
            }
        }

        protected override Document MapToModel(DataRow row)
        {
            return new Document
            {
                DocumentID = row.GetValue<int>("DocumentID"),
                DocumentTransactionType = row.GetValue<string>("DocumentTransactionType"),
                DocumentTransactionID = row.GetValue<int>("DocumentTransactionID"),
                DocumentType = row.GetValue<string>("DocumentType"),
                DocumentFilePath = row.GetValue<string>("DocumentFilePath"),
                DocumentUploadDate = row.GetValue<DateTime>("DocumentUploadDate"),
                DocumentUserID = row.GetValue<int>("DocumentUserID"),

                // Navigation properties
                User = GetUser(row.GetValue<int>("DocumentUserID"))
            };
        }

        protected override Dictionary<string, object> GetInsertParameters(Document entity)
        {
            return new Dictionary<string, object>
            {
                { "DocumentTransactionType", entity.DocumentTransactionType },
                { "DocumentTransactionID", entity.DocumentTransactionID },
                { "DocumentType", entity.DocumentType },
                { "DocumentFilePath", entity.DocumentFilePath },
                { "DocumentUploadDate", entity.DocumentUploadDate },
                { "DocumentUserID", entity.DocumentUserID }
            };
        }

        protected override Dictionary<string, object> GetUpdateParameters(Document entity)
        {
            return new Dictionary<string, object>
            {
                { "DocumentTransactionType", entity.DocumentTransactionType },
                { "DocumentTransactionID", entity.DocumentTransactionID },
                { "DocumentType", entity.DocumentType },
                { "DocumentFilePath", entity.DocumentFilePath },
                { "DocumentUploadDate", entity.DocumentUploadDate },
                { "DocumentUserID", entity.DocumentUserID }
            };
        }

        protected override int GetEntityId(Document entity)
        {
            return entity.DocumentID;
        }

        // Get documents by transaction
        public List<Document> GetByTransaction(string transactionType, int transactionId)
        {
            string query = "SELECT * FROM Documents WHERE DocumentTransactionType = @transactionType AND DocumentTransactionID = @transactionId";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@transactionType", transactionType),
                DatabaseHelper.CreateParameter("@transactionId", transactionId)
            };

            var dataTable = DatabaseHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dataTable);
        }

        // Get documents by type
        public List<Document> GetByDocumentType(string documentType)
        {
            string query = "SELECT * FROM Documents WHERE DocumentType = @documentType";
            var parameter = DatabaseHelper.CreateParameter("@documentType", documentType);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get documents by user
        public List<Document> GetByUser(int userId)
        {
            string query = "SELECT * FROM Documents WHERE DocumentUserID = @userId";
            var parameter = DatabaseHelper.CreateParameter("@userId", userId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            return ConvertDataTableToList(dataTable);
        }

        // Get documents by date range
        public List<Document> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM Documents WHERE DocumentUploadDate BETWEEN @startDate AND @endDate";
            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            var dataTable = DatabaseHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dataTable);
        }

        // Upload document and save to database
        public int UploadDocument(string transactionType, int transactionId, string documentType,
                                 string sourceFilePath, int userId)
        {
            try
            {
                // 1. Create directory for the transaction type if it doesn't exist
                string transactionDir = Path.Combine(_documentsBasePath, transactionType);
                if (!Directory.Exists(transactionDir))
                {
                    Directory.CreateDirectory(transactionDir);
                }

                // 2. Create directory for the specific transaction if it doesn't exist
                string transactionIdDir = Path.Combine(transactionDir, transactionId.ToString());
                if (!Directory.Exists(transactionIdDir))
                {
                    Directory.CreateDirectory(transactionIdDir);
                }

                // 3. Generate a unique filename with timestamp
                string fileName = $"{documentType}_{DateTime.Now:yyyyMMdd_HHmmss}{Path.GetExtension(sourceFilePath)}";
                string destFilePath = Path.Combine(transactionIdDir, fileName);

                // 4. Copy the file
                File.Copy(sourceFilePath, destFilePath, true);

                // 5. Store in database
                string relativePath = Path.Combine(transactionType, transactionId.ToString(), fileName).Replace("\\", "/");
                var document = new Document
                {
                    DocumentTransactionType = transactionType,
                    DocumentTransactionID = transactionId,
                    DocumentType = documentType,
                    DocumentFilePath = relativePath,
                    DocumentUploadDate = DateTime.Now,
                    DocumentUserID = userId
                };

                return Insert(document);
            }
            catch (Exception ex)
            {
                // Log the error
                var errorLog = new ErrorLog
                {
                    ErrorSeverity = "Error",
                    ErrorSource = "DocumentRepository.UploadDocument",
                    ErrorContent = $"Error uploading document for {transactionType} ID: {transactionId}",
                    ErrorUsername = CurrentUser.Username,
                    ErrorExceptionType = ex.GetType().Name,
                    ErrorMessage = ex.Message,
                    ErrorInnerException = ex.InnerException?.Message,
                    ErrorStackTrace = ex.StackTrace
                };

                // Log the error to the database
                LogError(errorLog);

                return -1;
            }
        }

        // Delete document
        public override bool Delete(int id)
        {
            try
            {
                // 1. Get the document
                var document = GetById(id);
                if (document == null)
                    return false;

                // 2. Delete the file if it exists
                string fullPath = Path.Combine(_documentsBasePath, document.DocumentFilePath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                // 3. Delete from database
                return base.Delete(id);
            }
            catch (Exception ex)
            {
                // Log the error
                var errorLog = new ErrorLog
                {
                    ErrorSeverity = "Error",
                    ErrorSource = "DocumentRepository.Delete",
                    ErrorContent = $"Error deleting document ID: {id}",
                    ErrorUsername = CurrentUser.Username,
                    ErrorExceptionType = ex.GetType().Name,
                    ErrorMessage = ex.Message,
                    ErrorInnerException = ex.InnerException?.Message,
                    ErrorStackTrace = ex.StackTrace
                };

                // Log the error to the database
                LogError(errorLog);

                return false;
            }
        }

        // Get document statistics
        public DataTable GetDocumentStatistics()
        {
            string query = @"
                SELECT 
                    DocumentTransactionType,
                    DocumentType,
                    COUNT(*) AS DocumentCount
                FROM Documents
                GROUP BY DocumentTransactionType, DocumentType
                ORDER BY DocumentCount DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Log error
        private void LogError(ErrorLog errorLog)
        {
            string query = @"
                INSERT INTO ErrorLogs (
                    ErrorID,
                    ErrorDate,
                    ErrorSeverity,
                    ErrorSource,
                    ErrorContent,
                    ErrorUsername,
                    ErrorExceptionType,
                    ErrorMessage,
                    ErrorInnerException,
                    ErrorStackTrace
                ) VALUES (
                    @errorId,
                    @errorDate,
                    @errorSeverity,
                    @errorSource,
                    @errorContent,
                    @errorUsername,
                    @errorExceptionType,
                    @errorMessage,
                    @errorInnerException,
                    @errorStackTrace
                )";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@errorId", errorLog.ErrorID),
                DatabaseHelper.CreateParameter("@errorDate", errorLog.ErrorDate),
                DatabaseHelper.CreateParameter("@errorSeverity", errorLog.ErrorSeverity),
                DatabaseHelper.CreateParameter("@errorSource", errorLog.ErrorSource),
                DatabaseHelper.CreateParameter("@errorContent", errorLog.ErrorContent),
                DatabaseHelper.CreateParameter("@errorUsername", errorLog.ErrorUsername),
                DatabaseHelper.CreateParameter("@errorExceptionType", errorLog.ErrorExceptionType),
                DatabaseHelper.CreateParameter("@errorMessage", errorLog.ErrorMessage),
                DatabaseHelper.CreateParameter("@errorInnerException", errorLog.ErrorInnerException),
                DatabaseHelper.CreateParameter("@errorStackTrace", errorLog.ErrorStackTrace)
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                // If we can't log to the database, at least write to a local file
                try
                {
                    string logPath = Path.Combine(_documentsBasePath, "errors.log");
                    using (StreamWriter writer = File.AppendText(logPath))
                    {
                        writer.WriteLine($"[{DateTime.Now}] {errorLog.ErrorSeverity}: {errorLog.ErrorMessage}");
                        writer.WriteLine($"Source: {errorLog.ErrorSource}");
                        writer.WriteLine($"Content: {errorLog.ErrorContent}");
                        writer.WriteLine($"User: {errorLog.ErrorUsername}");
                        writer.WriteLine($"Exception: {errorLog.ErrorExceptionType}");
                        writer.WriteLine($"Inner Exception: {errorLog.ErrorInnerException}");
                        writer.WriteLine($"Stack Trace: {errorLog.ErrorStackTrace}");
                        writer.WriteLine(new string('-', 80));
                    }
                }
                catch
                {
                    // At this point we can't do much more
                }
            }
        }

        // Helper method to get user
        private User GetUser(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @userId";
            var parameter = DatabaseHelper.CreateParameter("@userId", userId);
            var dataTable = DatabaseHelper.ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new User
            {
                UserID = row.GetValue<int>("UserID"),
                UserFirstName = row.GetValue<string>("UserFirstName"),
                UserLastName = row.GetValue<string>("UserLastName"),
                Username = row.GetValue<string>("Username")
                // Add other fields as needed
            };
        }
    }
}