using System;
using System.Collections.Generic;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using System.Drawing;
using Org.BouncyCastle.Asn1.Pkcs;

namespace car_rental_sales_desktop.Forms.Controls
{
    public partial class RentalsControl : UserControl
    {
        private RentalRepository _rentalRepository;
        private CustomerRepository _customerRepository;
        private VehicleRepository _vehicleRepository;
        private UserRepository _userRepository;
        private List<Customer> _customers; // Müşteri listesi
        private List<Vehicle> _vehicles; // Araç listesi

        public RentalsControl()
        {
            InitializeComponent();

            // Initialize repositories
            _rentalRepository = new RentalRepository();
            _customerRepository = new CustomerRepository();
            _vehicleRepository = new VehicleRepository();
            _userRepository = new UserRepository();

            // Register event handlers
            this.Load += RentalsControl_Load;
            btnCustomerLoad.Click += BtnCustomerLoad_Click;
            btnVehicleLoad.Click += BtnVehicleLoad_Click;

            // Register date picker events
            dtpRentalStartDate.ValueChanged += DtpRentalStartDate_ValueChanged;
            dtpRentalEndDate.ValueChanged += DtpRentalEndDate_ValueChanged;

            dtpLicenseDate.Value = dtpLicenseDate.MinDate;
            dtpDateOfBirth.Value = dtpDateOfBirth.MinDate;
            dtpRentalStartDate.Value = DateTime.Now;
            dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            txtBoxRentalPaymentType.Text = "Nakit";

        }

        private void RentalsControl_Load(object sender, EventArgs e)
        {
            LoadRentals();
            LoadCustomersForAutoComplete();
            LoadVehiclesForAutoComplete();

            dtpRentalStartDate.MinDate = DateTime.Today;
            dtpRentalEndDate.MinDate = DateTime.Today.AddDays(1);
        }

        // TR: Bu metot, kiralama verilerini yüklemek için kullanılır.
        // EN: This method is used to load rental data.
        private void LoadRentals()
        {
            try
            {
                // Get all rentals from the repository
                List<Rental> rentals = _rentalRepository.GetAll();

                // For each rental, load related data
                foreach (var rental in rentals)
                {
                    // Load customer data
                    if (rental.RentalCustomerID > 0)
                    {
                        rental.Customer = _customerRepository.GetById(rental.RentalCustomerID);
                    }

                    // Load vehicle data
                    if (rental.RentalVehicleID > 0)
                    {
                        rental.Vehicle = _vehicleRepository.GetById(rental.RentalVehicleID);
                    }

                    // Load user data
                    if (rental.RentalUserID > 0)
                    {
                        rental.User = _userRepository.GetById(rental.RentalUserID);
                    }
                }

                // Set the data source for the main grid
                sfDataGridRentals.DataSource = rentals;

                // Create a sorted list for the latest rentals grid (most recent first)
                var latestRentals = rentals.OrderByDescending(r => r.RentalCreatedAt).ToList();

                // Set the data source for the latest rentals grid
                sfDataGridLastRentals.DataSource = latestRentals;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kiralama verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, kiralama verileri tablosunda gösterilirken satır stillerini ayarlamak için kullanılır.
        // EN: This method is used to set row styles when displaying rental data in the table.
        private void SfDataGridRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255); // Light blue tone
            }
        }

        // TR: Bu metot, son kiralamalar tablosunda gösterilirken satır stillerini ayarlamak için kullanılır.
        // EN: This method is used to set row styles when displaying latest rentals data in the table.
        private void SfDataGridLastRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255); // Light blue tone
            }
        }

        #region Customer Operations

        // TR: Bu metot, müşterileri otomatik tamamlama için yüklemek için kullanılır.
        // EN: This method is used to load customers for autocomplete.
        private void LoadCustomersForAutoComplete()
        {
            try
            {
                // Get all active customers
                _customers = _customerRepository.GetActiveCustomers();

                // Create AutoCompleteStringCollection
                AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();

                // Add customer names to the collection
                foreach (var customer in _customers)
                {
                    string fullName = $"{customer.CustomerFirstName} {customer.CustomerLastName}";
                    autoCompleteSource.Add(fullName);
                }

                // Set autocomplete properties
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

        // TR: Bu metot, btnCustomerLoad düğmesine tıklandığında çalışır ve seçilen müşterinin bilgilerini yükler.
        // EN: This method runs when the btnCustomerLoad button is clicked and loads the selected customer's information.
        private void BtnCustomerLoad_Click(object sender, EventArgs e)
        {
            string searchText = txtBoxSearchCustomer.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find the customer
            Customer selectedCustomer = FindCustomerByFullName(searchText);

            if (selectedCustomer != null)
            {
                // Load customer info to the form
                LoadCustomerInfo(selectedCustomer);
            }
            else
            {
                MessageBox.Show("Müşteri bulunamadı. Lütfen geçerli bir müşteri seçiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // TR: Bu metot, müşteriyi ad ve soyadına göre bulmak için kullanılır.
        // EN: This method is used to find a customer by full name.
        private Customer FindCustomerByFullName(string fullName)
        {
            // Split full name into first name and last name
            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length < 2)
                return null;

            string firstName = nameParts[0];

            // Last name might contain multiple words
            string lastName = string.Join(" ", nameParts, 1, nameParts.Length - 1);

            // Search for the customer
            return _customers.Find(c =>
                c.CustomerFirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                c.CustomerLastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        // TR: Bu metot, seçilen müşterinin bilgilerini form alanlarına yüklemek için kullanılır.
        // EN: This method is used to load the selected customer's information into the form fields.
        private void LoadCustomerInfo(Customer customer)
        {
            if (customer == null)
                return;

            // Update customer information fields
            txtBoxCustomerFullName.Text = $"{customer.CustomerFirstName} {customer.CustomerLastName}";
            tctBoxNationalID.Text = customer.CustomerNationalID;
            txtBoxPhoneNo.Text = customer.CustomerPhone;
            txtBoxEmail.Text = customer.CustomerEmail;
            txtBoxAddress.Text = customer.CustomerAddress;
            txtBoxLicenseNo.Text = customer.CustomerLicenseNumber;
            txtBoxLicenseClass.Text = customer.CustomerLicenseClass;

            // Format dates if they exist using DateTimePickers
            if (customer.CustomerLicenseDate.HasValue)
                dtpLicenseDate.Value = customer.CustomerLicenseDate.Value;
            else
                dtpLicenseDate.Value = dtpLicenseDate.MinDate; // Minimum tarih değeri

            if (customer.CustomerDateOfBirth.HasValue)
                dtpDateOfBirth.Value = customer.CustomerDateOfBirth.Value;
            else
                dtpDateOfBirth.Value = dtpDateOfBirth.MinDate; // Minimum tarih değeri

            // Show success message
            lblProgressWarning.Text = "Müşteri bilgileri başarıyla yüklendi.";
            lblProgressWarning.ForeColor = Color.Green;
        }

        #endregion

        #region Vehicle Operations

        // TR: Bu metot, araçları otomatik tamamlama için yüklemek için kullanılır.
        // EN: This method is used to load vehicles for autocomplete.
        private void LoadVehiclesForAutoComplete()
        {
            try
            {
                // Get all available vehicles
                _vehicles = _vehicleRepository.GetAvailableVehicles();

                // Create AutoCompleteStringCollection
                AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();

                // Add vehicle plate numbers to the collection
                foreach (var vehicle in _vehicles)
                {
                    autoCompleteSource.Add(vehicle.VehiclePlateNumber);
                }

                // Set autocomplete properties
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

        // TR: Bu metot, btnVehicleLoad düğmesine tıklandığında çalışır ve seçilen aracın bilgilerini yükler.
        // EN: This method runs when the btnVehicleLoad button is clicked and loads the selected vehicle's information.
        private void BtnVehicleLoad_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearchVehicle.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Lütfen bir araç seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find the vehicle
            Vehicle selectedVehicle = FindVehicleByPlate(searchText);

            if (selectedVehicle != null)
            {
                // Load vehicle info to the form
                LoadVehicleInfo(selectedVehicle);
            }
            else
            {
                MessageBox.Show("Araç bulunamadı. Lütfen geçerli bir araç plakası giriniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // TR: Bu metot, aracı plaka numarasına göre bulmak için kullanılır.
        // EN: This method is used to find a vehicle by plate number.
        private Vehicle FindVehicleByPlate(string plateNumber)
        {
            // Search for the vehicle by plate number
            return _vehicles.Find(v =>
                v.VehiclePlateNumber.Equals(plateNumber, StringComparison.OrdinalIgnoreCase));
        }

        // TR: Bu metot, seçilen aracın bilgilerini form alanlarına yüklemek için kullanılır.
        // EN: This method is used to load the selected vehicle's information into the form fields.
        private void LoadVehicleInfo(Vehicle vehicle)
        {
            if (vehicle == null)
                return;

            // Update vehicle information fields
            txtBoxVehiclePlate.Text = vehicle.VehiclePlateNumber;
            txtBoxVehicleBrand.Text = vehicle.VehicleBrand;
            txtBoxVehicleModel.Text = vehicle.VehicleModel;
            txtBoxVehicleYear.Text = vehicle.VehicleYear.ToString();
            txtBoxVehicleColor.Text = vehicle.VehicleColor;
            txtBoxVehicleFuelType.Text = vehicle.VehicleFuelType;
            txtBoxVehicleTransmission.Text = vehicle.VehicleTransmissionType;
            txtBoxVehicleMileage.Text = $"{vehicle.VehicleMileage} KM";

            // Set vehicle location (branch name)
            if (vehicle.Branch != null)
            {
                txtBoxVehicleLocation.Text = vehicle.Branch.BranchName;
            }
            else
            {
                txtBoxVehicleLocation.Text = "Belirsiz";
            }

            // Set vehicle status
            if (vehicle.VehicleStatus != null)
            {
                txtBoxVehicleStatus.Text = vehicle.VehicleStatus.VehicleStatusName;
            }
            else
            {
                txtBoxVehicleStatus.Text = "Belirsiz";
            }

            // Set rental information fields with DateTimePickers
            // Assuming the current date for rental start
            DateTime rentalStartDate = DateTime.Now;
            // Default rental period: 1 day
            DateTime rentalEndDate = rentalStartDate.AddDays(1);

            dtpRentalStartDate.Value = rentalStartDate;
            dtpRentalEndDate.Value = rentalEndDate;
            txtBoxRentalStartMileage.Text = vehicle.VehicleMileage.ToString();

            // Calculate rental amount based on vehicle class if available
            CalculateRentalAmount();

            // Show success message
            lblProgressWarning.Text = "Araç bilgileri başarıyla yüklendi.";
            lblProgressWarning.ForeColor = Color.Green;
        }

        #endregion

        #region Rental Calculations

        // TR: Bu metot, kiralama tutarını hesaplamak için kullanılır.
        // EN: This method is used to calculate the rental amount.
        private void CalculateRentalAmount()
        {
            // Eğer araç seçili değilse hesaplama yapma
            if (string.IsNullOrEmpty(txtBoxVehiclePlate.Text))
                return;

            // Seçili aracı bul
            Vehicle selectedVehicle = FindVehicleByPlate(txtBoxVehiclePlate.Text);
            if (selectedVehicle == null || !selectedVehicle.VehicleClassID.HasValue)
                return;

            // Tarih aralığını hesapla
            TimeSpan rentalPeriod = dtpRentalEndDate.Value.Date - dtpRentalStartDate.Value.Date;
            int days = rentalPeriod.Days + 1; // Son günü de dahil et

            // Eğer başlangıç bitiş tarihinden sonra ise düzelt
            if (days <= 0)
            {
                dtpRentalEndDate.Value = dtpRentalStartDate.Value.AddDays(1);
                days = 2;
            }

            // Günlük kiralama tutarını al
            var classRepository = new VehicleClassRepository();
            decimal dailyRate = classRepository.GetRentalPrice(selectedVehicle.VehicleClassID.Value, RentalType.Daily);

            // Toplam tutarı hesapla
            decimal totalAmount = dailyRate * days;
            txtBoxRentalAmount.Text = totalAmount.ToString("N2") + " ₺";

            // Depozitoyu güncelle (Kiralama tutarının %50'si)
            decimal depositAmount = totalAmount * 0.5m;
            txtBoxRentalDeposit.Text = depositAmount.ToString("N2") + " ₺";

            // Default payment type: Cash
            txtBoxRentalPaymentType.Text = "Nakit";
        }

        // TR: DateTimePicker olay işleyicileri
        // EN: DateTimePicker event handlers
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
            // Clear customer info
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

            // Clear vehicle info
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

            // Clear rental info
            dtpRentalStartDate.Value = DateTime.Now;
            dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            txtBoxRentalStartMileage.Text = string.Empty;
            textBox8.Text = string.Empty; // This seems to be the end mileage
            txtBoxRentalPaymentType.Text = "Nakit"; // Default to cash
            txtBoxRentalAmount.Text = string.Empty;
            txtBoxRentalDeposit.Text = string.Empty;
            txtBoxRentalNote.Text = string.Empty;
        }

        private bool ValidateRentalForm()
        {
            // Check if customer is selected
            if (string.IsNullOrEmpty(txtBoxCustomerFullName.Text))
            {
                lblProgressWarning.Text = "Please select a customer.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            // Check if vehicle is selected
            if (string.IsNullOrEmpty(txtBoxVehiclePlate.Text))
            {
                lblProgressWarning.Text = "Please select a vehicle.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            // Check if rental dates are valid
            if (dtpRentalEndDate.Value < dtpRentalStartDate.Value)
            {
                lblProgressWarning.Text = "End date cannot be earlier than start date.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            // Check if rental amount is calculated
            if (string.IsNullOrEmpty(txtBoxRentalAmount.Text))
            {
                lblProgressWarning.Text = "Rental amount is not calculated.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            // Check if starting mileage is entered
            if (string.IsNullOrEmpty(txtBoxRentalStartMileage.Text))
            {
                lblProgressWarning.Text = "Starting mileage must be entered.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            // Check if payment type is entered
            if (string.IsNullOrEmpty(txtBoxRentalPaymentType.Text))
            {
                lblProgressWarning.Text = "Payment type must be entered.";
                lblProgressWarning.ForeColor = Color.Red;
                return false;
            }

            return true;
        }

        private void CreateRental()
        {
            try
            {
                // Find the selected customer
                Customer selectedCustomer = FindCustomerByFullName(txtBoxCustomerFullName.Text);
                if (selectedCustomer == null)
                {
                    lblProgressWarning.Text = "Selected customer not found.";
                    lblProgressWarning.ForeColor = Color.Red;
                    return;
                }

                // Find the selected vehicle
                Vehicle selectedVehicle = FindVehicleByPlate(txtBoxVehiclePlate.Text);
                if (selectedVehicle == null)
                {
                    lblProgressWarning.Text = "Selected vehicle not found.";
                    lblProgressWarning.ForeColor = Color.Red;
                    return;
                }

                // Parse rental amount
                string amountText = txtBoxRentalAmount.Text.Replace("₺", "").Trim();
                if (!decimal.TryParse(amountText, out decimal rentalAmount))
                {
                    lblProgressWarning.Text = "Invalid rental amount.";
                    lblProgressWarning.ForeColor = Color.Red;
                    return;
                }

                // Parse deposit amount
                decimal? depositAmount = null;
                if (!string.IsNullOrEmpty(txtBoxRentalDeposit.Text))
                {
                    string depositText = txtBoxRentalDeposit.Text.Replace("₺", "").Trim();
                    if (decimal.TryParse(depositText, out decimal deposit))
                    {
                        depositAmount = deposit;
                    }
                }

                // Parse starting mileage
                if (!int.TryParse(txtBoxRentalStartMileage.Text.Replace("KM", "").Trim(), out int startKm))
                {
                    lblProgressWarning.Text = "Invalid starting mileage.";
                    lblProgressWarning.ForeColor = Color.Red;
                    return;
                }

                // Create new rental object
                Rental newRental = new Rental
                {
                    RentalCustomerID = selectedCustomer.CustomerID,
                    RentalVehicleID = selectedVehicle.VehicleID,
                    RentalStartDate = dtpRentalStartDate.Value,
                    RentalEndDate = dtpRentalEndDate.Value,
                    RentalReturnDate = null, // Not returned yet
                    RentalStartKm = startKm,
                    RentalEndKm = null, // Not returned yet
                    RentalAmount = rentalAmount,
                    RentalDepositAmount = depositAmount,
                    RentalPaymentType = txtBoxRentalPaymentType.Text,
                    RentalContractID = null, // No contract yet
                    RentalUserID = Utils.CurrentUser.UserID, // Current logged in user
                };

                // Add rental note if provided
                string noteText = txtBoxRentalNote.Text;
                int rentalId;

                if (!string.IsNullOrEmpty(noteText))
                {
                    // Use the special method to create rental with note
                    rentalId = _rentalRepository.CreateRentalWithNote(newRental, noteText);
                }
                else
                {
                    // If we're using regular Insert, we need to manually update vehicle status
                    rentalId = _rentalRepository.Insert(newRental);

                    if (rentalId > 0)
                    {
                        // Update vehicle status to Rented (status ID 3)
                        _vehicleRepository.UpdateVehicleStatus(selectedVehicle.VehicleID, 3);
                    }
                }

                if (rentalId > 0)
                {
                    // If there's a deposit, create a payment record
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

                    // Refresh the data grids
                    LoadRentals();

                    // Clear the form for new entry
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
            lblProgressWarning.Text = "Form cleared. Ready for new rental entry.";
            lblProgressWarning.ForeColor = Color.Blue;
        }
    }
}