using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Forms
{
    public partial class RentalOperationsForm : Form
    {
        private int _rentalId;
        private Rental _rental;
        private RentalRepository _rentalRepository;
        private CustomerRepository _customerRepository;
        private VehicleRepository _vehicleRepository;
        private decimal _lateFee = 0;
        private decimal _totalAmount = 0;

        public RentalOperationsForm(int rentalId)
        {
            InitializeComponent();

            _rentalId = rentalId;
            _rentalRepository = new RentalRepository();
            _customerRepository = new CustomerRepository();
            _vehicleRepository = new VehicleRepository();

            this.Load += RentalOperationsForm_Load;
            dtpReturnDate.ValueChanged += DtpReturnDate_ValueChanged;
            numReturnMileage.ValueChanged += NumReturnMileage_ValueChanged;
            btnCompleteReturn.Click += BtnCompleteReturn_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void RentalOperationsForm_Load(object sender, EventArgs e)
        {
            LoadRentalDetails();
        }

        private void LoadRentalDetails()
        {
            try
            {
                // Load rental details
                _rental = _rentalRepository.GetById(_rentalId);

                if (_rental == null)
                {
                    MessageBox.Show("Rental information could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Load customer information
                if (_rental.Customer == null && _rental.RentalCustomerID > 0)
                {
                    _rental.Customer = _customerRepository.GetById(_rental.RentalCustomerID);
                }

                // Load vehicle information
                if (_rental.Vehicle == null && _rental.RentalVehicleID > 0)
                {
                    _rental.Vehicle = _vehicleRepository.GetById(_rental.RentalVehicleID);
                }

                // Display rental information
                lblRentalID.Text = _rental.RentalID.ToString();
                lblCustomerName.Text = _rental.Customer?.FullName ?? "Unknown Customer";
                lblVehicleInfo.Text = _rental.Vehicle?.VehiclePlateNumber ?? "Unknown Vehicle";
                lblStartDate.Text = _rental.RentalStartDate.ToString("dd.MM.yyyy");
                lblEndDate.Text = _rental.RentalEndDate.ToString("dd.MM.yyyy");
                lblStartMileage.Text = _rental.RentalStartKm.ToString() + " KM";
                lblAmount.Text = _rental.RentalAmount.ToString("N2") + " ₺";

                // Set initial return values
                dtpReturnDate.Value = DateTime.Now;
                numReturnMileage.Value = _rental.RentalStartKm;
                numReturnMileage.Minimum = _rental.RentalStartKm; // Ensure return mileage is not less than start mileage

                // Load existing notes
                if (_rental.RentalID > 0)
                {
                    // Get all notes for this rental
                    List<RentalNote> notes = _rentalRepository.GetNotes(_rental.RentalID);
                    if (notes != null && notes.Count > 0)
                    {
                        // Show the most recent note in the note text box
                        txtRentalNote.Text = notes[0].RentalNoteText;

                        // If multiple notes exist, append them with timestamps
                        if (notes.Count > 1)
                        {
                            txtRentalNote.Text += Environment.NewLine + Environment.NewLine + "Previous notes:";
                            for (int i = 1; i < notes.Count; i++)
                            {
                                txtRentalNote.Text += Environment.NewLine +
                                    $"[{notes[i].RentalNoteCreatedAt:dd.MM.yyyy HH:mm}] {notes[i].RentalNoteText}";
                            }
                        }
                    }
                }

                // Check if rental is already returned
                if (_rental.RentalReturnDate.HasValue)
                {
                    lblStatus.Text = "This rental has already been returned.";
                    lblStatus.ForeColor = Color.Blue;

                    // Disable return operation controls
                    dtpReturnDate.Enabled = false;
                    numReturnMileage.Enabled = false;
                    txtRentalNote.ReadOnly = true;
                    btnCompleteReturn.Enabled = false;

                    // Show return information
                    lblReturnDateInfo.Text = _rental.RentalReturnDate.Value.ToString("dd.MM.yyyy");
                    lblReturnMileageInfo.Text = _rental.RentalEndKm.ToString() + " KM";
                }
                else
                {
                    lblStatus.Text = "This rental is active and can be returned.";
                    lblStatus.ForeColor = Color.Green;

                    // Calculate initial return information
                    CalculateReturnDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rental details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateReturnDetails()
        {
            try
            {
                // Get values
                DateTime returnDate = dtpReturnDate.Value;
                int returnMileage = (int)numReturnMileage.Value;

                // Calculate late fee if returned after due date
                _lateFee = 0;
                if (returnDate > _rental.RentalEndDate)
                {
                    int lateDays = (returnDate.Date - _rental.RentalEndDate.Date).Days;

                    // Calculate daily rate (total rental / total days)
                    int rentalDays = (_rental.RentalEndDate.Date - _rental.RentalStartDate.Date).Days + 1;
                    decimal dailyRate = _rental.RentalAmount / rentalDays;

                    // Apply late fee (1.5x daily rate per late day)
                    _lateFee = lateDays * dailyRate * 1.5m;

                    lblLateFee.Text = _lateFee.ToString("N2") + " ₺";
                    lblLateDays.Text = lateDays.ToString() + " days late";
                    pnlLateFee.Visible = true;
                }
                else
                {
                    lblLateFee.Text = "0.00 ₺";
                    lblLateDays.Text = "0 days (on time)";
                    pnlLateFee.Visible = false;
                }

                // Calculate total amount
                _totalAmount = _rental.RentalAmount + _lateFee;
                lblTotalAmount.Text = _totalAmount.ToString("N2") + " ₺";

                // Display mileage information
                int mileageDifference = returnMileage - _rental.RentalStartKm;
                lblMileageInfo.Text = $"Driven distance: {mileageDifference} KM";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating return details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateReturnDetails();
        }

        private void NumReturnMileage_ValueChanged(object sender, EventArgs e)
        {
            CalculateReturnDetails();
        }

        private void BtnCompleteReturn_Click(object sender, EventArgs e)
        {
            try
            {
                // Confirm return
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to complete this rental return?",
                    "Confirm Return",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                // Process the return
                DateTime returnDate = dtpReturnDate.Value;
                int returnMileage = (int)numReturnMileage.Value;

                bool success = _rentalRepository.ProcessReturn(_rental.RentalID, returnDate, returnMileage);

                if (success)
                {
                    // If late fee exists, create a payment record
                    if (_lateFee > 0)
                    {
                        Payment lateFeePayment = new Payment
                        {
                            PaymentTransactionType = "Rental",
                            PaymentTransactionID = _rental.RentalID,
                            PaymentCustomerID = _rental.RentalCustomerID,
                            PaymentAmount = _lateFee,
                            PaymentDate = returnDate,
                            PaymentType = "Late Fee",
                            PaymentNote = $"Late fee for rental ID {_rental.RentalID}",
                            PaymentUserID = CurrentUser.UserID
                        };

                        var paymentRepository = new PaymentRepository();
                        paymentRepository.Insert(lateFeePayment);
                    }

                    // Add the return note if provided
                    string noteText = txtRentalNote.Text.Trim();
                    if (!string.IsNullOrEmpty(noteText))
                    {
                        // Add a note to the rental
                        _rentalRepository.AddNote(_rental.RentalID, noteText, CurrentUser.UserID);
                    }

                    MessageBox.Show(
                        "Rental return has been successfully processed.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "An error occurred while processing the rental return.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing return: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}