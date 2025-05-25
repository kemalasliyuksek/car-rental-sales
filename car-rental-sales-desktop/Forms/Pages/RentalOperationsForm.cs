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
            
            this.CancelButton = btnCancel;
        }

        private void RentalOperationsForm_Load(object sender, EventArgs e)
        {
            LoadRentalDetails();
        }

        private void LoadRentalDetails()
        {
            try
            {
                _rental = _rentalRepository.GetById(_rentalId);

                if (_rental == null)
                {
                    MessageBox.Show("Rental information could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (_rental.Customer == null && _rental.RentalCustomerID > 0)
                {
                    _rental.Customer = _customerRepository.GetById(_rental.RentalCustomerID);
                }

                if (_rental.Vehicle == null && _rental.RentalVehicleID > 0)
                {
                    _rental.Vehicle = _vehicleRepository.GetById(_rental.RentalVehicleID);
                }

                lblRentalID.Text = _rental.RentalID.ToString();
                lblCustomerName.Text = _rental.Customer?.FullName ?? "Unknown Customer";
                lblVehicleInfo.Text = _rental.Vehicle?.VehiclePlateNumber ?? "Unknown Vehicle";
                lblStartDate.Text = _rental.RentalStartDate.ToString("dd.MM.yyyy");
                lblEndDate.Text = _rental.RentalEndDate.ToString("dd.MM.yyyy");
                lblStartMileage.Text = _rental.RentalStartKm.ToString() + " KM";
                lblAmount.Text = _rental.RentalAmount.ToString("N2") + " ₺";

                dtpReturnDate.Value = DateTime.Now;
                numReturnMileage.Value = _rental.RentalStartKm;
                numReturnMileage.Minimum = _rental.RentalStartKm;

                if (_rental.RentalID > 0)
                {
                    List<RentalNote> notes = _rentalRepository.GetNotes(_rental.RentalID);
                    if (notes != null && notes.Count > 0)
                    {
                        txtRentalNote.Text = notes[0].RentalNoteText;

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

                if (_rental.RentalReturnDate.HasValue)
                {
                    lblStatus.Text = "This rental has already been returned.";
                    lblStatus.ForeColor = Color.Blue;

                    dtpReturnDate.Enabled = false;
                    numReturnMileage.Enabled = false;
                    btnCompleteReturn.Enabled = false;

                    btnCompleteReturn.Text = "Save Note";
                    btnCompleteReturn.Enabled = true;
                    btnCompleteReturn.BackColor = System.Drawing.Color.DodgerBlue;

                    lblReturnDateInfo.Text = _rental.RentalReturnDate.Value.ToString("dd.MM.yyyy");
                    lblReturnMileageInfo.Text = _rental.RentalEndKm.ToString() + " KM";

                    dtpReturnDate.Value = _rental.RentalReturnDate.Value;

                    if (_rental.RentalEndKm.HasValue)
                    {
                        numReturnMileage.Value = _rental.RentalEndKm.Value;
                        int mileageDifference = _rental.RentalEndKm.Value - _rental.RentalStartKm;
                        lblMileageInfo.Text = $"Driven distance: {mileageDifference} KM";
                    }
                    else
                    {
                        lblMileageInfo.Text = "Driven distance: 0 KM";
                    }

                    CalculateReturnDetails();
                }
                else
                {
                    lblStatus.Text = "This rental is active and can be returned.";
                    lblStatus.ForeColor = Color.Green;

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
                DateTime returnDate = dtpReturnDate.Value;
                int returnMileage = (int)numReturnMileage.Value;

                _lateFee = 0;
                if (returnDate > _rental.RentalEndDate)
                {
                    int lateDays = (returnDate.Date - _rental.RentalEndDate.Date).Days;

                    int rentalDays = (_rental.RentalEndDate.Date - _rental.RentalStartDate.Date).Days + 1;
                    decimal dailyRate = _rental.RentalAmount / rentalDays;

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

                _totalAmount = _rental.RentalAmount + _lateFee;
                lblTotalAmount.Text = _totalAmount.ToString("N2") + " ₺";

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
                if (_rental.RentalReturnDate.HasValue)
                {
                    string noteText = txtRentalNote.Text.Trim();
                    if (!string.IsNullOrEmpty(noteText))
                    {
                        bool noteSuccess = _rentalRepository.AddNote(_rental.RentalID, noteText, CurrentUser.UserID);

                        if (noteSuccess)
                        {
                            MessageBox.Show(
                                "Note has been successfully added to the rental.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show(
                                "An error occurred while saving the note.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Please enter a note or click cancel.",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to complete this rental return?",
                    "Confirm Return",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                DateTime returnDate = dtpReturnDate.Value;
                int returnMileage = (int)numReturnMileage.Value;

                bool success = _rentalRepository.ProcessReturn(_rental.RentalID, returnDate, returnMileage);

                if (success)
                {
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

                    string noteText = txtRentalNote.Text.Trim();
                    if (!string.IsNullOrEmpty(noteText))
                    {
                        _rentalRepository.AddNote(_rental.RentalID, noteText, CurrentUser.UserID);
                    }

                    MessageBox.Show(
                        "Rental return has been successfully processed.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
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
                MessageBox.Show($"Error processing operation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}