using System;
using System.Data;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Repositories
{
    public class ReportRepository
    {
        // Dashboard summary report
        public DataTable GetDashboardSummary()
        {
            string query = @"
                SELECT
                    (SELECT COUNT(*) FROM Vehicles WHERE VehicleStatusID = 1) AS AvailableVehicles,
                    (SELECT COUNT(*) FROM Vehicles WHERE VehicleStatusID = 3) AS RentedVehicles,
                    (SELECT COUNT(*) FROM Rentals WHERE RentalReturnDate IS NULL) AS ActiveRentals,
                    (SELECT COUNT(*) FROM Rentals WHERE RentalEndDate < CURDATE() AND RentalReturnDate IS NULL) AS OverdueRentals,
                    (SELECT COUNT(*) FROM Sales WHERE SaleDate >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)) AS RecentSales,
                    (SELECT COUNT(*) FROM Vehicles WHERE VehicleStatusID = 2) AS VehiclesForSale,
                    (SELECT COUNT(*) FROM Customers) AS TotalCustomers,
                    (SELECT COUNT(*) FROM Vehicles) AS TotalVehicles,
                    (SELECT COUNT(*) FROM Branches) AS TotalBranches,
                    (SELECT COUNT(*) FROM Users WHERE UserActive = 1) AS ActiveUsers";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Onaylı kiralamaların raporunu getir
        public DataTable GetApprovedRentalsReport(DateTime startDate, DateTime endDate)
        {
            string query = @"
        SELECT 
            r.RentalID,
            CONCAT(c.CustomerFirstName, ' ', c.CustomerLastName) AS CustomerName,
            c.CustomerNationalID,
            c.CustomerPhone,
            v.VehiclePlateNumber,
            CONCAT(v.VehicleBrand, ' ', v.VehicleModel) AS VehicleInfo,
            r.RentalStartDate,
            r.RentalEndDate,
            r.RentalAmount,
            r.RentalPaymentType,
            r.RentalStatus,
            CONCAT(u.UserFirstName, ' ', u.UserLastName) AS StaffName,
            r.RentalCreatedAt,
            r.RentalUpdatedAt
        FROM Rentals r
        INNER JOIN Customers c ON r.RentalCustomerID = c.CustomerID
        INNER JOIN Vehicles v ON r.RentalVehicleID = v.VehicleID
        INNER JOIN Users u ON r.RentalUserID = u.UserID
        WHERE r.RentalStatus = 'Approved'
        AND r.RentalCreatedAt BETWEEN @startDate AND @endDate
        ORDER BY r.RentalCreatedAt DESC";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // Monthly rental income report
        public DataTable GetMonthlyRentalIncome(int year)
        {
            string query = @"
                SELECT 
                    MONTH(RentalStartDate) AS Month,
                    COUNT(*) AS RentalCount,
                    SUM(RentalAmount) AS TotalIncome
                FROM Rentals
                WHERE YEAR(RentalStartDate) = @year
                GROUP BY MONTH(RentalStartDate)
                ORDER BY Month";

            var parameter = DatabaseHelper.CreateParameter("@year", year);
            return DatabaseHelper.ExecuteQuery(query, parameter);
        }

        // Monthly sales income report
        public DataTable GetMonthlySalesIncome(int year)
        {
            string query = @"
                SELECT 
                    MONTH(SaleDate) AS Month,
                    COUNT(*) AS SalesCount,
                    SUM(SaleAmount) AS TotalIncome
                FROM Sales
                WHERE YEAR(SaleDate) = @year
                GROUP BY MONTH(SaleDate)
                ORDER BY Month";

            var parameter = DatabaseHelper.CreateParameter("@year", year);
            return DatabaseHelper.ExecuteQuery(query, parameter);
        }

        // Branch performance report
        public DataTable GetBranchPerformance(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    b.BranchID,
                    b.BranchName,
                    COUNT(DISTINCT r.RentalID) AS RentalCount,
                    SUM(r.RentalAmount) AS RentalIncome,
                    COUNT(DISTINCT s.SaleID) AS SalesCount,
                    SUM(s.SaleAmount) AS SalesIncome,
                    (SUM(r.RentalAmount) + IFNULL(SUM(s.SaleAmount), 0)) AS TotalIncome
                FROM Branches b
                LEFT JOIN Vehicles v ON b.BranchID = v.VehicleBranchID
                LEFT JOIN Rentals r ON v.VehicleID = r.RentalVehicleID AND r.RentalStartDate BETWEEN @startDate AND @endDate
                LEFT JOIN Sales s ON v.VehicleID = s.SaleVehicleID AND s.SaleDate BETWEEN @startDate AND @endDate
                GROUP BY b.BranchID, b.BranchName
                ORDER BY TotalIncome DESC";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // Vehicle utilization report
        public DataTable GetVehicleUtilization(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    v.VehicleID,
                    v.VehiclePlateNumber,
                    v.VehicleBrand,
                    v.VehicleModel,
                    COUNT(r.RentalID) AS RentalCount,
                    SUM(DATEDIFF(IFNULL(r.RentalReturnDate, r.RentalEndDate), r.RentalStartDate)) AS TotalRentalDays,
                    SUM(r.RentalAmount) AS TotalIncome,
                    SUM(r.RentalAmount) / SUM(DATEDIFF(IFNULL(r.RentalReturnDate, r.RentalEndDate), r.RentalStartDate)) AS DailyAvgIncome
                FROM Vehicles v
                LEFT JOIN Rentals r ON v.VehicleID = r.RentalVehicleID 
                    AND r.RentalStartDate <= @endDate 
                    AND (r.RentalEndDate >= @startDate OR r.RentalReturnDate >= @startDate)
                WHERE v.VehicleStatusID IN (1, 3) -- Available or Rented
                GROUP BY v.VehicleID, v.VehiclePlateNumber, v.VehicleBrand, v.VehicleModel
                HAVING TotalRentalDays > 0
                ORDER BY TotalIncome DESC";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // Customer rental history report
        public DataTable GetCustomerRentalHistory(int customerId)
        {
            string query = @"
                SELECT 
                    r.RentalID,
                    r.RentalStartDate,
                    r.RentalEndDate,
                    r.RentalReturnDate,
                    r.RentalStartKm,
                    r.RentalEndKm,
                    r.RentalAmount,
                    v.VehiclePlateNumber,
                    v.VehicleBrand,
                    v.VehicleModel,
                    DATEDIFF(IFNULL(r.RentalReturnDate, r.RentalEndDate), r.RentalStartDate) AS RentalDays,
                    CASE 
                        WHEN r.RentalEndDate < CURDATE() AND r.RentalReturnDate IS NULL THEN 'Overdue'
                        WHEN r.RentalReturnDate IS NULL THEN 'Active'
                        WHEN r.RentalReturnDate > r.RentalEndDate THEN 'Returned Late'
                        ELSE 'Completed'
                    END AS RentalStatus
                FROM Rentals r
                INNER JOIN Vehicles v ON r.RentalVehicleID = v.VehicleID
                WHERE r.RentalCustomerID = @customerId
                ORDER BY r.RentalStartDate DESC";

            var parameter = DatabaseHelper.CreateParameter("@customerId", customerId);
            return DatabaseHelper.ExecuteQuery(query, parameter);
        }

        // Customer purchase history report
        public DataTable GetCustomerPurchaseHistory(int customerId)
        {
            string query = @"
                SELECT 
                    s.SaleID,
                    s.SaleDate,
                    s.SaleAmount,
                    s.SalePaymentType,
                    s.SaleInstallmentCount,
                    s.SaleNotaryDate,
                    v.VehiclePlateNumber,
                    v.VehicleBrand,
                    v.VehicleModel,
                    v.VehicleYear,
                    v.VehicleChassisNumber
                FROM Sales s
                INNER JOIN Vehicles v ON s.SaleVehicleID = v.VehicleID
                WHERE s.SaleCustomerID = @customerId
                ORDER BY s.SaleDate DESC";

            var parameter = DatabaseHelper.CreateParameter("@customerId", customerId);
            return DatabaseHelper.ExecuteQuery(query, parameter);
        }

        // Vehicle maintenance history report
        public DataTable GetVehicleMaintenanceHistory(int vehicleId)
        {
            string query = @"
                SELECT 
                    m.MaintenanceID,
                    m.MaintenanceStartDate,
                    m.MaintenanceEndDate,
                    m.MaintenanceType,
                    m.MaintenanceNote,
                    m.MaintenanceCost,
                    s.ServiceName,
                    CONCAT(u.UserFirstName, ' ', u.UserLastName) AS CreatedBy
                FROM Maintenances m
                LEFT JOIN Services s ON m.MaintenanceServiceID = s.ServiceID
                INNER JOIN Users u ON m.MaintenanceUserID = u.UserID
                WHERE m.MaintenanceVehicleID = @vehicleId
                ORDER BY m.MaintenanceStartDate DESC";

            var parameter = DatabaseHelper.CreateParameter("@vehicleId", vehicleId);
            return DatabaseHelper.ExecuteQuery(query, parameter);
        }

        // Payment reports
        public DataTable GetPaymentReport(DateTime startDate, DateTime endDate, string paymentType = null)
        {
            string query = @"
                SELECT 
                    p.PaymentID,
                    p.PaymentTransactionType,
                    p.PaymentTransactionID,
                    p.PaymentAmount,
                    p.PaymentDate,
                    p.PaymentType,
                    b.BankName,
                    CONCAT(c.CustomerFirstName, ' ', c.CustomerLastName) AS CustomerName,
                    CONCAT(u.UserFirstName, ' ', u.UserLastName) AS ProcessedBy
                FROM Payments p
                INNER JOIN Customers c ON p.PaymentCustomerID = c.CustomerID
                INNER JOIN Users u ON p.PaymentUserID = u.UserID
                LEFT JOIN Banks b ON p.PaymentBankID = b.BankID
                WHERE p.PaymentDate BETWEEN @startDate AND @endDate";

            if (!string.IsNullOrEmpty(paymentType))
                query += " AND p.PaymentType = @paymentType";

            query += " ORDER BY p.PaymentDate DESC";

            var parameters = string.IsNullOrEmpty(paymentType)
                ? new[]
                {
                    DatabaseHelper.CreateParameter("@startDate", startDate),
                    DatabaseHelper.CreateParameter("@endDate", endDate)
                }
                : new[]
                {
                    DatabaseHelper.CreateParameter("@startDate", startDate),
                    DatabaseHelper.CreateParameter("@endDate", endDate),
                    DatabaseHelper.CreateParameter("@paymentType", paymentType)
                };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // Staff performance report
        public DataTable GetStaffPerformance(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    u.UserID,
                    CONCAT(u.UserFirstName, ' ', u.UserLastName) AS StaffName,
                    u.Username,
                    r.RoleName,
                    b.BranchName,
                    COUNT(DISTINCT rent.RentalID) AS RentalsProcessed,
                    SUM(rent.RentalAmount) AS RentalRevenue,
                    COUNT(DISTINCT s.SaleID) AS SalesProcessed,
                    SUM(s.SaleAmount) AS SalesRevenue,
                    (SUM(rent.RentalAmount) + IFNULL(SUM(s.SaleAmount), 0)) AS TotalRevenue
                FROM Users u
                INNER JOIN Roles r ON u.UserRoleID = r.RoleID
                LEFT JOIN Branches b ON u.UserBranchID = b.BranchID
                LEFT JOIN Rentals rent ON u.UserID = rent.RentalUserID AND rent.RentalStartDate BETWEEN @startDate AND @endDate
                LEFT JOIN Sales s ON u.UserID = s.SaleUserID AND s.SaleDate BETWEEN @startDate AND @endDate
                WHERE r.RoleName IN ('Sales Agent', 'Manager', 'Admin')
                GROUP BY u.UserID, u.UserFirstName, u.UserLastName, u.Username, r.RoleName, b.BranchName
                ORDER BY TotalRevenue DESC";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // Profit margin report
        public DataTable GetProfitMarginReport(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    s.SaleID,
                    s.SaleDate,
                    v.VehicleBrand,
                    v.VehicleModel,
                    v.VehiclePlateNumber,
                    v.VehiclePurchasePrice,
                    s.SaleAmount,
                    (s.SaleAmount - v.VehiclePurchasePrice) AS GrossProfit,
                    ROUND(((s.SaleAmount - v.VehiclePurchasePrice) / v.VehiclePurchasePrice) * 100, 2) AS ProfitMarginPercent
                FROM Sales s
                INNER JOIN Vehicles v ON s.SaleVehicleID = v.VehicleID
                WHERE s.SaleDate BETWEEN @startDate AND @endDate AND v.VehiclePurchasePrice IS NOT NULL
                ORDER BY ProfitMarginPercent DESC";

            var parameters = new[]
            {
                DatabaseHelper.CreateParameter("@startDate", startDate),
                DatabaseHelper.CreateParameter("@endDate", endDate)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        // Vehicle inventory report
        public DataTable GetVehicleInventoryReport(int? branchId = null)
        {
            string query = @"
                SELECT 
                    v.VehicleID,
                    v.VehiclePlateNumber,
                    v.VehicleBrand,
                    v.VehicleModel,
                    v.VehicleYear,
                    v.VehicleChassisNumber,
                    v.VehicleMileage,
                    v.VehicleFuelType,
                    v.VehicleTransmissionType,
                    vs.VehicleStatusName,
                    vc.VehicleClassName,
                    b.BranchName,
                    v.VehicleAcquisitionDate,
                    v.VehiclePurchasePrice,
                    v.VehicleSalePrice,
                    DATEDIFF(CURDATE(), v.VehicleAcquisitionDate) AS DaysInInventory
                FROM Vehicles v
                INNER JOIN VehicleStatuses vs ON v.VehicleStatusID = vs.VehicleStatusID
                LEFT JOIN VehicleClasses vc ON v.VehicleClassID = vc.VehicleClassID
                LEFT JOIN Branches b ON v.VehicleBranchID = b.BranchID";

            if (branchId.HasValue)
                query += " WHERE v.VehicleBranchID = @branchId";

            query += " ORDER BY v.VehicleBrand, v.VehicleModel, v.VehicleYear DESC";

            var parameter = branchId.HasValue
                ? new[] { DatabaseHelper.CreateParameter("@branchId", branchId.Value) }
                : null;

            return DatabaseHelper.ExecuteQuery(query, parameter);
        }

        // Customer demographics report
        public DataTable GetCustomerDemographicsReport()
        {
            string query = @"
                SELECT 
                    CustomerType,
                    COUNT(*) AS Count,
                    ROUND((COUNT(*) / (SELECT COUNT(*) FROM Customers)) * 100, 2) AS Percentage
                FROM Customers
                GROUP BY CustomerType";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Vehicle popularity report
        public DataTable GetVehiclePopularityReport()
        {
            string query = @"
                SELECT 
                    v.VehicleBrand,
                    v.VehicleModel,
                    COUNT(r.RentalID) AS RentalCount,
                    SUM(DATEDIFF(IFNULL(r.RentalReturnDate, r.RentalEndDate), r.RentalStartDate)) AS TotalRentalDays,
                    SUM(r.RentalAmount) AS TotalIncome
                FROM Vehicles v
                INNER JOIN Rentals r ON v.VehicleID = r.RentalVehicleID
                GROUP BY v.VehicleBrand, v.VehicleModel
                ORDER BY RentalCount DESC, TotalIncome DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Revenue comparison report
        public DataTable GetRevenueComparisonReport(int year)
        {
            string query = @"
                SELECT 
                    MONTH(date_data.month_date) AS Month,
                    IFNULL(rental_data.RentalIncome, 0) AS RentalIncome,
                    IFNULL(sale_data.SaleIncome, 0) AS SaleIncome,
                    (IFNULL(rental_data.RentalIncome, 0) + IFNULL(sale_data.SaleIncome, 0)) AS TotalIncome
                FROM (
                    SELECT DATE_FORMAT(CONCAT(@year, '-', m, '-01'), '%Y-%m-%d') AS month_date
                    FROM (
                        SELECT 1 AS m UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5 UNION SELECT 6
                        UNION SELECT 7 UNION SELECT 8 UNION SELECT 9 UNION SELECT 10 UNION SELECT 11 UNION SELECT 12
                    ) AS months
                ) AS date_data
                LEFT JOIN (
                    SELECT 
                        MONTH(RentalStartDate) AS Month,
                        SUM(RentalAmount) AS RentalIncome
                    FROM Rentals
                    WHERE YEAR(RentalStartDate) = @year
                    GROUP BY MONTH(RentalStartDate)
                ) AS rental_data ON MONTH(date_data.month_date) = rental_data.Month
                LEFT JOIN (
                    SELECT 
                        MONTH(SaleDate) AS Month,
                        SUM(SaleAmount) AS SaleIncome
                    FROM Sales
                    WHERE YEAR(SaleDate) = @year
                    GROUP BY MONTH(SaleDate)
                ) AS sale_data ON MONTH(date_data.month_date) = sale_data.Month
                ORDER BY Month";

            var parameter = DatabaseHelper.CreateParameter("@year", year);
            return DatabaseHelper.ExecuteQuery(query, parameter);
        }
    }
}