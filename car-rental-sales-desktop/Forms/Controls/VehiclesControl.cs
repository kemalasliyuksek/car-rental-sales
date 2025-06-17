using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace car_rental_sales_desktop.Forms.Controls
{
    public partial class VehiclesControl : UserControl
    {
        private VehicleRepository _vehicleRepository;
        private BranchRepository _branchRepository;
        private VehicleClassRepository _vehicleClassRepository;
        private List<Vehicle> _vehicleList;
        private List<Branch> _branchList;
        private List<VehicleClass> _vehicleClassList;
        private List<VehicleStatus> _vehicleStatusList;
        private bool _isEditMode = false;
        private int _editingVehicleId = 0;

        // Bu, VehiclesControl sınıfının yapıcı metodudur.
        // Gerekli repository nesnelerini başlatır ve Load olayına bir olay dinleyici ekler.
        public VehiclesControl()
        {
            InitializeComponent();
            _vehicleRepository = new VehicleRepository();
            _branchRepository = new BranchRepository();
            _vehicleClassRepository = new VehicleClassRepository();

            this.Load += VehiclesControl_Load;
        }

        // Bu metot, kontrol yüklendiğinde çağrılır.
        // Araçları, şubeleri, araç sınıflarını, araç durumlarını yükler ve ComboBox'ları ayarlar.
        private void VehiclesControl_Load(object sender, EventArgs e)
        {
            LoadVehicles();
            LoadBranches();
            LoadVehicleClasses();
            LoadVehicleStatuses();
            SetupFuelTypeComboBox();
            SetupTransmissionTypeComboBox();

            // Rol bazlı kontroller
            ConfigureControlsByRole();
        }

        private void ConfigureControlsByRole()
        {
            // Araç ekleme/düzenleme/silme butonları
            bool canManageVehicles = CurrentUser.CanPerformAction("manage_vehicles");
            btnEditVehicle.Visible = canManageVehicles;
            btnDeleteVehicle.Visible = CurrentUser.IsAdmin(); // Sadece admin silebilir
            btnSaveVehicle.Visible = canManageVehicles;

            // Durum değiştirme sadece teknisyen ve bakım personeli
            btnToggleVehicleStatus.Visible = CurrentUser.CanPerformAction("edit_vehicle_status");

            // Şube müdürü sadece kendi şubesindeki araçları görebilir
            if (CurrentUser.IsBranchManager() && CurrentUser.BranchID.HasValue)
            {
                _vehicleList = _vehicleList.Where(v => v.VehicleBranchID == CurrentUser.BranchID.Value).ToList();
                sfDataGridVehicles.DataSource = _vehicleList;

                // Şube seçimini sadece kendi şubesi olarak sabitle
                cmbBranch.SelectedValue = CurrentUser.BranchID.Value;
                cmbBranch.Enabled = false;
            }
        }

        // Bu metot, araç verilerini veritabanından yükler ve DataGrid'e bağlar.
        // Hata oluşursa kullanıcıya bir mesaj gösterir.
        private void LoadVehicles()
        {
            try
            {
                _vehicleList = _vehicleRepository.GetAll();
                sfDataGridVehicles.DataSource = _vehicleList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicle data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bu metot, aktif şubeleri veritabanından yükler ve şube ComboBox'ını doldurur.
        // "Atanmamış" seçeneğini de ComboBox'a ekler.
        private void LoadBranches()
        {
            try
            {
                _branchList = _branchRepository.GetActiveBranches();

                var branchesWithEmpty = new List<Branch>
                {
                    new Branch { BranchID = 0, BranchName = "Not Assigned" }
                };
                branchesWithEmpty.AddRange(_branchList);

                cmbBranch.DataSource = branchesWithEmpty;
                cmbBranch.DisplayMember = "BranchName";
                cmbBranch.ValueMember = "BranchID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading branch data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bu metot, araç sınıflarını veritabanından yükler ve araç sınıfı ComboBox'ını doldurur.
        // "Atanmamış" seçeneğini de ComboBox'a ekler.
        private void LoadVehicleClasses()
        {
            try
            {
                _vehicleClassList = _vehicleClassRepository.GetAll();

                var classesWithEmpty = new List<VehicleClass>
                {
                    new VehicleClass { VehicleClassID = 0, VehicleClassName = "Not Assigned" }
                };
                classesWithEmpty.AddRange(_vehicleClassList);

                cmbVehicleClass.DataSource = classesWithEmpty;
                cmbVehicleClass.DisplayMember = "VehicleClassName";
                cmbVehicleClass.ValueMember = "VehicleClassID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicle class data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bu metot, araç durumlarını (statik bir listeden) yükler ve araç durumu ComboBox'ını doldurur.
        private void LoadVehicleStatuses()
        {
            try
            {
                _vehicleStatusList = new List<VehicleStatus>
                {
                    new VehicleStatus { VehicleStatusID = 1, VehicleStatusName = "Available" },
                    new VehicleStatus { VehicleStatusID = 2, VehicleStatusName = "For Sale" },
                    new VehicleStatus { VehicleStatusID = 3, VehicleStatusName = "Sold" },
                    new VehicleStatus { VehicleStatusID = 4, VehicleStatusName = "For Rent" },
                    new VehicleStatus { VehicleStatusID = 5, VehicleStatusName = "Rented" },
                    new VehicleStatus { VehicleStatusID = 6, VehicleStatusName = "Reserved" },
                    new VehicleStatus { VehicleStatusID = 7, VehicleStatusName = "Reservation Expired" },
                    new VehicleStatus { VehicleStatusID = 8, VehicleStatusName = "Service" },
                    new VehicleStatus { VehicleStatusID = 9, VehicleStatusName = "Faulty" },
                    new VehicleStatus { VehicleStatusID = 10, VehicleStatusName = "Maintenance" }
                };

                cmbVehicleStatus.DataSource = _vehicleStatusList;
                cmbVehicleStatus.DisplayMember = "VehicleStatusName";
                cmbVehicleStatus.ValueMember = "VehicleStatusID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicle status data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bu metot, yakıt tipi ComboBox'ını önceden tanımlanmış değerlerle ayarlar.
        // Varsayılan olarak "Gasoline" seçilir.
        private void SetupFuelTypeComboBox()
        {
            cmbFuelType.Items.Clear();
            cmbFuelType.Items.AddRange(new string[] { "Gasoline", "Diesel", "Electric", "Hybrid", "Petrol" });
            cmbFuelType.SelectedIndex = 0;
        }

        // Bu metot, şanzıman tipi ComboBox'ını önceden tanımlanmış değerlerle ayarlar.
        // Varsayılan olarak "Manual" seçilir.
        private void SetupTransmissionTypeComboBox()
        {
            cmbTransmissionType.Items.Clear();
            cmbTransmissionType.Items.AddRange(new string[] { "Manual", "Automatic" });
            cmbTransmissionType.SelectedIndex = 0;
        }

        // Bu metot, DataGrid'de seçili olan aracı döndürür.
        // Seçili bir araç yoksa veya bir hata oluşursa null döndürür.
        private Vehicle GetSelectedVehicle()
        {
            try
            {
                if (sfDataGridVehicles.SelectedIndex >= 0 && sfDataGridVehicles.SelectedIndex < _vehicleList.Count)
                {
                    return _vehicleList[sfDataGridVehicles.SelectedIndex];
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving selected vehicle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Bu metot, araç ekleme/düzenleme formundaki tüm alanları temizler.
        // Ayrıca düzenleme modunu sıfırlar ve form başlığını/buton metnini günceller.
        private void ClearForm()
        {
            txtPlateNumber.Text = "";
            txtBrand.Text = "";
            txtModel.Text = "";
            numYear.Value = DateTime.Now.Year;
            txtEngineNumber.Text = "";
            txtChassisNumber.Text = "";
            txtColor.Text = "";
            numMileage.Value = 0;
            cmbFuelType.SelectedIndex = 0;
            cmbTransmissionType.SelectedIndex = 0;
            cmbVehicleStatus.SelectedIndex = 0;
            dtpAcquisitionDate.Checked = false;
            numPurchasePrice.Value = 0;
            numSalePrice.Value = 0;
            cmbBranch.SelectedIndex = 0;
            cmbVehicleClass.SelectedIndex = 0;

            _isEditMode = false;
            _editingVehicleId = 0;
            lblVehicleFormTitle.Text = "Add New Vehicle";
            btnSaveVehicle.Text = "Save Vehicle";
        }

        // Bu metot, seçilen bir aracın bilgilerini araç ekleme/düzenleme formuna doldurur.
        // Formu düzenleme moduna geçirir ve ilgili alanları günceller.
        private void FillFormWithVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return;

            txtPlateNumber.Text = vehicle.VehiclePlateNumber ?? "";
            txtBrand.Text = vehicle.VehicleBrand ?? "";
            txtModel.Text = vehicle.VehicleModel ?? "";
            numYear.Value = vehicle.VehicleYear;
            txtEngineNumber.Text = vehicle.VehicleEngineNumber ?? "";
            txtChassisNumber.Text = vehicle.VehicleChassisNumber ?? "";
            txtColor.Text = vehicle.VehicleColor ?? "";
            numMileage.Value = vehicle.VehicleMileage;
            numPurchasePrice.Value = vehicle.VehiclePurchasePrice ?? 0;
            numSalePrice.Value = vehicle.VehicleSalePrice ?? 0;

            if (!string.IsNullOrEmpty(vehicle.VehicleFuelType))
            {
                int fuelIndex = cmbFuelType.Items.IndexOf(vehicle.VehicleFuelType);
                cmbFuelType.SelectedIndex = fuelIndex >= 0 ? fuelIndex : 0;
            }

            if (!string.IsNullOrEmpty(vehicle.VehicleTransmissionType))
            {
                int transIndex = cmbTransmissionType.Items.IndexOf(vehicle.VehicleTransmissionType);
                cmbTransmissionType.SelectedIndex = transIndex >= 0 ? transIndex : 0;
            }

            cmbVehicleStatus.SelectedValue = vehicle.VehicleStatusID;

            if (vehicle.VehicleAcquisitionDate.HasValue)
            {
                dtpAcquisitionDate.Value = vehicle.VehicleAcquisitionDate.Value;
                dtpAcquisitionDate.Checked = true;
            }
            else
            {
                dtpAcquisitionDate.Checked = false;
            }

            if (vehicle.VehicleBranchID.HasValue && vehicle.VehicleBranchID.Value > 0)
            {
                cmbBranch.SelectedValue = vehicle.VehicleBranchID.Value;
            }
            else
            {
                cmbBranch.SelectedValue = 0;
            }

            if (vehicle.VehicleClassID.HasValue && vehicle.VehicleClassID.Value > 0)
            {
                cmbVehicleClass.SelectedValue = vehicle.VehicleClassID.Value;
            }
            else
            {
                cmbVehicleClass.SelectedValue = 0;
            }

            _isEditMode = true;
            _editingVehicleId = vehicle.VehicleID;
            lblVehicleFormTitle.Text = "Edit Vehicle";
            btnSaveVehicle.Text = "Update Vehicle";
        }

        // Bu metot, DataGrid'deki satırların stilini özelleştirmek için kullanılır.
        // Çift ve tek satırlara farklı arka plan renkleri atar.
        private void SfDataGridVehicles_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255);
            }
        }

        // "Düzenle" butonu tıklandığında çağrılır.
        // Seçili aracı alır, formu bu araçla doldurur ve araç ekleme/düzenleme sekmesine geçer.
        private void BtnEditVehicle_Click(object sender, EventArgs e)
        {
            var selectedVehicle = GetSelectedVehicle();
            if (selectedVehicle == null)
            {
                MessageBox.Show("Please select a vehicle to edit.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FillFormWithVehicle(selectedVehicle);
            tabControlVehicles.SelectedIndex = 1;
        }

        // "Sil" butonu tıklandığında çağrılır.
        // Seçili aracı silmeden önce kullanıcıdan onay alır.
        // Silme işlemi başarılı olursa araç listesini yeniler.
        private void BtnDeleteVehicle_Click(object sender, EventArgs e)
        {
            var selectedVehicle = GetSelectedVehicle();
            if (selectedVehicle == null)
            {
                MessageBox.Show("Please select a vehicle to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete the vehicle '{selectedVehicle.VehiclePlateNumber} - {selectedVehicle.VehicleBrand} {selectedVehicle.VehicleModel}'?\n\n" +
                "This operation cannot be undone and will delete all data for the vehicle.\n" +
                "WARNING: Rental, sales, and maintenance records for the vehicle will also be deleted.",
                "Confirm Vehicle Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _vehicleRepository.Delete(selectedVehicle.VehicleID);
                    if (success)
                    {
                        MessageBox.Show("Vehicle deleted successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVehicles();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while deleting the vehicle.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the vehicle: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // "Durum Değiştir" butonu tıklandığında çağrılır.
        // Seçili aracın durumunu "Available" (Mevcut) ve "Maintenance" (Bakımda) arasında değiştirir.
        // İşlem öncesi kullanıcıdan onay alır.
        private void BtnToggleVehicleStatus_Click(object sender, EventArgs e)
        {
            var selectedVehicle = GetSelectedVehicle();
            if (selectedVehicle == null)
            {
                MessageBox.Show("Please select a vehicle to change its status.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newStatusId = selectedVehicle.VehicleStatusID == 1 ? 10 : 1; // 1: Available, 10: Maintenance
            string newStatusName = newStatusId == 1 ? "Available" : "Maintenance";

            var result = MessageBox.Show(
                $"Are you sure you want to change the status of vehicle '{selectedVehicle.VehiclePlateNumber}' to '{newStatusName}'?",
                "Confirm Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _vehicleRepository.UpdateVehicleStatus(selectedVehicle.VehicleID, newStatusId);
                    if (success)
                    {
                        MessageBox.Show($"Vehicle status successfully changed to '{newStatusName}'.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVehicles();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while changing the vehicle status.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while changing the vehicle status: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // "Yenile" butonu tıklandığında çağrılır.
        // Araç listesini yeniden yükler ve kullanıcıya bilgi mesajı gösterir.
        private void BtnRefreshVehicles_Click(object sender, EventArgs e)
        {
            LoadVehicles();
            MessageBox.Show("Vehicle list refreshed.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // "Kaydet" butonu tıklandığında çağrılır.
        // Formdaki verileri doğrular, plaka ve şasi numarasının benzersizliğini kontrol eder.
        // Yeni bir araç ekler veya mevcut bir aracı günceller.
        private void BtnSaveVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPlateNumber.Text) ||
                    string.IsNullOrEmpty(txtBrand.Text) ||
                    string.IsNullOrEmpty(txtModel.Text) ||
                    string.IsNullOrEmpty(txtChassisNumber.Text) ||
                    cmbFuelType.SelectedItem == null ||
                    cmbTransmissionType.SelectedItem == null ||
                    cmbVehicleStatus.SelectedValue == null)
                {
                    MessageBox.Show("Please fill in all required fields.\n(Plate, Brand, Model, Chassis No, Fuel Type, Transmission Type, and Status are mandatory)",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingVehicle = _vehicleRepository.GetByPlateNumber(txtPlateNumber.Text);
                if (existingVehicle != null && (!_isEditMode || existingVehicle.VehicleID != _editingVehicleId))
                {
                    MessageBox.Show("This plate number is already in use by another vehicle.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingVehicleByChassis = _vehicleRepository.GetByChassisNumber(txtChassisNumber.Text);
                if (existingVehicleByChassis != null && (!_isEditMode || existingVehicleByChassis.VehicleID != _editingVehicleId))
                {
                    MessageBox.Show("This chassis number is already in use by another vehicle.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Vehicle vehicle;
                if (_isEditMode)
                {
                    vehicle = _vehicleRepository.GetById(_editingVehicleId);
                    if (vehicle == null)
                    {
                        MessageBox.Show("The vehicle to be edited was not found.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    vehicle = new Vehicle();
                }

                vehicle.VehiclePlateNumber = txtPlateNumber.Text.Trim();
                vehicle.VehicleBrand = txtBrand.Text.Trim();
                vehicle.VehicleModel = txtModel.Text.Trim();
                vehicle.VehicleYear = (int)numYear.Value;
                vehicle.VehicleEngineNumber = string.IsNullOrEmpty(txtEngineNumber.Text) ? null : txtEngineNumber.Text.Trim();
                vehicle.VehicleChassisNumber = txtChassisNumber.Text.Trim();
                vehicle.VehicleColor = string.IsNullOrEmpty(txtColor.Text) ? null : txtColor.Text.Trim();
                vehicle.VehicleMileage = (int)numMileage.Value;
                vehicle.VehicleFuelType = cmbFuelType.SelectedItem.ToString();
                vehicle.VehicleTransmissionType = cmbTransmissionType.SelectedItem.ToString();
                vehicle.VehicleStatusID = (int)cmbVehicleStatus.SelectedValue;
                vehicle.VehiclePurchasePrice = numPurchasePrice.Value > 0 ? numPurchasePrice.Value : (decimal?)null;
                vehicle.VehicleSalePrice = numSalePrice.Value > 0 ? numSalePrice.Value : (decimal?)null;
                vehicle.VehicleBranchID = (int)cmbBranch.SelectedValue == 0 ? null : (int?)cmbBranch.SelectedValue;
                vehicle.VehicleClassID = (int)cmbVehicleClass.SelectedValue == 0 ? null : (int?)cmbVehicleClass.SelectedValue;

                vehicle.VehicleAcquisitionDate = dtpAcquisitionDate.Checked ? dtpAcquisitionDate.Value : (DateTime?)null;

                bool success;
                if (_isEditMode)
                {
                    success = _vehicleRepository.Update(vehicle);
                }
                else
                {
                    int newVehicleId = _vehicleRepository.Insert(vehicle);
                    success = newVehicleId > 0;
                }

                if (success)
                {
                    string message = _isEditMode ? "Vehicle updated successfully." : "Vehicle added successfully.";
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadVehicles();
                    tabControlVehicles.SelectedIndex = 0;
                }
                else
                {
                    string message = _isEditMode ? "An error occurred while updating the vehicle." : "An error occurred while adding the vehicle.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the operation: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "İptal" butonu tıklandığında çağrılır.
        // Formu temizler ve araç listesi sekmesine geri döner.
        private void BtnCancelVehicle_Click(object sender, EventArgs e)
        {
            ClearForm();
            tabControlVehicles.SelectedIndex = 0;
        }
    }
}