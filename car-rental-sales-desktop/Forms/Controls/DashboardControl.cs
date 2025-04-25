using car_rental_sales_desktop.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace car_rental_sales_desktop.Forms.Controls
{
    public partial class DashboardControl : UserControl
    {
        private ReportRepository _reportRepository;
        private RentalRepository _rentalRepository;
        private SaleRepository _saleRepository;
        private VehicleRepository _vehicleRepository;

        public DashboardControl()
        {
            InitializeComponent();

            // Initialize repositories
            _reportRepository = new ReportRepository();
            _rentalRepository = new RentalRepository();
            _saleRepository = new SaleRepository();
            _vehicleRepository = new VehicleRepository();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstatistik verileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            // Get dashboard summary data
            DataTable dashboardData = _reportRepository.GetDashboardSummary();
            if (dashboardData != null && dashboardData.Rows.Count > 0)
            {
                DataRow row = dashboardData.Rows[0];

                // 3. Active Rentals
                lblActiveRentalsCount.Text = row["ActiveRentals"].ToString();

                // 4. Recent Sales (Last 30 days)
                lblMonthlyRentalsCount.Text = row["RecentSales"].ToString();

                // 5. Overdue Rentals (Using this as Canceled Rentals for now)
                lblCanceledRentalsCount.Text = row["OverdueRentals"].ToString();
            }

            // Get total rentals count
            int totalRentalsCount = GetTotalRentalsCount();
            lblTotalRentalsCount.Text = totalRentalsCount.ToString();

            // Get total sales count
            int totalSalesCount = GetTotalSalesCount();
            lblTotalSalesCount.Text = totalSalesCount.ToString();
        }

        private int GetTotalRentalsCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Rentals";
                object result = Utils.DatabaseHelper.ExecuteScalar(query);
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0;
            }
        }

        private int GetTotalSalesCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Sales";
                object result = Utils.DatabaseHelper.ExecuteScalar(query);
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0;
            }
        }
    }
}