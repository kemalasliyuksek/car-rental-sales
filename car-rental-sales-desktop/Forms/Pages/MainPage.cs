using car_rental_sales_desktop.Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental_sales_desktop.Forms.Pages
{
    public partial class MainPage : Form
    {
        // Ana sayfa formu oluşturulduğunda çalışan yapıcı metot.
        public MainPage()
        {
            InitializeComponent(); // Formun bileşenlerini başlatan metot.
        }

        // Ana sayfa formu yüklendiğinde çalışan metot.
        private void MainPage_Load(object sender, EventArgs e)
        {
            // Kullanıcı bilgilerini ilgili etiketlere atar.
            lblUsername.Text = Utils.CurrentUser.FullName; // Kullanıcının tam adını gösterir.
            lblUserRole.Text = Utils.CurrentUser.RoleName; // Kullanıcının rolünü gösterir.
            lblBranchName.Text = Utils.CurrentUser.BranchName; // Kullanıcının şube adını gösterir.

            // Rol bazlı menü görünürlüğünü ayarla
            ConfigureMenuByRole();

            ResetButtons(); // Yan menüdeki butonların görünümünü sıfırlar.
            SetActiveButton(btnMainPage); // Ana sayfa butonunu aktif olarak ayarlar.

            pnlContent.Controls.Clear(); // İçerik panelindeki mevcut kontrolleri temizler.
            var mainPageControl = new MainPageControl(); // Ana sayfa için kullanıcı kontrolü oluşturur.
            mainPageControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(mainPageControl); // Kontrolü içerik paneline ekler.
        }

        // Kullanıcının rolüne göre yan menüdeki butonların görünürlüğünü ayarlar.
        private void ConfigureMenuByRole()
        {
            string userRole = Utils.CurrentUser.RoleName?.ToLower();

            // Önce tüm menüleri gizle
            btnDashboard.Visible = false;
            btnCustomers.Visible = false;
            btnVehicles.Visible = false;
            btnRentals.Visible = false;
            btnConfirmations.Visible = false;
            btnBranches.Visible = false;
            btnStaff.Visible = false;
            btnReports.Visible = false;
            btnService.Visible = false;
            btnSettings.Visible = false;

            // Ana sayfa her zaman görünür
            btnMainPage.Visible = true;

            switch (userRole)
            {
                case "administrator":
                    // Admin her şeye erişebilir
                    btnDashboard.Visible = true;
                    btnCustomers.Visible = true;
                    btnVehicles.Visible = true;
                    btnRentals.Visible = true;
                    btnConfirmations.Visible = true;
                    btnBranches.Visible = true;
                    btnStaff.Visible = true;
                    btnReports.Visible = true;
                    btnService.Visible = true;
                    btnSettings.Visible = true;
                    break;

                case "branch manager":
                    // Şube müdürü kendi şubesindeki işlemleri yönetebilir
                    btnDashboard.Visible = true;
                    btnCustomers.Visible = true;
                    btnVehicles.Visible = true;
                    btnRentals.Visible = true;
                    btnConfirmations.Visible = true;
                    btnStaff.Visible = true; // Kendi şubesindeki personeli görebilir
                    btnReports.Visible = true;
                    btnService.Visible = true;
                    break;

                case "staff":
                    // Personel araç işlemleri, rezervasyon ve kiralama yapabilir
                    btnCustomers.Visible = true;
                    btnVehicles.Visible = true;
                    btnRentals.Visible = true;
                    btnConfirmations.Visible = true;
                    break;

                case "technician":
                    // Teknisyen sadece servis işlemleri görebilir
                    btnVehicles.Visible = true; // Araç durumlarını görmek için
                    btnService.Visible = true;
                    break;

                case "maintenance staff":
                    // Bakım personeli araç ve servis işlemleri görebilir
                    btnVehicles.Visible = true;
                    btnService.Visible = true;
                    break;

                case "customer":
                    // Müşteriler sadece kendi işlemlerini görebilir (ileride eklenebilir)
                    // Şimdilik sadece ana sayfayı görsün
                    break;
            }
        }

        // Oturumu kapatma butonuna tıklandığında çalışan metot.
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Kullanıcıya oturumu kapatmak isteyip istemediğini sorar.
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) // Eğer kullanıcı "Evet" derse:
            {
                Utils.CurrentUser.Logout(); // Mevcut kullanıcının oturumunu kapatır.
                this.Close(); // Ana sayfa formunu kapatır.
                LoginPage loginPage = new LoginPage(); // Yeni bir giriş sayfası oluşturur.
                loginPage.Show(); // Giriş sayfasını gösterir.
            }
        }

        // Yan menüdeki tüm butonların görünümünü varsayılan durumuna sıfırlayan metot.
        private void ResetButtons()
        {
            foreach (Control control in pnlSideMenu.Controls) // Yan menüdeki her bir kontrol için döngü başlatır.
            {
                if (control is FontAwesome.Sharp.IconButton) // Eğer kontrol bir IconButton ise:
                {
                    control.BackColor = Color.FromArgb(49, 76, 143); // Butonun arka plan rengini ayarlar.
                    control.ForeColor = Color.White; // Butonun yazı rengini ayarlar.
                }
            }
        }

        // Tıklanan butonu aktif olarak işaretleyen ve sayfa başlığını güncelleyen metot.
        private void SetActiveButton(object button)
        {
            if (button != null) // Eğer buton nesnesi boş değilse:
            {
                // Aktif butonun arka plan ve yazı rengini ayarlar.
                ((FontAwesome.Sharp.IconButton)button).BackColor = Color.FromArgb(73, 113, 194);
                ((FontAwesome.Sharp.IconButton)button).ForeColor = Color.White;

                // Mevcut sayfanın ikonunu ve başlığını aktif butonun ikonuna ve metnine göre günceller.
                iconCurrentPage.IconChar = ((FontAwesome.Sharp.IconButton)button).IconChar;
                lblPageTitle.Text = ((FontAwesome.Sharp.IconButton)button).Text.Trim();
            }
        }

        // Ana Sayfa butonuna tıklandığında çalışan metot.
        private void btnMainPage_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var mainPageControl = new MainPageControl(); // Ana sayfa kontrolünü oluşturur.
            mainPageControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(mainPageControl); // Kontrolü içerik paneline ekler.
        }

        // Gösterge Paneli butonuna tıklandığında çalışan metot.
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var dashboardControl = new DashboardControl(); // Gösterge paneli kontrolünü oluşturur.
            dashboardControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(dashboardControl); // Kontrolü içerik paneline ekler.
        }

        // Müşteriler butonuna tıklandığında çalışan metot.
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var customersControl = new CustomersControl(); // Müşteriler kontrolünü oluşturur.
            customersControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(customersControl); // Kontrolü içerik paneline ekler.
        }

        // Araçlar butonuna tıklandığında çalışan metot.
        private void btnVehicles_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var vehiclesControl = new VehiclesControl(); // Araçlar kontrolünü oluşturur.
            vehiclesControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(vehiclesControl); // Kontrolü içerik paneline ekler.
        }

        // Kiralamalar butonuna tıklandığında çalışan metot.
        private void btnRentals_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var rentalsControl = new RentalsControl(); // Kiralamalar kontrolünü oluşturur.
            rentalsControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(rentalsControl); // Kontrolü içerik paneline ekler.
        }

        // Şubeler butonuna tıklandığında çalışan metot.
        private void btnBranches_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var branchesControl = new BranchesControl(); // Şubeler kontrolünü oluşturur.
            branchesControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(branchesControl); // Kontrolü içerik paneline ekler.
        }

        // Onaylar butonuna tıklandığında çalışan metot.
        private void btnConfirmations_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var confirmationsControl = new ConfirmationsControl(); // Onaylar kontrolünü oluşturur.
            confirmationsControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(confirmationsControl); // Kontrolü içerik paneline ekler.
        }

        // Personel butonuna tıklandığında çalışan metot.
        private void btnStaff_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var staffControl = new StaffControl(); // Personel kontrolünü oluşturur.
            staffControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(staffControl); // Kontrolü içerik paneline ekler.
        }

        // Raporlar butonuna tıklandığında çalışan metot.
        private void btnReports_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var reportsControl = new ReportsControl(); // Raporlar kontrolünü oluşturur.
            reportsControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(reportsControl); // Kontrolü içerik paneline ekler.
        }

        // Servis butonuna tıklandığında çalışan metot.
        private void btnService_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var serviceControl = new ServiceControl(); // Servis kontrolünü oluşturur.
            serviceControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(serviceControl); // Kontrolü içerik paneline ekler.
        }

        // Ayarlar butonuna tıklandığında çalışan metot.
        private void btnSettings_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Butonları sıfırlar.
            SetActiveButton(sender); // Tıklanan butonu aktif yapar.

            pnlContent.Controls.Clear(); // İçerik panelini temizler.
            var settingsControl = new SettingsControl(); // Ayarlar kontrolünü oluşturur.
            settingsControl.Dock = DockStyle.Fill; // Kontrolü panele yayar.
            pnlContent.Controls.Add(settingsControl); // Kontrolü içerik paneline ekler.
        }
    }
}