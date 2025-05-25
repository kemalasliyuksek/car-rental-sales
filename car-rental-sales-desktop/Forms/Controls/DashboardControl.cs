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
        private VehicleRepository _vehicleRepository;

        public DashboardControl()
        {
            InitializeComponent();

            _reportRepository = new ReportRepository();
            _rentalRepository = new RentalRepository();
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
            DataTable dashboardData = _reportRepository.GetDashboardSummary();
            if (dashboardData != null && dashboardData.Rows.Count > 0)
            {
                DataRow row = dashboardData.Rows[0];

                lblActiveRentalsCount.Text = row["ActiveRentals"].ToString();

                lblCanceledRentalsCount.Text = row["OverdueRentals"].ToString();
            }

            int totalRentalsCount = GetTotalRentalsCount();
            lblTotalRentalsCount.Text = totalRentalsCount.ToString();
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
    }
}