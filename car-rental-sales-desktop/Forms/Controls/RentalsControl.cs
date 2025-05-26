using System;
using System.Collections.Generic;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using System.Drawing;
using System.Linq;
using car_rental_sales_desktop.Methods;
using Syncfusion.WinForms.DataGrid.Enums; // Added for RowType
using Syncfusion.WinForms.DataGrid.Events; // Added for CellClickEventArgs
using Syncfusion.Windows.Forms.Tools; // Added for TabControlAdv
using Syncfusion.WinForms.DataGrid.Helpers; // Added for potential SfDataGrid extension methods

namespace car_rental_sales_desktop.Forms.Controls
{
    public partial class RentalsControl : UserControl
    {
        private RentalRepository _rentalRepository;
        private CustomerRepository _customerRepository;
        private VehicleRepository _vehicleRepository;
        private UserRepository _userRepository;
        private List<Customer> _customers;
        private List<Vehicle> _vehicles;

        private RentalFormControlManager _formManager;

        public RentalsControl()
        {
            InitializeComponent();

            _rentalRepository = new RentalRepository();
            _customerRepository = new CustomerRepository();
            _vehicleRepository = new VehicleRepository();
            _userRepository = new UserRepository();

            _formManager = new RentalFormControlManager(this);

            this.Load += RentalsControl_Load;
            btnCustomerLoad.Click += BtnCustomerLoad_Click;
            btnVehicleLoad.Click += BtnVehicleLoad_Click;

            dtpRentalStartDate.ValueChanged += DtpRentalStartDate_ValueChanged;
            dtpRentalEndDate.ValueChanged += DtpRentalEndDate_ValueChanged;

            sfDataGridLastRentals.CellDoubleClick += SfDataGridLastRentals_CellDoubleClick;
            sfDataGridRentals.CellDoubleClick += SfDataGridRentals_CellDoubleClick; // Added this line
            btnShowRental.Click += BtnShowRental_Click;

            _formManager.InitializeFormDefaults();

            sfDataGridLastRentals.QueryRowStyle += SfDataGridLastRentals_QueryRowStyle;
            sfDataGridRentals.QueryRowStyle += SfDataGridRentals_QueryRowStyle;
        }

        // ... (rest of the existing code) ...

        private void SfDataGridRentals_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow != null && e.DataRow.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                var selectedRentalFromGrid = e.DataRow.RowData as Rental;
                if (selectedRentalFromGrid != null)
                {
                    // Set selected item for sfDataGridRentals (this will be used by LoadSelectedRental if the item isn't found in sfDataGridLastRentals)
                    sfDataGridRentals.SelectedItem = selectedRentalFromGrid;

                    // Find and set the corresponding item in sfDataGridLastRentals
                    var rentalInLastRentalsGrid = (sfDataGridLastRentals.DataSource as List<Rental>)?.FirstOrDefault(r => r.RentalID == selectedRentalFromGrid.RentalID);
                    if (rentalInLastRentalsGrid != null)
                    {
                        sfDataGridLastRentals.SelectedItem = rentalInLastRentalsGrid;
                        // The SfDataGrid often scrolls to the SelectedItem automatically.
                        // The following lines are commented out to resolve CS1061.
                        // If explicit scrolling is still needed, verify the API for your Syncfusion version.
                        // var rowIndex = sfDataGridLastRentals.ResolveToRowIndex(rentalInLastRentalsGrid); // CS1061 here
                        // if (rowIndex >= 0)
                        // {
                        //     sfDataGridLastRentals.ScrollInView(rowIndex); // CS1061 here
                        // }
                    }
                    else
                    {
                        // If not found in the other grid, clear its selection or leave as is
                        // sfDataGridLastRentals.ClearSelections(false); // Optional: if you want to clear selection
                    }

                    // Load the selected rental data into the form fields
                    // LoadSelectedRental will use sfDataGridLastRentals.SelectedItem first, then sfDataGridRentals.SelectedItem
                    LoadSelectedRental();

                    // Switch to the Rental Add tab
                    // Assuming tabPageRentalAdd is a TabPageAdv and its parent is a TabControlAdv
                    if (tabPageRentalAdd != null && tabPageRentalAdd.Parent is TabControlAdv parentTabControl)
                    {
                        parentTabControl.SelectedTab = tabPageRentalAdd;
                    }
                    // Removed the else-if for System.Windows.Forms.TabControl to fix CS0029,
                    // as tabPageRentalAdd (being a TabPageAdv) cannot be assigned to System.Windows.Forms.TabControl.SelectedTab.
                }
            }
        }

        private void RentalsControl_Load(object sender, EventArgs e)
        {
            LoadRentals();
            LoadCustomersForAutoComplete();
            LoadVehiclesForAutoComplete();

            dtpRentalStartDate.MinDate = DateTime.Today;
            dtpRentalEndDate.MinDate = DateTime.Today.AddDays(1);
        }

        private void LoadRentals()
        {
            try
            {
                List<Rental> rentals = _rentalRepository.GetAll();
                foreach (var rental in rentals)
                {
                    if (rental.RentalCustomerID > 0 && rental.Customer == null)
                        rental.Customer = _customerRepository.GetById(rental.RentalCustomerID);
                    if (rental.RentalVehicleID > 0 && rental.Vehicle == null)
                        rental.Vehicle = _vehicleRepository.GetById(rental.RentalVehicleID);
                    if (rental.RentalUserID > 0 && rental.User == null)
                        rental.User = _userRepository.GetById(rental.RentalUserID);
                }
                sfDataGridRentals.DataSource = rentals;
                sfDataGridLastRentals.DataSource = rentals.OrderByDescending(r => r.RentalCreatedAt).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kiralama verileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SfDataGridRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                var rental = e.RowData as Rental;
                if (rental != null)
                {
                    RentalMethods.RentalStatus status = RentalMethods.GetRentalStatus(rental);
                    e.Style.BackColor = RentalMethods.GetStatusColor(status);
                    e.Style.TextColor = (status == RentalMethods.RentalStatus.Overdue) ? Color.White : Color.Black;
                    e.Style.Font.Bold = true;
                }
                else
                {
                    e.Style.BackColor = (e.RowIndex % 2 == 0) ? Color.White : Color.FromArgb(240, 245, 255);
                    e.Style.TextColor = Color.Black;
                    e.Style.Font.Bold = false;
                }
            }
        }

        private void SfDataGridLastRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                var rental = e.RowData as Rental;
                if (rental != null)
                {
                    RentalMethods.RentalStatus status = RentalMethods.GetRentalStatus(rental);
                    e.Style.BackColor = RentalMethods.GetStatusColor(status);
                    e.Style.TextColor = (status == RentalMethods.RentalStatus.Overdue) ? Color.White : Color.Black;
                    e.Style.Font.Bold = true;
                }
                else
                {
                    e.Style.BackColor = (e.RowIndex % 2 == 0) ? Color.White : Color.FromArgb(240, 245, 255);
                    e.Style.TextColor = Color.Black;
                    e.Style.Font.Bold = false;
                }
            }
        }

        #region Customer Operations

        private void LoadCustomersForAutoComplete()
        {
            try
            {
                _customers = _customerRepository.GetActiveCustomers();
                AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
                foreach (var customer in _customers)
                {
                    autoCompleteSource.Add($"{customer.CustomerFirstName} {customer.CustomerLastName}");
                }
                txtBoxSearchCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxSearchCustomer.AutoCompleteCustomSource = autoCompleteSource;
                txtBoxSearchCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteri verileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCustomerLoad_Click(object sender, EventArgs e)
        {
            string searchText = txtBoxSearchCustomer.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer selectedCustomer = RentalMethods.FindCustomerByFullName(searchText, _customers);

            if (selectedCustomer != null)
            {
                var customerActiveRentals = RentalMethods.CheckCustomerActiveRentals(selectedCustomer.CustomerID, _rentalRepository, _vehicleRepository);
                if (customerActiveRentals.Count > 0)
                {
                    string activeRentalInfo = string.Join("\n", customerActiveRentals.Take(3)
                        .Select(r => $"• Plaka: {r.Vehicle?.VehiclePlateNumber ?? "Bilinmiyor"} - Bitiş: {r.RentalEndDate:dd.MM.yyyy}"));
                    if (customerActiveRentals.Count > 3) activeRentalInfo += $"\n• ... ve {customerActiveRentals.Count - 3} kiralama daha";

                    DialogResult result = MessageBox.Show($"UYARI: Bu müşterinin aktif {customerActiveRentals.Count} kiralaması var:\n\n{activeRentalInfo}\n\nYeni kiralama yapmak istiyor musunuz?",
                        "Aktif Kiralama Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        txtBoxSearchCustomer.Text = string.Empty;
                        return;
                    }
                }
                _formManager.LoadCustomerInfo(selectedCustomer);
                _formManager.UpdateProgressWarning(customerActiveRentals.Any() ? $"Müşteri yüklendi. DİKKAT: {customerActiveRentals.Count} aktif kiralama var!" : "Müşteri bilgileri başarıyla yüklendi.",
                                                  customerActiveRentals.Any() ? Color.OrangeRed : Color.Green);
            }
            else
            {
                MessageBox.Show("Müşteri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Vehicle Operations

        private void LoadVehiclesForAutoComplete()
        {
            try
            {
                _vehicles = _vehicleRepository.GetAll().Where(v => v.VehicleStatusID == 1 || v.VehicleStatusID == 4).ToList();
                var rentedVehicleIds = _rentalRepository.GetActiveRentals().Select(r => r.RentalVehicleID).ToHashSet();
                _vehicles = _vehicles.Where(v => !rentedVehicleIds.Contains(v.VehicleID)).ToList();

                AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
                foreach (var vehicle in _vehicles) autoCompleteSource.Add(vehicle.VehiclePlateNumber);
                textBoxSearchVehicle.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxSearchVehicle.AutoCompleteCustomSource = autoCompleteSource;
                textBoxSearchVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araç verileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVehicleLoad_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearchVehicle.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Lütfen bir araç seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Vehicle selectedVehicle = RentalMethods.FindVehicleByPlate(searchText, _vehicles);

            if (selectedVehicle != null)
            {
                if (!RentalMethods.IsVehicleAvailableForRental(selectedVehicle, _rentalRepository))
                {
                    MessageBox.Show($"Araç ({selectedVehicle.VehiclePlateNumber}) kiralamaya uygun değil. Durum: {selectedVehicle.VehicleStatus?.VehicleStatusName ?? "Bilinmiyor"}.",
                        "Araç Uygun Değil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadVehiclesForAutoComplete();
                    textBoxSearchVehicle.Text = string.Empty;
                    return;
                }
                _formManager.LoadVehicleInfo(selectedVehicle, CalculateRentalAmount);
                _formManager.UpdateProgressWarning("Araç bilgileri başarıyla yüklendi.", Color.Green);
            }
            else
            {
                MessageBox.Show("Araç bulunamadı veya uygun değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadVehiclesForAutoComplete();
            }
        }
        #endregion

        #region Rental Calculations

        public void CalculateRentalAmount()
        {
            if (string.IsNullOrEmpty(txtBoxVehiclePlate.Text)) return;
            Vehicle selectedVehicle = RentalMethods.FindVehicleByPlate(txtBoxVehiclePlate.Text, _vehicles);
            if (selectedVehicle == null || !selectedVehicle.VehicleClassID.HasValue) return;

            int days = 1;
            if (dtpRentalEndDate.Value.Date >= dtpRentalStartDate.Value.Date)
            {
                days = (dtpRentalEndDate.Value.Date - dtpRentalStartDate.Value.Date).Days + 1;
            }
            else
            {
                dtpRentalEndDate.Value = dtpRentalStartDate.Value.AddDays(1);
                days = 1;
            }


            var classRepository = new VehicleClassRepository();
            decimal dailyRate = classRepository.GetRentalPrice(selectedVehicle.VehicleClassID.Value, RentalType.Daily);
            decimal totalAmount = dailyRate * days;
            txtBoxRentalAmount.Text = totalAmount.ToString("N2") + " ₺";
            txtBoxRentalDeposit.Text = (totalAmount * 0.5m).ToString("N2") + " ₺";
        }

        private void DtpRentalStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRentalEndDate.Value < dtpRentalStartDate.Value)
            {
                dtpRentalEndDate.MinDate = dtpRentalStartDate.Value.AddDays(1);
                dtpRentalEndDate.Value = dtpRentalStartDate.Value.AddDays(1);
            }
            else
            {
                dtpRentalEndDate.MinDate = dtpRentalStartDate.Value.AddDays(1);
            }
            CalculateRentalAmount();
        }

        private void DtpRentalEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRentalEndDate.Value < dtpRentalStartDate.Value)
            {
                // Bu durumun oluşmaması gerekir çünkü MinDate ayarlanıyor.
            }
            CalculateRentalAmount();
        }
        #endregion

        private void ClearForm()
        {
            _formManager.ClearFormInputs();
            _formManager.SetFormReadOnly(false);
            _formManager.UpdateProgressWarning("Form temizlendi.", Color.Blue);
        }

        private bool ValidateRentalForm()
        {
            if (string.IsNullOrEmpty(txtBoxCustomerFullName.Text))
            {
                _formManager.UpdateProgressWarning("Lütfen bir müşteri seçin.", Color.Red);
                txtBoxSearchCustomer.Focus(); return false;
            }
            if (string.IsNullOrEmpty(txtBoxVehiclePlate.Text))
            {
                _formManager.UpdateProgressWarning("Lütfen bir araç seçin.", Color.Red);
                textBoxSearchVehicle.Focus(); return false;
            }

            Customer selectedCustomer = RentalMethods.FindCustomerByFullName(txtBoxCustomerFullName.Text, _customers);
            if (selectedCustomer == null)
            {
                _formManager.UpdateProgressWarning("Seçilen müşteri geçerli değil.", Color.Red);
                txtBoxSearchCustomer.Focus(); return false;
            }

            Vehicle selectedVehicle = RentalMethods.FindVehicleByPlate(txtBoxVehiclePlate.Text, _vehicles);
            if (selectedVehicle == null)
            {
                _formManager.UpdateProgressWarning("Seçilen araç geçerli değil.", Color.Red);
                textBoxSearchVehicle.Focus(); return false;
            }

            if (!RentalMethods.IsVehicleAvailableForRental(selectedVehicle, _rentalRepository))
            {
                _formManager.UpdateProgressWarning("Araç kiralamaya uygun değil.", Color.Red);
                LoadVehiclesForAutoComplete();
                textBoxSearchVehicle.Text = string.Empty;
                txtBoxVehiclePlate.Text = string.Empty;
                return false;
            }

            if (dtpRentalEndDate.Value.Date < dtpRentalStartDate.Value.Date)
            {
                _formManager.UpdateProgressWarning("Bitiş tarihi başlangıçtan önce olamaz.", Color.Red);
                dtpRentalEndDate.Focus(); return false;
            }

            if (string.IsNullOrEmpty(txtBoxRentalAmount.Text) || !decimal.TryParse(txtBoxRentalAmount.Text.Replace("₺", "").Trim(), out _))
            {
                _formManager.UpdateProgressWarning("Kiralama tutarı geçersiz.", Color.Red); return false;
            }
            if (string.IsNullOrEmpty(txtBoxRentalStartMileage.Text) || !int.TryParse(txtBoxRentalStartMileage.Text.Replace("KM", "").Trim(), out _))
            {
                _formManager.UpdateProgressWarning("Başlangıç KM girilmelidir.", Color.Red);
                txtBoxRentalStartMileage.Focus(); return false;
            }
            if (string.IsNullOrEmpty(txtBoxRentalPaymentType.Text))
            {
                _formManager.UpdateProgressWarning("Ödeme türü girilmelidir.", Color.Red);
                txtBoxRentalPaymentType.Focus(); return false;
            }


            var customerActiveRentals = RentalMethods.CheckCustomerActiveRentals(selectedCustomer.CustomerID, _rentalRepository, _vehicleRepository);
            if (customerActiveRentals.Count > 0)
            {
                DialogResult result = MessageBox.Show($"Son kontrol: Müşterinin {customerActiveRentals.Count} aktif kiralaması var. Devam edilsin mi?",
                    "Aktif Kiralama Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    _formManager.UpdateProgressWarning("Kiralama iptal edildi.", Color.Blue);
                    return false;
                }
            }
            return true;
        }

        private void CreateRental()
        {
            try
            {
                Customer selectedCustomer = RentalMethods.FindCustomerByFullName(txtBoxCustomerFullName.Text, _customers);
                Vehicle selectedVehicle = RentalMethods.FindVehicleByPlate(txtBoxVehiclePlate.Text, _vehicles);

                if (selectedCustomer == null || selectedVehicle == null)
                {
                    _formManager.UpdateProgressWarning("Müşteri veya araç bulunamadı.", Color.Red); return;
                }
                if (!RentalMethods.IsVehicleAvailableForRental(selectedVehicle, _rentalRepository))
                {
                    _formManager.UpdateProgressWarning("Araç uygun değil, işlem iptal edildi.", Color.Red);
                    LoadVehiclesForAutoComplete();
                    textBoxSearchVehicle.Text = string.Empty;
                    txtBoxVehiclePlate.Text = string.Empty;
                    return;
                }

                if (!decimal.TryParse(txtBoxRentalAmount.Text.Replace("₺", "").Trim(), out decimal rentalAmount) ||
                    !int.TryParse(txtBoxRentalStartMileage.Text.Replace("KM", "").Trim(), out int startKm))
                {
                    _formManager.UpdateProgressWarning("Tutar veya KM formatı geçersiz.", Color.Red); return;
                }
                decimal? depositAmount = null;
                if (decimal.TryParse(txtBoxRentalDeposit.Text.Replace("₺", "").Trim(), out decimal deposit))
                {
                    depositAmount = deposit;
                }

                Rental newRental = new Rental
                {
                    RentalCustomerID = selectedCustomer.CustomerID,
                    RentalVehicleID = selectedVehicle.VehicleID,
                    RentalStartDate = dtpRentalStartDate.Value,
                    RentalEndDate = dtpRentalEndDate.Value,
                    RentalStartKm = startKm,
                    RentalAmount = rentalAmount,
                    RentalDepositAmount = depositAmount,
                    RentalPaymentType = txtBoxRentalPaymentType.Text,
                    RentalUserID = Utils.CurrentUser.UserID,
                    RentalCreatedAt = DateTime.Now
                };

                int rentalId = string.IsNullOrEmpty(txtBoxRentalNote.Text.Trim())
                    ? _rentalRepository.Insert(newRental)
                    : _rentalRepository.CreateRentalWithNote(newRental, txtBoxRentalNote.Text.Trim());

                if (rentalId > 0)
                {
                    _vehicleRepository.UpdateVehicleStatus(selectedVehicle.VehicleID, 2);
                    if (depositAmount.HasValue && depositAmount.Value > 0)
                    {
                        var paymentRepository = new PaymentRepository();
                        paymentRepository.Insert(new Payment
                        {
                            PaymentTransactionType = "Rental",
                            PaymentTransactionID = rentalId,
                            PaymentCustomerID = selectedCustomer.CustomerID,
                            PaymentAmount = depositAmount.Value,
                            PaymentDate = DateTime.Now,
                            PaymentType = "Deposit",
                            PaymentNote = $"Kiralama ID {rentalId} depozito",
                            PaymentUserID = Utils.CurrentUser.UserID
                        });
                    }
                    _formManager.UpdateProgressWarning($"Kiralama ID {rentalId} başarıyla oluşturuldu!", Color.Green);
                    LoadRentals();
                    LoadVehiclesForAutoComplete();
                    ClearForm();
                }
                else
                {
                    _formManager.UpdateProgressWarning("Kiralama oluşturulamadı.", Color.Red);
                }
            }
            catch (Exception ex)
            {
                _formManager.UpdateProgressWarning($"Kiralama hatası: {ex.Message}", Color.Red);
            }
        }

        private void btnAddRental_Click(object sender, EventArgs e)
        {
            if (ValidateRentalForm())
            {
                CreateRental();
            }
        }

        private void btnClearRentalForm_Click(object sender, EventArgs e)
        {
            ClearForm();
            _formManager.UpdateProgressWarning("Form temizlendi. Yeni kiralama girişi için hazır.", Color.Blue);
        }

        private void SfDataGridLastRentals_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow != null && e.DataRow.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                LoadSelectedRental();
                // Switch to the Rental Add tab if not already there
                if (tabPageRentalAdd != null && tabPageRentalAdd.Parent is TabControlAdv parentTabControl)
                {
                    parentTabControl.SelectedTab = tabPageRentalAdd;
                }
                // Removed the else-if for System.Windows.Forms.TabControl to fix CS0029
            }
        }

        private void BtnShowRental_Click(object sender, EventArgs e)
        {
            LoadSelectedRental();
            // Switch to the Rental Add tab if not already there
            if (tabPageRentalAdd != null && tabPageRentalAdd.Parent is TabControlAdv parentTabControl)
            {
                parentTabControl.SelectedTab = tabPageRentalAdd;
            }
            // Removed the else-if for System.Windows.Forms.TabControl to fix CS0029
        }

        private void LoadSelectedRental()
        {
            try
            {
                Rental selectedRental = sfDataGridLastRentals.SelectedItem as Rental ?? sfDataGridRentals.SelectedItem as Rental;
                if (selectedRental == null)
                {
                    MessageBox.Show("Lütfen listeden bir kiralama seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _formManager.ClearFormInputs();


                if (selectedRental.RentalCustomerID > 0)
                {
                    selectedRental.Customer = _customerRepository.GetById(selectedRental.RentalCustomerID);
                }
                else
                {
                    selectedRental.Customer = null;
                }

                if (selectedRental.RentalVehicleID > 0)
                {
                    selectedRental.Vehicle = _vehicleRepository.GetById(selectedRental.RentalVehicleID);
                }
                else
                {
                    selectedRental.Vehicle = null;
                }

                List<RentalNote> notes = (selectedRental.RentalID > 0) ? _rentalRepository.GetNotes(selectedRental.RentalID) : new List<RentalNote>();

                DateTime originalMinDateStart = dtpRentalStartDate.MinDate;
                DateTime originalMinDateEnd = dtpRentalEndDate.MinDate;
                try
                {
                    dtpRentalStartDate.MinDate = DateTimePicker.MinimumDateTime;
                    dtpRentalEndDate.MinDate = DateTimePicker.MinimumDateTime;

                    _formManager.PopulateSelectedRentalDetails(selectedRental, notes, CalculateRentalAmount);
                }
                finally
                {
                    if (!selectedRental.RentalReturnDate.HasValue)
                    {
                        dtpRentalStartDate.MinDate = DateTime.Today;
                        dtpRentalEndDate.MinDate = dtpRentalStartDate.Value.AddDays(1);
                    }
                    else
                    {
                        dtpRentalStartDate.MinDate = originalMinDateStart;
                        dtpRentalEndDate.MinDate = originalMinDateEnd;
                    }
                }

                _formManager.SetFormReadOnly(true);
                RentalMethods.RentalStatus status = RentalMethods.GetRentalStatus(selectedRental);
                _formManager.UpdateProgressWarning($"Kiralama Durumu: {RentalMethods.GetStatusDescription(status)}", RentalMethods.GetStatusTextColor(status));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kiralama bilgileri yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRentalOperations_Click(object sender, EventArgs e)
        {
            Rental selectedRental = sfDataGridLastRentals.SelectedItem as Rental ?? sfDataGridRentals.SelectedItem as Rental;
            if (selectedRental == null)
            {
                MessageBox.Show("Lütfen işlem için bir kiralama seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RentalOperationsForm operationsForm = new RentalOperationsForm(selectedRental.RentalID);
            DialogResult result = operationsForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                LoadRentals();
                LoadVehiclesForAutoComplete();

                var refreshedRental = _rentalRepository.GetById(selectedRental.RentalID);
                if (refreshedRental != null)
                {
                    // Try to reselect in the grids
                    var rentalInLastRentalsGrid = (sfDataGridLastRentals.DataSource as List<Rental>)?.FirstOrDefault(r => r.RentalID == refreshedRental.RentalID);
                    if (rentalInLastRentalsGrid != null) sfDataGridLastRentals.SelectedItem = rentalInLastRentalsGrid;

                    var rentalInRentalsGrid = (sfDataGridRentals.DataSource as List<Rental>)?.FirstOrDefault(r => r.RentalID == refreshedRental.RentalID);
                    if (rentalInRentalsGrid != null) sfDataGridRentals.SelectedItem = rentalInRentalsGrid;

                    // If the originally selected item (or its refreshed version) is still what we want to show:
                    if ((sfDataGridLastRentals.SelectedItem as Rental)?.RentalID == refreshedRental.RentalID ||
                         (sfDataGridRentals.SelectedItem as Rental)?.RentalID == refreshedRental.RentalID)
                    {
                        LoadSelectedRental();
                    }
                    else
                    {
                        ClearForm(); // Or select the refreshed rental if found and load it
                    }
                }
                else
                {
                    ClearForm();
                }
                _formManager.UpdateProgressWarning("Kiralama işlemleri tamamlandı. Veriler yenilendi.", Color.Blue);
            }
        }
    }
}