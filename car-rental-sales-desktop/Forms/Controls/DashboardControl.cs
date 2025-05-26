using car_rental_sales_desktop.Repositories;
using System;
using System.Data;
using System.Windows.Forms;

namespace car_rental_sales_desktop.Forms.Controls
{
    // DashboardControl sınıfı, UserControl sınıfından miras alır
    public partial class DashboardControl : UserControl
    {
        // Rapor deposu için özel bir alan
        private ReportRepository _reportRepository;
        // Kiralama deposu için özel bir alan
        private RentalRepository _rentalRepository;
        // Araç deposu için özel bir alan
        private VehicleRepository _vehicleRepository;

        // DashboardControl sınıfının yapıcı metodu
        public DashboardControl()
        {
            // Bileşenleri başlatan metod çağrılır (Tasarımcı tarafından oluşturulur)
            InitializeComponent();

            // Rapor deposu nesnesi oluşturulur
            _reportRepository = new ReportRepository();
            // Kiralama deposu nesnesi oluşturulur
            _rentalRepository = new RentalRepository();
            // Araç deposu nesnesi oluşturulur
            _vehicleRepository = new VehicleRepository();
        }

        // DashboardControl yüklendiğinde çalışan olay metodu
        private void DashboardControl_Load(object sender, EventArgs e)
        {
            // Hata yakalama bloğu
            try
            {
                // İstatistikleri yükleyen metod çağrılır
                LoadStatistics();
            }
            // Hata oluşursa çalışacak blok
            catch (Exception ex)
            {
                // Hata mesajı gösterilir
                MessageBox.Show($"İstatistik verileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // İstatistikleri yükleyen özel metod
        private void LoadStatistics()
        {
            // Rapor deposundan gösterge paneli özet verileri alınır
            DataTable dashboardData = _reportRepository.GetDashboardSummary();
            // Veri tablosu boş değilse ve satır içeriyorsa
            if (dashboardData != null && dashboardData.Rows.Count > 0)
            {
                // İlk satır alınır
                DataRow row = dashboardData.Rows[0];

                // Aktif kiralama sayısı etiketine değer atanır
                lblActiveRentalsCount.Text = row["ActiveRentals"].ToString();

                // İptal edilen/vadesi geçmiş kiralama sayısı etiketine değer atanır
                lblCanceledRentalsCount.Text = row["OverdueRentals"].ToString();
            }

            // Toplam kiralama sayısı alınır
            int totalRentalsCount = GetTotalRentalsCount();
            // Toplam kiralama sayısı etiketine değer atanır
            lblTotalRentalsCount.Text = totalRentalsCount.ToString();
        }

        // Toplam kiralama sayısını getiren özel metod
        private int GetTotalRentalsCount()
        {
            // Hata yakalama bloğu
            try
            {
                // Veritabanından toplam kiralama sayısını getiren sorgu
                string query = "SELECT COUNT(*) FROM Rentals";
                // Sorguyu çalıştırıp sonucu alan yardımcı metod çağrılır
                object result = Utils.DatabaseHelper.ExecuteScalar(query);
                // Sonuç tamsayıya dönüştürülür
                return Convert.ToInt32(result);
            }
            // Hata oluşursa çalışacak blok
            catch
            {
                // Hata durumunda 0 döndürülür
                return 0;
            }
        }
    }
}