using System;
using System.Collections.Generic;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using System.Drawing;
using System.Linq;
using Org.BouncyCastle.Asn1.Pkcs;

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

        public enum RentalStatus
        {
            Active,
            CompletedOnTime,
            CompletedLate,
            Overdue
        }

        public RentalsControl()
        {
            InitializeComponent();

            _rentalRepository = new RentalRepository();
            _customerRepository = new CustomerRepository();
            _vehicleRepository = new VehicleRepository();
            _userRepository = new UserRepository();

            this.Load += RentalsControl_Load;
            btnCustomerLoad.Click += BtnCustomerLoad_Click;
            btnVehicleLoad.Click += BtnVehicleLoad_Click;

            dtpRentalStartDate.ValueChanged += DtpRentalStartDate_ValueChanged;
            dtpRentalEndDate.ValueChanged += DtpRentalEndDate_ValueChanged;

            sfDataGridLastRentals.CellDoubleClick += SfDataGridLastRentals_CellDoubleClick;
            btnShowRental.Click += BtnShowRental_Click;

            btnRentalOperations.Click += btnRentalOperations_Click;

            dtpLicenseDate.Value = dtpLicenseDate.MinDate;
            dtpDateOfBirth.Value = dtpDateOfBirth.MinDate;
            dtpRentalStartDate.Value = DateTime.Now;
            dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            txtBoxRentalPaymentType.Text = "Nakit";

            sfDataGridLastRentals.QueryRowStyle += SfDataGridLastRentals_QueryRowStyle;
            sfDataGridRentals.QueryRowStyle += SfDataGridRentals_QueryRowStyle;
        }

        private void RentalsControl_Load(object sender, EventArgs e)
        {
            LoadRentals();
            LoadCustomersForAutoComplete();
            LoadVehiclesForAutoComplete();

            dtpRentalStartDate.MinDate = DateTime.Today;
            dtpRentalEndDate.MinDate = DateTime.Today.AddDays(1);
        }

        private RentalStatus GetRentalStatus(Rental rental)
        {
            DateTime today = DateTime.Today;

            if (!rental.RentalReturnDate.HasValue)
            {
                if (rental.RentalEndDate.Date < today)
                {
                    return RentalStatus.Overdue;
                }
                return RentalStatus.Active;
            }

            if (rental.RentalReturnDate.Value.Date <= rental.RentalEndDate.Date)
            {
                return RentalStatus.CompletedOnTime;
            }
            else
            {
                return RentalStatus.CompletedLate;
            }
        }

        private Color GetStatusColor(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return Color.LightBlue;
                case RentalStatus.CompletedOnTime:
                    return Color.LightGreen;
                case RentalStatus.CompletedLate:
                    return Color.Orange;
                case RentalStatus.Overdue:
                    return Color.Crimson;
                default:
                    return Color.White;
            }
        }

        private string GetStatusDescription(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return "Aktif Kiralama";
                case RentalStatus.CompletedOnTime:
                    return "Zamanında Tamamlandı";
                case RentalStatus.CompletedLate:
                    return "Geç Tamamlandı (Cezalı)";
                case RentalStatus.Overdue:
                    return "Süresi Geçmiş";
                default:
                    return "Belirsiz";
            }
        }

        private void LoadRentals()
        {
            try
            {
                List<Rental> rentals = _rentalRepository.GetAll();

                foreach (var rental in rentals)
                {
                    if (rental.RentalCustomerID > 0)
                    {
                        rental.Customer = _customerRepository.GetById(rental.RentalCustomerID);
                    }

                    if (rental.RentalVehicleID > 0)
                    {
                        rental.Vehicle = _vehicleRepository.GetById(rental.RentalVehicleID);
                    }

                    if (rental.RentalUserID > 0)
                    {
                        rental.User = _userRepository.GetById(rental.RentalUserID);
                    }
                }

                sfDataGridRentals.DataSource = rentals;

                var latestRentals = rentals.OrderByDescending(r => r.RentalCreatedAt).ToList();

                sfDataGridLastRentals.DataSource = latestRentals;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kiralama verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SfDataGridRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                var rental = e.RowData as Rental;
                if (rental != null)
                {
                    RentalStatus status = GetRentalStatus(rental);

                    e.Style.BackColor = GetStatusColor(status);

                    switch (status)
                    {
                        case RentalStatus.Overdue:
                            e.Style.TextColor = Color.White;
                            e.Style.Font.Bold = true;
                            break;
                        case RentalStatus.CompletedLate:
                            e.Style.TextColor = Color.Black;
                            e.Style.Font.Bold = true;
                            break;
                        case RentalStatus.Active:
                            e.Style.TextColor = Color.Black;
                            e.Style.Font.Bold = true;
                            break;
                        case RentalStatus.CompletedOnTime:
                            e.Style.TextColor = Color.Black;
                            e.Style.Font.Bold = true;
                            break;
                        default:
                            e.Style.TextColor = Color.Black;
                            e.Style.Font.Bold = true;
                            break;
                    }
                }
                else
                {
                    if (e.RowIndex % 2 == 0)
                        e.Style.BackColor = Color.White;
                    else
                        e.Style.BackColor = Color.FromArgb(240, 245, 255);

                    e.Style.TextColor = Color.Black;
                    e.Style.Font.Bold = true;
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
                    RentalStatus status = GetRentalStatus(rental);

                    e.Style.BackColor = GetStatusColor(status);

                    switch (status)
                    {
                        case RentalStatus.Overdue:
                            e.Style.TextColor = Color.White;
                            e.Style.Font.Bold = true;
                            break;
                        case RentalStatus.CompletedLate:
                            e.Style.TextColor = Color.Black;
                            e.Style.Font.Bold = true;
                            break;
                        case RentalStatus.Active:
                            e.Style.TextColor = Color.Black;
                            e.Style.Font.Bold = true;
                            break;
                        case RentalStatus.CompletedOnTime:
                            e.Style.TextColor = Color.Black;
                            e.Style.Font.Bold = true;
                            break;
                        default:
                            e.Style.TextColor = Color.Black;
                            e.Style.Font.Bold = true;
                            break;
                    }
                }
                else
                {
                    if (e.RowIndex % 2 == 0)
                        e.Style.BackColor = Color.White;
                    else
                        e.Style.BackColor = Color.FromArgb(240, 245, 255);

                    e.Style.TextColor = Color.Black;
                    e.Style.Font.Bold = true;
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
                    string fullName = $"{customer.CustomerFirstName} {customer.CustomerLastName}";
                    autoCompleteSource.Add(fullName);
                }

                txtBoxSearchCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxSearchCustomer.AutoCompleteCustomSource = autoCompleteSource;
                txtBoxSearchCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteri verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Customer selectedCustomer = FindCustomerByFullName(searchText);

            if (selectedCustomer != null)
            {
                var customerActiveRentals = CheckCustomerActiveRentals(selectedCustomer.CustomerID);

                if (customerActiveRentals.Count > 0)
                {
                    string activeRentalInfo = "";
                    foreach (var rental in customerActiveRentals.Take(3))
                    {
                        activeRentalInfo += $"• Plaka: {rental.Vehicle?.VehiclePlateNumber ?? "Bilinmiyor"} - Bitiş: {rental.RentalEndDate:dd.MM.yyyy}\n";
                    }

                    if (customerActiveRentals.Count > 3)
                    {
                        activeRentalInfo += $"• ... ve {customerActiveRentals.Count - 3} kiralama daha\n";
                    }

                    DialogResult result = MessageBox.Show(
                        $"UYARI: Bu müşterinin aktif {customerActiveRentals.Count} kiralaması bulunmaktadır:\n\n" +
                        activeRentalInfo + "\n" +
                        "Yine de bu müşteriyle yeni kiralama yapmak istiyor musunuz?",
                        "Aktif Kiralama Uyarısı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        txtBoxSearchCustomer.Text = string.Empty;
                        return;
                    }
                }

                LoadCustomerInfo(selectedCustomer);

                if (customerActiveRentals.Count > 0)
                {
                    lblProgressWarning.Text = $"Müşteri yüklendi. DİKKAT: {customerActiveRentals.Count} aktif kiralama var!";
                    lblProgressWarning.ForeColor = Color.Orange;
                }
            }
            else
            {
                MessageBox.Show("Müşteri bulunamadı. Lütfen geçerli bir müşteri seçiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<Rental> CheckCustomerActiveRentals(int customerId)
        {
            try
            {
                var activeRentals = _rentalRepository.GetActiveRentals();
                var customerActiveRentals = activeRentals.Where(r => r.RentalCustomerID == customerId).ToList();

                foreach (var rental in customerActiveRentals)
                {
                    if (rental.Vehicle == null && rental.RentalVehicleID > 0)
                    {
                        rental.Vehicle = _vehicleRepository.GetById(rental.RentalVehicleID);
                    }
                }

                return customerActiveRentals;
            }
            catch (Exception)
            {
                return new List<Rental>();
            }
        }

        private Customer FindCustomerByFullName(string fullName)
        {
            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length < 2)
                return null;

            string firstName = nameParts[0];

            string lastName = string.Join(" ", nameParts, 1, nameParts.Length - 1);

            return _customers.Find(c =>
                c.CustomerFirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                c.CustomerLastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        private void LoadCustomerInfo(Customer customer)
        {
            if (customer == null)
                return;

            txtBoxCustomerFullName.Text = $"{customer.CustomerFirstName} {customer.CustomerLastName}";
            tctBoxNationalID.Text = customer.CustomerNationalID;
            txtBoxPhoneNo.Text = customer.CustomerPhone;
            txtBoxEmail.Text = customer.CustomerEmail;
            txtBoxAddress.Text = customer.CustomerAddress;
            txtBoxLicenseNo.Text = customer.CustomerLicenseNumber;
            txtBoxLicenseClass.Text = customer.CustomerLicenseClass;

            if (customer.CustomerLicenseDate.HasValue)
                dtpLicenseDate.Value = customer.CustomerLicenseDate.Value;
            else
                dtpLicenseDate.Value = dtpLicenseDate.MinDate;

            if (customer.CustomerDateOfBirth.HasValue)
                dtpDateOfBirth.Value = customer.CustomerDateOfBirth.Value;
            else
                dtpDateOfBirth.Value = dtpDateOfBirth.MinDate;

            lblProgressWarning.Text = "Müşteri bilgileri başarıyla yüklendi.";
            lblProgressWarning.ForeColor = Color.Green;
        }

        #endregion

        #region Vehicle Operations

        private void LoadVehiclesForAutoComplete()
        {
            try
            {
                _vehicles = _vehicleRepository.GetAvailableVehicles();

                var activeRentals = _rentalRepository.GetActiveRentals();
                var rentedVehicleIds = activeRentals.Select(r => r.RentalVehicleID).ToHashSet();

                _vehicles = _vehicles.Where(v => !rentedVehicleIds.Contains(v.VehicleID)).ToList();

                AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();

                foreach (var vehicle in _vehicles)
                {
                    autoCompleteSource.Add(vehicle.VehiclePlateNumber);
                }

                textBoxSearchVehicle.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxSearchVehicle.AutoCompleteCustomSource = autoCompleteSource;
                textBoxSearchVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araç verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Vehicle selectedVehicle = FindVehicleByPlate(searchText);

            if (selectedVehicle != null)
            {
                if (!IsVehicleAvailableForRental(selectedVehicle))
                {
                    MessageBox.Show($"Seçilen araç ({selectedVehicle.VehiclePlateNumber}) şu anda kiralamaya uygun değil.\nAraç durumu kontrol edilip tekrardan deneyin.",
                        "Araç İşgal", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    LoadVehiclesForAutoComplete();
                    textBoxSearchVehicle.Text = string.Empty;
                    return;
                }

                LoadVehicleInfo(selectedVehicle);
            }
            else
            {
                MessageBox.Show("Araç bulunamadı veya kiralamaya uygun değil. Lütfen listeden uygun bir araç seçiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsVehicleAvailableForRental(Vehicle vehicle)
        {
            try
            {
                if (vehicle.VehicleStatusID != 1 && vehicle.VehicleStatusID != 4)
                {
                    return false;
                }

                var activeRentals = _rentalRepository.GetActiveRentals();
                bool isCurrentlyRented = activeRentals.Any(r => r.RentalVehicleID == vehicle.VehicleID);

                return !isCurrentlyRented;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Vehicle FindVehicleByPlate(string plateNumber)
        {
            // Search for the vehicle by plate number
            return _vehicles.Find(v =>
                v.VehiclePlateNumber.Equals(plateNumber, StringComparison.OrdinalIgnoreCase));
        }

        private void LoadVehicleInfo(Vehicle vehicle)
        {
            if (vehicle == null)
                return;

            txtBoxVehiclePlate.Text = vehicle.VehiclePlateNumber;
            txtBoxVehicleBrand.Text = vehicle.VehicleBrand;
            txtBoxVehicleModel.Text = vehicle.VehicleModel;
            txtBoxVehicleYear.Text = vehicle.VehicleYear.ToString();
            txtBoxVehicleColor.Text = vehicle.VehicleColor;
            txtBoxVehicleFuelType.Text = vehicle.VehicleFuelType;
            txtBoxVehicleTransmission.Text = vehicle.VehicleTransmissionType;
            txtBoxVehicleMileage.Text = $"{vehicle.VehicleMileage} KM";

            if (vehicle.Branch != null)
            {
                txtBoxVehicleLocation.Text = vehicle.Branch.BranchName;
            }
            else
            {
                txtBoxVehicleLocation.Text = "Belirsiz";
            }

            if (vehicle.VehicleStatus != null)
            {
                txtBoxVehicleStatus.Text = vehicle.VehicleStatus.VehicleStatusName;
            }
            else
            {
                txtBoxVehicleStatus.Text = "Belirsiz";
            }

            DateTime rentalStartDate = DateTime.Now;
            DateTime rentalEndDate = rentalStartDate.AddDays(1);

            dtpRentalStartDate.Value = rentalStartDate;
            dtpRentalEndDate.Value = rentalEndDate;
            txtBoxRentalStartMileage.Text = vehicle.VehicleMileage.ToString();

            CalculateRentalAmount();

            lblProgressWarning.Text = "Araç bilgileri başarıyla yüklendi.";
            lblProgressWarning.ForeColor = Color.Green;
        }

        #endregion

        #region Rental Calculations

        private void CalculateRentalAmount()
        {
            if (string.IsNullOrEmpty(txtBoxVehiclePlate.Text))
                return;

            Vehicle selectedVehicle = FindVehicleByPlate(txtBoxVehiclePlate.Text);
            if (selectedVehicle == null || !selectedVehicle.VehicleClassID.HasValue)
                return;

            TimeSpan rentalPeriod = dtpRentalEndDate.Value.Date - dtpRentalStartDate.Value.Date;
            int days = rentalPeriod.Days + 1;

            if (days <= 0)
            {
                dtpRentalEndDate.Value = dtpRentalStartDate.Value.AddDays(1);
                days = 2;
            }

            var classRepository = new VehicleClassRepository();
            decimal dailyRate = classRepository.GetRentalPrice(selectedVehicle.VehicleClassID.Value, RentalType.Daily);

            decimal totalAmount = dailyRate * days;
            txtBoxRentalAmount.Text = totalAmount.ToString("N2") + " ₺";

            decimal depositAmount = totalAmount * 0.5m;
            txtBoxRentalDeposit.Text = depositAmount.ToString("N2") + " ₺";

            txtBoxRentalPaymentType.Text = "Nakit";
        }

        private void DtpRentalStartDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateRentalAmount();
        }

        private void DtpRentalEndDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateRentalAmount();
        }

        private void ClearForm()
        {
            txtBoxSearchCustomer.Text = string.Empty;
            txtBoxCustomerFullName.Text = string.Empty;
            tctBoxNationalID.Text = string.Empty;
            txtBoxPhoneNo.Text = string.Empty;
            txtBoxEmail.Text = string.Empty;
            txtBoxAddress.Text = string.Empty;
            txtBoxLicenseNo.Text = string.Empty;
            txtBoxLicenseClass.Text = string.Empty;
            dtpLicenseDate.Value = dtpLicenseDate.MinDate;
            dtpDateOfBirth.Value = dtpDateOfBirth.MinDate;

            textBoxSearchVehicle.Text = string.Empty;
            txtBoxVehiclePlate.Text = string.Empty;
            txtBoxVehicleBrand.Text = string.Empty;
            txtBoxVehicleModel.Text = string.Empty;
            txtBoxVehicleYear.Text = string.Empty;
            txtBoxVehicleColor.Text = string.Empty;
            txtBoxVehicleFuelType.Text = string.Empty;
            txtBoxVehicleTransmission.Text = string.Empty;
            txtBoxVehicleMileage.Text = string.Empty;
            txtBoxVehicleLocation.Text = string.Empty;
            txtBoxVehicleStatus.Text = string.Empty;

            dtpRentalStartDate.Value = DateTime.Now;
            dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            txtBoxRentalStartMileage.Text = string.Empty;
            textBox8.Text = string.Empty;
            txtBoxRentalPaymentType.Text = "Nakit";
            txtBoxRentalAmount.Text = string.Empty;
            txtBoxRentalDeposit.Text = string.Empty;
            txtBoxRentalNote.Text = string.Empty;

            try
            {
                sfDataGridRentals.SelectedItem = null;
                sfDataGridRentals.SelectedIndex = -1;

                sfDataGridLastRentals.SelectedItem = null;
                sfDataGridLastRentals.SelectedIndex = -1;

                var currentSelectionMode1 = sfDataGridRentals.SelectionMode;
                var currentSelectionMode2 = sfDataGridLastRentals.SelectionMode;

                sfDataGridRentals.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.None;
                sfDataGridRentals.SelectionMode = currentSelectionMode1;

                sfDataGridLastRentals.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.None;
                sfDataGridLastRentals.SelectionMode = currentSelectionMode2;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Selection clearing failed: {ex.Message}");
            }
        }

        private bool ValidateRentalForm()
        {
            if (string.IsNullOrEmpty(txtBoxCustomerFullName.Text))
            {
                lblProgressWarning.Text = "Please select a customer.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxVehiclePlate.Text))
            {
                lblProgressWarning.Text = "Please select a vehicle.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            Customer selectedCustomer = FindCustomerByFullName(txtBoxCustomerFullName.Text);
            if (selectedCustomer == null)
            {
                lblProgressWarning.Text = "Selected customer is not valid. Please select again.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            Vehicle selectedVehicle = FindVehicleByPlate(txtBoxVehiclePlate.Text);
            if (selectedVehicle == null)
            {
                lblProgressWarning.Text = "Selected vehicle is not valid. Please select again.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            if (!IsVehicleAvailableForRental(selectedVehicle))
            {
                lblProgressWarning.Text = "Selected vehicle is no longer available for rental.";
                lblProgressWarning.ForeColor = Color.Red;

                LoadVehiclesForAutoComplete();
                textBoxSearchVehicle.Text = string.Empty;
                txtBoxVehiclePlate.Text = string.Empty;
                return false;
            }

            if (dtpRentalEndDate.Value < dtpRentalStartDate.Value)
            {
                lblProgressWarning.Text = "End date cannot be earlier than start date.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxRentalAmount.Text))
            {
                lblProgressWarning.Text = "Rental amount is not calculated.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxRentalStartMileage.Text))
            {
                lblProgressWarning.Text = "Starting mileage must be entered.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxRentalPaymentType.Text))
            {
                lblProgressWarning.Text = "Payment type must be entered.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            var customerActiveRentals = CheckCustomerActiveRentals(selectedCustomer.CustomerID);
            if (customerActiveRentals.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Son kontrol: Bu müşterinin {customerActiveRentals.Count} aktif kiralaması var.\n" +
                    "Yeni kiralama yapmaya devam etmek istediğinizden emin misiniz?",
                    "Final Uyarı - Aktif Kiralama",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    lblProgressWarning.Text = "Kiralama işlemi iptal edildi.";
                    lblProgressWarning.ForeColor = Color.Blue;
                    return false;
                }
            }

            return true;
        }

        private void CreateRental()
        {
            try
            {
                Customer selectedCustomer = FindCustomerByFullName(txtBoxCustomerFullName.Text);
                if (selectedCustomer == null)
                {
                    lblProgressWarning.Text = "Selected customer not found.";
                    lblProgressWarning.ForeColor = Color.Red;
                    return;
                }

                Vehicle selectedVehicle = FindVehicleByPlate(txtBoxVehiclePlate.Text);
                if (selectedVehicle == null)
                {
                    lblProgressWarning.Text = "Selected vehicle not found.";
                    lblProgressWarning.ForeColor = Color.Red;
                    return;
                }

                if (!IsVehicleAvailableForRental(selectedVehicle))
                {
                    lblProgressWarning.Text = "Vehicle became unavailable. Please select another vehicle.";
                    lblProgressWarning.ForeColor = Color.Red;

                    LoadVehiclesForAutoComplete();
                    LoadRentals();

                    textBoxSearchVehicle.Text = string.Empty;
                    txtBoxVehiclePlate.Text = string.Empty;
                    txtBoxVehicleBrand.Text = string.Empty;
                    txtBoxVehicleModel.Text = string.Empty;
                    return;
                }

                string amountText = txtBoxRentalAmount.Text.Replace("₺", "").Trim();
                if (!decimal.TryParse(amountText, out decimal rentalAmount))
                {
                    lblProgressWarning.Text = "Invalid rental amount.";
                    lblProgressWarning.ForeColor = Color.Red;
                    return;
                }

                decimal? depositAmount = null;
                if (!string.IsNullOrEmpty(txtBoxRentalDeposit.Text))
                {
                    string depositText = txtBoxRentalDeposit.Text.Replace("₺", "").Trim();
                    if (decimal.TryParse(depositText, out decimal deposit))
                    {
                        depositAmount = deposit;
                    }
                }

                if (!int.TryParse(txtBoxRentalStartMileage.Text.Replace("KM", "").Trim(), out int startKm))
                {
                    lblProgressWarning.Text = "Invalid starting mileage.";
                    lblProgressWarning.ForeColor = Color.Red;
                    return;
                }

                Rental newRental = new Rental
                {
                    RentalCustomerID = selectedCustomer.CustomerID,
                    RentalVehicleID = selectedVehicle.VehicleID,
                    RentalStartDate = dtpRentalStartDate.Value,
                    RentalEndDate = dtpRentalEndDate.Value,
                    RentalReturnDate = null,
                    RentalStartKm = startKm,
                    RentalEndKm = null,
                    RentalAmount = rentalAmount,
                    RentalDepositAmount = depositAmount,
                    RentalPaymentType = txtBoxRentalPaymentType.Text,
                    RentalContractID = null,
                    RentalUserID = Utils.CurrentUser.UserID,
                };

                string noteText = txtBoxRentalNote.Text;
                int rentalId;

                if (!string.IsNullOrEmpty(noteText))
                {
                    rentalId = _rentalRepository.CreateRentalWithNote(newRental, noteText);
                }
                else
                {
                    rentalId = _rentalRepository.Insert(newRental);

                    if (rentalId > 0)
                    {
                        _vehicleRepository.UpdateVehicleStatus(selectedVehicle.VehicleID, 5);
                    }
                }

                if (rentalId > 0)
                {
                    if (depositAmount.HasValue && depositAmount.Value > 0)
                    {
                        Payment depositPayment = new Payment
                        {
                            PaymentTransactionType = "Rental",
                            PaymentTransactionID = rentalId,
                            PaymentCustomerID = selectedCustomer.CustomerID,
                            PaymentAmount = depositAmount.Value,
                            PaymentDate = DateTime.Now,
                            PaymentType = "Deposit",
                            PaymentNote = "Rental deposit",
                            PaymentUserID = Utils.CurrentUser.UserID
                        };

                        var paymentRepository = new PaymentRepository();
                        paymentRepository.Insert(depositPayment);
                    }

                    lblProgressWarning.Text = "Rental successfully created!";
                    lblProgressWarning.ForeColor = Color.Green;

                    LoadRentals();
                    LoadVehiclesForAutoComplete();

                    ClearForm();
                }
                else
                {
                    lblProgressWarning.Text = "Failed to create rental.";
                    lblProgressWarning.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblProgressWarning.Text = $"Error creating rental: {ex.Message}";
                lblProgressWarning.ForeColor = Color.Red;
            }
        }

        #endregion

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
            SetFormReadOnly(false);
            lblProgressWarning.Text = "Form cleared. Ready for new rental entry.";
            lblProgressWarning.ForeColor = Color.Blue;
        }

        private void SfDataGridLastRentals_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                LoadSelectedRental();
            }
        }

        private void BtnShowRental_Click(object sender, EventArgs e)
        {
            LoadSelectedRental();
        }

        private void LoadSelectedRental()
        {
            try
            {
                Rental selectedRental = sfDataGridLastRentals.SelectedItem as Rental;

                if (selectedRental == null)
                {
                    MessageBox.Show("Lütfen listeden bir kiralama seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearForm();

                if (selectedRental.Customer != null)
                {
                    LoadCustomerInfo(selectedRental.Customer);
                }
                else if (selectedRental.RentalCustomerID > 0)
                {
                    Customer customer = _customerRepository.GetById(selectedRental.RentalCustomerID);
                    if (customer != null)
                    {
                        LoadCustomerInfo(customer);
                    }
                }

                if (selectedRental.Vehicle != null)
                {
                    LoadVehicleInfo(selectedRental.Vehicle);
                }
                else if (selectedRental.RentalVehicleID > 0)
                {
                    Vehicle vehicle = _vehicleRepository.GetById(selectedRental.RentalVehicleID);
                    if (vehicle != null)
                    {
                        LoadVehicleInfo(vehicle);
                    }
                }

                DateTime originalMinDateStart = dtpRentalStartDate.MinDate;
                DateTime originalMinDateEnd = dtpRentalEndDate.MinDate;

                try
                {
                    dtpRentalStartDate.MinDate = DateTimePicker.MinimumDateTime;
                    dtpRentalEndDate.MinDate = DateTimePicker.MinimumDateTime;

                    dtpRentalStartDate.Value = selectedRental.RentalStartDate;
                    dtpRentalEndDate.Value = selectedRental.RentalEndDate;
                }
                finally
                {
                    if (!selectedRental.RentalReturnDate.HasValue)
                    {
                        dtpRentalStartDate.MinDate = originalMinDateStart;
                        dtpRentalEndDate.MinDate = originalMinDateEnd;
                    }
                }

                txtBoxRentalStartMileage.Text = selectedRental.RentalStartKm.ToString();

                if (selectedRental.RentalEndKm.HasValue)
                {
                    textBox8.Text = selectedRental.RentalEndKm.Value.ToString();
                }

                txtBoxRentalPaymentType.Text = selectedRental.RentalPaymentType;
                txtBoxRentalAmount.Text = selectedRental.RentalAmount.ToString("N2") + " ₺";

                if (selectedRental.RentalDepositAmount.HasValue)
                {
                    txtBoxRentalDeposit.Text = selectedRental.RentalDepositAmount.Value.ToString("N2") + " ₺";
                }

                if (selectedRental.RentalID > 0)
                {
                    List<RentalNote> notes = _rentalRepository.GetNotes(selectedRental.RentalID);
                    if (notes != null && notes.Count > 0)
                    {
                        txtBoxRentalNote.Text = notes[0].RentalNoteText;
                    }
                }

                SetFormReadOnly(true);

                RentalStatus status = GetRentalStatus(selectedRental);
                lblProgressWarning.Text = $"Kiralama Durumu: {GetStatusDescription(status)}";
                lblProgressWarning.ForeColor = GetStatusTextColor(status);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kiralama bilgileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetStatusTextColor(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return Color.Blue;
                case RentalStatus.CompletedOnTime:
                    return Color.Green;
                case RentalStatus.CompletedLate:
                    return Color.Orange;
                case RentalStatus.Overdue:
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }

        private void SetFormReadOnly(bool isReadOnly)
        {
            dtpRentalStartDate.Enabled = !isReadOnly;
            dtpRentalEndDate.Enabled = !isReadOnly;
            txtBoxRentalPaymentType.ReadOnly = true;
            txtBoxRentalNote.ReadOnly = true;

            btnAddRental.Enabled = !isReadOnly;

            if (isReadOnly)
            {
                btnAddRental.BackColor = Color.Gray;
            }
            else
            {
                btnAddRental.BackColor = SystemColors.HotTrack;
            }
        }

        private void btnRentalOperations_Click(object sender, EventArgs e)
        {
            Rental selectedRental = sfDataGridLastRentals.SelectedItem as Rental;

            if (selectedRental == null)
            {
                MessageBox.Show("Please select a rental to perform operations.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RentalOperationsForm operationsForm = new Forms.RentalOperationsForm(selectedRental.RentalID);

            DialogResult result = operationsForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                LoadRentals();
                LoadVehiclesForAutoComplete();
                LoadCustomersForAutoComplete();

                lblProgressWarning.Text = "Rental operations completed. Data refreshed.";
                lblProgressWarning.ForeColor = Color.Blue;
            }
        }
    }
}