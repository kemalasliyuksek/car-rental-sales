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

        public VehiclesControl()
        {
            InitializeComponent();
            _vehicleRepository = new VehicleRepository();
            _branchRepository = new BranchRepository();
            _vehicleClassRepository = new VehicleClassRepository();

            this.Load += VehiclesControl_Load;
        }

        private void VehiclesControl_Load(object sender, EventArgs e)
        {
            LoadVehicles();
            LoadBranches();
            LoadVehicleClasses();
            LoadVehicleStatuses();
            SetupFuelTypeComboBox();
            SetupTransmissionTypeComboBox();
        }

        // TR: Bu metot, araç verilerini yüklemek için kullanılır.
        // EN: This method is used to load vehicle data.
        private void LoadVehicles()
        {
            try
            {
                _vehicleList = _vehicleRepository.GetAll();
                sfDataGridVehicles.DataSource = _vehicleList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araç verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, şubeleri combobox'a yükler.
        // EN: This method loads branches into the combobox.
        private void LoadBranches()
        {
            try
            {
                _branchList = _branchRepository.GetActiveBranches();

                // Add "Not Assigned" option
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
                MessageBox.Show($"Şube verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, araç sınıflarını combobox'a yükler.
        // EN: This method loads vehicle classes into the combobox.
        private void LoadVehicleClasses()
        {
            try
            {
                _vehicleClassList = _vehicleClassRepository.GetAll();

                // Add "Not Assigned" option
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
                MessageBox.Show($"Araç sınıfı verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, araç durumlarını combobox'a yükler.
        // EN: This method loads vehicle statuses into the combobox.
        private void LoadVehicleStatuses()
        {
            try
            {
                // Statik liste kullanarak (VehicleStatusHelper'dan)
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
                MessageBox.Show($"Araç durumu verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, yakıt tipi combobox'ını ayarlar.
        // EN: This method sets up the fuel type combobox.
        private void SetupFuelTypeComboBox()
        {
            cmbFuelType.Items.Clear();
            cmbFuelType.Items.AddRange(new string[] { "Gasoline", "Diesel", "Electric", "Hybrid", "Petrol" });
            cmbFuelType.SelectedIndex = 0; // Default to Gasoline
        }

        // TR: Bu metot, şanzıman tipi combobox'ını ayarlar.
        // EN: This method sets up the transmission type combobox.
        private void SetupTransmissionTypeComboBox()
        {
            cmbTransmissionType.Items.Clear();
            cmbTransmissionType.Items.AddRange(new string[] { "Manual", "Automatic" });
            cmbTransmissionType.SelectedIndex = 0; // Default to Manual
        }

        // TR: Bu metot, seçili aracı döndürür.
        // EN: This method returns the selected vehicle.
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
                MessageBox.Show($"Seçili araç alınırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // TR: Bu metot, form alanlarını temizler.
        // EN: This method clears the form fields.
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
            cmbBranch.SelectedIndex = 0; // "Not Assigned"
            cmbVehicleClass.SelectedIndex = 0; // "Not Assigned"

            _isEditMode = false;
            _editingVehicleId = 0;
            lblVehicleFormTitle.Text = "Add New Vehicle";
            btnSaveVehicle.Text = "Save Vehicle";
        }

        // TR: Bu metot, seçili aracın bilgilerini forma doldurur.
        // EN: This method fills the form with the selected vehicle's information.
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

            // Set fuel type
            if (!string.IsNullOrEmpty(vehicle.VehicleFuelType))
            {
                int fuelIndex = cmbFuelType.Items.IndexOf(vehicle.VehicleFuelType);
                cmbFuelType.SelectedIndex = fuelIndex >= 0 ? fuelIndex : 0;
            }

            // Set transmission type
            if (!string.IsNullOrEmpty(vehicle.VehicleTransmissionType))
            {
                int transIndex = cmbTransmissionType.Items.IndexOf(vehicle.VehicleTransmissionType);
                cmbTransmissionType.SelectedIndex = transIndex >= 0 ? transIndex : 0;
            }

            // Set vehicle status
            cmbVehicleStatus.SelectedValue = vehicle.VehicleStatusID;

            // Set acquisition date
            if (vehicle.VehicleAcquisitionDate.HasValue)
            {
                dtpAcquisitionDate.Value = vehicle.VehicleAcquisitionDate.Value;
                dtpAcquisitionDate.Checked = true;
            }
            else
            {
                dtpAcquisitionDate.Checked = false;
            }

            // Set branch
            if (vehicle.VehicleBranchID.HasValue && vehicle.VehicleBranchID.Value > 0)
            {
                cmbBranch.SelectedValue = vehicle.VehicleBranchID.Value;
            }
            else
            {
                cmbBranch.SelectedValue = 0; // "Not Assigned"
            }

            // Set vehicle class
            if (vehicle.VehicleClassID.HasValue && vehicle.VehicleClassID.Value > 0)
            {
                cmbVehicleClass.SelectedValue = vehicle.VehicleClassID.Value;
            }
            else
            {
                cmbVehicleClass.SelectedValue = 0; // "Not Assigned"
            }

            _isEditMode = true;
            _editingVehicleId = vehicle.VehicleID;
            lblVehicleFormTitle.Text = "Edit Vehicle";
            btnSaveVehicle.Text = "Update Vehicle";
        }

        // TR: Bu metot, veri tablosundaki satırların stilini özelleştirir.
        // EN: This method customizes the style of the rows in the data table.
        private void SfDataGridVehicles_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255); // Light blue tone
            }
        }

        // TR: Düzenle butonu tıklama olayı
        // EN: Edit button click event
        private void BtnEditVehicle_Click(object sender, EventArgs e)
        {
            var selectedVehicle = GetSelectedVehicle();
            if (selectedVehicle == null)
            {
                MessageBox.Show("Lütfen düzenlemek için bir araç seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FillFormWithVehicle(selectedVehicle);
            tabControlVehicles.SelectedIndex = 1; // Switch to Vehicle Add/Edit tab
        }

        // TR: Sil butonu tıklama olayı
        // EN: Delete button click event
        private void BtnDeleteVehicle_Click(object sender, EventArgs e)
        {
            var selectedVehicle = GetSelectedVehicle();
            if (selectedVehicle == null)
            {
                MessageBox.Show("Lütfen silmek için bir araç seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{selectedVehicle.VehiclePlateNumber} - {selectedVehicle.VehicleBrand} {selectedVehicle.VehicleModel}' aracını silmek istediğinizden emin misiniz?\n\n" +
                "Bu işlem geri alınamaz ve aracın tüm verilerini silecektir.\n" +
                "UYARI: Araca ait kiralama, satış ve bakım kayıtları da silinecektir.",
                "Araç Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _vehicleRepository.Delete(selectedVehicle.VehicleID);
                    if (success)
                    {
                        MessageBox.Show("Araç başarıyla silindi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVehicles(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Araç silinirken bir hata oluştu.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Araç silinirken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TR: Durum değiştir butonu tıklama olayı
        // EN: Toggle status button click event
        private void BtnToggleVehicleStatus_Click(object sender, EventArgs e)
        {
            var selectedVehicle = GetSelectedVehicle();
            if (selectedVehicle == null)
            {
                MessageBox.Show("Lütfen durumunu değiştirmek için bir araç seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Toggle between Available (1) and Maintenance (10)
            int newStatusId = selectedVehicle.VehicleStatusID == 1 ? 10 : 1;
            string newStatusName = newStatusId == 1 ? "Available" : "Maintenance";

            var result = MessageBox.Show(
                $"'{selectedVehicle.VehiclePlateNumber}' plakalı aracın durumunu '{newStatusName}' olarak değiştirmek istediğinizden emin misiniz?",
                "Durum Değiştirme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _vehicleRepository.UpdateVehicleStatus(selectedVehicle.VehicleID, newStatusId);
                    if (success)
                    {
                        MessageBox.Show($"Araç durumu başarıyla '{newStatusName}' olarak değiştirildi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVehicles(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Araç durumu değiştirilirken bir hata oluştu.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Araç durumu değiştirilirken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TR: Yenile butonu tıklama olayı
        // EN: Refresh button click event
        private void BtnRefreshVehicles_Click(object sender, EventArgs e)
        {
            LoadVehicles();
            MessageBox.Show("Araç listesi yenilendi.",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // TR: Kaydet butonu tıklama olayı
        // EN: Save button click event
        private void BtnSaveVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(txtPlateNumber.Text) ||
                    string.IsNullOrEmpty(txtBrand.Text) ||
                    string.IsNullOrEmpty(txtModel.Text) ||
                    string.IsNullOrEmpty(txtChassisNumber.Text) ||
                    cmbFuelType.SelectedItem == null ||
                    cmbTransmissionType.SelectedItem == null ||
                    cmbVehicleStatus.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen tüm gerekli alanları doldurun.\n(Plaka, Marka, Model, Şasi No, Yakıt Tipi, Şanzıman Tipi ve Durum zorunludur)",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if plate number already exists (for new vehicles or different vehicles)
                var existingVehicle = _vehicleRepository.GetByPlateNumber(txtPlateNumber.Text);
                if (existingVehicle != null && (!_isEditMode || existingVehicle.VehicleID != _editingVehicleId))
                {
                    MessageBox.Show("Bu plaka numarası zaten başka bir araç tarafından kullanılmaktadır.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if chassis number already exists
                var existingVehicleByChassis = _vehicleRepository.GetByChassisNumber(txtChassisNumber.Text);
                if (existingVehicleByChassis != null && (!_isEditMode || existingVehicleByChassis.VehicleID != _editingVehicleId))
                {
                    MessageBox.Show("Bu şasi numarası zaten başka bir araç tarafından kullanılmaktadır.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create or update vehicle object
                Vehicle vehicle;
                if (_isEditMode)
                {
                    vehicle = _vehicleRepository.GetById(_editingVehicleId);
                    if (vehicle == null)
                    {
                        MessageBox.Show("Düzenlenecek araç bulunamadı.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    vehicle = new Vehicle();
                }

                // Fill vehicle object
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

                // Set acquisition date
                vehicle.VehicleAcquisitionDate = dtpAcquisitionDate.Checked ? dtpAcquisitionDate.Value : (DateTime?)null;

                // Save to database
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
                    string message = _isEditMode ? "Araç başarıyla güncellendi." : "Araç başarıyla eklendi.";
                    MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadVehicles(); // Refresh the list
                    tabControlVehicles.SelectedIndex = 0; // Switch to Vehicles List tab
                }
                else
                {
                    string message = _isEditMode ? "Araç güncellenirken bir hata oluştu." : "Araç eklenirken bir hata oluştu.";
                    MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: İptal butonu tıklama olayı
        // EN: Cancel button click event
        private void BtnCancelVehicle_Click(object sender, EventArgs e)
        {
            ClearForm();
            tabControlVehicles.SelectedIndex = 0; // Switch to Vehicles List tab
        }
    }
}